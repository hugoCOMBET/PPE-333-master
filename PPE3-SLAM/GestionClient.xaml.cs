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
    /// Logique d'interaction pour GestionClient.xaml
    /// </summary>
    public partial class GestionClient : Window
    {
        
        public GestionClient()
        {
            InitializeComponent();
            rect_infoClient.Visibility = Visibility.Hidden;
            lbl_infosClient.Visibility = Visibility.Hidden;
            textblock_infoClient.Visibility = Visibility.Hidden;
        }

        private void Btn_selection_Click(object sender, RoutedEventArgs e)
        {
            if (list_boxClient.SelectedIndex >= 0)
            {
                rect_infoClient.Visibility = Visibility.Visible;
                lbl_infosClient.Visibility = Visibility.Visible;
                textblock_infoClient.Visibility = Visibility.Visible;
            }
           
        }

        private void Btn_suppprimer_Click(object sender, RoutedEventArgs e)
        {
            list_boxClient.Items.Remove(list_boxClient.SelectedItem);
        }
    }
}
