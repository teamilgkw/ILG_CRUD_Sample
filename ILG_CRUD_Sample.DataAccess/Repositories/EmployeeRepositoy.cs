using ILG_CRUD_Sample.BusinessLogic.Abstraction.Repositories;
using ILG_CRUD_Sample.BusinessLogic.Models;
using ILG_CRUD_Sample.BusinessLogic.ViewModels;
using ILG_CRUD_Sample.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG_CRUD_Sample.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ILG_CRUD_SampleContext ILG_CRUD_SampleContext;

        public EmployeeRepository(ILG_CRUD_SampleContext oILG_CRUD_SampleContext)
        {
            ILG_CRUD_SampleContext = oILG_CRUD_SampleContext;
        }

        public async Task<IEnumerable<Employee>> SelectAllAsync()
        {
            List<Employee> lEmployees = new List<Employee>();

            try
            {
               lEmployees = await ILG_CRUD_SampleContext.Employees.ToListAsync();
            }
            catch (Exception)
            {

            }

            return  lEmployees;
        }

        public async Task<IEnumerable<Employee>> SelectByCriteriaAsync(EmployeeSearchViewModel oEmployeeSearchViewModel)
        {

            IQueryable<Employee> oIQueryable = ILG_CRUD_SampleContext.Employees.AsQueryable();

            if (oEmployeeSearchViewModel != null)
            {
                if (!string.IsNullOrEmpty(oEmployeeSearchViewModel.Name))
                {
                    oIQueryable = oIQueryable.Where(e => e.Name.Contains(oEmployeeSearchViewModel.Name));
                }

                if (!string.IsNullOrEmpty(oEmployeeSearchViewModel.Email))
                {
                    oIQueryable = oIQueryable.Where(e => e.Email.Contains(oEmployeeSearchViewModel.Email));
                }

                if (oEmployeeSearchViewModel.AgeFrom.HasValue)
                {
                    oIQueryable = oIQueryable.Where(e => e.Age > oEmployeeSearchViewModel.AgeFrom);
                }

                if (oEmployeeSearchViewModel.AgeTo.HasValue)
                {
                    oIQueryable = oIQueryable.Where(e => e.Age < oEmployeeSearchViewModel.AgeTo);
                }

                if (oEmployeeSearchViewModel.BirthDateFrom.HasValue)
                {
                    oIQueryable = oIQueryable.Where(e => e.BirthDate > oEmployeeSearchViewModel.BirthDateFrom);
                }

                if (oEmployeeSearchViewModel.BirthDateTo.HasValue)
                {
                    oIQueryable = oIQueryable.Where(e => e.BirthDate < oEmployeeSearchViewModel.BirthDateTo);
                }
            }

            return await oIQueryable.ToListAsync();
        }

        public async Task<Employee> SelectByIdAsync(int nID)
        {
            Employee oEmployee = new Employee();

            try
            {
                oEmployee = await ILG_CRUD_SampleContext.Employees.FirstOrDefaultAsync(m=>m.ID == nID);
            }
            catch (Exception oException)
            {

            }

            return oEmployee;
        }

        public async Task<bool> Insert(Employee oEmployee)
        {
            try
            {
                ILG_CRUD_SampleContext.Employees.Add(oEmployee);
                ILG_CRUD_SampleContext.SaveChanges();
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Employee oEmployee)
        {
            try
            {
                ILG_CRUD_SampleContext.Entry(oEmployee).State = EntityState.Modified;
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
                Employee oEmployee = ILG_CRUD_SampleContext.Employees.Find(nID);

                ILG_CRUD_SampleContext.Employees.Remove(oEmployee);
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
