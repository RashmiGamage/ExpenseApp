using ExpenceApp.Application.Commands;
using ExpenceApp.Application.DTOs;
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
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, Unit>
    {
        private readonly IExpenseService _expenseService;


        public UpdateExpenseCommandHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<Unit> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            await _expenseService.UpdateExpenseAsync(new Expense
            {
                Id = request.Id,
                Description = request.Description,
                Amount = request.Amount,
                Date = request.Date,
                UserId = request.UserId
            });

            return Unit.Value;
        }
    }
}
