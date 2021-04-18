using auth.serviceimplementations;
using auth.services;
using db;
using db.serviceimplementations;
using db.services;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pagination.pg;
using System.Windows;
using validation4.factory;
using validation4.services.serviceimplementation;
using validation4.services.services;
using validation4.states.auth;
using validation4.states.msg;
using validation4.states.nav;
using validation4.viewmodels;
using validation4.views;

namespace validation4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        private static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((config, services) => 
                {
                    //view models
                    services.AddSingleton<MainVM>();
                    services.AddSingleton<DialogVM>();
                    services.AddSingleton<DeliveryVM>();
                    services.AddSingleton<HomeVM>(s => 
                    {
                        return new HomeVM(
                               s.GetRequiredService<IGetHospitals>(),
                               s.GetRequiredService<IVmFactory>(),
                               s.GetRequiredService<INav>()
                            );
                    
                    });
                    services.AddSingleton<ProviderVM>();
                    services.AddSingleton<ShowProviderVM>();
                   
                    services.AddSingleton<LoginVM>(s => 
                    {
                        return new LoginVM(s.GetRequiredService<IAuth>(), s.GetRequiredService<IMsg>(), s.GetRequiredService<Renav<HomeVM>>(), s.GetRequiredService<Renav<RegisterVM>>());
                    });
                    services.AddSingleton<RegisterVM>(s =>
                    {
                        return new RegisterVM(s.GetRequiredService<IMsg>(), s.GetRequiredService<IAuth>(), s.GetRequiredService<Renav<LoginVM>>(), s.GetRequiredService<IGetHospitals>());
                    });

                    //delegates
                    services.AddSingleton<CreateVM<HomeVM>>(s =>
                    {
                        return () => s.GetRequiredService<HomeVM>();
                    });
                    services.AddSingleton<CreateVM<DeliveryVM>>(s =>
                    {
                        return () => s.GetRequiredService<DeliveryVM>();
                    });
                    services.AddSingleton<CreateVM<ProviderVM>>(s =>
                    {
                        return () => s.GetRequiredService<ProviderVM>();
                    });
                    services.AddSingleton<CreateVM<LoginVM>>(s =>
                    {
                        return () => s.GetRequiredService<LoginVM>();
                    });
                    services.AddSingleton<CreateVM<RegisterVM>>(s =>
                    {
                        return () => s.GetRequiredService<RegisterVM>();
                    });
                    services.AddSingleton<CreateVM<ShowProviderVM>>(s =>
                    {
                        return () => s.GetRequiredService<ShowProviderVM>();
                    });






                    //nav states
                    services.AddScoped<INav, Nav>();
                    services.AddScoped<Renav<HomeVM>>();
                    services.AddScoped<Renav<RegisterVM>>();
                    services.AddScoped<Renav<LoginVM>>();


                    //messages states
                    services.AddTransient<IMsg, Msg>();

                    //auth states
                    services.AddSingleton<IAuth, Auth>();
                    //auth project
                    services.AddSingleton<IRegister, Register>();
                    services.AddSingleton<ILogin, Login>();


                    //vm factory
                    services.AddSingleton<IVmFactory, VmFactory>();

                    //database
                    string cs = config.Configuration.GetConnectionString("default");
                    services.AddSingleton<ProjectDbContext>();
                    services.AddSingleton<ProjectDbContextOptionFactory>(new ProjectDbContextOptionFactory(cs));
                    services.AddDbContext<ProjectDbContext>(o => o.UseMySql(cs));

                    //datanase services
                    services.AddSingleton<ICrudUser, CrudUser>();
                    services.AddSingleton<ICrudProvider, CrudProvider>();


                    //external
                    //password hasher
                    services.AddSingleton<IPasswordHasher, PasswordHasher>();
                    //pagination
                    services.AddSingleton<PgVM>();


                    //ui services
                    //providers
                    services.AddSingleton<IGetHospitals, GetHospital>();
                    services.AddSingleton<IUpdateProvider, UpdateProvider>();

                })
                .ConfigureAppConfiguration(config => 
                {
                    config.AddJsonFile("env.json");
                });
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            Window window = new MainWindow();
            window.DataContext = _host.Services.GetRequiredService<MainVM>();
            window.Show();
            base.OnStartup(e);
        }


        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
