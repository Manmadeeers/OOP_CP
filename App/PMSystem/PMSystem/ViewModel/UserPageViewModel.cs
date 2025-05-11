using Models;

namespace PMSystem.ViewModel
{
    public class UserPageViewModel
    {

        public UserModel User { get; set; }
        public UserPageViewModel(UserModel user) 
        {
            User = user;
        }



    }
}
