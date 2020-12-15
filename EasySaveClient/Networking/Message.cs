using EasySaveClient.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveClient.Networking
{
    public class Message : PacketStructure
    {
        public Message(string message) : base((ushort)(4 + message.Length), 2000)
        {
            Text = message;
            
        }

        public Message(byte[] packet) : base(packet)
        {

        }

        public string Text
        {
            get { return ReadString(0, finalBuffer.Length); }
            set { WriteString(value, 4); }
        }
    }
}
