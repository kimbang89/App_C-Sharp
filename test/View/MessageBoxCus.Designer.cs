namespace test.View
{
    partial class MessageBoxCus
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxCus));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.ptWarning = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbContent = new System.Windows.Forms.Label();
            this.btCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btOk = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lbTitle = new System.Windows.Forms.Label();
            this.ptError = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptConfirm = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptConfirm)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 50;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 5;
            this.guna2Panel1.Controls.Add(this.ptConfirm);
            this.guna2Panel1.Controls.Add(this.lbContent);
            this.guna2Panel1.Controls.Add(this.btCancel);
            this.guna2Panel1.Controls.Add(this.btOk);
            this.guna2Panel1.Controls.Add(this.lbTitle);
            this.guna2Panel1.Controls.Add(this.ptWarning);
            this.guna2Panel1.Controls.Add(this.ptError);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(779, 209);
            this.guna2Panel1.TabIndex = 1;
            // 
            // ptWarning
            // 
            this.ptWarning.Image = ((System.Drawing.Image)(resources.GetObject("ptWarning.Image")));
            this.ptWarning.ImageRotate = 0F;
            this.ptWarning.Location = new System.Drawing.Point(25, -7);
            this.ptWarning.Name = "ptWarning";
            this.ptWarning.Size = new System.Drawing.Size(253, 210);
            this.ptWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptWarning.TabIndex = 89;
            this.ptWarning.TabStop = false;
            this.ptWarning.Visible = false;
            // 
            // lbContent
            // 
            this.lbContent.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Bold);
            this.lbContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(44)))), ((int)(((byte)(109)))));
            this.lbContent.Location = new System.Drawing.Point(263, 92);
            this.lbContent.Name = "lbContent";
            this.lbContent.Size = new System.Drawing.Size(504, 33);
            this.lbContent.TabIndex = 88;
            this.lbContent.Text = "label1";
            this.lbContent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btCancel
            // 
            this.btCancel.BorderRadius = 10;
            this.btCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btCancel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(161)))), ((int)(((byte)(157)))));
            this.btCancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(159)))));
            this.btCancel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancel.ForeColor = System.Drawing.Color.White;
            this.btCancel.ImageSize = new System.Drawing.Size(35, 35);
            this.btCancel.Location = new System.Drawing.Point(556, 158);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(141, 39);
            this.btCancel.TabIndex = 87;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.BorderRadius = 10;
            this.btOk.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btOk.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btOk.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btOk.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btOk.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btOk.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(161)))), ((int)(((byte)(157)))));
            this.btOk.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(159)))));
            this.btOk.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btOk.ForeColor = System.Drawing.Color.White;
            this.btOk.ImageSize = new System.Drawing.Size(35, 35);
            this.btOk.Location = new System.Drawing.Point(321, 158);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(141, 39);
            this.btOk.TabIndex = 87;
            this.btOk.Text = "OK";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // lbTitle
            // 
            this.lbTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(46)))), ((int)(((byte)(56)))));
            this.lbTitle.Location = new System.Drawing.Point(312, 0);
            this.lbTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(397, 64);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "ERROR";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptError
            // 
            this.ptError.Image = ((System.Drawing.Image)(resources.GetObject("ptError.Image")));
            this.ptError.ImageRotate = 0F;
            this.ptError.Location = new System.Drawing.Point(0, 0);
            this.ptError.Name = "ptError";
            this.ptError.Size = new System.Drawing.Size(300, 203);
            this.ptError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptError.TabIndex = 0;
            this.ptError.TabStop = false;
            // 
            // ptConfirm
            // 
            this.ptConfirm.Image = ((System.Drawing.Image)(resources.GetObject("ptConfirm.Image")));
            this.ptConfirm.ImageRotate = 0F;
            this.ptConfirm.Location = new System.Drawing.Point(25, 0);
            this.ptConfirm.Name = "ptConfirm";
            this.ptConfirm.Size = new System.Drawing.Size(253, 210);
            this.ptConfirm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptConfirm.TabIndex = 90;
            this.ptConfirm.TabStop = false;
            this.ptConfirm.Visible = false;
            // 
            // MessageBoxCus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(779, 209);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBoxCus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBox";
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptConfirm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2GradientButton btCancel;
        private Guna.UI2.WinForms.Guna2GradientButton btOk;
        private System.Windows.Forms.Label lbTitle;
        private Guna.UI2.WinForms.Guna2PictureBox ptError;
        private System.Windows.Forms.Label lbContent;
        private Guna.UI2.WinForms.Guna2PictureBox ptWarning;
        private Guna.UI2.WinForms.Guna2PictureBox ptConfirm;
    }
}