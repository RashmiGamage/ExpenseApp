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
    public class GetExpensesByMonthQueryHandler : IRequestHandler<GetExpensesByMonthQuery, List<ExpenseDto>>
    {
        private readonly IExpenseService _expenseService;

        public GetExpensesByMonthQueryHandler(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        public async Task<List<ExpenseDto>> Handle(GetExpensesByMonthQuery request, CancellationToken cancellationToken)
        {
            return await _expenseService.GetExpensesByMonthAsync(request.Month, request.UserId);
        }
    }
}
