using EasySaveClient.Networking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace EasySaveClient
{
    public partial class WrkElement : UserControl
    {
      
        private Work work;

        public WrkElement(Work work)
        {
            this.work = work;
            InitializeComponent();

            UpdateWrkElement(work);
        }

        


        public void UpdateWrkElement(Work workItem)
        {
            workNameLbl.Content = workItem.workDict[Work.WorkProperties.Name];
            workSourceLbl.Content = workItem.workDict[Work.WorkProperties.Name];
            workTargetLbl.Content = workItem.workDict[Work.WorkProperties.Name];
            workTypeLbl.Content = workItem.workDict[Work.WorkProperties.Name];
            workProgressBar.Value =(double) workItem.workDict[Work.WorkProperties.Progress];
        }
    }
}
