using Dapper;
using InventoryService.RequestAndResponseModels;
using Microsoft.Data.SqlClient;

namespace InventoryService.Application.InventoryQueries
{
    public class InventoryQueries : IInventoryQueries
    {
        private readonly string _connectionString;

        public InventoryQueries(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(Constants.CONNECTION_STRING);
        }


        public async Task<List<InventoryResponseModel>> GetInventoryListAsync( CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync(cancellationToken);

            DateTime currentDate = DateTime.Now.Date;

            string sql = $@"SELECT 
                i.Id AS [{nameof(InventoryResponseModel .Id)}],
                i.[Application] AS [{nameof(InventoryResponseModel.Application)}],
                i.[Environment] AS [{nameof(InventoryResponseModel.Environment)}],
                i.[HostName] AS [{nameof(InventoryResponseModel.HostName)}],
                i.[IpAddress_Value] AS [{nameof(InventoryResponseModel.IpAddress)}],
                i.[OperatingSystem] AS [{nameof(InventoryResponseModel.OperatingSystem)}],
                i.[DatabaseVersion] AS [{nameof(InventoryResponseModel.DatabaseVersion)}],
                i.[DatabaseName] AS [{nameof(InventoryResponseModel.DatabaseName)}],
                i.[InstanceName] AS [{nameof(InventoryResponseModel.InstanceName)}],
                i.[TNS] AS [{nameof(InventoryResponseModel.TNS)}],
                i.[SysNSystCred] AS [{nameof(InventoryResponseModel.SysNSystCred)}],
                i.[OraCred] AS [{nameof(InventoryResponseModel.OraCred)}],
                i.[DbAdCred] AS [{nameof(InventoryResponseModel.DbAdCred)}],
                i.[Remark] AS [{nameof(InventoryResponseModel.Remark)}],
                i.[IsDeleted] AS [{nameof(InventoryResponseModel.IsDeleted)}]
            FROM
                [Inventory] i
            WHERE
            i.IsDeleted = 0 
            
            ORDER BY
                i.[Application] DESC";

            var result = await connection.QueryAsync<InventoryResponseModel>(sql);

            return result.ToList();
        }
    }
}
