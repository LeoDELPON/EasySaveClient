﻿using EasySaveClient.DTO;
using EasySaveClient.Networking;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveClient.Service
{
     public interface Observable
    {
        public void Subscribe(Observer obs);
        public void Unsuscribe(Observer obs);
        public void NotifyObserver(DTODataServer work);
        public List<Observer> obsList { get; set; }

    }
}
