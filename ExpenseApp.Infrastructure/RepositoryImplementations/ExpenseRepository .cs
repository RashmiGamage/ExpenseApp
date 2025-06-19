using ExpenseApp.Domain.Entities;
using ExpenseApp.Domain.RepositoryInterfaces;
using ExpenseApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Infrastructure.RepositoryImplementations
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;
        public ExpenseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Expense>> GetByMonthAsync(DateTime month, string userId)
        {
            return await _context.Expenses
                .Where(e => e.Date.Month == month.Month &&
                            e.Date.Year == month.Year &&
                            e.UserId == userId)
                .ToListAsync();
        }

        public async Task<Expense?> GetByIdAsync(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task AddAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expense expense)
        {
            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expense expense)
        {
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
        }
    }
}
