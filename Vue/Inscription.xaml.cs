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

namespace Proxar.Vue
{
    /// <summary>
    /// Interaction logic for Inscription.xaml
    /// </summary>
    public partial class Inscription : Window
    {
        private List<string> promotions = new List<string>();

        public Inscription()
        {
            InitializeComponent();
            for (int i = 1; i <= 5; i++)
            {
                this.promotions.Add("A" + i);
            }
            Promotion.ItemsSource = promotions;
        }
    }
}
