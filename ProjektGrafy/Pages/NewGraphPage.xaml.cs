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

        /// <summary>
        /// Konstruktor klasy NewGraphPage
        /// </summary>
        public NewGraphPage()
        {
            InitializeComponent();
            graph = new BipartiteGraph();
            ConnectionsTable.AutoGenerateColumns = false;
            SizeChanged += DrawOnSizeChange;
        }

        /// <summary>
        /// Metoda Button_AddLeft_Click wywoływana po kliknięciu lewego przycisku "Dodaj wierzchołek"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddLeft_Click(object sender, RoutedEventArgs e)
        {
            graph.AddToLeft();


            VertexControl ver = new VertexControl(graph.ReturnLastLeft());
            LeftGrid.RowDefinitions.Add(new RowDefinition());
            LeftGrid.Children.Add(ver);
            Grid.SetRow(ver, LeftGrid.RowDefinitions.Count - 1);
            drawConnections();
            

        }

        /// <summary>
        /// Metoda Button_AddRight_Click wywoływana po kliknięciu prawego przycisku "Dodaj wierzchołek"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_AddRight_Click(object sender, RoutedEventArgs e)
        {
            graph.AddToRight();

            VertexControl ver = new VertexControl(graph.ReturnLastRight());
            RightGrid.RowDefinitions.Add(new RowDefinition());
            RightGrid.Children.Add(ver);
            Grid.SetRow(ver, RightGrid.RowDefinitions.Count - 1);
            drawConnections();

        }

        /// <summary>
        /// Metoda SetSelectedVertex wywoływana po kliknięciu wierzchołka, 
        /// ustawia go na aktualnie wybrany, co umożliwia edycję jego
        /// połączeń, albo w momencie gdy <c>waitingToConnect == true</c> wybiera
        /// połączenie dla aktualnie wybranego wierzchołka  
        /// </summary>
        /// <param name="vertex"></param>
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
                    drawConnections();
                }
            }
            
        }

        /// <summary>
        /// Metoda AddConnection_Button_Click wywoływana po kliknięciu przycisku "Dodaj połączenie"
        /// ustawia <c>waitingToConnect = true</c> i oczekuje wybrania wierzchołka z którym ma byc ustalone połączenie
        /// w tym trybie przycisk zmienia swą wartośc na "Anuluj", co pozwala na anulowanie szukania połączenia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddConnection_Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (currentlySelectedVertex != null && !waitingToConnect)
            {
                waitingToConnect = true;
                if (graph.LeftOrRight(currentlySelectedVertex) == "Left")
                {
                    searchingInLeft = false;
                    RightGrid.Background = Brushes.Gray;
                }
                else if (graph.LeftOrRight(currentlySelectedVertex) == "Right")
                {
                    searchingInLeft = true;
                    LeftGrid.Background = Brushes.Gray;
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

        /// <summary>
        /// Metoda UpdateConnectionsTable aktualizująca Kontrolkę DataGrid z połączeniami aktualnie wybranego wierzchołka
        /// </summary>
        public void UpdateConnectionsTable()
        {
            ConnectionsTable.ItemsSource = currentlySelectedVertex.connectedWith;
            
        }

        /// <summary>
        /// Metoda drawConnections rysująca połączenia między wierzchołkami 
        /// </summary>
        void drawConnections()
        {

            //LineGrid.Children.Clear();

            foreach (Line ln in LineCanvas.Children)
            {
                ln.Opacity = 0;///memory usage intensifies!!!!111one
                ln.IsEnabled = false;
            }

            foreach (VertexControl vc in LeftGrid.Children)
            {
                
                Vertex temp = vc.ReturnVertex();
                Point startPoint = vc.PointToScreen(new Point(0d, 0d));
                Point controlPosition = this.PointToScreen(new Point(0d, 0d));
                double halfOfRowHeight = 0.5 * LeftGrid.ActualHeight / LeftGrid.RowDefinitions.Count;
                double halfOfRowWidth = 0.5 * LeftGrid.ActualWidth;
                startPoint.Y -= controlPosition.Y; /*(1/(LeftGrid.RowDefinitions.Count +1))*(double)vc.Height;*/
                startPoint.Y += halfOfRowHeight;
                startPoint.X -= controlPosition.X;
                startPoint.X += halfOfRowWidth;
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
                                double halfOfRowHeight2 = 0.5 * RightGrid.ActualHeight / RightGrid.RowDefinitions.Count;
                                double halfOfRowWidth2 = 0.5 * RightGrid.ActualWidth;
                                endPoint.Y -= controlPosition.Y; /*(1/(LeftGrid.RowDefinitions.Count +1))*(double)vc.Height;*/
                                endPoint.Y += halfOfRowHeight2;
                                endPoint.X -= controlPosition.X;
                                endPoint.X += halfOfRowWidth2;
                                newLine.X1 = startPoint.X;
                                newLine.Y1 = startPoint.Y;
                                newLine.X2 = endPoint.X;
                                newLine.Y2 = endPoint.Y;
                                newLine.StrokeThickness = 3;
                                SolidColorBrush redBrush = new SolidColorBrush();
                                redBrush.Color = Colors.Black;
                                newLine.Stroke = redBrush;
                                LineCanvas.Children.Add(newLine);
                                
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Metoda DrawOnSize wykorzystywana ze zdarzeniem zmiany wielkości okna
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <see cref="drawConnections"/>
        private void DrawOnSizeChange(object sender, RoutedEventArgs e)
        {
            drawConnections();
        }

        /// <summary>
        /// Metoda Save_Button_Click wywoływana kliknięciem przycisku "Zapisz graf" <see cref="BipartiteGraphIO"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            BipartiteGraphIO.SaveBipartitegraph(graph);
        }


        /// <summary>
        /// Metoda Back_Button_Click wywoływana kliknięciem przycisku "Cofnij", zmienia aktualnie wyśiwetlaną stornę na MenuPage <see cref="MenuPage"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Jesteś ", "Potwierdzenie usunięcia użytkownika", System.Windows.MessageBoxButton.YesNo);
            //if (messageBoxResult == MessageBoxResult.Yes)
            //{

            //}
            //else
            //{

            //}
            NavigationService.Navigate(new MenuPage());
        }

        private void ConnectionsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
