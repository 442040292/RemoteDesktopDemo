using AxMSTSCLib;
using MSTSCLib;
using NotifyAppBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDesktopDemo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        //public event Action<MyRDP> ConnectRemoteEvent;
        public event Action<string, string, string> ConnectRemoteEvent;

        public MainViewModel()
        {
            ConnectCommand = new RelayCommand(ConnectMethod);
            DisConnectCommand = new RelayCommand(DisConnectMethod);
            FullscreenCommand = new RelayCommand(FullscreenMethod);
        }


        private MyRDP _rdp;

        public MyRDP rdp { get => _rdp; set => Set(ref _rdp, value); }


        private string _Name = "infodator"; //"infodator";// "guxialv";

        public string Name { get => _Name; set => Set(ref _Name, value); }

        private string _Address = "127.0.0.1";//"192.168.179.137";// "10.199.79.95";

        public string Address { get => _Address; set => Set(ref _Address, value); }

        private string _Password = "123456";//"123456";// "888168";

        public string Password { get => _Password; set => Set(ref _Password, value); }

        private bool _HostVisible = true;

        public bool HostVisible { get => _HostVisible; set => Set(ref _HostVisible, value); }

        private bool _MaskVisible;

        public bool MaskVisible { get => _MaskVisible; set => Set(ref _MaskVisible, value); }


        private string _BtnContent = "connect";

        public string BtnContent { get => _BtnContent; set => Set(ref _BtnContent, value); }

        private string _Status;

        public string Status { get => _Status; set => Set(ref _Status, value); }

        private string _RunningLog = "";

        public string RunningLog { get => _RunningLog; set => Set(ref _RunningLog, value); }


        public void AddRunningLog(string log)
        {
            RunningLog += $"{DateTime.Now.ToString("HH:mm:ss")}: {log} {Environment.NewLine}";
        }

        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand DisConnectCommand { get; set; }
        public RelayCommand FullscreenCommand { get; set; }


        private void ConnectMethod()
        {
            this.ConnectRemoteEvent?.Invoke(this.Address, this.Name, this.Password);
        }

        private void DisConnectMethod()
        {

        }

        private void FullscreenMethod()
        {

        }


    }
}
