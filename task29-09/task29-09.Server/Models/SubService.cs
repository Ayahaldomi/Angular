using System;
using System.Collections.Generic;

namespace task29_09.Server.Models;

public partial class SubService
{
    public int SubServiceId { get; set; }

    public string SubServiceName { get; set; } = null!;

    public string? SubServiceDescription { get; set; }

    public string? SubServiceImage { get; set; }

    public int ServiceId { get; set; }

    public virtual Service Service { get; set; } = null!;
}
