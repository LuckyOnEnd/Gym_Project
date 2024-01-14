using System.Net.Http.Json;
using ThePowerSPAv2.Models.Memberships;
using ThePowerSPAv2.Pages.Memberships;

namespace ThePowerSPAv2.ServicesV2.Memberships;

internal sealed class MembershipService : IMembershipService
{
    private readonly HttpClient _client;

    public MembershipService(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<MembershipModel>> GetAllAsync()
    {
        var getAll = await _client.GetFromJsonAsync<IEnumerable<MembershipModel>>("api/Membership/get-all");
        return getAll;
    }

    public async Task<MembershipModel> GetByIdAsync(Guid id)
    {
        return await _client.GetFromJsonAsync<MembershipModel>($"api/Membership/get?id={id}");
    }

    public async Task AddAsync(MembershipModel mbpDto)
    {
        var asd = new CreateMembership() { Name = "asd", Duration = 123, Price = 123, Description = "asdasd" };
        await _client.PostAsJsonAsync("api/Membership/Add", asd);
    }
    
    public async Task UpdateAsync(MembershipModel mbpDto)
        => await _client.PutAsJsonAsync<MembershipModel>("api/Membership/Update", mbpDto);
    public async Task DeleteAsync(Guid Id)
    => await _client.DeleteAsync($"api/Membership/Delete/{Id}");
    
}