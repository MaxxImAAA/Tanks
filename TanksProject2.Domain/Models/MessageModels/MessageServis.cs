using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksProject2.Domain.Models.MessageModels
{
    public class MessageServis
    {
        public string SenderName { get; set; }
        public List<string> Messages { get; set; }
    }
}
