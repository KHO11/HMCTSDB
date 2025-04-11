using System.ComponentModel.DataAnnotations;

namespace HMCTS.TaskManagement.API.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
    }


}
