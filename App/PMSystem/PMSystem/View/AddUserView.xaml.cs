using PMSystem.ViewModel;
using System.Windows;



namespace PMSystem.View
{
    public partial class AddUserView : Window
    {
        public AddUserView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object senser, RoutedEventArgs e)
        {
            var selectedItem = RoleChecker.SelectedItem;
            var vm = DataContext as AddUserViewModel;
            if (selectedItem != null)
            {
                vm.SelectedRole = selectedItem.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
