using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektGrafy.Class
{
    class Checkout
    {
        public bool IsComplete(BipartiteGraph bipartiteGraph)
        {
            for (int i = 0;  i < bipartiteGraph.Left.AllVertecs.Count; i++)
            {
                for (int j = 0; j < bipartiteGraph.Right.AllVertecs.Count; j++)
                {
                    if (!bipartiteGraph.Left.AllVertecs[i].connectedWith.Contains(bipartiteGraph.Right.AllVertecs[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
