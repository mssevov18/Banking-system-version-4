using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("BankWorker")]
    [Index(nameof(PersonId), Name = "IX_BankWorker", IsUnique = true)]
    [Index(nameof(Username), Name = "IX_BankWorker_1", IsUnique = true)]
    public partial class BankWorker
    {
        public BankWorker()
        {
            RequestReviewers = new HashSet<Request>();
            RequestSenders = new HashSet<Request>();
        }

        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(256)]
        public string Password { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("BankWorker")]
        public virtual Person Person { get; set; }
        [InverseProperty(nameof(Request.Reviewer))]
        public virtual ICollection<Request> RequestReviewers { get; set; }
        [InverseProperty(nameof(Request.Sender))]
        public virtual ICollection<Request> RequestSenders { get; set; }
    }
}
