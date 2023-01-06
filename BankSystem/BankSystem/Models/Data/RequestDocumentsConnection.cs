using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("RequestDocumentsConnection")]
    public partial class RequestDocumentsConnection
    {
        [Key]
        public int Id { get; set; }
        public int RequestId { get; set; }
        public int DocumentId { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(DocumentId))]
        [InverseProperty("RequestDocumentsConnections")]
        public virtual Document Document { get; set; }
        [ForeignKey(nameof(RequestId))]
        [InverseProperty("RequestDocumentsConnections")]
        public virtual Request Request { get; set; }
    }
}
