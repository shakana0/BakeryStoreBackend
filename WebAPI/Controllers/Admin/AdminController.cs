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
using Application.BakeryProduct.Queries.GetBakeryProductDetails;
using Application.BakeryProduct.Queries.SearchBakeryProduct;
using Application.BakeryProduct.Queries.ViewModels;
using Application.BakeryProductIngredient.Commands.CreateBakeryProductIngredient;
using Application.BakeryProductIngredient.Commands.DeleteBakeryProductIngredient;
using Application.BakeryProductIngredient.Commands.UpdatebakeryProductIngredient;
using Application.BakeryProductIngredient.Queries.GetBakeryProductIngredient;
using Application.BakeryProductIngredient.Queries.ViewModels;
using Application.Common.ViewModel;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using WebAPI.Interfaces;

namespace WebAPI.Controllers.Admin
{
	public class AdminController : BaseController
	{
		private readonly IRedisCache _redisCache;
		private readonly ILogger<AdminController> _logger;

		public AdminController(IRedisCache redisCache, ILogger<AdminController> logger)
		{
			_redisCache = redisCache;
			_logger = logger;
		}

		[HttpGet("BakeryProduct/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BakeryProductViewModel>> GetBakeryProduct(int id)
		{
			var cacheKey = $"BakeryProduct_{id}";

			// Check if the product is already cached
			var cachedData = await _redisCache.GetCacheData<BakeryProductViewModel>(cacheKey);
			if (cachedData is not null) return Ok(cachedData);

			// 🔹 Fetch the product from the database if not cached
			var result = await Mediator.Send(new GetBakeryProductQuery() { Id = id });

			// Cache the result for faster future requests
			await _redisCache.SetCacheData(cacheKey, result, DateTimeOffset.UtcNow.AddMinutes(10));
			return Ok(result);
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
			try
			{
				var cacheKey = $"BakeryProduct_{command.Name ?? "default"}_{command.Description ?? "default"}_{command.CategoryId?.ToString() ?? "default"}_{command.PageNumber}_{command.PageSize}";
				var cachedData = await _redisCache.GetCacheData<PagedResponseViewModel<BakeryProductViewModel>>(cacheKey);
				if (cachedData is not null) return Ok(cachedData);

				var result = await Mediator.Send(command);

				await _redisCache.SetCacheData(cacheKey, result, DateTimeOffset.UtcNow.AddMinutes(5));

				return Ok(result);
			}
			//If Redis fails, the API fetches fresh data instead of breaking.
			catch (RedisConnectionException ex)
			{
				Console.WriteLine($"Redis Error: {ex.Message}");
				// Continue without Redis, only return fresh DB results
				return Ok(await Mediator.Send(command));
			}
			//if another unexpected error return generic error message
			catch (Exception ex)
			{
				Console.WriteLine($"Unexpected Error: {ex.Message}");
				return BadRequest("Something went wrong.");
			}
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

		//ProductIngredient
		[HttpPost("BakeryProductIngredient")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<int>> CreateBakeryProductIngredient(CreateBakeryProductIngredientCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		[HttpGet("BakeryProductIngredient/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BakeryProductIngredientViewModel>> GetBakeryProductIngredient(int id)
		{
			return Ok(await Mediator.Send(new GetBakeryProductIngredientQuery() { Id = id }));
		}

		[HttpDelete("BakeryProductIngredient/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<int>> DeleteBakeryProductIngredient(int id)
		{
			return Ok(await Mediator.Send(new DeleteBakeryProductIngredientCommand() { Id = id }));
		}

		[HttpPatch("BakeryProductIngredient/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<int>> UpdateBakeryProductIngredient(int id, UpdateBakeryProductIngredientCommand command)
		{
			command.SetBakeryProductIngredientId(id);
			return Ok(await Mediator.Send(command));
		}
		//ProductDetails

		[HttpGet("BakeryProductDetails/{id}")]
		[Produces("application/json")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BakeryProductDetailsViewModel>> GetBakeryProductDetails(int id)
		{
			try
			{
				var cacheKey = $"BakeryProduct_{id}";
				var cachedData = await _redisCache.GetCacheData<BakeryProductDetailsViewModel>(cacheKey);
				if (cachedData is not null)
				{
					return Ok(cachedData);
				}
				// Fetch fresh data
				var result = await Mediator.Send(new GetBakeryProductDetailsQuery { ProductId = id });
				// Cache the fresh data
				await _redisCache.SetCacheData(cacheKey, result, DateTimeOffset.UtcNow.AddMinutes(10));

				return Ok(result);
			}
			catch (RedisConnectionException ex)
			{
				_logger.LogError($"Redis Error: {ex.Message}");

				// Return fresh data if Redis fails
				var result = await Mediator.Send(new GetBakeryProductDetailsQuery { ProductId = id });
				return Ok(result);
			}
			catch (RedisTimeoutException ex)
			{
				_logger.LogError($"Redis Timeout: {ex.Message}");

				// Return fresh data if Redis times out
				var result = await Mediator.Send(new GetBakeryProductDetailsQuery { ProductId = id });
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Unexpected Error: {ex.Message}");
				return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred.");
			}
		}

	}
}
