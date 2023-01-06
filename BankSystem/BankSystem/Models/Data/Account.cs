using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("Account")]
    [Index(nameof(Iban), Name = "IX_Account", IsUnique = true)]
    [Index(nameof(Email), Name = "IX_Account_1", IsUnique = true)]
    [Index(nameof(Username), Name = "IX_Account_2", IsUnique = true)]
    public partial class Account
    {
        public Account()
        {
            Cards = new HashSet<Card>();
            Requests = new HashSet<Request>();
            TransactionAccountsConnectionRecievers = new HashSet<TransactionAccountsConnection>();
            TransactionAccountsConnectionSenders = new HashSet<TransactionAccountsConnection>();
        }

        [Key]
        public int Id { get; set; }
        public int PersonId { get; set; }
        [Required]
        [Column("IBAN")]
        [StringLength(34)]
        public string Iban { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(256)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CardReaderAccountConnection IdNavigation { get; set; }
        [ForeignKey(nameof(PersonId))]
        [InverseProperty("Accounts")]
        public virtual Person Person { get; set; }
        [InverseProperty(nameof(Card.Holder))]
        public virtual ICollection<Card> Cards { get; set; }
        [InverseProperty(nameof(Request.Requester))]
        public virtual ICollection<Request> Requests { get; set; }
        [InverseProperty(nameof(TransactionAccountsConnection.Reciever))]
        public virtual ICollection<TransactionAccountsConnection> TransactionAccountsConnectionRecievers { get; set; }
        [InverseProperty(nameof(TransactionAccountsConnection.Sender))]
        public virtual ICollection<TransactionAccountsConnection> TransactionAccountsConnectionSenders { get; set; }
    }
}
