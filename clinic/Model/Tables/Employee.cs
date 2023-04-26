using System;
using System.Collections.Generic;

namespace clinic.Model.Tables;

public partial class Employee
{
    public int Id { get; set; }

    public int EmployeeName { get; set; }

    public string Passwordhash { get; set; } = null!;

    public string Phonenumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Office { get; set; }

    public virtual Office OfficeNavigation { get; set; } = null!;
}
