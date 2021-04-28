using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class PositionObstacle
    {
        private int _idPositionObstacle;
        private Obstacle _nomObstacle;
        private Transactions _idReservation;
        private int _positionObstacle;

        public PositionObstacle()
        {
            _idPositionObstacle = 0;
            _nomObstacle = new Obstacle();
            _idReservation = new Transactions();
            _positionObstacle = 0;
        }

        public PositionObstacle(int unIdPositionObstacle , Obstacle unNomObstacle, Transactions unIdReservation, int unePositionObstacle)
        {
            _idPositionObstacle = unIdPositionObstacle;
            _nomObstacle = unNomObstacle;
            _idReservation = unIdReservation;
            _positionObstacle = unePositionObstacle;
        }

        public int IdPositionObstacle { get => _idPositionObstacle; set => _idPositionObstacle = value; }
        public Obstacle NomObstacle { get => _nomObstacle; set => _nomObstacle = value; }
        public Transactions IdReservation { get => _idReservation; set => _idReservation = value; }
        public int Position { get => _positionObstacle; set => _positionObstacle = value; }
    }
}
