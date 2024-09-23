using Application.BakeryProduct.Commands.CreateBakeryProduct;
using Application.BakeryProduct.Commands.DeleteBakeryProduct;
using Application.BakeryProduct.Commands.UpdateBakeryProduct;
using Application.BakeryProduct.Queries.GetBakeryProduct;
using Application.BakeryProduct.Queries.SearchBakeryProduct;
using Application.BakeryProduct.Queries.ViewModels;
using Application.Common.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Admin
{
	public class AdminController : BaseController
	{
		[HttpGet("{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BakeryProductViewModel>> GetEmergencyMessage(int id)
		{
			return Ok(await Mediator.Send(new GetBakeryProductQuery() { Id = id }));
		}

		[HttpPost("BakeryProduct")] // attribute specifies that this method will handle HTTP POST requests sent to the BakeryProduct endpoint.
		[Produces("application/json")] //attribute indicates that this method will return JSON-formatted responses.
		[ProducesResponseType(StatusCodes.Status200OK)]

		//This method is an asynchronous task that takes a CreateBakeryProductCommand object as a parameter.
		//It uses the Mediator to send the command and returns the result wrapped in an ActionResult<int>.
		public async Task<ActionResult<int>> CreateBakeryProduct(CreateBakeryProductCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		[HttpPatch("BakeryProduct/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> UpdateBakeryProduct(int id, UpdateBakeryProductCommand command)
		{
			command.SetBakeryProductId(id);
			return Ok(await Mediator.Send(command));
		}

		[HttpDelete("BakeryProduct/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> DeleteBakeryProduct(int id, DeleteBakeryProductCommand command)
		{
			return Ok(await Mediator.Send(new DeleteBakeryProductCommand() { Id = id }));
		}

		[HttpGet("EmergencyMessage/search")]
		[Produces("application/json")]
		[ProducesResponseType(200, Type = typeof(PagedResponseViewModel<BakeryProductViewModel>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> SearchEmergencyMessage([FromQuery] SearchBakeryProductQuery command)
		{
			return Ok(await Mediator.Send(command));
		}
	}
}
