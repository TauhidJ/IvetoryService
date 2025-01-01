using InventoryService.Aggregate;

namespace InventoryService.Configurations
{
    public interface IInventoryRepository
    {
        Task<Inventory?> GetByIdAsync(long id);
    }
}
