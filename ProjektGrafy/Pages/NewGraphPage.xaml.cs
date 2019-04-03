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
        bool waitingToConnect = false;
        bool searchingInLeft = false;

        public NewGraphPage()
        {
            InitializeComponent();
            graph = new BipartiteGraph();
            ConnectionsTable.AutoGenerateColumns = false;
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
            if (!waitingToConnect)
            {
                
                currentlySelectedVertex = vertex;
                UpdateConnectionsTable();
                ActualVertex_Info.Text = currentlySelectedVertex.idNumber.ToString();
                
            }
            else
            {

                if ((graph.LeftOrRight(vertex) == "Left" && searchingInLeft) || (graph.LeftOrRight(vertex) == "Right" && !searchingInLeft))
                {
                    currentlySelectedVertex.AddConnection(vertex);
                    vertex.AddConnection(currentlySelectedVertex);
                    waitingToConnect = false;
                    LeftGrid.Background = null;
                    RightGrid.Background = null;
                    AddConnection_Button.Content = "Dodaj połączenie";
                    UpdateConnectionsTable();
                    Vertex backup = currentlySelectedVertex;
                    SetSelectedVertex(vertex);
                    SetSelectedVertex(backup);//nosz.. tylko tak działa xD
                    //drawConnections();
                }
            }
            
        }

        private void AddConnection_Button_Click(object sender, RoutedEventArgs e)
        {
            draw();
            if (currentlySelectedVertex != null && !waitingToConnect)
            {
                waitingToConnect = true;
                if (graph.LeftOrRight(currentlySelectedVertex) == "Left")
                {
                    searchingInLeft = false;
                    RightGrid.Background = Brushes.Green;
                }
                else if (graph.LeftOrRight(currentlySelectedVertex) == "Right")
                {
                    searchingInLeft = true;
                    LeftGrid.Background = Brushes.Green;
                }
                AddConnection_Button.Content = "Anuluj";
            }
            else if (waitingToConnect)
            {
                waitingToConnect = false;
                LeftGrid.Background = null;
                RightGrid.Background = null;
                AddConnection_Button.Content = "Dodaj połączenie";
            }
        }

        public void UpdateConnectionsTable()
        {
            ConnectionsTable.ItemsSource = currentlySelectedVertex.connectedWith;
            
        }

        void drawConnections()
        {

            LineGrid.Children.Clear();

            foreach(VertexControl vc in LeftGrid.Children)
            {
                
                Vertex temp = vc.ReturnVertex();
                Point startPoint = vc.PointToScreen(new Point(0d, 0d));
                if (temp.connectedWith != null)
                {
                    foreach(Vertex v in temp.connectedWith)
                    {
                        foreach(VertexControl vc2 in RightGrid.Children)
                        {
                            Vertex temp2 = vc2.ReturnVertex();
                            if (temp2.idNumber == v.idNumber)
                            {
                                Point endPoint = vc2.PointToScreen(new Point(0d, 0d));
                                Line newLine = new Line();
                                newLine.X1 = startPoint.X;
                                newLine.Y1 = startPoint.Y;
                                newLine.X2 = endPoint.X;
                                newLine.Y2 = endPoint.Y;
                                newLine.StrokeThickness = 3;
                                SolidColorBrush redBrush = new SolidColorBrush();
                                redBrush.Color = Colors.Red;
                                newLine.Stroke = redBrush;
                                LineGrid.Children.Add(newLine);
                            }
                        }
                    }
                }
            }
        }

        void draw()
        {
            Line newLine = new Line();
            newLine.X1 = 305;
            newLine.Y1 = 374;
            newLine.X2 = 564;
            newLine.Y2 = 368;
            newLine.StrokeThickness = 3;
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Red;
            newLine.Stroke = redBrush;
            MainGrid.Children.Add(newLine);
        }
    }
}
