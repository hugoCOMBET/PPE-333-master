using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Business;
using Model.Data;
namespace AppConsole
{
    public class Program
    {
        private static DAOclients myDaoClient;
        private static DAOtransactions myDaoTransaction;

        private static Clients monClient;
        private static Transactions matransaction;

        static void Main(string[] args)
        {
            Dbal monDbal = new Dbal("LSRGames");
            monClient = new Clients();
            myDaoClient = new DAOclients(monDbal);

            matransaction = new Transactions();
            myDaoTransaction = new DAOtransactions(monDbal,myDaoClient);


            // select all transaction :
            //List<Transactions> lesTransaction = myDaoTransaction.SelectAll();

            //foreach (Transactions T in lesTransaction)
            //{
            //    Console.WriteLine(T.getIdTransactions());
            //}

            //select by id transaction :
            //Console.WriteLine(myDaoTransaction.SelectById(1).getMontantTransaction()); 

            //select byid client: 
            //Console.WriteLine(myDaoClient.SelectById(1).getEmailClient());
            //select byName name:
            //Console.WriteLine(myDaoClient.SelectByName("GROUSSAUD").getEmailClient());

            //List<Clients> lesClients = myDaoClient.SelectAll();

            //foreach (Clients C in lesClients)
            //{
            //    Console.WriteLine(C.getAdresseClient());
            //}

            DateTime uneDate = new DateTime(2000/01/01);

            Clients monClients = new Clients(4, "julien","gilbert","ffef","sonadresse",uneDate,"client@mail","0452326895",60) ;
            //myDaoClient.Insert(monClients);



            //myDaoClient.Update(monClients);
            myDaoClient.Delete(monClients);

            List<Clients> lesClients = myDaoClient.SelectAll();
            foreach (Clients C in lesClients)
            {
                Console.WriteLine(C.getAdresseClient());
            }

            Console.ReadKey();
        }
    }
}
