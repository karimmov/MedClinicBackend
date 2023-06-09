﻿using System;
using System.Collections.Generic;

namespace clinic.Model.Tables;

public partial class Office
{
    public int Officeid { get; set; }

    public string Officeaddress { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public virtual ICollection<Analysisresult> Analysisresults { get; } = new List<Analysisresult>();

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
