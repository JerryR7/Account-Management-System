namespace AccountManagementSystem.Web.DTOs.ViewModel;

public class RecordIndexViewModel
{
    public RecordViewModel? Record { get; set; }
    public IEnumerable<RecordViewModel> Records { get; set; }
}
