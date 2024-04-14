using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zvent.Server.Usecase.Common;

public class AppSettings
{
    public string ConnectionString { get; set; }
    public string SecretPrefix { get; set; }
}
