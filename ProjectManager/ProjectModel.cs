using System.ComponentModel.DataAnnotations;

namespace ProjectManager
{
    public class ProjectModel
    {
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TaskItem> Tasks { get; set; } = new();
    }


    public class TaskItem
    {
        public int Id { get; set; }

        [Required] 
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; } 
        public int ProjectId { get; set; }
        public ProjectModel Project { get; set; }
    }

    public enum TaskStatus
    {
        ToDo,
        InProgres,
        Done
    }
}
