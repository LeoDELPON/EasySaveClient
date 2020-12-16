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
            workSize.Content = workItem.Size;
            workEligibleFiles.Content = workItem.EligibleFiles;
            workTypeLbl.Content = workItem.SaveType;
            workProgressBar.Value = Int16.Parse(workItem.Progress);
        }
    }
}
