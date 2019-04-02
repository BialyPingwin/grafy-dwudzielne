using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGrafy.Class
{
    public class Vertex
    {
        public int idNumber;
        public List<int> connectedWith;
        
        public Vertex(int id)
        {
            idNumber = id;
            connectedWith = new List<int>();
        }

        public void AddConnection(int id)
        {
            if (connectedWith == null || !connectedWith.Contains(id))
            {
                connectedWith.Add(id);
            }
        }

        public override bool Equals(object obj)
        {

            Vertex toEqual = obj as Vertex;
            if (idNumber == toEqual.idNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
