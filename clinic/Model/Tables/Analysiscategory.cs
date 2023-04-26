using System;
using System.Collections.Generic;

namespace clinic.Model.Tables;

public partial class Analysiscategory
{
    public int Categoryid { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual ICollection<Analysistype> Analysistypes { get; } = new List<Analysistype>();
}
