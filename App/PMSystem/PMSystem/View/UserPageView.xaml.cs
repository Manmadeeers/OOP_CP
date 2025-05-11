using System.Windows;
using System.Windows.Controls;


namespace PMSystem.View
{
    public partial class UserPageView : Window
    {
        public UserPageView()
        {
            InitializeComponent();
        }
        private void CloseClick(object sender,RoutedEventArgs e)
        {
            this.Close();
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
