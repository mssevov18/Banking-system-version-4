using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("Request")]
    public partial class Request
    {
        public Request()
        {
            RequestDocumentsConnections = new HashSet<RequestDocumentsConnection>();
        }

        [Key]
        public int Id { get; set; }
        public int? RequesterId { get; set; }
        public int SenderId { get; set; }
        public int ReviewerId { get; set; }
        public DateTime Timestamp { get; set; }
        public bool? IsPermitted { get; set; }
        [Required]
        public string TableAffected { get; set; }
        [Required]
        public string Arguments { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(RequesterId))]
        [InverseProperty(nameof(Account.Requests))]
        public virtual Account Requester { get; set; }
        [ForeignKey(nameof(ReviewerId))]
        [InverseProperty(nameof(BankWorker.RequestReviewers))]
        public virtual BankWorker Reviewer { get; set; }
        [ForeignKey(nameof(SenderId))]
        [InverseProperty(nameof(BankWorker.RequestSenders))]
        public virtual BankWorker Sender { get; set; }
        [InverseProperty(nameof(RequestDocumentsConnection.Request))]
        public virtual ICollection<RequestDocumentsConnection> RequestDocumentsConnections { get; set; }
    }
}
