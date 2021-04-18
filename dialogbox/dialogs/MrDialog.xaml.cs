using dialogbox.dialogservices;
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
using System.Windows.Shapes;

namespace dialogbox.dialogs
{
    /// <summary>
    /// Interaction logic for MrDialog.xaml
    /// </summary>
    public partial class MrDialog : Window, IDialog
    {
        public MrDialog()
        {
            InitializeComponent();
        }
    }
}
