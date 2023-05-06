using System;
using System.Collections.Generic;

namespace RoomRentalManagementClassLibrary.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int? RoomId { get; set; }

    public string Name { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public DateTime Dob { get; set; }

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual Room? Room { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();

    public virtual ICollection<Room> RoomsNavigation { get; } = new List<Room>();
}
