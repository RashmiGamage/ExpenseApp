using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }
}
