
using BaretProject.Domain.Commons;
using System.ComponentModel.DataAnnotations;

namespace BaretProject.Core.Domain
{
    public abstract class BaseEntity:Entity,IDateEntity
    {
        [Key]
        public int Id { get; set; }     
        public DateTime UpdateTime { get; set; }
        public DateTime? RemoveTime { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
    }
}