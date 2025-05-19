using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class TaskModel
    {

        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public string TaskDescription { get; set; }
        public string Notes { get;set; }

        public int ProjectId { get; set; }
        public ProjectModel Project { get; set; }
        public int UserId { get;set; }
        public UserModel User { get; set; }


        public TaskModel(string TaskName,string TaskStatus,string TaskDescription,string Notes,int ProjectId,int UserId)
        {
            this.TaskName = TaskName;
            this.TaskStatus = TaskStatus;
            this.TaskDescription = TaskDescription;
            this.Notes = Notes;
            this.ProjectId = ProjectId;
            this.UserId = UserId;
        }

    }
}
