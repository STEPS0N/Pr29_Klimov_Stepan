using KlimovPR29.Classes;
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

namespace KlimovPR29.Pages.Clubs
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public ClubsContext AllClub = new ClubsContext();

        public Main()
        {
            InitializeComponent();
            foreach (Models.Clubs Club in AllClub.Clubs)
            {
                parent.Children.Add(new Elements.Item(Club, this));
            }
        }

        private void AddClub(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Clubs.Add(this));
        }

        private void FilterClear(object sender, RoutedEventArgs e)
        {
            filter.Clear();
        }

        private void Filter(object sender, TextChangedEventArgs e)
        {
            var text = filter.Text.Trim().ToLower();

            if (filter.Text == null)
            {
                parent.Children.Clear();
                foreach (Models.Clubs Club in AllClub.Clubs)
                {
                    parent.Children.Add(new Elements.Item(Club, this));
                }
                return;
            }

            var filtered = AllClub.Clubs.Where(x =>
            (x.Name.ToLower().Contains(text)) ||
            (x.Addres.ToLower().Contains(text)) ||
            (x.WorkTime.ToLower().Contains(text)));

            parent.Children.Clear();

            foreach (var club in filtered)
            {
                parent.Children.Add(new Elements.Item(club, this));
            }
        }
    }
}
