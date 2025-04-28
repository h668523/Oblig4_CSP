using System;
using System.Collections.Generic;

namespace Oblig4_CSP.Models;

public partial class Room
{
    public int Id { get; set; }

    public int NumberOfBeds { get; set; }

    public string RoomType { get; set; } = null!;

    public decimal PricePerNight { get; set; }

    public bool IsAvailable { get; set; }

    public virtual ICollection<HotelTask> HotelTasks { get; set; } = new List<HotelTask>();

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
