using System;
using System.Collections.Generic;
using System.Text;

namespace WatchService.Models.Entities
{
    public class Watch
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public decimal Price { get; set; }

        public string Type { get; set; } = null!;

        public int StockQuantity { get; set; }
    }
}
