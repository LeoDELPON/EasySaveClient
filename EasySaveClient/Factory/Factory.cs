using EasySaveClient.DAL;
using EasySaveClient.DTO;
using System.Collections.Generic;

namespace EasySaveClient.Factory
{
    public abstract class Factory
    {
        public abstract DTODataServer CreateDtoDataServer(Dictionary<WorkProperties, object> propertiesServer);
    }
}
