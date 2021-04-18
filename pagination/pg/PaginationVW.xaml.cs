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

namespace pagination.pg
{
    /// <summary>
    /// Interaction logic for PaginationVW.xaml
    /// </summary>
    public partial class PaginationVW : UserControl
    {
        public PaginationVW()
        {
            InitializeComponent();
        }

        

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                int number;
                bool success = Int32.TryParse(((TextBox)sender).Text, out number);
                if (success)
                {
                    ((PgVM)this.DataContext).RecalculatePagination();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
