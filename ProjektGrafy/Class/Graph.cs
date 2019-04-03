using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGrafy.Class
{
    class Graph
    {
        List<Vertex> AllVertecs;

        public Graph()
        {
            AllVertecs = new List<Vertex>();
        }

        public void AddVertecs(int id)
        {
            Vertex vertex = new Vertex(id);

            if (AllVertecs == null || !AllVertecs.Contains(vertex))
            {
                AllVertecs.Add(vertex);
            }
        }

        public Vertex ReturnLast()
        {
            return AllVertecs.Last<Vertex>();
        }

        public bool ContainsOf(Vertex vertex)
        {
            return AllVertecs.Contains(vertex);
        }
    }
}
