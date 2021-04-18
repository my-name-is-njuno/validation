using dialogbox.dialogs;
using dialogbox.dialogservices;
using dialogbox.vwm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace dialogbox
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IDialogService dialogService = new DialogService(MainWindow);
            dialogService.Register<DialogVM, MrDialog>();
            Window window = new MainWindow();
            window.DataContext = new MainVM(dialogService);
            window.Show();
            base.OnStartup(e);
        }
    }
}
