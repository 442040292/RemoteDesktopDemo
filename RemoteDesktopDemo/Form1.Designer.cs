
namespace RemoteDesktopDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axMsRdpClient9NotSafeForScripting1 = new AxMSTSCLib.AxMsRdpClient9NotSafeForScripting();
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient9NotSafeForScripting1)).BeginInit();
            this.SuspendLayout();
            // 
            // axMsRdpClient9NotSafeForScripting1
            // 
            this.axMsRdpClient9NotSafeForScripting1.Enabled = true;
            this.axMsRdpClient9NotSafeForScripting1.Location = new System.Drawing.Point(532, 188);
            this.axMsRdpClient9NotSafeForScripting1.Name = "axMsRdpClient9NotSafeForScripting1";
            this.axMsRdpClient9NotSafeForScripting1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMsRdpClient9NotSafeForScripting1.OcxState")));
            this.axMsRdpClient9NotSafeForScripting1.Size = new System.Drawing.Size(192, 192);
            this.axMsRdpClient9NotSafeForScripting1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axMsRdpClient9NotSafeForScripting1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axMsRdpClient9NotSafeForScripting1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxMSTSCLib.AxMsRdpClient9NotSafeForScripting axMsRdpClient9NotSafeForScripting1;
    }
}