using System;
using System.Collections.Generic;

namespace clinic.Model.Tables;

public partial class Request
{
    public int Id { get; set; }

    public int Analysistype { get; set; }

    public DateOnly Receptiondate { get; set; }

    public int Office { get; set; }

    public int Client { get; set; }

    public virtual Analysistype AnalysistypeNavigation { get; set; } = null!;

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual Office OfficeNavigation { get; set; } = null!;
}
