using System;
using System.Collections.Generic;

namespace DemoUnitTest.Models;

public partial class Salary
{
    public int SalaryId { get; set; }

    public int? Salary1 { get; set; }

    public int? UserId { get; set; }

    public virtual TblUser? User { get; set; }
}
