using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymProject.Contract.Commands.Memberships;
using GymProject.Contract.Dtos;
using GymProject.Contract.Queries.Memberships;

namespace GymProject.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MembershipController : ControllerBase
	{
		private readonly IMediator _mediator;
		public MembershipController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("get-all")]
		public async Task<IEnumerable<MembershipDTO>> GetAllAsync([FromQuery] GetAllMembershipsQuery query)
			=> await _mediator.Send(query);
		
		[HttpGet("get"), Authorize]
		public async Task<MembershipDTO> GetAsync([FromQuery] GetMembershipQuery query)
			=> await _mediator.Send(query);
		
		[HttpPost("add"), Authorize]
		public async Task AddAsync([FromBody] AddMembershipCommand command)
			=> await _mediator.Send(command);
		
		[HttpDelete("delete"), Authorize]
		public async Task RemoveAsync([FromBody] DeleteMembershipCommand command)
			=> await _mediator.Send(command);
		
		[HttpPut("update"), Authorize]
		public async Task UpdateAsync([FromBody] UpdateMembershipCommand command)
			=> await _mediator.Send(command);
	}
}
