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

namespace ProjektGrafy.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {

        /// <summary>
        /// Konstruktor klasy MenuPage
        /// </summary>
        public MenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda New_Button_Click wywoływana kliknięciem przycisku "Nowy graf", zmienia aktualną stronę na NewGraphPage <see cref="NewGraphPage"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void New_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewGraphPage());
        }

        /// <summary>
        /// Metoda LoadAndCheckButton_Click wywoływana kliknięciem przycisku "Wczytaj graf i sprawdź(...)", zmienia aktualną stronę na LoadGraphPage <see cref="LoadGraphPage"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadAndCheckButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoadGraphPage());
        }
    }
}
