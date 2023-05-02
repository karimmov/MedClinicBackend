using System;
using System.Collections.Generic;

namespace clinic.Model.Tables;

public partial class Office
{
    public int Officeid { get; set; }

    public string Officeaddress { get; set; } = null!;

    public virtual ICollection<Analysisresult> Analysisresults { get; } = new List<Analysisresult>();
}
