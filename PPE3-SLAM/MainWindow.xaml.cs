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

namespace PPE3_SLAM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        afficherTransaction AffichageTransaction = new afficherTransaction();
        gererCreditClient GererCreditClient = new gererCreditClient();
        GestionClient GererClient = new GestionClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_valider_Click(object sender, RoutedEventArgs e)
        {
            if (radioBtn_AfficherTransactions.IsChecked == true)
            {
                AffichageTransaction.Show();
            }
            if (radioBtn_GererClient.IsChecked == true)
            {
                GererClient.Show();
            }
            if (radioBtn_GererCreditClient.IsChecked == true)
            {
                GererCreditClient.Show();
            }
        }
    }
}
