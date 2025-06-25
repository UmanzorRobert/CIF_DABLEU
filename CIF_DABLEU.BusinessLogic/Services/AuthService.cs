using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIF_DABLEU.BusinessLogic.Contracts;
using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.Entities.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace CIF_DABLEU.BusinessLogic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> RegisterUserAsync(string fullName, string email, string password)
        {
            if (await _unitOfWork.User.GetByEmailAsync(email) != null)
            {
                return false; // El usuario ya existe
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                FullName = fullName,
                Email = email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _unitOfWork.User.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _unitOfWork.User.GetByEmailAsync(email);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null; // Credenciales incorrectas
            }

            return CreateToken(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            // IMPORTANTE: La clave secreta debe ser larga, compleja y guardada de forma segura,
            // ¡NUNCA hardcodeada en producción! La leeremos de un archivo de configuración en una fase posterior.
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ESTA_ES_UNA_LLAVE_SECRETA_MUCHO_MAS_LARGA_Y_SEGURA_PARA_CIF_DABLEU_2025_06!"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                // Aquí agregaremos roles en el futuro: new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                issuer: "CIF_DABLEU",
                audience: "CIF_DABLEU_Users",
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
