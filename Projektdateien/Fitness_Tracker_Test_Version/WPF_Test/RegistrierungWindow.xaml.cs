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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace WPF_Test
{
    /// <summary>
    /// Interaction logic for RegistrierungWindow.xaml
    /// </summary>
    public partial class RegistrierungWindow : Window
    {
        public RegistrierungWindow()
        {
            InitializeComponent();
        }

        private void registrieren_Click(object sender, RoutedEventArgs e)
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

            //Pruefen ob Email schon vorhanden ist
            if (!emailOutput.Contains(email.Text))
            {

                //Pruefen ob Paswoerter miteinander stimmen
                if (passwort.Password == passwortWiederholen.Password && passwortWiederholen.Password != null)
                {

                    //Preuefen ob Name angegeben wurde
                    if (vorname != null && nachname != null)
                    {
                        string name = vorname.Text + " " + nachname.Text;

                        SqlCommand commandInsertNeueBenutzer;
                        SqlDataAdapter dataAdapter = new SqlDataAdapter();
                        string sqlInsertAbfrage = "";

                        sqlInsertAbfrage = "INSERT INTO Benutzer (Benutzername, Email, Passwort) VALUES ('" + name + "', '" +email.Text + "', '" + passwort.Password + "');";

                        commandInsertNeueBenutzer = new SqlCommand(sqlInsertAbfrage, cnn);

                        dataAdapter.InsertCommand = new SqlCommand(sqlInsertAbfrage, cnn);
                        dataAdapter.InsertCommand.ExecuteNonQuery();

                        commandInsertNeueBenutzer.Dispose();

                        //Falls geburtsdatum angegeben wurde, wird es hinzugefuegt
                        if (geburtsdatum.SelectedDate != null)
                        {
                            SqlCommand commandInsertGeburtsdatum;
                            string updateGeburtsdatumAbfrage = "";

                            updateGeburtsdatumAbfrage = "UPDATE Benutzer SET Geburtsdatum='" + geburtsdatum.SelectedDate.Value.Date.ToString("yyyy-MM-dd") + "' WHERE Benutzername LIKE '" + name + "';";

                            commandInsertGeburtsdatum = new SqlCommand(updateGeburtsdatumAbfrage, cnn);

                            dataAdapter.InsertCommand = new SqlCommand(updateGeburtsdatumAbfrage, cnn);
                            dataAdapter.InsertCommand.ExecuteNonQuery();

                            commandInsertGeburtsdatum.Dispose();
                        }

                        //Falls Tagesziel angegeben wurde, wird es hinzugefuegt
                        if (kcalTagesziel.Text.Trim() != "")
                        {
                            SqlCommand commandInsertTagesziel;
                            string updateTageszielAbfrage = "";

                            updateTageszielAbfrage = "UPDATE Benutzer SET Tagesziel_in_Kcal=" + kcalTagesziel.Text + " WHERE Benutzername LIKE '" + name + "';";

                            commandInsertTagesziel = new SqlCommand(updateTageszielAbfrage, cnn);

                            dataAdapter.InsertCommand = new SqlCommand(updateTageszielAbfrage, cnn);
                            dataAdapter.InsertCommand.ExecuteNonQuery();

                            commandInsertTagesziel.Dispose();
                        }

                        //Navigation zu dem Mein_Konto_Window
                        MessageBox.Show("Sie wurden erfolgreich registriert");

                        var win = new MainWindow();
                        win.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Geben Sie bitte Ihre Vor- bzw. Nachname ein");
                    }
                }
                else
                {
                    MessageBox.Show("Die Passwoerter stimmen miteinander nicht zu. Bitte geben Sie sie erneuert ein");
                    passwort.Clear();
                    passwortWiederholen.Clear();
                }
            }
            else
            {
                MessageBox.Show("Konto mit dem Email ist schon vorhanden.");
            }

            cnn.Close();
        }
    }
}
