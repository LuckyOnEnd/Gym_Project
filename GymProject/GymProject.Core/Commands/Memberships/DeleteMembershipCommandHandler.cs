using GymProject.Contract.Commands.Memberships;
using GymProject.Core.Exceptions.Memberships;
using GymProject.Infastructure.Repositories.Memberships;
using MediatR;

namespace GymProject.Core.Commands.Memberships
{
	internal class DeleteMembershipCommandHandler : IRequestHandler<DeleteMembershipCommand>
	{
		private readonly IMembershipRepository _membershipRepository;
        public DeleteMembershipCommandHandler(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }
        public async Task Handle(DeleteMembershipCommand request, CancellationToken cancellationToken)
		{
			var membership = await _membershipRepository.GetAsync(request.Id);
			if (membership is null)
				throw new MembershipNullException();
			await _membershipRepository.DeleteAsync(membership);
		}
	}
}
