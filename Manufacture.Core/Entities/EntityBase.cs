using System.ComponentModel.DataAnnotations;

namespace Manufacture.Core.Entities
{
    public abstract class EntityBase
    {
        [Key] public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}