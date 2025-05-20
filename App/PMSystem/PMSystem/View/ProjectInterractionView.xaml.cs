using Models;
using PMSystem.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace PMSystem.View
{
    public partial class ProjectInterractionView : Window
    {
        private UserModel _user = new UserModel();
        public ProjectInterractionView(UserModel user)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            _user = user;
            if (user.IsAdmin)
            {
                this.IconText.Text = "A";

            }
            else
            {
                var UserLetter = user.UserName[0].ToString();
                this.IconText.Text = UserLetter;
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
        public void ExitClick(object sender, RoutedEventArgs e)
        {
            MainView main = new MainView(_user);
            main.Show();
            this.Close();
        }
        public void ElipseClick(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as ProjectInterractionViewModel;
            UserPageView userPage = new UserPageView() { DataContext = new UserPageViewModel(vm.User) };
            userPage.ShowDialog();
        }
    }
}
