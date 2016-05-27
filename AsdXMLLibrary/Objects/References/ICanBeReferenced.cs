using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsdXMLLibrary.Objects.References
{
    interface ICanBeReferenced
    {
        IAmReference GetReference();
    }
}
