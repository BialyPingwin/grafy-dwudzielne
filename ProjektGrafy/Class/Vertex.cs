using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGrafy.Class
{
    [Serializable]
    public class Vertex
    {
        public int idNumber { get; set; }
        public List<Vertex> connectedWith;
        
        public Vertex(int id)
        {
            idNumber = id;
            connectedWith = new List<Vertex>();
        }

        public void AddConnection(Vertex id)
        {
            if (connectedWith == null || !connectedWith.Contains(id))
            {
                connectedWith.Add(id);
            }
        }

        //public override bool Equals(object obj)
        //{

        //    Vertex toEqual = obj as Vertex;
        //    if (idNumber == toEqual.idNumber)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}


    }
}
