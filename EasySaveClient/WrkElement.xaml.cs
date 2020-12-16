using EasySaveClient.DTO;
using EasySaveClient.Networking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace EasySaveClient
{
    public partial class WrkElement : UserControl
    {
      
        public DTODataServer work;

        public WrkElement(DTODataServer work)
        {
            this.work = work;
            InitializeComponent();

            UpdateWrkElement(work);
        }

        public void UpdateWrkElement(DTODataServer workItem)
        {
            workNameLbl.Content = workItem.Name;
            
            
            workProgressBar.Value = Int16.Parse(workItem.Progress);
            workDuration.Content = workItem.Duration;
            workEligibleSize.Content = workItem.EligibleFiles;
            workEncryptDuration.Content = workItem.EncryptDuration;
            workRemainingSize.Content = workItem.RemainingSize;
            workSize.Content = workItem.Size;
            workTypeLbl.Content = workItem.TypeSave:


        }
    }
}
