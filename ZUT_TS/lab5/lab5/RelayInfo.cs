using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class RelayInfo
    {
        public RelayInfo(int port, bool isExitNode, ConsoleColor color)
        {
            this.port       = port;
            this.color      = color;
        }

        public int          port       { get; private set; }
        public ConsoleColor color      { get; private set; }
    }
}
