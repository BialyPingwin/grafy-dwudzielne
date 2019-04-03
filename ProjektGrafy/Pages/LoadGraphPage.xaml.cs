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
    /// Logika interakcji dla klasy LoadGraphPage.xaml
    /// </summary>
    public partial class LoadGraphPage : Page
    {
        
        BipartiteGraph graph;
        bool isGraphLoaded = false;
        delegate void GraphLoaded(object obj, RoutedEventArgs eventArgs);
        event GraphLoaded OnGraphLoaded;

        /// <summary>
        /// Konstruktor klasy LoadGraphPage
        /// </summary>
        public LoadGraphPage()
        {
            InitializeComponent();
            SizeChanged += DrawOnSizeChange;
            OnGraphLoaded += OnLoad;
        }

        
        /// <summary>
        /// Metoda LoadGraph wczytująca graf z pliku użytkownika <see cref="BipartiteGraphIO"/>
        /// </summary>
        private void LoadGraph()
        {
            graph = BipartiteGraphIO.LoadBipartiteGraph();
            if (graph != null)
            {
                UpdateVertex();
                
            }
        }

        /// <summary>
        /// Metoda UpdateVertex rusująca wierzchołki wczytanego grafu
        /// </summary>
        private void UpdateVertex()
        {
            foreach (Vertex v in graph.Left.AllVertecs)
            {
                VertexControl ver = new VertexControl(v);
                LeftGrid.RowDefinitions.Add(new RowDefinition());
                LeftGrid.Children.Add(ver);
                Grid.SetRow(ver, LeftGrid.RowDefinitions.Count - 1);
            }
            foreach (Vertex v in graph.Right.AllVertecs)
            {
                VertexControl ver = new VertexControl(v);
                RightGrid.RowDefinitions.Add(new RowDefinition());
                RightGrid.Children.Add(ver);
                Grid.SetRow(ver, RightGrid.RowDefinitions.Count - 1);
                
            }

        
            OnGraphLoaded(this, null);
            
        }

        /// <summary>
        /// Metoda drawConnections rysująca połączenia między wierzchołkami 
        /// </summary>
        void drawConnections()
        {

            

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
                startPoint.Y -= controlPosition.Y; 
                startPoint.Y += halfOfRowHeight;
                startPoint.Y -= 10; //Czemu?????
                startPoint.X -= controlPosition.X;
                startPoint.X += halfOfRowWidth;
                if (temp.connectedWith != null)
                {
                    foreach (Vertex v in temp.connectedWith)
                    {
                        foreach (VertexControl vc2 in RightGrid.Children)
                        {
                            Vertex temp2 = vc2.ReturnVertex();
                            if (temp2.idNumber == v.idNumber)
                            {
                                Point endPoint = vc2.PointToScreen(new Point(0d, 0d));
                                Line newLine = new Line();
                                double halfOfRowHeight2 = 0.5 * RightGrid.ActualHeight / RightGrid.RowDefinitions.Count;
                                double halfOfRowWidth2 = 0.5 * RightGrid.ActualWidth;
                                endPoint.Y -= controlPosition.Y; 
                                endPoint.Y += halfOfRowHeight2;
                                endPoint.Y -= 10;
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
        /// Metoda OnLoad wykorzystywana do informowania o wczytaniu grafu do UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoad(object sender, RoutedEventArgs e)
        {

            isGraphLoaded = true;
            
        }

        /// <summary>
        /// Metoda Load_Button_Click wywoływana po kliknięciu przycisku "Wczytaj graf"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Load_Button_Click(object sender, RoutedEventArgs e)
        {
            if (graph == null)
            {
                
                Load_Button.Content = "Resetuj";
                LoadGraphAcync();
                
            }
            else
            {
                NavigationService.Navigate(new LoadGraphPage());
                
            }
            
        }

        /// <summary>
        /// Metoda CheckGraph_Button_Click wywoływana po kliknięciu przycisku "Sprawdź czy graf jest zupełny"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckGraph_Button_Click(object sender, RoutedEventArgs e)
        {
            ////Tutaj Algorytm
        }

        /// <summary>
        /// Metoda Back_Button_Click wywoływana po kliknięciu przycisku "Cofnij"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MenuPage());
        }


        /// <summary>
        /// Metoda asynchroniczna LoadGraphAsync wczytująca graf, aktaulizująca UI i rysująca połączenia
        /// </summary>
        private async void LoadGraphAcync()
        {
            LoadGraph();
            await Task.Run(() => waitForLoad());
            drawConnections();
        }

        /// <summary>
        /// Metoda waitForLoad oczekująca wczytania grafu i zaktualizowania UI
        /// </summary>
        private void waitForLoad()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw = System.Diagnostics.Stopwatch.StartNew();
            while (true) 
            {
                if (sw.ElapsedMilliseconds > 1000)
                {
                    sw.Stop();
                    return;
                }

                if (isGraphLoaded == true)
                {
                    sw.Stop();
                    return;
                }
            }
        }

        
    }
}
