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
        
        public Mein_Konto_Window(int benutzerIDValue)
        {
            InitializeComponent();

            benutzerID.Content = benutzerIDValue;

            //Verbinden mit Server
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Server=OPOSSUM283\SQLEXPRESS;Database=FitnessTracker;Trusted_Connection=Yes;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            //Benutzername Abfrage formulieren
            SqlCommand commandBenutzername;
            SqlDataReader dataReader;
            string sqlBenutzernameAbfrage = "SELECT Benutzername FROM Benutzer WHERE BenutzerID=" + benutzerID.Content;

            commandBenutzername = new SqlCommand(sqlBenutzernameAbfrage, cnn);

            dataReader = commandBenutzername.ExecuteReader();
            string benutzernameOutput = "";

            //Passendes Email finden
            while (dataReader.Read())
            {
                benutzernameOutput = dataReader.GetString(0);
            }

            dataReader.Close();
            commandBenutzername.Dispose();


            begruessung.Text = "Hallo " + benutzernameOutput;
        }
        
    }
}
