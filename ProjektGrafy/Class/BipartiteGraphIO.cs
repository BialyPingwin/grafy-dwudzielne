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
    /// <summary>
    /// Klasa BipartiteGraphIO służąca do zapisywania i wczytywania grafu 
    /// </summary>
    class BipartiteGraphIO
    {
        /// <summary>
        /// Metoda Serialize zapisująca do konkretnego pliku graf
        /// </summary>
        /// <param name="path">ścieżka pliku</param>
        /// <param name="obj">obiekt BipartiteGraph<see cref="BipartiteGraph"/></param>
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
        
        /// <summary>
        /// Metoda Deserialize wczytująca z konkretnegej ścieżki plik i zwracająca go jako BipartiteGraph <see cref="BipartiteGraph"/>
        /// </summary>
        /// <param name="path">ścieżka do pliku</param>
        /// <returns>Zwraca klasę BipartiteGraph wczytaną z pliku <see cref="BipartiteGraph"/></returns>
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

        /// <summary>
        /// Statyczna publiczna metoda SaveBipartitegraph do 
        /// wywoływania z innych miejsc programu do zapisywania
        /// konkretnego grafu, pozwala wybrac użytkownikowi gdzie
        /// i pod jaką nazwą plik bedzie zapisany
        /// </summary>
        /// <param name="obj">obiekt klasy BipartiteGraph <see cref="BipartiteGraph"/></param>
        public static void SaveBipartitegraph(BipartiteGraph obj)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "graph files (*.graph)|*.graph";

            if (saveFileDialog.ShowDialog() == true)
            {
                Serialize(saveFileDialog.FileName, obj);
            }

        }

        /// <summary>
        /// publiczna stayczna metoda LoadBipartiteGraph służąca
        /// do wczytywania grafu z innych miejsc w programie
        /// pozwala wybrać użytkownikowi plik do wczytania
        /// </summary>
        /// <returns>Zwraca wczytaną z plkiu </returns>
        public static BipartiteGraph LoadBipartiteGraph()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "graph files (*.graph)|*.graph";

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
