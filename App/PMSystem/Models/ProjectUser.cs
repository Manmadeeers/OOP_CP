

namespace Models
{
    public class ProjectUser
    {

        public int ProjectId { get; set; }  
        public ProjectModel Project { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }


        public ProjectUser() { }
        public ProjectUser(int ProjectId,int UserId)
        {
            this.ProjectId = ProjectId;
            this.UserId = UserId;   
        }

    }
}
