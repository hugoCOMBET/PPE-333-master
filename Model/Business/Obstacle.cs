using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Business
{
    public class Obstacle
    {
        private string _nomObstacle;
        private string _definition;
        private string _photo;
        private string _typeObstacle;

        public Obstacle()
        {
            _nomObstacle = "";
            _definition = "";
            _photo = "";
            _typeObstacle = "";
        }

        public Obstacle(string unNomObstacle, string uneDefinition, string unePhoto, string unTypeObstacle)
        {
            _nomObstacle = unNomObstacle;
            _definition = uneDefinition;
            _photo = unePhoto;
            _typeObstacle = unTypeObstacle;
        }

        public string NomObstacle { get => _nomObstacle; set => _nomObstacle = value; }

        public string Definition { get => _definition; set => _definition = value; }

        public string Photo { get => _photo; set => _photo = value; }

        public string TypeObstacle { get => _typeObstacle; set => _typeObstacle = value; }
    }
}
