using KlimovPR29.Classes;
using KlimovPR29.Models;
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

namespace KlimovPR29.Pages.Clubs.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        Main MainClub;
        Users.Main MainUser;
        Models.Clubs Club;
        public UserContext AllUser = new UserContext();

        public Item(Models.Clubs Club, Main MainClub)
        {
            InitializeComponent();

            this.Name.Text = Club.Name;
            this.Addres.Text = Club.Addres;
            this.WorkTime.Text = Club.WorkTime;

            this.MainClub = MainClub;
            this.Club = Club;
            this.MainUser = new Pages.Users.Main();
        }

        private void EditClub(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Clubs.Add(this.MainClub, this.Club));
        }

        private void DeleteClub(object sender, RoutedEventArgs e)
        {
            try
            {
                var rents = MainUser.AllUsers.Users.Where(x => x.IdClub == this.Club.Id).ToList();

                if (rents.Any())
                {
                    MainUser.AllUsers.RemoveRange(rents);
                    MainUser.AllUsers.SaveChanges();
                }

                MainClub.AllClub.Remove(Club);
                MainClub.AllClub.SaveChanges();

                MainClub.parent.Children.Remove(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка");
            }
        }
    }
}
