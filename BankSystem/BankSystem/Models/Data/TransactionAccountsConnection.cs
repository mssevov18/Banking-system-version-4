using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("TransactionAccountsConnection")]
    [Index(nameof(TransactionId), nameof(SenderId), nameof(RecieverId), Name = "IX_TransactionAccountsConnection", IsUnique = true)]
    public partial class TransactionAccountsConnection
    {
        [Key]
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(RecieverId))]
        [InverseProperty(nameof(Account.TransactionAccountsConnectionRecievers))]
        public virtual Account Reciever { get; set; }
        [ForeignKey(nameof(SenderId))]
        [InverseProperty(nameof(Account.TransactionAccountsConnectionSenders))]
        public virtual Account Sender { get; set; }
        [ForeignKey(nameof(TransactionId))]
        [InverseProperty("TransactionAccountsConnections")]
        public virtual Transaction Transaction { get; set; }
    }
}
