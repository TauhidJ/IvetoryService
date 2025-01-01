using InventoryService.Aggregate;
using InventoryService.Application.InventoryQueries;
using InventoryService.Configurations;
using InventoryService.RequestAndResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Application
{
    [Route("inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private ApplicationDbContext _inventoryRepository;
        private readonly IInventoryRepository _invRepository;
        private readonly IInventoryQueries _inventoryQueries;

        public InventoryController(ApplicationDbContext inventoryRepository, IInventoryRepository invRepository, IInventoryQueries inventoryQueries)
        {
            _inventoryRepository = inventoryRepository;
            _invRepository = invRepository;
            _inventoryQueries = inventoryQueries;
        }


        /// <summary>
        /// Get list of inventories.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("/inventories")]
        [ProducesResponseType(typeof(List<InventoryResponseModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetInventoryListAsync(CancellationToken cancellationToken = default)
        {
            var inventories = await _inventoryQueries.GetInventoryListAsync(cancellationToken);

            return Ok(inventories);
        }


        /// <summary>
        /// Create inventory
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        [HttpPost]
        [ProducesResponseType(typeof(InventoryResponseModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync(InventoryRequestModel model, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                var ip = IpAddress.Create(model.IpAddress!);
                var inventory = new Inventory(model.Application!, model.Environment!, model.HostName!, ip!, model.OperatingSystem!, model.DatabaseVersion!, model.DatabaseName!, model.InstanceName!, model.TNS!, model.SysNSystCred!, model.OraCred!, model.DbAdCred!, model.Remark);

                await _inventoryRepository.AddAsync(inventory);
                await _inventoryRepository.SaveChangesAsync(cancellationToken);

                return Created("inventory/" + inventory.Id, InventoryResponseModelFactory.Create(inventory));
            }
            return ValidationProblem(ModelState);
        }

       
        /// <summary>
        /// Update inventory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        [HttpPut("/inventory/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(long id, UpdateInventoryRequestModel model, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                var inventory = await _invRepository.GetByIdAsync(id);
                if (inventory == null) return NotFound();

                IpAddress? ipAddress = null;
                if (!string.IsNullOrWhiteSpace(model.IpAddress))
                {
                    ipAddress = IpAddress.Create(model.IpAddress);
                }
                inventory.UpdateInventory(model.Application, model.Environment, model.HostName, ipAddress, model.OperatingSystem, model.DatabaseVersion, model.DatabaseName, model.InstanceName, model.TNS, model.SysNSystCred, model.OraCred, model.DbAdCred, model.Remark);
                await _inventoryRepository.SaveChangesAsync(cancellationToken);

                return NoContent();
            }
            return ValidationProblem(ModelState);
        }

        /// <summary>
        /// Delete inventory
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        [HttpDelete("/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            var inventory = await _invRepository.GetByIdAsync(id);
            if (inventory == null) return NotFound();

            inventory.Delete();
            await _inventoryRepository.SaveChangesAsync(cancellationToken);

            return NoContent();
        }
    }
}
