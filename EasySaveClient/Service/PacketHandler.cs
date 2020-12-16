using EasySaveClient.DAL;
using EasySaveClient.DTO;
using EasySaveClient.Networking;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;

namespace EasySaveClient.Service
{
    public sealed class PacketHandler : Observable

    {
        private Dictionary<WorkProperties, object> _work;
        public List<Observer> obsList { get; set; }
        private static readonly Lazy<PacketHandler> lazy = new Lazy<PacketHandler>(() => new PacketHandler());
        public static PacketHandler Instance { get { return lazy.Value; } }
        private readonly object tLock = new object();
        private PacketHandler()
        {
            obsList = new List<Observer>();
        }

        public  void Handle(byte[] packet, Socket clientSocket)
        {
            Monitor.Enter(tLock);
            try
            {
                Message msg = new Message(packet);
                DTODataServer dataServer = JsonSerializer.Deserialize<DTODataServer>(msg.Text);
                NotifyObserver(dataServer);
            } catch(Exception e)
            {
                Console.WriteLine("[-] {0}", e);
            } finally
            {
                Monitor.Exit(tLock);
            }
        }

        public void NotifyObserver(DTODataServer work)
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
                Console.WriteLine("[-] An error occured while trying to notify the server: {0}", e);
            }

        }

        public void Subscribe(Observer obs)
        {
            obsList.Add(obs);
        }

        public void Unsuscribe(Observer obs)
        {
            obsList.Remove(obs);
        }
    }
}
