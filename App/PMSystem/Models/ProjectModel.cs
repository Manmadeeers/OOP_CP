

using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ProjectModel
    {

        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectMethodology { get; set; }


        public ICollection<TaskModel> Tasks { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }


    }
}
