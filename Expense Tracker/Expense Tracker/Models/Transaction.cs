using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; } //primary key

        //CategoryId
        public int CategoryId { get; set; }
        public Category Category { get; set; }



        public int Amount { get; set; } //transaction amount in dollar/taka

        [Column(TypeName = "nvarchar(75)")]
        public string? Note { get; set; } //write detail transation note.
                                          //?is for nullable datatype. 

        public DateTime Date { get; set; } = DateTime.Now; //transation time of a transaction 



    }
}