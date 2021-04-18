using dialogmvvm.services;
using dialogmvvm.vm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace dialogmvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IDialogService dialogService = new DialogService(MainWindow);
            dialogService.Register<DialogVM, dialog>();
            Window window = new MainWindow();
            window.DataContext = new MainVM(dialogService);
            window.Show();
            base.OnStartup(e);
        }
    }
}
