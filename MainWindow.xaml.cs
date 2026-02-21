using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KlimovPR29
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;

            OpenPage(new Pages.Users.Main());
        }

        public void OpenPage(Page Page)
        {
            frame.Navigate(Page);
        }

        private void Clubs(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Clubs.Main());
        }

        private void Users(object sender, RoutedEventArgs e)
        {
            OpenPage(new Pages.Users.Main());
        }
    }
}