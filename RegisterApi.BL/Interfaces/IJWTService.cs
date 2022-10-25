using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.BL.Interfaces
{
    public interface IJWTService
    {
        string GetJwtToken(string userName, string role);

    }
}
