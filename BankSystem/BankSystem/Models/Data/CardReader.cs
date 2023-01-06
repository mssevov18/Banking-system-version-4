using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DatabaseLibrary.Models.Data
{
    [Table("CardReader")]
    public partial class CardReader
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CardReaderAccountConnection IdNavigation { get; set; }
    }
}
