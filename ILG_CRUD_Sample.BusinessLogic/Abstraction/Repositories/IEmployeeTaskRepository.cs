using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ILG_CRUD_Sample.BusinessLogic.Abstraction.Repositories
{
    public interface IEmployeeTaskRepository<T>
    {
        Task<IEnumerable<T>> SelectAllAsync();
        Task<T> SelectByIdAsync(int nID);
        Task<bool> Insert(T oEmployee);
        Task<bool> UpdateByID(T oEmployee);
        Task<bool> DeleteByID(int nID);
    }
}
