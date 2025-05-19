using System.Windows;
using Models;
using PMSystem.ViewModel;

namespace PMSystem.View
{
    public partial class AddNewTaskView : Window
    {
        public AddNewTaskView()
        {
            InitializeComponent();
        }


        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedItem = StatusChecker.SelectedItem;
            var vm = DataContext as AddNewTaskViewModel;
            if (selectedItem != null)
            {
                vm.Status = selectedItem.ToString();
            }
        }


        private void ListBoxProject_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedItem = ProjectsChecker.SelectedItem as ProjectModel;
            var vm = DataContext as AddNewTaskViewModel;
            if(selectedItem != null)
            {
                vm.SelectedProject = selectedItem;
            }
        }


        private void ListBoxusers_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedItem = UsersChecker.SelectedItem as UserModel;
            var vm = DataContext as AddNewTaskViewModel;
            if(selectedItem != null)
            {
                vm.SelectedUser = selectedItem;
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
