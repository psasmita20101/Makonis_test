using Makonis.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makonis.Services.Interfaces
{
    public interface IJsonFileSaveService
    {
        string SaveUserDetailsToFile(User user);
    }
}
