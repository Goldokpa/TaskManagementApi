namespace TaskManagementAPI.Models
{
    public class TaskItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Category { get; set; }

        public bool IsCompleted { get; set; }

    }
}
