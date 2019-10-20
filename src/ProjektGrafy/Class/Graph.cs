using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGrafy.Class
{
    /// <summary>
    /// Logika klasy Graph przechowującą liste wierzchołków w danym grafie
    /// </summary>
    [Serializable]
    class Graph
    {
        /// <summary>
        /// Lista zawierająca wszystkie wierzchołki zawarte w tym grafie <see cref="Vertex"/>
        /// </summary>
        public List<Vertex> AllVertecs;

        /// <summary>
        /// Konstruktor klasy Graph, tworzący listę wierzchołków z wartością null
        /// </summary>
        public Graph()
        {
            AllVertecs = new List<Vertex>();
        }

        /// <summary>
        /// Metoda AddVertecs dodająca wierzchołek do grafu po zadanym numerze id
        /// </summary>
        /// <param name="id">numer id</param>
        public void AddVertecs(int id)
        {
            Vertex vertex = new Vertex(id);

            if (AllVertecs == null || !AllVertecs.Contains(vertex))
            {
                AllVertecs.Add(vertex);
            }
        }

        /// <summary>
        /// Metoda ReturnLast zwracająca ostatni dodany do grafu wierzchołek 
        /// </summary>
        /// <returns></returns>
        public Vertex ReturnLast()
        {
            return AllVertecs.Last<Vertex>();
        }

        /// <summary>
        /// Metoda ContainsOf sprawdzająca czy dany wierzchołek zawiera się w tym grafie
        /// </summary>
        /// <param name="vertex">przyjmyje jako parametr Wierzchołek <see cref="Vertex"/></param>
        /// <returns>zwraca wartość true albo false</returns>
        public bool ContainsOf(Vertex vertex)
        {
            return AllVertecs.Contains(vertex);
        }

        
    }
}
