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

namespace KlimovPR29.Pages.Users.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public ClubsContext AllClub = new ClubsContext();

        Main Main;

        Models.Users Users;

        public Item(Main Main, Models.Users Users)
        {
            InitializeComponent();
            this.Main = Main;
            this.Users = Users;

            this.FIO.Text = Users.FIO;
            this.RentDate.Text = Users.RentStart.ToString("yyyy-MM-dd");
            this.RentTime.Text = Users.RentStart.ToString("HH:mm");
            this.Duration.Text = Users.Duration.ToString();
            this.Club.Text = AllClub.Clubs.Where(x => x.Id == Users.IdClub).First().Name;
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            MainWindow.init.OpenPage(new Pages.Users.Add(this.Main, this.Users));
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            Main.AllUsers.Remove(Users);
            Main.AllUsers.SaveChanges();
            Main.parent.Children.Remove(this);
        }
    }
}
