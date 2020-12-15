using EasySaveClient.Service;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveClient.Networking
{
    public class Work 
    {

        
        public enum WorkProperties
        {
            Name,
            Source,
            TypeSave,
            Target,
            Date,
            State,
            Progress,
            Duration,
            CurrentFile,
            EligibleFiles,
            RemainingFiles,
            Size,
            RemainingSize,
            Extensions,
            Key,
            EncryptDuration
        }
        public Dictionary<WorkProperties, object> workDict;


        public Work(JObject json) 
        {
            workDict = new Dictionary<WorkProperties, object>();       

        }
        public void UpdateWorkProperties(JObject json)
        {
            workDict[WorkProperties.Name] = json["Name"];
            workDict[WorkProperties.Source] = json["Source"];
            workDict[WorkProperties.TypeSave] = json["TypeSave"];
            workDict[WorkProperties.Target] = json["Target"];
            workDict[WorkProperties.Date] = json["Date"];
            workDict[WorkProperties.State] = json["State"];
            workDict[WorkProperties.Progress] = json["Progress"];
            workDict[WorkProperties.Duration] = json["Duration"];
            workDict[WorkProperties.CurrentFile] = json["CurrentFile"];
            workDict[WorkProperties.EligibleFiles] = json["EligibleFiles"];
            workDict[WorkProperties.RemainingFiles] = json["RemainingFiles"];
            workDict[WorkProperties.Size] = json["Size"];
            workDict[WorkProperties.RemainingSize] = json["RemainingSize"];
            workDict[WorkProperties.Extensions] = json["Extensions"];
            workDict[WorkProperties.EncryptDuration] = json["EncryptDuration"];

        }

      
    }

       
}
