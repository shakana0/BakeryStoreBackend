using Application.BakeryProduct.Queries.GetBakeryProduct;
using Application.BakeryProduct.Queries.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class ProductController : BaseController
	{
		[HttpGet("{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BakeryProductViewModel>> GetEmergencyMessage(int id)
		{
			return Ok(await Mediator.Send(new GetBakeryProductQuery() { Id = id }));
		}
	}
}
