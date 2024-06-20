using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } //primary key

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Title is required.")] //form validation for 
        public string Title { get; set; }  //maybe for naming the expense

        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = "";  //this property is used for icons of category

        [Column(TypeName = "nvarchar(10)")]
        public string Type { get; set; } = "Expense";  //meaning type is income or expense.
                                                       //Most of the case it will be expense-type.By default type is "Expense."
                                                       //So initialized with default type="expense"

        [NotMapped]
        public string? TitleWithIcon
        {
            get
            {
                return this.Icon + " " + this.Title; // showing the icon with the list 
            }
        }



    }
}