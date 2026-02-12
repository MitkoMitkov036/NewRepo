using System;
using System.Collections.Generic;
using System.Text;

namespace WatchService.Models.Responses;

public class SellWatchResponse
{
    public bool IsSuccessful { get; set; }

    public string Message { get; set; } = null!;
}
