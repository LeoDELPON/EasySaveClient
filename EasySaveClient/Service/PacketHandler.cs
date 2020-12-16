using EasySaveClient.DAL;
using EasySaveClient.DTO;
using EasySaveClient.Factory;
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
            //KIKI EST UNE ENORME TARLOUZZE
        }

        public  void Handle(byte[] packet, Socket clientSocket)
        {
            Monitor.Enter(tLock);
            try
            {
                Message msg = new Message(packet);
                DTODataServer dataServer = JsonSerializer.Deserialize<DTODataServer>(msg.Text);
                //JObject json = JObject.Parse(msg.Text);
                //_work = UpdateWorkProperties(json);
                //DTODataServer dataServer = new DataServerFactory().CreateDtoDataServer(_work);
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

        private Dictionary<WorkProperties, object> UpdateWorkProperties(JObject json)
        {
            Dictionary<WorkProperties, object> work = new Dictionary<WorkProperties, object>();
            work[WorkProperties.Name] = json["Name"];
            work[WorkProperties.TypeSave] = json["TypeSave"];
            work[WorkProperties.Date] = json["Date"];
            work[WorkProperties.State] = json["State"];
            work[WorkProperties.Progress] = json["Progress"];
            work[WorkProperties.Duration] = json["Duration"];
            work[WorkProperties.CurrentFile] = json["CurrentFile"];
            work[WorkProperties.EligibleFiles] = json["EligibleFiles"];
            work[WorkProperties.RemainingFiles] = json["RemainingFiles"];
            work[WorkProperties.Size] = json["Size"];
            work[WorkProperties.RemainingSize] = json["RemainingSize"];
            work[WorkProperties.Extensions] = json["Extensions"];
            work[WorkProperties.EncryptDuration] = json["EncryptDuration"];
            return work;
        }
    }
}
