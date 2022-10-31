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

namespace WPF_Test
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=OPOSSUM283\SQLEXPRESS;Database=FitnessTracker;Trusted_Connection=Yes;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command;
            SqlDataReader reader;
            string sqlAbfrage = "SELECT Email FROM Benutzer";

            command = new SqlCommand(sqlAbfrage, cnn);

            reader = command.ExecuteReader();
            List<string> output = new List<string>();

            while (reader.Read())
            {
                output.Add((string)reader.GetValue(0));
            }

            if (output.Contains(email.Text))
            {
                var win = new Mein_Konto_Window();
                win.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ungueltige Daten!");
            }

            reader.Close();
            command.Dispose();
            cnn.Close();
        }
    }
}
