using System;
using System.Collections.Generic;

namespace Demo.Data;

public class Town
{
    public int TownId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; } = new List<Address>();
}
