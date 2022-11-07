using System;
using System.Collections.Generic;
using System.Text;

namespace Zork.Common
{
    internal class IInputService
    {

        event EventHandler<string> InputReceived;
    }
}
