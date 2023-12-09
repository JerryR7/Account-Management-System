using AccountManagementSystem.App.UseCase;
using AccountManagementSystem.Web.DTOs;
using AccountManagementSystem.Web.DTOs.API;
using AccountManagementSystem.Web.DTOs.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AccountManagementSystem.Web.Controllers;

public class RecordsController : Controller
{
    private readonly GetAllRecordsUseCase _getAllRecordsUseCase;
    private readonly CreateRecordUseCase _createRecordUseCase;

    public RecordsController(GetAllRecordsUseCase getAllRecordsUseCase, CreateRecordUseCase createRecordUseCase)
    {
        _getAllRecordsUseCase = getAllRecordsUseCase;
        _createRecordUseCase = createRecordUseCase;
    }

    public IActionResult Index()
    {
        var viewModel = new RecordIndexViewModel
        {
            Records = _getAllRecordsUseCase.Execute().Select(RecordViewModel.DomainToViewModel)
        };

        return View("~/Web/Views/Index.cshtml", viewModel);
    }

    [HttpPost]
    public IActionResult Create(RecordViewModel recordViewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _createRecordUseCase.Execute(new CreateRecordUseCase.Input(recordViewModel.Amount, recordViewModel.Date,
                    recordViewModel.Remark));
                return RedirectToAction("Index");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
        }

        var viewModel = new RecordIndexViewModel
        {
            Record = recordViewModel,
            Records = _getAllRecordsUseCase.Execute().Select(RecordViewModel.DomainToViewModel)
        };

        return View("~/Web/Views/Index.cshtml", viewModel);
    }

    [HttpGet("api/records")]
    public IActionResult GetAllRecords()
    {
        var records = _getAllRecordsUseCase.Execute().Select(RecordDto.DomainToDto).ToList();

        return Ok(records);
    }
}