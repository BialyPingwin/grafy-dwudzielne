using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjektGrafy.Class
{
    /// <summary>
    /// Logika klasy BipartiteGraph
    /// </summary>
    [Serializable]
    class BipartiteGraph
    {
        public Graph Left;
        public Graph Right;
        protected int nextID = 0;

        /// <summary>
        /// Konstruktor klasy BipartiteGraph tworzący dwa człowny grafu dwudzielnego lewy i prawy
        /// </summary>
        public BipartiteGraph()
        {
            Left = new Graph();
            Right = new Graph();
        }

        /// <summary>
        /// Metoda AddToLeft dodająca wierzchołek do lewej czesci grafu
        /// </summary>
        public void AddToLeft()
        {
            Left.AddVertecs(nextID);
            nextID++;
        }

        /// <summary>
        /// Metoda AddToRight dodająca wierzchołek do prawej czesci grafu
        /// </summary>
        public void AddToRight()
        {
            Right.AddVertecs(nextID);
            nextID++;
        }

        /// <summary>
        /// Metoda ReturnLastLeft zwracająca ostatni wierzchołek z lewej części grafu
        /// </summary>
        /// <returns>Zwraca ostatni wierzchołek z lewej części grafu <see cref="Vertex"/></returns>
        public Vertex ReturnLastLeft()
        {
            return Left.ReturnLast();
        }

        /// <summary>
        /// Metoda ReturnLastRight zwracająca ostatni wierzchołek z prawej części grafu
        /// </summary>
        /// <returns>Zwraca ostatni wierzchołek z prawej części grafu <see cref="Vertex"/></returns>
        public Vertex ReturnLastRight()
        {
            return Right.ReturnLast();
        }

        /// <summary>
        /// Metoda decydująca czy dany wierzchołek nalezy do lewej czy do prawej części grafu 
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns>Zwraca wartość tekstową "Left", "Right" lub "null"</returns>
        public string LeftOrRight(Vertex vertex)
        {
            if (Left.ContainsOf(vertex))
            {
                return "Left";
            }
            else if (Right.ContainsOf(vertex))
            {
                return "Right";
            }
            else
            {
                return "null";
            }

        }
    }
}
