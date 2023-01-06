using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("Transaction")]
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionAccountsConnections = new HashSet<TransactionAccountsConnection>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }
        [Required]
        [Column(TypeName = "ntext")]
        public string Reason { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(TransactionAccountsConnection.Transaction))]
        public virtual ICollection<TransactionAccountsConnection> TransactionAccountsConnections { get; set; }
    }
}
