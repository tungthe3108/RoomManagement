using System;
using System.Collections.Generic;

namespace RoomRentalManagementClassLibrary.Models;

public partial class Area
{
    public int Id { get; set; }

    public decimal Area1 { get; set; }
    public override string ToString()
    {
        return $"{Area1}";
    }
}
