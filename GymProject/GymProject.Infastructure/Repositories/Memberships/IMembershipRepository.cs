using GymProject.Domain.Models.Memberships;

namespace GymProject.Infastructure.Repositories.Memberships;

public interface IMembershipRepository
{
    Task<IEnumerable<Subscription>> GetAllAsync();
	Task<Subscription> GetAsync(Guid Id);
	Task AddAsync(Subscription subscription);
	Task DeleteAsync(Subscription subscription);
	Task UpdateAsync(Subscription subscription);
}