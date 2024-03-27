using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix2.Controllers.Iterator
{
    public interface InterfaceIterator
    {
        bool HasNext();
        object Next();

    }
}
