using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IInputRequestTrigger
    {
        public Func<string> ExpectedInputEvent { get; set; }
    }
}
