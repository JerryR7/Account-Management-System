using AccountManagementSystem.Domain.AccountManagementSystem;

namespace AccountManagementSystem.Web.DTOs.API;

public class RecordDto
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Remark { get; set; }

    public static RecordDto DomainToDto(Record record)
    {
        return new RecordDto { Amount = (decimal)record.Amount, Date = record.Date, Remark = record.Remark };
    }
}