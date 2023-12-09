using  AccountManagementSystem.App.Outport;
using AccountManagementSystem.Domain.AccountManagementSystem;

namespace AccountManagementSystem.Web.Repositories;

public class WebRecordRepository : IRecordRepository
{
    private static readonly List<Record> Records = new();

    public void Save(Record record)
    {
        Records.Add(record);
    }

    public IEnumerable<Record> GetAllRecords()
    {
        return Records;
    }
}