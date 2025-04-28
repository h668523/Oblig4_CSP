using System;
using System.Collections.Generic;

namespace Oblig4_CSP.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public int RoomId { get; set; }

    public string UserId { get; set; } = null!;

    public int Status { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
