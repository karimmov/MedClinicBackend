using System;
using System.Collections.Generic;

namespace clinic.Model.Tables;

public partial class Analysistype
{
    public int Analysisid { get; set; }

    public string Analysistitle { get; set; } = null!;

    public int Price { get; set; }

    public string Duration { get; set; } = null!;

    public int Category { get; set; }

    public virtual ICollection<Analysispopularuty> Analysispopularuties { get; } = new List<Analysispopularuty>();

    public virtual ICollection<Analysisresult> Analysisresults { get; } = new List<Analysisresult>();

    public virtual Analysiscategory CategoryNavigation { get; set; } = null!;
}
