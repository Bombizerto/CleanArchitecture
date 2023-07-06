using CleanArchitecture.Application.Features.UserFeatures.CreateUser;
using CleanArchitecture.Application.Features.UserFeatures.DeleteUserByEmail;
using CleanArchitecture.Application.Features.UserFeatures.GetAllUser;
using CleanArchitecture.Application.Features.UserFeatures.GetUserByEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace CleanArchitecture.WebAPI.Controller
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController (IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetAllUserResponse>>> GetAll(CancellationToken cancellationToken)
        {
            Version response = (Version)await _mediator.Send(new GetAllUserRequest(), cancellationToken);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>>Create(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpPost]
        [Route("ByEmail")]
        public async Task<ActionResult<GetUserByEmailResponse>>GetUserByEmail(GetUserByEmailRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        [HttpDelete]
        [Route("DeleteByEmail")]
        public async Task <ActionResult<DeleteUserByEmailResponse>>DeleteUserByEmail(DeleteUserByEmailRequest request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
