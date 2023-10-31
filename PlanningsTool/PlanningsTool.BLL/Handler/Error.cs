using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.BLL.Handler
{
    public class Error
    {
        public Error(string type, string description)
        {
            Type = type;
            Description = description;
        }

        public string Type { get; private set; }
        public string Description { get; private set; }
    }
}
