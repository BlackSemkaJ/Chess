using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChessAPI.Controllers
{
    public class VersionController : ApiController
    {
        public string GetVersion()
        {
            return "pre-reliase 0.0.1";
        }
    }
}
