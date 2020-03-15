using System.ComponentModel.DataAnnotations;

namespace SalaryCalculator.Domain
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
