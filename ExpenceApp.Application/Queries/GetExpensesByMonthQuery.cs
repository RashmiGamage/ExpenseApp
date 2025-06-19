using ExpenceApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceApp.Application.Queries
{
    public class GetExpensesByMonthQuery : IRequest<List<ExpenseDto>>
    {
        public DateTime Month { get; set; }
        public string UserId { get; set; }

        public GetExpensesByMonthQuery(DateTime month, string userId)
        {
            Month = month;
            UserId = userId;
        }
    }
}
