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

        //Login Prozess
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //Verbinden mit Server
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=OPOSSUM283\SQLEXPRESS;Database=FitnessTracker;Trusted_Connection=Yes;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            //Email Abfrage formulieren
            SqlCommand commandEmail;
            SqlDataReader dataReader;
            string sqlEmailAbfrage = "SELECT Email FROM Benutzer";

            commandEmail = new SqlCommand(sqlEmailAbfrage, cnn);

            dataReader = commandEmail.ExecuteReader();
            List<string> emailOutput = new List<string>();

            //Passendes Email finden
            while (dataReader.Read())
            {
                emailOutput.Add((string)dataReader.GetValue(0));
            }

            dataReader.Close();
            commandEmail.Dispose();

            if (emailOutput.Contains(email.Text))
            {
                //Passwort Abfrage formulieren
                SqlCommand commandPasswort;
                string sqlPasswortAbfrage = "SELECT Passwort FROM Benutzer WHERE Email LIKE '" + email.Text + "'";

                commandPasswort = new SqlCommand(sqlPasswortAbfrage, cnn);

                dataReader = commandPasswort.ExecuteReader();
                string passwortOutput = "";

                //Passendes Passwort finden
                while (dataReader.Read())
                {
                    passwortOutput = dataReader.GetString(0);
                }
                
                dataReader.Close();
                commandPasswort.Dispose();

                if (passwortOutput == passwort.Password)
                {
                    //Benutzername Abfrage formulieren
                    SqlCommand commandBenutzername;
                    string sqlBenutzernameAbfrage = "SELECT Benutzername FROM Benutzer WHERE Email LIKE '" + email.Text + "'";

                    commandBenutzername = new SqlCommand(sqlBenutzernameAbfrage, cnn);

                    dataReader = commandBenutzername.ExecuteReader();
                    string benutzernameOutput = "";

                    //Passendes Passwort finden
                    while (dataReader.Read())
                    {
                        benutzernameOutput = dataReader.GetString(0);
                    }

                    dataReader.Close();
                    commandBenutzername.Dispose();


                    var win = new Mein_Konto_Window();
                    win.begruessung.Text = "Hallo " + benutzernameOutput;
                    win.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ihr Passwort ist falsch");
                    passwort.Clear();
                }
            }
            else
            {
                MessageBox.Show("Kein Konto mit dem Email vorhanden");
            }

            cnn.Close();
        }

        //Passwort vergessen
        private void Passwort_vergessen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wenden Sie sich bitte an unsere Support");
        }

        //Registrieren
        private void registrieren_Click(object sender, RoutedEventArgs e)
        {
            var win = new RegistrierungWindow();
            win.Show();
            this.Close();
        }
    }
}
