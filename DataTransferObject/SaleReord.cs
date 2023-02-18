using System;

namespace DataTransferObject
{
    public class SaleReord
    {
        public string CarId { get; set; }
        public int TotalCarQuantitySold { get; set; }
        public decimal Revenue { get; set; }
        public string CarName { get; set; }
    }
}
