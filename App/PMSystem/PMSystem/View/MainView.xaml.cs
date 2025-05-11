using System.Windows;
using System.Windows.Controls;
using Models;
using PMSystem.ViewModel;

namespace PMSystem.View
{
    public partial class MainView : Window
    {
        private UserModel _user;
        public MainView(UserModel user)
        {
            InitializeComponent();
            _user = user;
            DataContext = new MainViewModel(user,this);
            if (user.IsAdmin)
            {
                this.UsersButton.Visibility = Visibility.Visible;
                this.IconText.Text = "A";
            }
            else
            {
                var UserLetter = user.UserName[0].ToString();
                this.IconText.Text = UserLetter;
            }
        }


        public void ElipseClick(object sender, RoutedEventArgs e)
        {
            UserPageView userPage = new UserPageView() { DataContext = new UserPageViewModel(_user) };
            userPage.ShowDialog();
        }
        public void LangChangeClick(object sender,RoutedEventArgs e)
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
    }
}
