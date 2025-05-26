
namespace SmartTasker.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; } // Low, Medium, High
        public bool IsDone { get; set; }
    }
}
