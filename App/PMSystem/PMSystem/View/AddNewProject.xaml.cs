using System.Windows;
using Models;
using PMSystem.ViewModel;



namespace PMSystem.View
{
    public partial class AddNewProject : Window
    {
        public AddNewProject()
        {
            InitializeComponent();
            this.DataContext = new AddNewProjectViewModel();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedUsers = UserChecker.SelectedItems.Cast<UserModel>().ToList();
            var viewModel = DataContext as AddNewProjectViewModel;
            viewModel.SelectedUsers.Clear();
            foreach( var user in selectedUsers )
            {
                viewModel.SelectedUsers.Add( user );
            }
        }
    }
}
