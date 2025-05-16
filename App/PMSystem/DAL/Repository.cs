
using Models;

namespace DAL
{
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Completed
    }
    interface IRepository:IDisposable
    {
        //All methods for User
        public List<UserModel> GetAllUsers();
        public List<UserModel> GetUsersWithRole(string role);
        public UserModel?GetUserById(int id);
        public bool AddUser(UserModel user);
        public bool DeleteUser(int id);
        public bool UpdateUser(UserModel updUSer, int id);
        public List<TaskModel>GetAllTasksByUserId(int id);
        public List<ProjectModel> GetAllProjectsByUserId(int id);

        public List<TaskModel> GetAllUsersCompletedTasks(int userId);
        public List<TaskModel>GetAllUsersInProgressTasks(int userId);

        public List<TaskModel>GetAllUsersNotStartedTasks(int userId);
        //All methods for Task
        public List<TaskModel> GetAllTasks();
        public UserModel?GetUserAssignedOnTask(int userId);
        public bool AddTask(TaskModel task);
        public bool UpdateTask(TaskModel updTask,int id);
        public bool DeleteTask(int id);

        //all methods for projects
        public bool AddProject(ProjectModel project);

        public bool UpdateProject(ProjectModel updProject,int id);

        public bool DeleteProject(int id);

        public List<ProjectModel> GetAllProjects();
    }


    public class Repository:IRepository
    {

        Context _context;
        public Repository(Context context) { this._context = context; }

        //get all users as a list of users
        public List<UserModel> GetAllUsers() { return this._context.Users.ToList<UserModel>(); }
        //get user by id or null if there's no such user
        public UserModel?GetUserById(int id) { return this._context.Users.FirstOrDefault(u => u.UserId == id); }


        public List<UserModel>GetUsersWithRole(string role)
        {
            return this._context.Users.Where(u=>u.UserRole== role).ToList();
        }

        //add a user(for admin)
        public bool AddUser(UserModel user)
        {
            if(this._context.Users.Add(user) is not null)
            {
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete a user(for admin)
        public bool DeleteUser(int id)
        {
            UserModel? userToDelete = this._context.Users.FirstOrDefault(u => u.UserId == id);
            if(userToDelete is not null)
            {
                this._context.Users.Remove(userToDelete);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //update a user(for admin)
        public bool UpdateUser(UserModel updUSer,int id)
        {
            UserModel? UserToUpdate = this._context.Users.FirstOrDefault(u => u.UserId == id);
            if(UserToUpdate is not null)
            {
                UserToUpdate.UserRole = updUSer.UserRole;
                UserToUpdate.UserEmail = updUSer.UserEmail;
                UserToUpdate.UserName = updUSer.UserName;
                UserToUpdate.UserPassword = updUSer.UserPassword;
                UserToUpdate.IsAdmin = updUSer.IsAdmin;
                this._context.Users.Update(UserToUpdate);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //get all tasks assigned to a user
        public List<TaskModel>GetAllTasksByUserId(int id)
        {
            return this._context.Tasks.Where(t=>t.UserId == id).ToList();
        }

        //get all projects assigned to a user
        public List<ProjectModel> GetAllProjectsByUserId(int id)
        {
            return this._context.ProjectUsers.Where(pu => pu.UserId == id).Select(pu => pu.Project).ToList();
        }
        //get all completed tasks for a user
        public List<TaskModel> GetAllUsersCompletedTasks(int userId)
        {
            return this._context.Tasks.Where(t => t.TaskStatus == "Completed").ToList();
        }
        //get all "In Progress" tasks for a user
        public List<TaskModel> GetAllUsersInProgressTasks(int userId)
        {
            return this._context.Tasks.Where(t => t.TaskStatus == "In Progress").ToList();
        }
        //get all "Not Started" tasks for a user
        public List<TaskModel> GetAllUsersNotStartedTasks(int userId)
        {
            return this._context.Tasks.Where(t => t.TaskStatus == "Not Started").ToList();
        }

        //get all tasks as a list
        public List<TaskModel> GetAllTasks()
        {
            return this._context.Tasks.ToList();
        }

        //get a user who's responsible for a task
        public UserModel? GetUserAssignedOnTask(int taskId)
        {
            return this._context.Users.Where(u=>u.UserId == taskId).FirstOrDefault();
        }
        
        //add a task
        public bool AddTask(TaskModel task)
        {
            if(this._context.Tasks.Add(task) is not null)
            {
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTask(TaskModel updTask, int id)
        {
            TaskModel?taskToUpdate = this._context.Tasks.FirstOrDefault(t=>t.TaskId == id);
            if(taskToUpdate is not null)
            {
                taskToUpdate.TaskName = updTask.TaskName;
                taskToUpdate.TaskId = updTask.TaskId;
                taskToUpdate.UserId = updTask.UserId;
                taskToUpdate.Notes = updTask.Notes;
                taskToUpdate.ProjectId = updTask.ProjectId;
                taskToUpdate.TaskStatus = updTask.TaskStatus;
                taskToUpdate.TaskDescription = updTask.TaskDescription;
                this._context.Tasks.Update(taskToUpdate);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteTask(int id)
        {
            TaskModel?taskToDelete = this._context.Tasks.FirstOrDefault(t=>t.TaskId == id);
            if(taskToDelete is not null)
            {
                this._context.Tasks.Remove(taskToDelete);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false; 
            }
        }


        public bool AddProject(ProjectModel project)
        {
            if (this._context.Projects.Add(project) is not null)
            {
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateProject(ProjectModel updProject, int id)
        {
            ProjectModel? projectToUpdate = this._context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if(projectToUpdate is not null)
            {
                projectToUpdate.ProjectId = id;
                projectToUpdate.ProjectName = updProject.ProjectName;
                projectToUpdate.ProjectMethodology = updProject.ProjectMethodology;
                this._context.Update(projectToUpdate);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteProject(int id)
        {
            ProjectModel? projToDelete = this._context.Projects.FirstOrDefault(p => p.ProjectId == id);
            if(projToDelete is not null)
            {
                this._context.Projects.Remove(projToDelete);
                this._context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ProjectModel> GetAllProjects()
        {
            return this._context.Projects.ToList();
        }
        public void Dispose() { }

    }
}
