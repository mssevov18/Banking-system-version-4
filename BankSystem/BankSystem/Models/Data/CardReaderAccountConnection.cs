using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("CardReaderAccountConnection")]
    [Index(nameof(RecieverId), Name = "IX_CardReaderAccountConnection", IsUnique = true)]
    [Index(nameof(CardReaderId), Name = "IX_CardReaderAccountConnection_1", IsUnique = true)]
    public partial class CardReaderAccountConnection
    {
        [Key]
        public int Id { get; set; }
        public int CardReaderId { get; set; }
        public int RecieverId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Account Account { get; set; }
        public virtual CardReader CardReader { get; set; }
    }
}
