using System;
using System.Collections.Generic;

namespace RoomRentalManagementClassLibrary.Models;

public partial class RoomPrice
{
    public int Id { get; set; }

    public decimal Price { get; set; }
    public override string ToString()
    {
        return Price.ToString("N0");
    }
}
