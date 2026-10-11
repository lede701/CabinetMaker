using System;
using System.Collections.Generic;
using System.Text;

namespace CabinetMaker.DAL.Extensions;

public class DalServiceConfiguration
{
    public string DatabaseProvider { get; set; } = "MySql";
    public string DatabaseConnectionString { get; set; } = string.Empty;
}
