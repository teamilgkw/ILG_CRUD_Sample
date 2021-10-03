using ILG_CRUD_Sample.BusinessLogic.Models;
using ILG_CRUD_Sample.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ILG_CRUD_Sample.BusinessLogic.Abstraction.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> SelectAllAsync();
        Task<IEnumerable<Employee>> SelectByCriteriaAsync(EmployeeSearchViewModel oEmployeeSearchViewModel);
        Task<Employee> SelectByIdAsync(int nID);
        Task<bool> Insert(Employee oEmployee);
        Task<bool> Update(Employee oEmployee);
        Task<bool> DeleteByID(int nID);
    }
}
