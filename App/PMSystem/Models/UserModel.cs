
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string UserEmail { get; set; }
        public bool IsAdmin { get; set; }

        public string UserRole { get; set; }

       // public string UserPhotoPath { get; set; }
        public ICollection<TaskModel> Tasks { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }



        public UserModel(int id, string name, string email, string password, bool isAdmin)
        {
            UserId = id;
            UserName = name;
            UserEmail = email;
            UserPassword = password;
            IsAdmin = isAdmin;
        }
        public UserModel() { }
    }
}

