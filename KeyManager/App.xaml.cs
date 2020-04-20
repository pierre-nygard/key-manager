using KeyManager.Data;
using KeyManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KeyManager
{

    public partial class App : Application
    {
        private readonly IHost _host;
        
        public App()
        {
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            _host = new HostBuilder()
            .ConfigureAppConfiguration((hostContext, configApp) =>
            {
                configApp.SetBasePath(Directory.GetCurrentDirectory());
                configApp.AddJsonFile("appsettings.json");
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<VaultContext>(options => 
                    options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));
                services.AddSingleton<AuthenticationWindow>();
                services.AddSingleton<DbInitializer>();
            })
            .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();

            _host.Services.GetService<DbInitializer>().Initialize();

            AuthenticationWindow authWindow = _host.Services.GetService<AuthenticationWindow>();
            authWindow.ShowDialog();

            if (authWindow.User != null)
            {
                this.ShutdownMode = ShutdownMode.OnMainWindowClose;
                VaultContext context = _host.Services.GetService<VaultContext>();
                
                new MainWindow(context, authWindow.User).ShowDialog();
            }
            Shutdown();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            using(_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
        }
    }
}
