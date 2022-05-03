using Makonis.Common;
using Makonis.Common.Models;
using Makonis.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Makonis.Services.Services
{
    public class JsonFileSaveService: IJsonFileSaveService
    {
        public string SaveUserDetailsToFile(User user)
        {
            try
            {
                var filePath = Constants.FilePath;
                string json = JsonSerializer.Serialize(user);
                File.WriteAllText(filePath, json);
                return filePath;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
