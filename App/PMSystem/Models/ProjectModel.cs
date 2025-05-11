

namespace Models
{
    public class ProjectModel
    {

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectMethodology { get; set; }


        public ICollection<TaskModel> Tasks { get; set; }
        public ICollection<ProjectUser> Users { get; set; }


    }
}
