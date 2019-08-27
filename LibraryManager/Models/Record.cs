using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryManager.Models
{
    public class Record
    {
        public int RecordId { get; set; }

        public int StudentId { get; set; }

        public int BookId { get;set; }

        public DateTime IssuedDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}