using System;
using System.Collections.Generic;
using System.Text;

namespace WatchService.Models.Configurations;

public class MongoDbConfiguration
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}
