using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string mes) : base(mes)
        {
            
        }
        public NotFoundException()
        {
            
        }
    }
}
