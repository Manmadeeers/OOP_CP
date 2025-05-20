using Models;
using System.Windows;
using System.Windows.Controls;


namespace PMSystem.View
{
    public partial class StatisticsView : Window
    {
        private UserModel _user = new UserModel();
        public StatisticsView(UserModel user)
        {
            InitializeComponent();
            _user = user;
            if (_user.IsAdmin)
            {
                this.AdminStat.Visibility = Visibility.Visible;
                this.UserStat.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.AdminStat.Visibility = Visibility.Collapsed;
                this.UserStat.Visibility = Visibility.Visible;
            }
        }


        public void LangChangeClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Content.ToString().ToLower() == "en")
                {
                    ((App)Application.Current).ChangeLanguage("ru");
                    btn.Content = "Ru";
                }
                else if (btn.Content.ToString().ToLower() == "ru")
                {
                    ((App)Application.Current).ChangeLanguage("en");
                    btn.Content = "En";
                }
            }
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
