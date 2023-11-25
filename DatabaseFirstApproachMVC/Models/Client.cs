﻿using System;
using System.Collections.Generic;

namespace DatabaseFirstApproachMVC.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }
}
