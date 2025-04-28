using System;
using System.Collections.Generic;

namespace Oblig4_CSP.Models;

public partial class HotelTask
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public string Type { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Room Room { get; set; } = null!;
}
