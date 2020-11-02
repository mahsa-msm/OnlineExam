using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Domain.Core
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
