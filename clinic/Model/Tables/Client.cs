using System;
using System.Collections.Generic;

namespace clinic.Model.Tables;

public partial class Client
{
    public int Clientid { get; set; }

    public string Clientname { get; set; } = null!;

    public string? Phonenumber { get; set; }

    public string Passwordhash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public virtual ICollection<Analysisresult> Analysisresults { get; } = new List<Analysisresult>();
}
