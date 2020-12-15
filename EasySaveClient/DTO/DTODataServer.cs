using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveClient.DTO
{
    public class DTODataServer
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public int Size { get; set; }
        public DateTime Duration { get; set; }
        public int EncryptDuration { get; set; }
        public string State { get; set; }
        public int EligibleFiles { get; set; }
        public double Progress { get; set; }
        public int RemaningFiles { get; set; }
        public int RemainingSize { get; set; }
    }
}
