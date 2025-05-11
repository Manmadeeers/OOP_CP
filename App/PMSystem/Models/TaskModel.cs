

namespace Models
{
    public class TaskModel
    {

        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskStatus { get; set; }
        public string TaskDescription { get; set; }
        public string Notes { get;set; }

        public int ProjectId { get; set; }
        public ProjectModel Project { get; set; }
        public int UserId { get;set; }
        public UserModel User { get; set; }

    }
}
