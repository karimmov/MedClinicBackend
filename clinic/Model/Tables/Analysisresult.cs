using System;
using System.Collections.Generic;

namespace clinic.Model.Tables;

public partial class Analysisresult
{
    public int Id { get; set; }

    public int Client { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public int Analysistype { get; set; }

    public string Analysisresult1 { get; set; } = null!;

    public virtual Analysistype AnalysistypeNavigation { get; set; } = null!;

    public virtual Client ClientNavigation { get; set; } = null!;
}
