using System;
using System.Collections.Generic;

namespace RoomRentalManagementClassLibrary.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomName { get; set; } = null!;

    public int Floor { get; set; }

    public int NumOfPerson { get; set; }

    public int NumOfLiving { get; set; }

    public decimal Area { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();

    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual ICollection<Customer> Customers1 { get; } = new List<Customer>();

    public virtual ICollection<Customer> CustomersNavigation { get; } = new List<Customer>();
}
