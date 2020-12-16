using EasySaveClient.DAL;
using EasySaveClient.DTO;
using EasySaveClient.Networking;
using EasySaveClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace EasySaveClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Observer
    {        
        private static ClientSocket _client;
        public List<DTODataServer> workList;
        public List<WrkElement> workElements;
        public PacketHandler _handler;

        public MainWindow()
        {
            _handler = PacketHandler.Instance;
            _handler.Subscribe(this);
            workList = new List<DTODataServer>();
            InitializeComponent();
            InitializeSocket();
        }

        private void InitializeSocket()
        {
            _client = new ClientSocket();
            _client.Connect("192.168.1.25", 9999);
            
        }

        public void GetCurrentWorks()
        {

        }

        public void UpdateWorkList()
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkList(DTODataServer work)
        {
            if (!workList.Any())
            {
                workList.Add(work);
            }
            else
            {
                for(int i = 0; i< workList.Count; i++)
                {
                    if (workList[i].Name == work.Name)
                    {
                        workList[i] = work;
                        PrintComponents();
                        return;
                    }
                }
                workList.Add(work);
            }
            PrintComponents();
        }
        public void PrintComponents()
        {
            int worksNumber = workList.Count;
            
            if (!workList.Any())
            {
                return;
            }
            for (int i = 0; i < workList.Count; i++)
            {
                if (!workElements.Any())
                {
                    workElements[i] = new WrkElement(workList[i]);
                    return;


                }
                for(int j = 0; j< workElements.Count(); j++)
                {
                    if(workElements[j].Name == workList[i].Name)
                    {
                        workElements[j].UpdateWrkElement(workList[i]);
                        return;
                    }
                }
                workElements.Add(new WrkElement(workList[i]));
                WorkList.Items.Add(workElements.LastOrDefault());

            }

        }

        private void ConnectToServer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
