using ILG_CRUD_Sample.BusinessLogic.Abstraction.Repositories;
using ILG_CRUD_Sample.BusinessLogic.Abstraction.Services;
using ILG_CRUD_Sample.BusinessLogic.Models;
using ILG_CRUD_Sample.BusinessLogic.ViewModels;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_CRUD_Sample.Web.Services
{
    public class EmployeesService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeesService(IEmployeeRepository oEmployeeRepository)
        {
            _employeeRepository = oEmployeeRepository;
        }

        #region public functions
        public async Task<EmployeeViewModel> SelectByIdAsync(int nID)
        {
            Employee oEmployee = await _employeeRepository.SelectByIdAsync(nID);

            EmployeeViewModel oEmployeeViewModel = oConvertToViewModel(oEmployee);

            return oEmployeeViewModel;
        }

        public async Task<IEnumerable<EmployeeViewModel>> SelectAllAsync()
        {
            IEnumerable<Employee> lEmployees = await _employeeRepository.SelectAllAsync();

            List<EmployeeViewModel>  lEmployeeViewModels = lConvertToViewModels(lEmployees);

            return lEmployeeViewModels;
        }

        public async Task<IEnumerable<EmployeeViewModel>> SelectByCriteriaAsync(EmployeeSearchViewModel oEmployeeSearchViewModel)
        {
            IEnumerable<Employee> lEmployees = await _employeeRepository.SelectByCriteriaAsync(oEmployeeSearchViewModel);

            List<EmployeeViewModel> lEmployeeViewModels = lConvertToViewModels(lEmployees);

            return lEmployeeViewModels;
        }

        public async Task<bool> Insert(EmployeeViewModel oEntity)
        {
            Employee oEmployee = oConvertToDataModel(oEntity);

            bool bEmployeeInserted = await _employeeRepository.Insert(oEmployee);

            return bEmployeeInserted;
        }

        public async Task<bool> Update(EmployeeViewModel oEntity)
        {
            Employee oEmployee = oConvertToDataModel(oEntity);

            bool bEmployeeUpdated = await _employeeRepository.Update(oEmployee);

            return bEmployeeUpdated;
        }

        public async Task<bool> DeleteByID(int nEntityID)
        {
            bool bEmployeeDeleted = await _employeeRepository.DeleteByID(nEntityID);

            return bEmployeeDeleted;
        }

        #endregion

        #region data conversion

        public List<EmployeeViewModel> lConvertToViewModels(IEnumerable<Employee> lEmployees)
        {
            List<EmployeeViewModel> lEmployeeViewModels = new List<EmployeeViewModel>();
            EmployeeViewModel oEmployeeViewModel;

            if (lEmployees.Any()) 
            {
                foreach (Employee oEmployee in lEmployees)
                {
                    oEmployeeViewModel = oConvertToViewModel(oEmployee);
                    lEmployeeViewModels.Add(oEmployeeViewModel);
                }
            }

            return lEmployeeViewModels;
        }

        public EmployeeViewModel oConvertToViewModel(Employee oTDataModel)
        {
            EmployeeViewModel oEmployeeViewModel = new EmployeeViewModel();

            oEmployeeViewModel.ID = oTDataModel.ID;
            oEmployeeViewModel.Name = oTDataModel.Name;
            oEmployeeViewModel.Email = oTDataModel.Email;
            oEmployeeViewModel.Age = oTDataModel.Age;
            oEmployeeViewModel.BirthDate = oTDataModel.BirthDate;

            return oEmployeeViewModel;
        }

        public  Employee oConvertToDataModel(EmployeeViewModel oEmployeeViewModel)
        {
            Employee oEmployee = new Employee();

            oEmployee.ID = oEmployeeViewModel.ID;
            oEmployee.Name = oEmployeeViewModel.Name;
            oEmployee.Email = oEmployeeViewModel.Email;
            oEmployee.Age = oEmployeeViewModel.Age;
            oEmployee.BirthDate = oEmployeeViewModel.BirthDate;

            return oEmployee;
        }

        #endregion
    }
}
