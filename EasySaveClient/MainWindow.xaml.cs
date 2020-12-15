﻿using EasySaveClient.Networking;
using EasySaveClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static EasySaveClient.Networking.Work;

namespace EasySaveClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Observer
    {        
        private static ClientSocket _client;
        public List<Work> workList;
        public List<WrkElement> workElements;

        


        public MainWindow()
        {
            workList = new List<Work>();
            InitializeComponent();
            InitializeSocket();

            


            

        }

        private void InitializeSocket()
        {
            _client = new ClientSocket();
            _client.Connect("192.168.137.1", 9999);
            
        }

        public void GetCurrentWorks()
        {

           
        }

        public void UpdateWorkList()
        {
            throw new NotImplementedException();
        }

        public void UpdateWorkList(Work work)
        {
            if (!workList.Any())
            {
                workList.Add(work);
            }
            else
            {
                for(int i = 0; i< workList.Count; i++)
                {
                    if (workList[i].workDict[WorkProperties.Name] == work.workDict[WorkProperties.Name])
                    {
                        workList[i] = work;
                        PrintComponents();
                        return;
                    }
                }
                workList.Add(work);
                PrintComponents();

            }
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
                    if(workElements[i].Name == workList[i].workDict[WorkProperties.Name])
                    {
                        workElements[i].UpdateWrkElement(workList[i]);
                        return;
                    }
                }
                workElements.Add(new WrkElement(workList[i]));
                CurrentWorksListBox.Items.Add(workElements.LastOrDefault());

            }

        }
    }
}
