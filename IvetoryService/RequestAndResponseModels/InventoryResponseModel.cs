namespace InventoryService.RequestAndResponseModels
{
    public class InventoryResponseModel
    {
        public long Id { get; set; }
        public string Application { get; set; }
        public string Environment { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
        public string OperatingSystem { get; set; }
        public string DatabaseVersion { get; set; }
        public string DatabaseName { get; set; }
        public string InstanceName { get; set; }
        public string TNS { get; set; }
        public string SysNSystCred { get; set; }
        public string OraCred { get; set; }
        public string DbAdCred { get; set; }
        public string? Remark { get; set; }
        public bool IsDeleted { get; set; }
    }
}
