using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("Card")]
    [Index(nameof(Number), Name = "IX_Card", IsUnique = true)]
    public partial class Card
    {
        [Key]
        public int Id { get; set; }
        public int HolderId { get; set; }
        [Required]
        [StringLength(16)]
        public string Number { get; set; }
        [Required]
        [Column("PIN")]
        [StringLength(256)]
        public string Pin { get; set; }
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpiresOn { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(HolderId))]
        [InverseProperty(nameof(Account.Cards))]
        public virtual Account Holder { get; set; }
    }
}
