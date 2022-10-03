﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw.Requests
{
    internal interface IHttpRequest
    {
        string Path { get; }
        string Url { get; }
        Dictionary<string,object> FormData { get; }
        Dictionary<string,object> QueryData { get; }
        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }
    }
}
