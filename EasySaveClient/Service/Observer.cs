using EasySaveClient.DTO;
using EasySaveClient.Networking;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveClient.Service
{
    public interface Observer
    {
        public void UpdateWorkList(DTODataServer work);
    }
}
