using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Model.Business;
using Model.Data;

namespace PPE3_SLAM_HUGO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //déclarer ici les attributs de la class App
        //on viendra y déclarer notamement nos objets Dbal et Dao
        //au lancement de la solution, Dbal et Dao seront donc instanciés et passés aux différentes fenêtres

        private Dbal thedbal;
        private DAOclients thedaoClient;
        private DAOtransactions thedaoTransaction;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //C'est ici, dans la méthode Application_Startup, qu'on instancie nos objets Dbal et Dao
            thedbal = new Dbal("LSRGames");
            thedaoClient = new DAOclients(thedbal);
            thedaoTransaction = new DAOtransactions(thedbal,thedaoClient);

            // Create the startup window
            //là, on lance la fenêtre souhaitée en instanciant la classe de notre fenêtre
            MainWindow wnd = new MainWindow(thedaoClient,thedaoTransaction);
            //et on utilise la méthode Show() de notre objet fenêtre pour afficher la fenêtre
            //exemple: MainWindow lafenetre = new MainWindow(); (et on y passe en paramètre Dbal et Dao au besoin)
            wnd.Show();
        }

        //Méthode permettant d'afficher les exceptions non gérées (voir wpftutorial.com)
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
}
