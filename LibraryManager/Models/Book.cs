using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LibraryManager.Models
{
    [Table("college_books")]
    public class Book
    {
        [Key]
        [Column("book_id")]
        [Display(Name ="ISBN ID",Prompt ="ISBN ID")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="ISBN ID should be of 10 characters")]
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [StringLength(30,MinimumLength =10,ErrorMessage ="Enter valid book name")]
        public string Name { get; set; }

        [Column("category_id")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [DataType(DataType.Date)]
        [Column("buy_date")]
        [DateValidation("2017/01/01")]
        public string Date { get; set; }
    }

    public class DateValidation:ValidationAttribute
    {
        private object oldestBuyDate { get; set; }

        public DateValidation(object minDate):this("Book cannot be bought before {0}")
        {
            oldestBuyDate = minDate;

        }

        private DateValidation(string errorMsg)
        {
            base.ErrorMessage = errorMsg;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (((DateTime)value) < (DateTime)oldestBuyDate)
            {
                return new ValidationResult(string.Format(CultureInfo.InvariantCulture, this.ErrorMessage, ((DateTime)value).ToShortDateString()));
            }
            else
                return ValidationResult.Success;
        }
    }
}