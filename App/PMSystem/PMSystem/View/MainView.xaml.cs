using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DAL;
using Models;
using PMSystem.ViewModel;

namespace PMSystem.View
{
    public partial class MainView : Window
    {
        private UserModel _user;


        private List<Button> _buttons = new List<Button>();
        public MainView(UserModel user)
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            _user = user;
            DataContext = new MainViewModel(user,this);
            if (user.IsAdmin)
            {
                if (App.DatContext.Users.Count() == 0)
                {
                    this.IconText.Text = "B";
                }
                else
                {
                    this.UsersButton.Visibility = Visibility.Visible;
                    this.IconText.Text = "A";
                }
       
            }
            else
            {
                var UserLetter = user.UserName[0].ToString();
                this.IconText.Text = UserLetter;
            }

            _buttons.Add(this.ProjectsBUtton);
            _buttons.Add(this.TasksButton);
            _buttons.Add(this.UsersButton);
            _buttons.Add(this.StatisticsButton);

        }


        private void ClearButtonsBackground(Button ignore)
        {
            foreach(var button in _buttons)
            {
                if (button.Name != ignore.Name)
                {
                    button.Background = new SolidColorBrush(Colors.Transparent);
                    button.Foreground = new SolidColorBrush(Color.FromRgb(51, 51, 51));
                }
            }
        }
        
        public void ElipseClick(object sender, RoutedEventArgs e)
        {
            UserPageView userPage = new UserPageView() { DataContext = new UserPageViewModel(_user) };
            userPage.ShowDialog();
        }

        public void ProjectsClick(object sender, RoutedEventArgs e)
        {
            ClearButtonsBackground(this.ProjectsBUtton);
            this.ProjectsBUtton.Background = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            this.ProjectsBUtton.Foreground = new SolidColorBrush(Colors.White);


        }

        public void TasksClick(object sender, RoutedEventArgs e)
        {
            ClearButtonsBackground(this.TasksButton);
            this.TasksButton.Background = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            this.TasksButton.Foreground = new SolidColorBrush(Colors.White);
        }

        public void StatisticsClick(object sender, RoutedEventArgs e)
        {
            ClearButtonsBackground(this.StatisticsButton);
            this.StatisticsButton.Background = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            this.StatisticsButton.Foreground = new SolidColorBrush(Colors.White);
        }
        
        public void UsersClick(object sender, RoutedEventArgs e)
        {
            ClearButtonsBackground(this.UsersButton);
            this.UsersButton.Background = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            this.UsersButton.Foreground = new SolidColorBrush(Colors.White);
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
