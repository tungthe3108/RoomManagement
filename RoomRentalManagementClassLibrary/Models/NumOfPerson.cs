using System;
using System.Collections.Generic;

namespace RoomRentalManagementClassLibrary.Models;

public partial class NumOfPerson
{
    public int Id { get; set; }

    public int NumOfPerson1 { get; set; }
    public override string ToString()
    {
        return $"{NumOfPerson1}";
    }
}
