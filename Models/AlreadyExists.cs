using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo_Swagger.Models
{
    public class AlreadyExists : Exception
    {
        public AlreadyExists(string message) : base(message) { }
    }
}
