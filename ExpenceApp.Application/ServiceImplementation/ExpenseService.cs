using ExpenceApp.Application.DTOs;
using ExpenceApp.Application.ServiceInterfaces;
using ExpenseApp.Domain.Entities;
using ExpenseApp.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceApp.Application.ServiceImplementation
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;

        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateExpenseAsync(Expense expense)
        {
            await _repository.AddAsync(expense);
            return expense.Id;
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            var ExistingExpense = await _repository.GetByIdAsync(expense.Id);
            if (ExistingExpense == null)
                throw new KeyNotFoundException("Expense not found.");

            if (ExistingExpense.UserId != expense.UserId)
                throw new UnauthorizedAccessException("You are not allowed to update this expense.");

            expense.Description = expense.Description;
            expense.Amount = expense.Amount;
            expense.Date = expense.Date;

            await _repository.UpdateAsync(ExistingExpense);
        }

        public async Task DeleteExpenseAsync(int id, string userId)
        {
            var expense = await _repository.GetByIdAsync(id);
            if (expense == null || expense.UserId != userId)
                throw new UnauthorizedAccessException();

            await _repository.DeleteAsync(expense);
        }

        public async Task<ExpenseDto?> GetExpenseByIdAsync(int id, string userId)
        {
            //var expense = await _repository.GetByIdAsync(id);
            //return expense?.UserId == userId ? expense : null;
            var expense = await _repository.GetByIdAsync(id);

            if (expense == null || expense.UserId != userId)
                return null;

            return new ExpenseDto
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date
            };
        }

        public async Task<List<ExpenseDto>> GetExpensesByMonthAsync(DateTime month, string userId)
        {
            var expenses = await _repository.GetByMonthAsync(month, userId);
            return expenses.Select(e => new ExpenseDto
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                Date = e.Date
            }).ToList();
        }
    }
}
