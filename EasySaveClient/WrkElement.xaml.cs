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
      
        public DTODataServer Work;

        public WrkElement(DTODataServer work)
        {
            this.Work = work;      

            InitializeComponent();
            UpdateWrkElement(this.Work);
        }

        public void UpdateWrkElement(DTODataServer workItem)
        {
            this.Work = workItem;

            workNameLbl.Content = workItem.Name;         
            
            workProgressBar.Value = Int16.Parse(workItem.Progress);
            workDuration.Content = workItem.Duration.ToString();
            workEligibleSize.Content = workItem.EligibleFiles.ToString();
            workEncryptDuration.Content = workItem.EncryptDuration.ToString();
            workRemainingSize.Content = workItem.RemainingSize.ToString();
            workSize.Content = workItem.Size.ToString();
            //workTypeLbl.Content = workItem.TypeSave.ToString();


        }
    }
}
