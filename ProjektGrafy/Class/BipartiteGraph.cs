using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGrafy.Class
{
    class BipartiteGraph
    {
        Graph Left;
        Graph Right;
        protected int nextID = 0;


        public BipartiteGraph()
        {
            Left = new Graph();
            Right = new Graph();
        }

        public void AddToLeft()
        {
            Left.AddVertecs(nextID);
            nextID++;
        }

        public void AddToRight()
        {
            Right.AddVertecs(nextID);
            nextID++;
        }

        public Vertex ReturnLastLeft()
        {
            return Left.ReturnLast();
        }

        public Vertex ReturnLastRight()
        {
            return Right.ReturnLast();
        }

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
