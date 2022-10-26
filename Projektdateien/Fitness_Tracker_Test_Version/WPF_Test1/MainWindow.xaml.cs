using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WPF_Test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Passwort_vergessen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wenden Sie sich bitte an unsere Support");
        }

        private void registrieren_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hier soll das Anlegen neues Benutzers erfolgen");
        }
    }
}
