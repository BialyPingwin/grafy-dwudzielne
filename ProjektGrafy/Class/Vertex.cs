using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGrafy.Class
{
    /// <summary>
    /// Logika klasy Vertex, czyli pojedyńczych wierzchołków
    /// </summary>
    [Serializable]
    public class Vertex
    {
        public int idNumber { get; set; }
        public List<Vertex> connectedWith;
        
        /// <summary>
        /// konstruktor klasy Vertex, tworzący wierzchołek
        /// o konkretnym numerze id i tworzący listę powiązań 
        /// z tym wierzchołkiem z wartością początkową null
        /// </summary>
        /// <param name="id">numer id</param>
        public Vertex(int id)
        {
            idNumber = id;
            connectedWith = new List<Vertex>();
        }

        /// <summary>
        /// Metoda AddConnection dodająca połączenie miedzy tym, a konkretnym wierzchołkiem
        /// </summary>
        /// <param name="id">przyjmuje wierzchołek z którym ma byc ustanowione połączenie <see cref="Vertex"/></param>
        public void AddConnection(Vertex id)
        {
            if (connectedWith == null || !connectedWith.Contains(id))
            {
                connectedWith.Add(id);
            }
        }

        
    }
}
