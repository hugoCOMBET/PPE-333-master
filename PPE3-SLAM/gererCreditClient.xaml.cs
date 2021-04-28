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

namespace PPE3_SLAM
{
    /// <summary>
    /// Logique d'interaction pour gererCreditClient.xaml
    /// </summary>
    public partial class gererCreditClient : Window
    {
        public gererCreditClient()
        {
            InitializeComponent();
            rect_infoClient.Visibility = Visibility.Hidden;
            lbl_infosClient.Visibility = Visibility.Hidden;
            textblock_infoClient.Visibility = Visibility.Hidden;
            btn_ajouter.Visibility = Visibility.Hidden;
            btn_supprimer.Visibility = Visibility.Hidden;
            lbl_crédit.Visibility = Visibility.Hidden;
            txt_boxcrédit.Visibility = Visibility.Hidden;
        }
        private void Btn_selection_Click(object sender, RoutedEventArgs e)
        {
            if (list_boxClient.SelectedIndex >= 0)
            {
                rect_infoClient.Visibility = Visibility.Visible;
                lbl_infosClient.Visibility = Visibility.Visible;
                textblock_infoClient.Visibility = Visibility.Visible;
                btn_ajouter.Visibility = Visibility.Visible;
                btn_supprimer.Visibility = Visibility.Visible;
                lbl_crédit.Visibility = Visibility.Visible;
                txt_boxcrédit.Visibility = Visibility.Visible;
            }

        }
    }
}
