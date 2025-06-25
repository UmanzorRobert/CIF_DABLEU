using CIF_DABLEU.BusinessLogic.Contracts;
using CIF_DABLEU.BusinessLogic.Services;
using CIF_DABLEU.DataAccess.Contracts;
using CIF_DABLEU.DataAccess.Data;
using CIF_DABLEU.DataAccess.Repositories;
using CIF_DABLEU.UI.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace CIF_DABLEU.UI
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // Flujo de autenticación
            using (var loginForm = ServiceProvider.GetRequiredService<LoginForm>())
            {
                // Muestra el formulario de login como un diálogo modal
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Si el login es exitoso (DialogResult.OK), obtenemos el token
                    string? token = loginForm.JwtToken;
                    // Aquí podrías guardar el token en una clase estática o de contexto para usarlo en la app
                    // Por ahora, solo procedemos a abrir el formulario principal.

                    // Inicia el formulario principal de la aplicación
                    var mainForm = ServiceProvider.GetRequiredService<Form1>();
                    Application.Run(mainForm);
                }
                // Si el login falla o se cierra el formulario, la aplicación termina.
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // 1. DbContext
            // AddDbContext es la forma recomendada, gestiona el ciclo de vida por nosotros.
            services.AddDbContext<ApplicationDbContext>();

            // 2. Capa DataAccess (Unit of Work y Repositorios)
            // Usamos AddScoped para que la misma instancia de UnitOfWork (y DbContext)
            // se utilice en una operación de negocio completa.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();//Necesario para UnitOfWork

            // 3. Capa BusinessLogic (Servicios)
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();

            // 4. Formularios de la UI
            // Los formularios suelen ser transitorios (se crea uno nuevo cada vez que se necesita).
            services.AddTransient<Form1>();
            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterForm>();
        }
    }
}