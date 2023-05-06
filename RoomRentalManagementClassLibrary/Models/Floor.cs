using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace RoomRentalManagementClassLibrary.Models;

public partial class Floor
{
    public int Id { get; set; }

    public int Floor1 { get; set; }
    public override string ToString()
    {
        return $"{Floor1}";
    }
}
