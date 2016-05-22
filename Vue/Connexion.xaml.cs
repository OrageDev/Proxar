using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Proxar.Modele;

namespace Proxar.Vue
{
    /// <summary>
    /// Interaction logic for Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public Connexion()
        {

            InitializeComponent();
        }
        
        
        private void connexionButton_Click(object sender, RoutedEventArgs e)
        {
            BDDUserManagement connection = new BDDUserManagement();
            if (connection.Connection() != false)
            {
               
                if(false != connection.SelectStudent(Identifiant.Text, MotDePasse.Password))
                {
                    MessageBox.Show("Bonjour : " + connection.Name);
                }
            }
            else
            {
                MessageBox.Show("Failed to connect to the Database");
            }
            
        }
    }
}
