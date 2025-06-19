using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceApp.Application.Commands
{
    public class DeleteExpenseCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public DeleteExpenseCommand(int id, string userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
