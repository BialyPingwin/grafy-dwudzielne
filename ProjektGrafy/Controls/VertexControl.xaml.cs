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

namespace ProjektGrafy.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy VertexControl.xaml
    /// </summary>
    public partial class VertexControl : UserControl
    {
        Vertex vertex;

        public VertexControl(Vertex vertex)
        {
            InitializeComponent();
            this.vertex = vertex;
            VertexButton.Content = vertex.idNumber;
        }

        private void VertexButton_Click(object sender, RoutedEventArgs e)
        {
            
           // Application.Current.MainWindow
        }
    }
}
