
using BaretProject.Domain.Commons;

namespace BaretProject.Core.Domain
{
    public abstract class BaseEntity:Entity,IDateEntity
    {
        public int Id { get; set; }     
        public DateTime UpdateTime { get; set; }
        public DateTime? RemoveTime { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
    }
}