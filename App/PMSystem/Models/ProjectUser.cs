

namespace Models
{
    public class ProjectUser
    {

        public int ProjectId { get; set; }  
        public ProjectModel Project { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }


    }
}
