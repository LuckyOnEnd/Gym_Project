using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymProject.Contract.Commands.Memberships;
using GymProject.Domain.Models.Memberships;
using GymProject.Infastructure.Repositories.Memberships;
using GymProject.Contract.Dtos;
using GymProject.Core.Exceptions.Memberships;
using GymProject.Core.Maps;

namespace GymProject.Core.Commands.Memberships
{
	public class AddMembershipCommandHandler : IRequestHandler<AddMembershipCommand>
	{
		private readonly IMembershipRepository _membershipRepository;

        public AddMembershipCommandHandler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }
		public async Task Handle(AddMembershipCommand request, CancellationToken cancellationToken)
		{ 

			var membershipAdd = new Subscription
			{
				Duration = request.Duration,
				Price = request.Price,
				Name = request.Name,
				Description = request.Description,
			};
			
		  await _membershipRepository.AddAsync(membershipAdd);
		}

	}
}
