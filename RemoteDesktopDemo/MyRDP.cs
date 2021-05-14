using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDesktopDemo
{
    public class MyRDP : AxMSTSCLib.AxMsRdpClient9NotSafeForScripting
    {
        public MyRDP()
            : base()
        {
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // Fix for the missing focus issue on the rdp client component
            if (m.Msg == 0x0021) // WM_MOUSEACTIVATE
            {
                if (!this.ContainsFocus)
                {
                    this.Focus();
                }
            }

            base.WndProc(ref m);
        }
    }
}
