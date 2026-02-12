using System;
using System.Collections.Generic;
using System.Text;

namespace WatchService.Models.Requests;

public class AddWatchRequest
{
    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public decimal Price { get; set; }

    public string Type { get; set; } = null!;

    public int StockQuantity { get; set; }
}
