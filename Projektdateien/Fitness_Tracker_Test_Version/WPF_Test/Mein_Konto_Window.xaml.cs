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
using System.Data.SqlClient;

namespace WPF_Test
{
    /// <summary>
    /// Interaction logic for Mein_Konto_Window.xaml
    /// </summary>
    public partial class Mein_Konto_Window : Window
    {
        public Mein_Konto_Window()
        {
            InitializeComponent();
        }

        private void SQL_Click(object sender, RoutedEventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=OPOSSUM283\SQLEXPRESS;Database=FitnessTracker;Trusted_Connection=Yes;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            
            SqlCommand command;
            SqlDataReader reader;
            string sqlAbfrage, output = "";

            sqlAbfrage = "SELECT BenutzerID, Benutzername FROM Benutzer";

            command = new SqlCommand(sqlAbfrage, cnn);

            reader = command.ExecuteReader();

            while (reader.Read())
            {
                output = output + reader.GetValue(0) + ". " + reader.GetValue(1) + "\n";
            }

            MessageBox.Show(output);

            reader.Close();
            command.Dispose();
            cnn.Close();

        }
    }
}
