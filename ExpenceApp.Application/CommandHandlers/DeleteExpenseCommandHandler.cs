using ExpenceApp.Application.Commands;
using ExpenceApp.Application.ServiceInterfaces;
using ExpenseApp.Domain.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceApp.Application.CommandHandlers
{
    public class DeleteExpenseCommandHandler : IRequestHandler<DeleteExpenseCommand , Unit>
    {
        private readonly IExpenseService _expenseService;

        public DeleteExpenseCommandHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<Unit> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
        {
            await _expenseService.DeleteExpenseAsync(request.Id, request.UserId);
            return Unit.Value;
        }
    }
}
