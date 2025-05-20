
using PMSystem.ViewModel;
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
                //this.NewStatusPanel.Visibility = Visibility.Visible;
                this.DeleteButton.Visibility = Visibility.Visible;
            }
        }

        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedItem = StatusChecker.SelectedItem;
            var vm = DataContext as TaskMoreViewModel;
            if (selectedItem != null)
            {
                vm.Status = selectedItem.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
