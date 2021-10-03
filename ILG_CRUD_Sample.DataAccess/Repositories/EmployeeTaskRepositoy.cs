using ILG_CRUD_Sample.BusinessLogic.Abstraction.Repositories;
using ILG_CRUD_Sample.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ILG_CRUD_Sample.DataAccess.Repositories
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository<EmployeeTask>
    {
        ILG_CRUD_SampleContext ILG_CRUD_SampleContext;

        public EmployeeTaskRepository(ILG_CRUD_SampleContext oILG_CRUD_SampleContext)
        {
            ILG_CRUD_SampleContext = oILG_CRUD_SampleContext;
        }

        public async Task<IEnumerable<EmployeeTask>> SelectAllAsync()
        {
            List<EmployeeTask> lEmployeeTasks = new List<EmployeeTask>();

            try
            {
               lEmployeeTasks = await ILG_CRUD_SampleContext.EmployeeTasks.ToListAsync();
            }
            catch (Exception)
            {
            }

            return  lEmployeeTasks;
        }

        public async Task<EmployeeTask> SelectByIdAsync(int nID)
        {
            EmployeeTask oEmployeeTask = new EmployeeTask();

            try
            {
                oEmployeeTask = await ILG_CRUD_SampleContext.EmployeeTasks.FirstOrDefaultAsync(m=>m.ID == nID);
            }
            catch (Exception)
            {
            }

            return oEmployeeTask;
        }

        public async Task<bool> Insert(EmployeeTask oEmployeeTask)
        {
            try
            {
                ILG_CRUD_SampleContext.EmployeeTasks.Add(oEmployeeTask);
                ILG_CRUD_SampleContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateByID(EmployeeTask oEmployeeTask)
        {
            try
            {
                ILG_CRUD_SampleContext.Entry(oEmployeeTask).State = EntityState.Modified;
                ILG_CRUD_SampleContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteByID(int nID)
        {
            try
            {
                EmployeeTask oEmployeeTask = ILG_CRUD_SampleContext.EmployeeTasks.Find(nID);

                ILG_CRUD_SampleContext.EmployeeTasks.Remove(oEmployeeTask);
                ILG_CRUD_SampleContext.SaveChanges();

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
