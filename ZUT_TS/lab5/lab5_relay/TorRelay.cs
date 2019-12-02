using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace lab5_relay
{
    class TorRelay
    {
        public TorRelay(bool isExitNode, int port)
        {
            this.isExitNode = isExitNode;
            this.port       = port;
        }

        private bool isExitNode;
        private int  port;

        public void start()
        {
            tcpClient   = new TcpClient("localhost", port);
            tcpListener = new TcpListener(IPAddress.Parse("localhost"), port);
            if (isExitNode)
                webClient = new WebClient();
        }

        TcpClient   tcpClient;
        TcpListener tcpListener;

        WebClient   webClient;
    }
}
