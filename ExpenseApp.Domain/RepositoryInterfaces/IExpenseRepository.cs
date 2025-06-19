using ExpenseApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Domain.RepositoryInterfaces
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetByMonthAsync(DateTime month, string userId);
        Task<Expense?> GetByIdAsync(int id);
        Task AddAsync(Expense expense);
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(Expense expense);
    }
}
