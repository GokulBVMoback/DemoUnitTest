using System;
using System.Collections.Generic;

namespace DemoUnitTest.Models;

public partial class TblUser
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<Salary> Salaries { get; } = new List<Salary>();
}
