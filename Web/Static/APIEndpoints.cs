using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Static
{
    public static class APIEndpoints
    {
#if DEBUG
        internal const string ServerBaseUrl = "https://localhost:5003/api/";
#else
    internal const string ServerBaseUrl = "https://Scheduler.azurewebsites.net";
#endif
        internal readonly static string s_register = $"{ServerBaseUrl}user/register";
        internal readonly static string s_signin = $"{ServerBaseUrl}user/signin";
    }
}
