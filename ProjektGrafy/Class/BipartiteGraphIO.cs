using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using Microsoft.Win32;

namespace ProjektGrafy.Class
{
    class BipartiteGraphIO
    {
        //serializacja binarna
        private static void Serialize(string path, BipartiteGraph obj)
        {
            if (obj != null)
            {
                using (var fs = new FileStream(path, FileMode.Create))
                {
                    var bf = new BinaryFormatter();

                    bf.Serialize(fs, obj);
                }
            }

        }
        //desreializacja binarna
        private static BipartiteGraph Deserialize(string path)
        {
            BipartiteGraph temp = default(BipartiteGraph);

            if (File.Exists(path))
            {

                using (var fs = new FileStream(path, FileMode.Open))
                {

                    if (fs.Length > 0)
                    {

                        var bf = new BinaryFormatter();

                        return (BipartiteGraph)bf.Deserialize(fs);

                    }

                }

            }

            return temp;

        }


        public static void SaveBipartitegraph(BipartiteGraph obj)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "grpah files (*.graph)|*.graph";
            //saveFileDialog.FilterIndex = 1;
            //saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == true)
            {
                Serialize(saveFileDialog.FileName, obj);
            }

        }

        public static BipartiteGraph LoadBipartiteGraph()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "grpah files (*.graph)|*.graph";

            if (openFileDialog.ShowDialog() == true)
            {
                return (BipartiteGraph)Deserialize(openFileDialog.FileName);
            }
            else
            {
                return null;
            }

            
            
        }

    }
}
