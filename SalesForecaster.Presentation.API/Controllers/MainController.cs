using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SalesForecaster.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator
        {
            get
            {
                if (_mediator == null)
                {
                    _mediator = HttpContext.RequestServices.GetRequiredService<IMediator>();
                }

                return _mediator;
            }
        }
    }
}
