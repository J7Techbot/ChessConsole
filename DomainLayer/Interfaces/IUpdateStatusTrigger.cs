using HW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interfaces
{
    public interface IUpdateStatusTrigger
    {
        public Action<GameStatus> UpdateGameStatusEvent { get; set; }
    }
}
