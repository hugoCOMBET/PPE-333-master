using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Business;

namespace Model.Data
{
    public class daoPositionObstacle
    {
        private Dbal _DBAL;

        public daoPositionObstacle(Dbal unDBAL)
        {
            _DBAL = unDBAL;
        }

        public void Insert(PositionObstacle unePositionObstacle)
        {
            _DBAL.Insert(" PositionObstacle values ('"+unePositionObstacle.IdPositionObstacle+"','" + unePositionObstacle.NomObstacle.NomObstacle + "', " + unePositionObstacle.IdReservation + "," + unePositionObstacle.Position + ");");
        }

        public void Update(PositionObstacle unePositionObstacle)
        {
            _DBAL.Update("  PositionObstacle SET idPositionObstacle = "+unePositionObstacle.IdPositionObstacle+",nomObstacle = '" + unePositionObstacle.NomObstacle + "', idReservation = " + unePositionObstacle.IdReservation + " , positionObstacle = " + unePositionObstacle.Position + " WHERE nomObstacle = '" + unePositionObstacle.NomObstacle + "';");
        }

        public void Delete(PositionObstacle unePositionObstacle)
        {
            _DBAL.Delete(" PositionObstacle WHERE idPositionObstacle = '" + unePositionObstacle.IdPositionObstacle + "' ;");
        }

        public List<PositionObstacle> SelectAll()
        {
            List<PositionObstacle> uneListePositionObstacle = new List<PositionObstacle>();
            DataTable uneDataTable = _DBAL.SelectAll("PositionObstacle");
            foreach (DataRow dtr in uneDataTable.Rows)
            {
                PositionObstacle unePositionObstacle = new PositionObstacle((int)dtr["idPositionObstacle"],(Obstacle)dtr["nomObstacle"],(Transactions)dtr["idReservation"], (int)dtr["positionObstacle"]);
                uneListePositionObstacle.Add(unePositionObstacle);
            }
            return uneListePositionObstacle;
        }

        public PositionObstacle SelectById(int idPositionObstacle)
        {
            DataRow UneDataRow = _DBAL.SelectById("PositionObstacle", idPositionObstacle);
            PositionObstacle unePositionObstacle = new PositionObstacle((int)UneDataRow["idPositionObstacle"], (Obstacle)UneDataRow["nomObstacle"], (Transactions)UneDataRow["idReservation"], (int)UneDataRow["PositionObstacle"]);
            return unePositionObstacle;
        }
    }
}
