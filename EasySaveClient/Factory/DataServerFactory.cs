using EasySaveClient.DAL;
using EasySaveClient.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveClient.Factory
{
    public class DataServerFactory : Factory
    {
        public override DTODataServer CreateDtoDataServer(Dictionary<WorkProperties, object> propertiesServer)
        {
            DTODataServer dataServer = new DTODataServer();
            dataServer.Date = (DateTime)propertiesServer[WorkProperties.Date];
            dataServer.Name = propertiesServer[WorkProperties.Name].ToString();
            dataServer.Source = propertiesServer[WorkProperties.Source].ToString();
            dataServer.Target = propertiesServer[WorkProperties.Target].ToString();
            dataServer.Size = (int)propertiesServer[WorkProperties.Size];
            dataServer.Duration = (DateTime)propertiesServer[WorkProperties.Duration];
            dataServer.EncryptDuration = (int)propertiesServer[WorkProperties.EncryptDuration];
            dataServer.State = propertiesServer[WorkProperties.State].ToString();
            dataServer.EligibleFiles = (int)propertiesServer[WorkProperties.EligibleFiles];
            dataServer.Progress = (double)propertiesServer[WorkProperties.Progress];
            dataServer.RemainingSize = (int)propertiesServer[WorkProperties.RemainingSize];
            return dataServer;
        }
    }
}
