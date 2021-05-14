using AxMSTSCLib;
using RemoteDesktopDemo.ViewModel;
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

namespace RemoteDesktopDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel = this.DataContext as MainViewModel;
            ViewModel.ConnectRemoteEvent += ViewModel_ConnectRemoteEvent1;
            InitData();
        }

        private void ViewModel_ConnectRemoteEvent1(string arg1, string arg2, string arg3)
        {
            if (IsConnected)
            {
                this.rdp.Disconnect();
            }
            else
            {
                Connect(arg1, arg2, arg3);
            }
        }


        public MyRDP rdp { get; set; }
        private void InitData()
        {
            this.rdp = new MyRDP();
            ((System.ComponentModel.ISupportInitialize)(rdp)).BeginInit();
            this.rdp.Name = "rdp";
            this.rdp.Enabled = true;
            this.rdp.Dock = System.Windows.Forms.DockStyle.None;
            this.rdp.Location = new System.Drawing.Point(0, 0);
            this.rdp.OnConnecting += new EventHandler(this.RDPClient_OnConnecting);
            this.rdp.OnAuthenticationWarningDisplayed += Rdp_OnAuthenticationWarningDisplayed;
            this.rdp.OnAuthenticationWarningDismissed += Rdp_OnAuthenticationWarningDismissed;
            this.rdp.OnConnected += new EventHandler(this.RDPClient_OnConnected);
            this.rdp.OnDisconnected += new AxMSTSCLib.IMsTscAxEvents_OnDisconnectedEventHandler(this.RDPClient_OnDisconnected);


            this.host.Child = this.rdp;

            ((System.ComponentModel.ISupportInitialize)(rdp)).EndInit();

            //this.BtnContent = "connect";

            //this.MaskVisible = true;
            //this.HostVisible = false;
        }

        private void Rdp_OnAuthenticationWarningDismissed(object sender, EventArgs e)
        {
            Console.WriteLine("Rdp_OnAuthenticationWarningDismissed");
            ViewModel.AddRunningLog("Rdp_OnAuthenticationWarningDismissed");
        }

        public bool IsConnected { get; set; }
        private void Rdp_OnAuthenticationWarningDisplayed(object sender, EventArgs e)
        {
            Console.WriteLine("Rdp_OnAuthenticationWarningDisplayed");
            ViewModel.AddRunningLog("Rdp_OnAuthenticationWarningDisplayed");
        }

        private void RDPClient_OnDisconnected(object sender, IMsTscAxEvents_OnDisconnectedEvent e)
        {
            IsConnected = false;
            Console.WriteLine($"RDPClient_OnDisconnected {e.discReason}");
            ViewModel.AddRunningLog($"RDPClient_OnDisconnected {e.discReason}");
        }

        private void RDPClient_OnConnected(object sender, EventArgs e)
        {
            IsConnected = true;
            Console.WriteLine("RDPClient_OnConnected");
            ViewModel.AddRunningLog("RDPClient_OnConnected");
        }

        private void RDPClient_OnConnecting(object sender, EventArgs e)
        {
            Console.WriteLine("RDPClient_OnConnecting");
            ViewModel.AddRunningLog("RDPClient_OnConnecting");
        }

        private void Connect(string address, string name, string password)
        {


            //this.rdp.Server = address;
            this.rdp.Server = System.Net.Dns.GetHostName();// "localhost";
            this.rdp.Domain = System.Environment.UserDomainName;
            this.rdp.UserName = name;
            this.rdp.AdvancedSettings2.RDPPort = 3389;
            this.rdp.AdvancedSettings2.SmartSizing = true;
            this.rdp.AdvancedSettings2.ClearTextPassword = password;
            this.rdp.Width = Convert.ToInt32(System.Windows.SystemParameters.PrimaryScreenWidth);
            this.rdp.Height = Convert.ToInt32(System.Windows.SystemParameters.PrimaryScreenHeight);
            this.rdp.DesktopWidth = Convert.ToInt32(System.Windows.SystemParameters.PrimaryScreenWidth);
            this.rdp.DesktopHeight = Convert.ToInt32(System.Windows.SystemParameters.PrimaryScreenHeight);
            this.rdp.FullScreenTitle = "this is test";

            //MSTSCLib.IMsTscNonScriptable secured = (MSTSCLib.IMsTscNonScriptable)rdp.GetOcx();
            //secured.ClearTextPassword = password;


            MSTSCLib.IMsRdpClientNonScriptable7 secured2 = (MSTSCLib.IMsRdpClientNonScriptable7)rdp.GetOcx();

            secured2.AllowPromptingForCredentials = false;
            secured2.EnableCredSspSupport = true;
            secured2.AllowCredentialSaving = false;
            secured2.PromptForCredentials = false;
            secured2.PromptForCredsOnClient = false;
            secured2.EnableCredSspSupport = true;

            try
            {
                this.rdp.Connect();

            }
            catch (Exception ex)
            {
            }
        }

        private void ToggleFullScreen()
        {
            this.rdp.FullScreen = !this.rdp.FullScreen;
        }
    }
}
