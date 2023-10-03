using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanksProject2.Domain.Enum;

namespace TanksProject2.Domain.Models.Servise
{
    public class ServiseResponse<T>
    {
        public T Data { get; set; }
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public List<string> ValidMessage { get; set; }
    }
}
