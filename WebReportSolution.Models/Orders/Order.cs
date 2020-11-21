using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebReportSolution.Models.Base;

namespace WebReportSolution.Models.Orders
{
    [Table("Order")]
    public class Order : DomainObject
    {
        [Key]
        [Column("Id")]
        public override Guid Id { get; set; }

        [Required]
        [Column("Price")]
        public int Price { get; set; }

        [Required]
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}