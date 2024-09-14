using Application.BakeryProduct.Commands.CreateBakeryProduct;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Admin
{
	public class AdminController : BaseController
	{
		[HttpPost("BakeryProduct")] // attribute specifies that this method will handle HTTP POST requests sent to the BakeryProduct endpoint.
		[Produces("application/json")] //attribute indicates that this method will return JSON-formatted responses.
		[ProducesResponseType(StatusCodes.Status200OK)]

		//This method is an asynchronous task that takes a CreateBakeryProductCommand object as a parameter.
		//It uses the Mediator to send the command and returns the result wrapped in an ActionResult<int>.
		public async Task<ActionResult<int>> CreateBakeryProduct(CreateBakeryProductCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		//[HttpGet("{id}")]

	}
}
