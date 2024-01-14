using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymProject.Contract.Commands.Memberships;
using GymProject.Core.Exceptions.Memberships;
using GymProject.Core.Maps;
using GymProject.Infastructure.Repositories.Memberships;

namespace GymProject.Core.Commands.Memberships
{
	public class UpdateMembershipCommandHandler : IRequestHandler<UpdateMembershipCommand>
	{
		private readonly IMembershipRepository _membershipRepository;
		public UpdateMembershipCommandHandler(IMembershipRepository membershipRepository) 
		{
			_membershipRepository = membershipRepository;
		}

		public async Task Handle(UpdateMembershipCommand request, CancellationToken cancellationToken)
		{
			var membership = await _membershipRepository.GetAsync(request.membershipDTO.Id);
			if (membership is null)
				throw new MembershipNullException();
			var updateMembership = MembershipMapping.MapToEntity(request.membershipDTO);
			await _membershipRepository.UpdateAsync(updateMembership);
		}
	}
}
