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
            _host = new HostBuilder()
            .ConfigureAppConfiguration((hostContext, configApp) =>
            {
                configApp.SetBasePath(Directory.GetCurrentDirectory());
                configApp.AddJsonFile("appsettings.json");
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<VaultContext>();
                services.AddSingleton<DbInitializer>();
            })
            .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            await _host.StartAsync();

            DbInitializer initializer = _host.Services.GetService<DbInitializer>();
            initializer.Initialize();

            VaultContext context = _host.Services.GetService<VaultContext>();

            IUserAuther authentication = new UserAuther(context).Run();

            if (authentication.AuthIsValid() == true)
            {
                this.ShutdownMode = ShutdownMode.OnMainWindowClose;
                new MainUpstart(context).SetForUser(authentication.User).Run();
            }
            else
            {
                Shutdown();
            }
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
