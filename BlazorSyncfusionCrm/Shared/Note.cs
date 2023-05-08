using System.ComponentModel.DataAnnotations;

namespace BlazorSyncfusionCrm.Shared
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public required string Text { get; set; } = string.Empty;
        public int? ContactId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public Contact? Contact { get; set; }

    }
}
