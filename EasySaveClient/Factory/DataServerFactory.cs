using EasySaveClient.DAL;
using EasySaveClient.DTO;
using System.Collections.Generic;

namespace EasySaveClient.Factory
{
    public class DataServerFactory : Factory
    {
        public override DTODataServer CreateDtoDataServer(Dictionary<WorkProperties, object> propertiesServer)
        {
            DTODataServer dataServer = new DTODataServer();
            dataServer.Date = propertiesServer[WorkProperties.Date].ToString();
            dataServer.Name = propertiesServer[WorkProperties.Name].ToString();
            dataServer.Size = propertiesServer[WorkProperties.Size].ToString();
            dataServer.Duration = propertiesServer[WorkProperties.Duration].ToString();
            dataServer.EncryptDuration = propertiesServer[WorkProperties.EncryptDuration].ToString();
            dataServer.State = propertiesServer[WorkProperties.State].ToString();
            dataServer.EligibleFiles = propertiesServer[WorkProperties.EligibleFiles].ToString();
            dataServer.Progress = propertiesServer[WorkProperties.Progress].ToString();
            dataServer.RemainingSize = propertiesServer[WorkProperties.RemainingSize].ToString();
            dataServer.SaveType = propertiesServer[WorkProperties.TypeSave].ToString();
            return dataServer;
        }
    }
}
