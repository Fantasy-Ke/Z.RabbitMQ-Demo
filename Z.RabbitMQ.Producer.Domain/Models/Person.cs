using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Z.RabbitMQ.Producer.Domain.Models
{
    public class Person
    {
        /// <summary>
        /// 自动生成id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "最大长度100", MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "最大长度100", MinimumLength = 1)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
