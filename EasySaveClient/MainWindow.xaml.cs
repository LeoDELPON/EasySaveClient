using EasySaveClient.DAL;
using EasySaveClient.DTO;
using EasySaveClient.Networking;
using EasySaveClient.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            workElements = new List<WrkElement>();
            InitializeComponent();
            WorkList.Items.Add(new MainElement());
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
            if (workList.Count > 0)
            {
                Dispatcher.Invoke(() => {
                    abortBtn.IsEnabled = true;
                });
                Dispatcher.Invoke(() =>
                {
                    pauseBtn.IsEnabled = true;
                });
                Dispatcher.Invoke(() =>
                {
                    resumeBtn.IsEnabled = true;
                });
            }
            if (!workList.Any())
            {
                workList.Add(work);
               

                Dispatcher.Invoke(() => {
                    workElements.Add(new WrkElement(work));
                    WorkList.Items.Add(workElements[workElements.Count - 1]);
                workElements[workElements.Count - 1].UpdateWrkElement(work);
                });
                return;
            }
            else
            {
                for(int i = 0; i< workList.Count; i++)
                {
                    if (workList[i].Name == work.Name)
                    {
                        workList[i] = work;

                            Dispatcher.Invoke(() => {
                                workElements[i].UpdateWrkElement(work);
                            });
                        return;
                    }

                }

                workList.Add(work);
                
                        Dispatcher.Invoke(() => {
                            workElements.Add(new WrkElement(work));
                            WorkList.Items.Add(workElements[workElements.Count -1]);
                workElements[workElements.Count - 1].UpdateWrkElement(work);
                        });
                return;
            }
            
        }
        public void PrintComponents(DTODataServer work)
        {           
            
          
            

        }

        private void AbortBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Message msg = new Message("STOP");
                _client.Send(msg.finalBuffer);
            } catch(Exception exception)
            {
                Console.WriteLine("[-] An error has occured {0}", exception);
            }
        }
        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Message msg = new Message("PAUSE");
                _client.Send(msg.finalBuffer);
            } catch(Exception exception)
            {
                Console.WriteLine("[-] An error has occured {0}", exception);
            }
        }
        private void ResumeBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Message msg = new Message("START");
                _client.Send(msg.finalBuffer);
            }
            catch (Exception exception)
            {
                Console.WriteLine("[-] An error has occured {0}", exception);
            }
        }

        public void PrintComponents()
        {
            throw new NotImplementedException();
        }
    }
}
