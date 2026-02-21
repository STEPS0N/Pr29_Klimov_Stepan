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

namespace KlimovPR29.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public UserContext AllUsers = new UserContext();
        public ClubsContext AllClubs = new ClubsContext();

        public Main()
        {
            InitializeComponent();

            filterClub.Items.Clear();
            filterClub.Items.Add("Любой");

            foreach (Models.Clubs clubs in AllClubs.Clubs)
            {
                filterClub.Items.Add(clubs.Name);
            }

            foreach (Models.Users User in AllUsers.Users)
            {
                parent.Children.Add(new Elements.Item(this, User));
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Users.Add(this));
        }

        private void FilterClear(object sender, RoutedEventArgs e)
        {
            filterFIO.Clear();
            filterClub.SelectedIndex = 0;
            filterDate.Text = null;
            filterDuration.Clear();

            parent.Children.Clear();

            foreach (Models.Users User in AllUsers.Users)
            {
                parent.Children.Add(new Elements.Item(this, User));
            }
        }

        private void FilterFIO(object sender, TextChangedEventArgs e)
        {
            var text = filterFIO.Text.Trim().ToLower();

            if (filterFIO.Text == null)
            {
                parent.Children.Clear();
                foreach (Models.Users User in AllUsers.Users)
                {
                    parent.Children.Add(new Elements.Item(this, User));
                }
                return;
            }

            var filtered = AllUsers.Users.Where(x => x.FIO.ToLower().Contains(text));

            parent.Children.Clear();

            foreach (var user in filtered)
            {
                parent.Children.Add(new Elements.Item(this, user));
            }
        }

        private void FilterClub(object sender, SelectionChangedEventArgs e)
        {
            if (filterClub.SelectedItem.ToString() == "Любой")
            {
                parent.Children.Clear();
                foreach (Models.Users User in AllUsers.Users)
                {
                    parent.Children.Add(new Elements.Item(this, User));
                }
                return;
            }

            var club = AllClubs.Clubs.FirstOrDefault(x => x.Name == filterClub.SelectedItem.ToString());

            if (club != null)
            {
                parent.Children.Clear();

                var filtered = AllUsers.Users.Where(x => x.IdClub == club.Id);

                foreach (var user in filtered)
                {
                    parent.Children.Add(new Elements.Item(this, user));
                }
            }
        }

        private void FilterDate(object sender, SelectionChangedEventArgs e)
        {
            var text = filterDate.Text.Trim();

            if (filterDate.Text == null)
            {
                parent.Children.Clear();
                foreach (Models.Users User in AllUsers.Users)
                {
                    parent.Children.Add(new Elements.Item(this, User));
                }
                return;
            }

            var filtered = AllUsers.Users.ToList().Where(x => x.RentStart.ToString("dd.MM.yyyy").Contains(text));

            parent.Children.Clear();

            foreach (var user in filtered)
            {
                parent.Children.Add(new Elements.Item(this, user));
            }
        }

        private void FilterDuration(object sender, TextChangedEventArgs e)
        {
            var text = filterDuration.Text.Trim();

            if (filterDuration.Text == null)
            {
                parent.Children.Clear();
                foreach (Models.Users User in AllUsers.Users)
                {
                    parent.Children.Add(new Elements.Item(this, User));
                }
                return;
            }

            var filtered = AllUsers.Users.Where(x => x.Duration.ToString().Contains(text));

            parent.Children.Clear();

            foreach (var user in filtered)
            {
                parent.Children.Add(new Elements.Item(this, user));
            }
        }
    }
}
