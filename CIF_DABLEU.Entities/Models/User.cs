using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CIF_DABLEU.Entities.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; } = new byte[0];

        public byte[] PasswordSalt { get; set; } = new byte[0];

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        //Futuras propiedades para seguridad
        public int FailedLoginAttempts { get; set; }

        public DateTime? LockoutEnd { get; set; }
    }
}
