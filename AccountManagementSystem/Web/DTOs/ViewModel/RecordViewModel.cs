using System.ComponentModel.DataAnnotations;
using AccountManagementSystem.Domain.AccountManagementSystem;

namespace AccountManagementSystem.Web.DTOs.ViewModel;

public class RecordViewModel
{
    [Required(ErrorMessage = "Amount is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive number.")]
    public double Amount { get; set; }
    
    [Required(ErrorMessage = "Date is required.")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "Remark is required.")]
    [StringLength(50, ErrorMessage = "Remark cannot exceed 50 characters in length.")]
    public string Remark { get; set; }

    public static RecordViewModel DomainToViewModel(Record record)
    {
        return new RecordViewModel{Amount = record.Amount, Date = record.Date, Remark = record.Remark};
    }
}