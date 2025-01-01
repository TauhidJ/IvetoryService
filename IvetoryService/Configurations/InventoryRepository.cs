using InventoryService.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Configurations
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Inventory?> GetByIdAsync(long id)
        {
            return await _context.Inventory
                .FirstOrDefaultAsync(i => i.Id == id && !i.IsDeleted);
        }
    }
}
