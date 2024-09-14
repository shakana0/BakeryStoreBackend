using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	// this attribute defines the URL pattern for the API. It includes a version number and the controller name.
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController] //attribute indicates that this class is an API controller, which means it will handle HTTP requests and responses.
	[ApiVersion(Common.ApiVersion.V1)] //attribute specifies the version of the API that this controller will handle.
	public class BaseController : Controller //inherits from the Controller class, which is a base class for MVC controllers.
	{
		//The Mediator property is used to get an instance of IMediator from the dependency injection container. This is done lazily
		//meaning the instance is only created when it’s first needed.
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); //property that returns the Mediator instance. If the instance is null, it creates a new instance using the RequestServices property of the HttpContext.
	}
}
