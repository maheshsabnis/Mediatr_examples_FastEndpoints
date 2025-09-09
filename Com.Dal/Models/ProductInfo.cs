﻿using System;
using System.Collections.Generic;

namespace Com.Dal.Models;

public partial class ProductInfo
{
    public string ProductId { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int UnitPrice { get; set; }

    public int ProductRecordId { get; set; }
}
