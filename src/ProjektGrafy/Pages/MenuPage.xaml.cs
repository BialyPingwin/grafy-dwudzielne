using System;
using System.Collections.Generic;
using System.IO;
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
using ProjektGrafy.Controls;

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
            AppInfo.Text = "Projekt 26 - Sprawdzenie czy graf dwudzielny jest zupełny. \n\nAutorzy:\nMichał Bogusławski\nZuzanna Żbikowska";
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
