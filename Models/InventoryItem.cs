using System.ComponentModel.DataAnnotations;

namespace InventoryService.Models
{
    public class InventoryItem
    {
        [Key]
        public Guid ItemId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(150)]
        public string ItemName { get; set; }

        [StringLength(100)]
        public string? Category { get; set; }

        [Required]
        public int Quantity { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}