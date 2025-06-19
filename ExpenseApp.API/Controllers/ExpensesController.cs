using ExpenceApp.Application.Commands;
using ExpenceApp.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private string GetCurrentUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        //private int GetCurrentUserId() => 1;


        [HttpPost]
        public async Task<IActionResult> Create(CreateExpenseCommand command)
        {
            command.UserId = GetCurrentUserId();
            var id = await _mediator.Send(command);
            return Ok(new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetByMonth([FromQuery] DateTime month)
        {
            return Ok(await _mediator.Send(new GetExpensesByMonthQuery(month, GetCurrentUserId())));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var expense = await _mediator.Send(new GetExpenseByIdQuery(id, GetCurrentUserId()));
            return expense == null ? NotFound() : Ok(expense);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateExpenseCommand command)
        {
            command.Id = id;
            command.UserId = GetCurrentUserId();
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteExpenseCommand(id, GetCurrentUserId()));
            return NoContent();
        }
    }
}
