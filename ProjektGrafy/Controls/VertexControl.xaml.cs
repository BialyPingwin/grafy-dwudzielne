using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjektGrafy.Class;
using ProjektGrafy.Pages;

namespace ProjektGrafy.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy VertexControl.xaml kontrolki przechowującej wierzchołki
    /// </summary>
    public partial class VertexControl : UserControl
    {
        Vertex vertex;

        /// <summary>
        /// Konstruktor kontrolki VertecControl
        /// </summary>
        /// <param name="vertex">przyjmuje wierzchołek który ma przechowywać <see cref="Vertex"/></param>
        public VertexControl(Vertex vertex)
        {
            InitializeComponent();
            this.vertex = vertex;
            VertexButton.Content = vertex.idNumber;
        }

        /// <summary>
        /// Metoda VertexButton_Click wywoływana kliknięciem na kontrolkę 
        /// odwołująca sie do NewGraphPage <see cref="NewGraphPage"/>
        /// i wywołująca metodę SetSelectedVertex <see cref="NewGraphPage.SetSelectedVertex(Vertex)"/>
        /// przekazując odniesienie do wierzchołka przechowywanego w tej kontrolce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VertexButton_Click(object sender, RoutedEventArgs e)
        {

            MainWindow main = Application.Current.MainWindow as MainWindow;
            if (main.Main.Content is NewGraphPage)
            {
                NewGraphPage page = main.Main.Content as NewGraphPage;
                page.SetSelectedVertex(vertex);
                page.UpdateConnectionsTable();
            }
        }

        /// <summary>
        /// Metoda zwracająca odniesienie do przechowywanego wierzchołka 
        /// </summary>
        /// <returns>zwraca wierzchołek <see cref="Vertex"/></returns>
        public Vertex ReturnVertex()
        {
            return vertex;
        }
    }
}
