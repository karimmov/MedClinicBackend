using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace clinic.Model.Tables;

public partial class Client
{
    public int Clientid { get; set; }

    public string Name { get; set; } = null!;

    public string? Phonenumber { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Passwordhash { get; set; } = null!;

    public virtual ICollection<Analysisresult> Analysisresults { get; } = new List<Analysisresult>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
