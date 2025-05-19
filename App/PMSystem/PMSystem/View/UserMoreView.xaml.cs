using Models;
using System.Windows;

namespace PMSystem.View
{

    public partial class UserMoreView : Window
    {

        public UserMoreView(UserModel user)
        {
            InitializeComponent();
            if (user.IsAdmin)
            {
                this.DeleteButton.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
