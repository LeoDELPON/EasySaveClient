using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveClient.Service
{
    public abstract class PacketStructure
    {
        private byte[] _buffer;
        public byte[] finalBuffer { get { return _buffer; } }
        public PacketStructure(ushort length, ushort type)
        {
            _buffer = new byte[length];
            WriteUShort(length, 0);
            WriteUShort(type, 2);
        }

        public PacketStructure(byte[] packet)
        {
            _buffer = packet;
        }

        public void WriteUShort(ushort value, int offset)
        {
            // la taille est de deux parce qu'un ushort est de 16 bits
            byte[] tempBuffer = new byte[2];
            tempBuffer = BitConverter.GetBytes(value);
            Buffer.BlockCopy(tempBuffer, 0, _buffer, offset, 2);
        }

        public void WriteString(string message, int offset)
        {
            byte[] tempBuff = new byte[message.Length];
            tempBuff = Encoding.ASCII.GetBytes(message);

            //Array.Copy est index-based et Buffer.BlockCopy est byte-based (c'est utilisé pour des sections critiques de perf) mais c'est 
            // quoi Marshal.Copy ?

            Buffer.BlockCopy(tempBuff, 0, _buffer, offset, message.Length);
        }

        public string ReadString(int offset, int count)
        {
            return Encoding.ASCII.GetString(_buffer, offset, count);
        }
    }
}
