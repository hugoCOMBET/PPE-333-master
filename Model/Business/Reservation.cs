using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Business;

namespace Model.Business
{
    public class Reservations
    {
        private int _idReservation;
        private Clients _LeClient;
        private salles _LaSalle;
        private Transactions _LaTransaction;
        private DateTime _dateReservation;
        private int _nbJoueurs;
        private int _nbObstacles;

        public Reservations()
        {
            _idReservation = 0;
            _LeClient = new Clients();
            _LaSalle = new salles();
            _LaTransaction = new Transactions();
            _dateReservation = new DateTime();
            _nbJoueurs = 0;
            _nbObstacles = 0;
        }

        public Reservations(int unIdReservation, Clients unIdClient, salles unIdSalle, Transactions unIdTransaction, DateTime uneDateReservation,int unNbJoueurs, int unNbObstacle)
        {
            _idReservation = unIdReservation;
            _LeClient = unIdClient;
            _LaSalle = unIdSalle;
            _LaTransaction = unIdTransaction;

            _dateReservation = uneDateReservation;
            _nbJoueurs = unNbJoueurs;
            _nbObstacles = unNbObstacle;
        }

        public int IdReservation { get => _idReservation; set => _idReservation = value; }
        public Clients LeClient { get => _LeClient; set => _LeClient = value; }
        public salles LaSalle { get => _LaSalle; set => _LaSalle = value; }
        public Transactions LaTransaction { get => _LaTransaction; set => _LaTransaction = value; }
        public DateTime DateReservation { get => _dateReservation; set => _dateReservation = value; }
        public int NbJoueurs { get => _nbJoueurs; set => _nbJoueurs = value; }
        public int NbObstacles { get => _nbObstacles; set => _nbObstacles = value; }
    }
}
