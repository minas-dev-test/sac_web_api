using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAC_WebAPI.Logic
{
    public interface ISenderEmail
    {
        bool SenderEmail(string text, string email);
    }
}
