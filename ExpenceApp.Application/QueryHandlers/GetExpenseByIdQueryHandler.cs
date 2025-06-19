using ExpenceApp.Application.DTOs;
using ExpenceApp.Application.Queries;
using ExpenceApp.Application.ServiceInterfaces;
using ExpenseApp.Domain.RepositoryInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceApp.Application.QueryHandlers
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseDto?>
    {
        private readonly IExpenseService _expenseService;

        public GetExpenseByIdQueryHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<ExpenseDto?> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _expenseService.GetExpenseByIdAsync(request.Id, request.UserId);
        }
    }
}
