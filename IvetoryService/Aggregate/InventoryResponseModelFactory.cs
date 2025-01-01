using InventoryService.RequestAndResponseModels;

namespace InventoryService.Aggregate
{
    public class InventoryResponseModelFactory
    {
        public static InventoryResponseModel Create(Inventory inventory)
        {
            return new InventoryResponseModel
            {
                Id = inventory.Id,
                Application = inventory.Application,
                Environment = inventory.Environment,
                HostName = inventory.HostName,
                IpAddress = inventory.IpAddress.Value,
                OperatingSystem = inventory.OperatingSystem,
                DatabaseVersion = inventory.DatabaseVersion,
                DatabaseName = inventory.DatabaseName,
                InstanceName = inventory.InstanceName,
                TNS = inventory.TNS,
                SysNSystCred = inventory.SysNSystCred,
                OraCred = inventory.OraCred,
                DbAdCred = inventory.DbAdCred,
                Remark = inventory.Remark,
            };
        }
    }
}
