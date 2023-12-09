using AccountManagementSystem.App.Outport;
using AccountManagementSystem.Domain.AccountManagementSystem;

namespace AccountManagementSystem.App.UseCase;

public class CreateRecordUseCase
{
    private readonly IRecordRepository _recordRepository;

    public CreateRecordUseCase(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public void Execute(Input input)
    {
        var record = new Record(input.GetAmount(), input.GetDate(), input.GetRemark());
        _recordRepository.Save(record);
    }

    public class Input
    {
        private double Amount { get; }
        private DateTime Date { get; }
        private string Remark { get; }

        public Input(double amount, DateTime date, string remark)
        {
            Amount = amount;
            Date = date;
            Remark = remark;
        }

        public double GetAmount()
        {
            return Amount;
        }

        public DateTime GetDate()
        {
            return Date;
        }

        public string GetRemark()
        {
            return Remark;
        }
    }
}