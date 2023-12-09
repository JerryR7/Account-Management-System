using AccountManagementSystem.Domain.AccountManagementSystem;

namespace AccountManagementSystem.App.Outport;

public interface IRecordRepository
{ 
    void Save(Record record);
    IEnumerable<Record> GetAllRecords();
}