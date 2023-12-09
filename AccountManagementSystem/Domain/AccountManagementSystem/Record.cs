namespace AccountManagementSystem.Domain.AccountManagementSystem;

public class Record
{
    private static readonly List<string> ValidTypes = new() { "Payment", "Refund" };

    private string _type = null!;

    public double Amount { get; private set; }

    public DateTime Date { get; private set; }

    public string Remark { get; private set; }
    
    public string Type
    {
        get => _type;
        private set
        {
            if (!IsValidType(value))
                throw new ArgumentException("Invalid record type.");
            _type = value;
        }
    }

    public Record(double amount, DateTime date, string remark, string type = "Payment")
    {
        Amount = amount;
        Date = date;
        Remark = remark;
        Type = type;

        ValidateBusinessRules();
    }
    
    private void ValidateBusinessRules()
    {
        if (Type == "Refund" && Amount > 1000) 
        {
            throw new InvalidOperationException("Refund amount cannot exceed 1000.");
        }

        if (Date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
        {
            throw new InvalidOperationException("Record date cannot be on weekends.");
        }
    }

    private static bool IsValidType(string type)
    {
        return ValidTypes.Contains(type);
    }


    protected void UpdateAmount(double newAmount)
    {
        Amount = newAmount;
    }

    protected void UpdateDate(DateTime newDate)
    {
        Date = newDate;
    }

    protected void UpdateRemark(string newRemark)
    {
        Remark = newRemark;
    }
}