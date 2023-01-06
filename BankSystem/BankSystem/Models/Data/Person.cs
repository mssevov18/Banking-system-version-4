using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("Person")]
    [Index(nameof(Egn), Name = "IX_Person", IsUnique = true)]
    public partial class Person
    {
        public Person()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [Column("EGN")]
        [StringLength(10)]
        public string Egn { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string Residence { get; set; }
        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty("Person")]
        public virtual BankWorker BankWorker { get; set; }
        [InverseProperty(nameof(Account.Person))]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
