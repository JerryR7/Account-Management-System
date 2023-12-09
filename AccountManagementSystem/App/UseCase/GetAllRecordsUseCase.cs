using AccountManagementSystem.App.Outport;
using AccountManagementSystem.Domain.AccountManagementSystem;

namespace AccountManagementSystem.App.UseCase;

public class GetAllRecordsUseCase
{ 
    private readonly IRecordRepository _recordRepository;

    public GetAllRecordsUseCase(IRecordRepository recordRepository)
    {
        _recordRepository = recordRepository;
    }

    public IEnumerable<Record> Execute()
    {
        return _recordRepository.GetAllRecords();
    }
}