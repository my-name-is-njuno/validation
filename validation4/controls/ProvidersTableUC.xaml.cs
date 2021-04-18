using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using validation4.services.serviceimplementation;
using validation4.services.services;
using validation4.viewmodels;
using validation4.views.dialogs;

namespace validation4.controls
{
    /// <summary>
    /// Interaction logic for ProvidersTableUC.xaml
    /// </summary>
    public partial class ProvidersTableUC : UserControl
    {
        public ProvidersTableUC()
        {
            InitializeComponent();
        }

       

        private void updated_btn_Click(object sender, RoutedEventArgs e)
        {
            Window showProvider = new ShowWindow();
            object dt = ((App)Application.Current)._host.Services.GetRequiredService<DialogVM>();
            showProvider.Owner = Window.GetWindow(this);
            showProvider.DataContext = dt;
            showProvider.ShowDialog();
        }
    }
}
