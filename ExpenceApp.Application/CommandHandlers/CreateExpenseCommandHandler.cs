using ExpenceApp.Application.Commands;
using ExpenceApp.Application.ServiceInterfaces;
using ExpenseApp.Domain.Entities;
using ExpenseApp.Domain.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceApp.Application.CommandHandlers
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, int>
    {
        private readonly IExpenseService _expenseService;

        public CreateExpenseCommandHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<int> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = new Expense
            {
                Description = request.Description,
                Amount = request.Amount,
                Date = request.Date,
                UserId = request.UserId
            };

            await _expenseService.CreateExpenseAsync(expense);
            return expense.Id;
        }
    }
}
