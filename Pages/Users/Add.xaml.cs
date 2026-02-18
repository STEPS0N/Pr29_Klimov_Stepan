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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public ClubsContext AllClub = new ClubsContext();

        public Models.Users Users;

        public Main Main;

        public Add(Main Main, Models.Users Users = null)
        {
            InitializeComponent();
            this.Users = Users;
            this.Main = Main;

            foreach (Models.Clubs Club in AllClub.Clubs)
            {
                club.Items.Add(Club.Name);
            }
            club.Items.Add("Выберите...");

            if (Users != null)
            {
                this.FIO.Text = Users.FIO;
                this.RentDate.Text = Users.RentStart.ToString("yyyy-MM-dd");
                this.RentTime.Text = Users.RentStart.ToString("HH:mm");
                this.Duration.Text = Users.Duration.ToString();
                club.SelectedItem = AllClub.Clubs.Where(x => x.Id == Users.IdClub).First().Name;
                btn.Content = "Изменить:";
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            DateTime DTRentStart = new DateTime();
            DateTime.TryParse(this.RentDate.Text, out DTRentStart);
            DTRentStart = DTRentStart.Add(TimeSpan.Parse(this.RentTime.Text));

            if (Users == null)
            {
                Users = new Models.Users();

                Users.FIO = this.FIO.Text;
                Users.RentStart = DTRentStart;
                Users.Duration = Convert.ToInt32(this.Duration.Text);
                Users.IdClub = AllClub.Clubs.Where(x => x.Name == club.SelectedItem).First().Id;

                this.Main.AllUsers.Users.Add(this.Users);
            }
            else
            {
                Users.FIO = this.FIO.Text;
                Users.RentStart = DTRentStart;
                Users.Duration = Convert.ToInt32(this.Duration.Text);
                Users.IdClub = AllClub.Clubs.Where(x => x.Name == club.SelectedItem).First().Id;
            }

            this.Main.AllUsers.SaveChanges();

            MainWindow.init.OpenPage(new Pages.Users.Main());
        }
    }
}
