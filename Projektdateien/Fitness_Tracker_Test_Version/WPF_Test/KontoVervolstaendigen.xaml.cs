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
    /// Interaction logic for KontoVervolstaendigen.xaml
    /// </summary>
    public partial class KontoVervolstaendigen : Page
    {
        public KontoVervolstaendigen()
        {
            InitializeComponent();
        }

        private void bestaetigen_Click(object sender, RoutedEventArgs e)
        {
            if (vorname.Text != null && nachname.Text != null)
            {
                string name = vorname.Text + " " + nachname.Text;

                //Verbinden mit Server
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Server=OPOSSUM283\SQLEXPRESS;Database=FitnessTracker;Trusted_Connection=Yes;";
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                //SQL Abfrage formulieren
                SqlCommand commandBenutzerFinden;
                SqlDataReader dataReader;
                string sqlBenutzerFindenAbfrage = "SELECT TOP 1 * FROM Benutzer ORDER BY BenutzerID DESC";

                commandBenutzerFinden = new SqlCommand(sqlBenutzerFindenAbfrage, cnn);

                dataReader = commandBenutzerFinden.ExecuteReader();
                int outputBenutzerID = 0;

                while (dataReader.Read())
                {
                    outputBenutzerID = dataReader.GetInt32(0);
                }

                dataReader.Close();
                commandBenutzerFinden.Dispose();

                SqlCommand commandUpdateNeueBenutzer;
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                string sqlUpdateAbfrage = "";

                sqlUpdateAbfrage = "UPDATE Benutzer SET Benutzername='" + name + "' WHERE BenutzerID=" + outputBenutzerID;

                commandUpdateNeueBenutzer = new SqlCommand(sqlUpdateAbfrage, cnn);

                dataAdapter.InsertCommand = new SqlCommand(sqlUpdateAbfrage, cnn);
                dataAdapter.InsertCommand.ExecuteNonQuery();

                commandUpdateNeueBenutzer.Dispose();



                cnn.Close();
            }
            else
            {
                MessageBox.Show("Geben Sie Ihre Vor- und Nachname");
            }
        }
    }
}
