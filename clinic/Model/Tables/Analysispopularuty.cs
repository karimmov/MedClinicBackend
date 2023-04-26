using System;
using System.Collections.Generic;

namespace clinic.Model.Tables;

public partial class Analysispopularuty
{
    public int Analysispopularityid { get; set; }

    public int Analysisname { get; set; }

    public int Purchasescount { get; set; }

    public virtual Analysistype AnalysisnameNavigation { get; set; } = null!;
}
