
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using ILG_CRUD_Sample.BusinessLogic.Abstraction.Services;
using ILG_CRUD_Sample.BusinessLogic.ViewModels;

namespace ILG_CRUD_Sample.Web.Controllers
{
    public class EmployeesController : _ControllerBase<EmployeeSearchViewModel>
    {
        #region Controller Dependencies
        public IEmployeeService _employeeService { get; set; }
        public EmployeesController(IEmployeeService oEmployeeService)
        {
            _employeeService = oEmployeeService;
        }
        #endregion


        #region Search Actions
        [HttpPost]
        public ActionResult Search(EmployeeSearchViewModel oEmployeeSearchViewModel)
        {
            SearchViewModel = oEmployeeSearchViewModel;

            return RedirectToAction("Index");
        }

        public ActionResult Reset()
        {
            SearchViewModel = new EmployeeSearchViewModel();

            return RedirectToAction("Index");
        }

        #endregion

        public async Task<ActionResult> Index()
        {
            EmployeeSearchViewModel oEmployeeSearchViewModel = SearchViewModel;
            oEmployeeSearchViewModel.SearchResult = await _employeeService.SelectByCriteriaAsync(oEmployeeSearchViewModel);

            return View(oEmployeeSearchViewModel);
        }

        public async Task<ActionResult> Details(int id)
        {
            EmployeeViewModel oEmployeeViewModel = await _employeeService.SelectByIdAsync(id);
            return View(oEmployeeViewModel);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeViewModel oEmployeeViewModel)
        {
            await _employeeService.Insert(oEmployeeViewModel);
            // throw new Exception("ddd");
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult>  Edit(int id)
        {
            EmployeeViewModel oEmployeeViewModel = await _employeeService.SelectByIdAsync(id);

            return View(oEmployeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeeViewModel oEmployeeViewModel)
        {
            bool bEmployeeUpdated = await _employeeService.Update(oEmployeeViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            EmployeeViewModel oEmployeeViewModel = await _employeeService.SelectByIdAsync(id);

            return View(oEmployeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(EmployeeViewModel oEmployeeViewModel)
        {
            bool bEmployeeDeleted = await _employeeService.DeleteByID(oEmployeeViewModel.ID);

            return RedirectToAction(nameof(Index));
        }
    }
}
