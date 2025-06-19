using ExpenceApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceApp.Application.Queries
{
    public class GetExpenseByIdQuery : IRequest<ExpenseDto?>
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public GetExpenseByIdQuery(int id, string userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
