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
        bool isSelectable;

        /// <summary>
        /// Konstruktor kontrolki VertecControl
        /// </summary>
        /// <param name="vertex">przyjmuje wierzchołek który ma przechowywać <see cref="Vertex"/></param>
        /// <param name="isSelectable">Zmienna która po przekazaniu do niej true włącza możliwość kliknięcia kontrolki </param>
        public VertexControl(Vertex vertex, bool isSelectable = false)
        {
            InitializeComponent();
            this.vertex = vertex;
            this.isSelectable = isSelectable;
            VertexButton.Content = vertex.idNumber;
            if (!isSelectable)
            {
                VertexButton.IsEnabled = false;
            }
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

                

                //foreach (VertexControl vc in page.LeftGrid.Children)
                //{
                //    vc.Deselect();
                //}
                //foreach (VertexControl vc in page.RightGrid.Children)
                //{
                //    vc.Deselect();
                //}

                //Select();

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

        /// <summary>
        /// Metoda Select zmienia kolor aktualnie zaznaczonej kontrolki 
        /// </summary>
        private void Select()
        {
            VertexButton.Background = Brushes.SeaGreen;
        }

        /// <summary>
        /// Metoda Deselect zmienia kolor aktualnie zaznaczonej kontrolki 
        /// </summary>
        private void Deselect()
        {
            VertexButton.Background = Brushes.White;
        }

        /// <summary>
        /// Metoda HighlightSelected po wywołaniu wykonuje metode Select <see cref="Select"/>
        /// czyli zaznacza podany po idNumer wierzchołek, a dla kazdego innego wykonuje metodę Deselect <see cref="Deselect"/>
        /// </summary>
        /// <param name="newGraphPage">Strona w której należy zmienić kolor kontrolek</param>
        /// <param name="idNumber">numer szukanego wierzchołka</param>
        public static void HighlightSelected(NewGraphPage newGraphPage, int idNumber)
        {
            foreach (VertexControl vc in newGraphPage.LeftGrid.Children)
            {
                if (vc.vertex.idNumber == idNumber)
                {
                    vc.Select();
                }
                else
                {
                    vc.Deselect();
                }              
            }
            foreach (VertexControl vc in newGraphPage.RightGrid.Children)
            {
                if (vc.vertex.idNumber == idNumber)
                {
                    vc.Select();
                }
                else
                {
                    vc.Deselect();
                }
            }
        }

    }
}
