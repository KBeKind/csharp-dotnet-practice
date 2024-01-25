using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public double Amount { get; set; }
}
