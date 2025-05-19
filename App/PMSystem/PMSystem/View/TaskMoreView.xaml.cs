
using System.Windows;

namespace PMSystem.View
{
    public partial class TaskMoreView : Window
    {
        public TaskMoreView(bool granted)
        {
            InitializeComponent();
            if (granted)
            {
                this.NewDescriptionPanel.Visibility = Visibility.Visible;
                this.NewNamePanel.Visibility = Visibility.Visible;
                this.NewStatusPanel.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
