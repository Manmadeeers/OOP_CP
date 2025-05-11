using System.Windows;


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
    }
}
