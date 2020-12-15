using EasySaveClient.Networking;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace EasySaveClient.Service



  
{
    public sealed class PacketHandler : Observable

    {
        public List<Observer> obsList { get; set; }
        private static readonly Lazy<PacketHandler> lazy = new Lazy<PacketHandler>(() => new PacketHandler());
        public static PacketHandler Instance { get { return lazy.Value; } }

        private PacketHandler()
        {
            obsList = new List<Observer>();

        }

        public  void Handle(byte[] packet, Socket clientSocket)
        {


            Message msg = new Message(packet);
            JObject json = JObject.Parse(msg.Text);
            Work work = new Work(json);

            NotifyObserver(work);


        }

        public void NotifyObserver(Work work)
        {
            try
            {
                
                foreach (Observer obs in obsList)
                {
                    obs.UpdateWorkList(work);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[-] An error occured while trying to notify the server");
            }

        }

        public void Subscribe(Observer obs)
        {
            
        }

        public void Unsuscribe(Observer obs)
        {
            
        }
    }
}
