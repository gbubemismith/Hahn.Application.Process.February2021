using System;
using Hahn.ApplicationProcess.February2021.Domain.Entities;

namespace Hahn.ApplicationProcess.February2021.Domain.Dtos
{
    public class AssetDto
    {
        public int ID { get; set; }
        public string AssetName { get; set; }
        public string Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
        public bool broken { get; set; }
    }
}