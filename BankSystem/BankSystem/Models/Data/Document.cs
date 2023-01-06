using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    public partial class Document
    {
        public Document()
        {
            RequestDocumentsConnections = new HashSet<RequestDocumentsConnection>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public byte[] Bytes { get; set; }
        [Required]
        [StringLength(15)]
        public string Extension { get; set; }
        public bool IsDeleted { get; set; }

        [InverseProperty(nameof(RequestDocumentsConnection.Document))]
        public virtual ICollection<RequestDocumentsConnection> RequestDocumentsConnections { get; set; }
    }
}
