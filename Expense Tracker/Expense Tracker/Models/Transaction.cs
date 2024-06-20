using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; } //primary key

        //CategoryId
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")] //validation message for invalid input, have to select a icon.
        public int CategoryId { get; set; }
        public Category? Category { get; set; }



        public int Amount { get; set; } //transaction amount in dollar/taka
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")] //the ammount must be greater than 0
        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; } //write detail transation note.
                                          //?is for nullable datatype. 

        public DateTime Date { get; set; } = DateTime.Now; //transation time of a transaction 



        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }

        //handle negative and positive ammount of money
        [NotMapped]
        public string? FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense") ? "- " : "+ ") + Amount.ToString("C0");
            }
        }




    }
}