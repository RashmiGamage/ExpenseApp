using ExpenceApp.Application.DTOs;
using ExpenseApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceApp.Application.ServiceInterfaces
{
    public interface IExpenseService
    {
        Task<int> CreateExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(int id, string userId);
        Task<ExpenseDto?> GetExpenseByIdAsync(int id, string userId);
        Task<List<ExpenseDto>> GetExpensesByMonthAsync(DateTime month, string userId);
    }
}
