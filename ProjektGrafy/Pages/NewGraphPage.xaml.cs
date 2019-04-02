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
using ProjektGrafy.Controls;

namespace ProjektGrafy.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy NewGraphPage.xaml
    /// </summary>
    public partial class NewGraphPage : Page
    {
        BipartiteGraph graph;
        Vertex currentlySelectedVertex;

        public NewGraphPage()
        {
            InitializeComponent();
            graph = new BipartiteGraph();
        }

        private void Button_AddLeft_Click(object sender, RoutedEventArgs e)
        {
            graph.AddToLeft();


            VertexControl ver = new VertexControl(graph.ReturnLastLeft());
            LeftGrid.RowDefinitions.Add(new RowDefinition());
            LeftGrid.Children.Add(ver);
            Grid.SetRow(ver, LeftGrid.RowDefinitions.Count - 1);
            

        }

        private void Button_AddRight_Click(object sender, RoutedEventArgs e)
        {
            graph.AddToRight();

            VertexControl ver = new VertexControl(graph.ReturnLastRight());
            RightGrid.RowDefinitions.Add(new RowDefinition());
            RightGrid.Children.Add(ver);
            Grid.SetRow(ver, RightGrid.RowDefinitions.Count - 1);

        }

        public void SetSelectedVertex(Vertex vertex)
        {
            currentlySelectedVertex = vertex;
        }
    }
}
