using System;

namespace Hahn.ApplicationProcess.February2021.Domain.Entities
{
    public class Asset : BaseEntity
    {

        public string AssetName { get; set; }
        public DepartmentType Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public bool broken { get; set; }
    }

    public enum DepartmentType
    {
        HQ = 1,
        Store1 = 2,
        Store2 = 3,
        Store3 = 4,
        MaintenanceStation = 5
    }


}