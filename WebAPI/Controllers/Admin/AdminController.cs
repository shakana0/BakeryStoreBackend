using Application.BakeryCategory.Commands.CreateBakeryCategory;
using Application.BakeryCategory.Commands.DeleteBakeryCategory;
using Application.BakeryCategory.Commands.UpdateBakeryCategory;
using Application.BakeryCategory.Queries.GetBakeryCategory;
using Application.BakeryCategory.Queries.ViewModels;
using Application.BakeryIngredient.Commands.CreateBakeryIngredient;
using Application.BakeryIngredient.Commands.DeleteBakeryIngredient;
using Application.BakeryIngredient.Queries.GetBakeryIngredient;
using Application.BakeryIngredient.Queries.ViewModels;
using Application.BakeryIngredient.UpdateBakeryIngredient;
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
		[HttpGet("BakeryProduct/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BakeryProductViewModel>> GetBakeryProduct(int id)
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
		public async Task<ActionResult<int>> DeleteBakeryProduct(int id)
		{
			return Ok(await Mediator.Send(new DeleteBakeryProductCommand() { Id = id }));
		}

		[HttpGet("BakeryProduct/search")]
		[Produces("application/json")]
		[ProducesResponseType(200, Type = typeof(PagedResponseViewModel<BakeryProductViewModel>))]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> SearchBakeryProduct([FromQuery] SearchBakeryProductQuery command)
		{
			return Ok(await Mediator.Send(command));
		}

		/*Category*/

		[HttpGet("BakeryCategory/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BakeryCategoryViewModel>> GetBakeryCategory(int id)
		{
			return Ok(await Mediator.Send(new GetBakeryCategoryQuery() { Id = id }));
		}

		[HttpPost("BakeryCategory")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> CreateBakeryCatgory(CreateBakeryCategoryCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		[HttpDelete("BakeryCategory/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> DeleteBakeryCategory(int id)
		{
			return Ok(await Mediator.Send(new DeleteBakeryCategoryCommand() { Id = id }));
		}

		[HttpPatch("BakeryCategory/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> UpdateBakeryCategory(int id, UpdateBakeryCategoryCommand command)
		{
			command.SetBakeryCategoryId(id);
			return Ok(await Mediator.Send(command));
		}

		/*Ingredient*/

		[HttpGet("BakeryIngredient/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BakeryIngredientViewModel>> GetBakeryIngredient(int id)
		{
			return Ok(await Mediator.Send(new GetBakeryIngredientQuery() { Id = id }));
		}

		[HttpPost("BakeryIngredient")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> CreateBakeryIngredient(CreateBakeryIngredientCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		[HttpDelete("BakeryIngredient/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> DeleteBakeryIngredient(int id)
		{
			return Ok(await Mediator.Send(new DeleteBakeryIngredientCommand() { Id = id }));
		}

		[HttpPatch("BakeryIngredient/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> UpdateBakeryIngredient(int id, UpdateBakeryIngredientCommand command)
		{
			command.SetBakeryIngredientId(id);
			return Ok(await Mediator.Send(command));
		}
	}
}
