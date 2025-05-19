

using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProjectModel
    {

        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectMethodology { get; set; }

        public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
        public ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();


        public ProjectModel() { }
        public ProjectModel(string ProjectName,string ProjectMethodology)
        {
            this.ProjectName = ProjectName;
            this.ProjectMethodology = ProjectMethodology;
        }

        public override string ToString()
        {
            return this.ProjectName;
        }
    }
}
