﻿using KeyManager.Data;
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
                services.AddSingleton<MainWindow>();
            })
            .Build();
        }

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await _host.StartAsync();
            
            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow.Show();
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