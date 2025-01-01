using InventoryService.RequestAndResponseModels;

namespace InventoryService.Application.InventoryQueries
{
    public interface IInventoryQueries
    {
        Task<List<InventoryResponseModel>> GetInventoryListAsync( CancellationToken cancellationToken = default);
    }
}
