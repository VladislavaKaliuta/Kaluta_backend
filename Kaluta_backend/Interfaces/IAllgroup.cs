using Kaluta_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Kaluta_backend.Interfaces
{
    public interface IAllgroup
    {
        IEnumerable<group> Allgroup { get; }
    }
}
