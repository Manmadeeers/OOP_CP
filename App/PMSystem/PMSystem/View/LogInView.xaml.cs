using PMSystem.ViewModel;
using System.Windows;
using System.Windows.Controls;


namespace PMSystem.View
{

    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
            DataContext = new LogInViewModel(this);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModel.LogInViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }

        private void LangChngeClick(object sender, RoutedEventArgs e)
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
