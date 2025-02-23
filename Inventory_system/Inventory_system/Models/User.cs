using System;
using System.Collections.Generic;

namespace Inventory_system.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
