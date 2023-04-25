using System;
using System.Collections.Generic;

namespace _002_DbFirst;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }
}
