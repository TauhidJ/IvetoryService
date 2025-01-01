using System;

namespace InventoryService.Aggregate
{
    public class Inventory
    {
        public long Id  { get; set; }
        public string Application { get; set; }
        public string Environment { get; set; }
        public string HostName { get; set; }
        public  IpAddress IpAddress { get; set; }
        public string OperatingSystem { get; set; }
        public string DatabaseVersion { get; set; }
        public string DatabaseName { get; set; }
        public string InstanceName { get; set; }
        public string TNS { get; set; }
        public string SysNSystCred { get; set; }
        public string OraCred { get; set; }
        public string DbAdCred { get; set; }
        public string? Remark { get; set; }
        public  bool IsDeleted { get; set; }
        public Inventory()
        {
            
        }

        public Inventory(string application, string env, string hostName, IpAddress ipAddress, string oSys, string databaseVersion, string databaseName, string instName, string tns, string sysCred, string orcCred, string dbCred, string? remark)
        {
            Application = application;
            Environment = env;
            HostName = hostName;
            IpAddress = ipAddress;
            OperatingSystem = oSys;
            DatabaseVersion = databaseVersion;
            DatabaseName = databaseName;
            InstanceName = instName;
            TNS = tns;
            SysNSystCred = sysCred;
            OraCred = orcCred;
            DbAdCred = dbCred;
            Remark = remark;
        }

        public void UpdateInventory(string? application, string? env, string? hostName, IpAddress? ipAddress, string? oSys, string? databaseVersion, string? databaseName, string? instName, string? tns, string? sysCred, string? orcCred, string? dbCred, string? remark)
        {
            if(application != null) { Application = application; }
            if(env != null) { Environment = env; }
            if(hostName != null) { HostName = hostName; }
            if(ipAddress != null) { IpAddress = ipAddress; }
            if(oSys != null) { OperatingSystem = oSys; }
            if(databaseVersion != null) { DatabaseVersion = databaseVersion; }
            if(databaseName != null) { DatabaseName = databaseName; }
            if(instName != null) { InstanceName = instName; }
            if(tns != null) { TNS = tns; }
            if(sysCred != null) { SysNSystCred = sysCred; }
            if(orcCred != null) { OraCred = orcCred; }
            if(dbCred != null) { DbAdCred = dbCred; }
            if(remark != null) { Remark = remark; }
        }


        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
