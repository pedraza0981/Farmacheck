using Farmacheck.Infrastructure.Models;

namespace Farmacheck.Infrastructure.Services
{
    public interface IBrandApiClient
    {
        Task<List<BrandResponse>> GetBrandsAsync();
        Task<BrandResponse?> GetBrandAsync(int id);
        Task<int> CreateAsync(BrandRequest request);
        Task DeleteAsync(int id);
    }
}
