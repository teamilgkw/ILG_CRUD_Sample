using ILG_CRUD_Sample.BusinessLogic.Models;
using ILG_CRUD_Sample.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ILG_CRUD_Sample.BusinessLogic.Abstraction.Services
{
    public interface IEmployeeService
    {

        #region public functions
        Task<EmployeeViewModel> SelectByIdAsync(int nID);
        Task<IEnumerable<EmployeeViewModel>> SelectAllAsync();
        Task<IEnumerable<EmployeeViewModel>> SelectByCriteriaAsync(EmployeeSearchViewModel oEmployeeSearchViewModel);
        Task<bool> Insert(EmployeeViewModel oEntity);
        Task<bool> Update(EmployeeViewModel oEntity);
        Task<bool> DeleteByID(int nEntityID);
        #endregion

        #region data conversion
        List<EmployeeViewModel> lConvertToViewModels(IEnumerable<Employee> lEmployees);
        EmployeeViewModel oConvertToViewModel(Employee oEmployee);
        Employee oConvertToDataModel(EmployeeViewModel oEmployeeViewModel);
        #endregion

    }
}
