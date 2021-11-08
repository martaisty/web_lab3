using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.DTOs.Admin;

namespace Abstractions.Services.Admin
{
    public interface ISageService
    {
        Task<List<SageDto>> GetAllAsync();

        Task<SageDto> GetAsync(int id);

        Task<SageDto> InsertAsync(CreateSageDto dto);

        Task<SageDto> UpdateAsync(UpdateSageDto dto);

        Task DeleteAsync(int id);
    }
}