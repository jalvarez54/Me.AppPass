namespace Me.AppPass.UI
{
    partial class UcHost
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonValidateAuthentication = new System.Windows.Forms.Button();
            this.comboBoxAuthenticationProvider = new System.Windows.Forms.ComboBox();
            this.labelAuthenticationProvider = new System.Windows.Forms.Label();
            this.groupBoxChild = new System.Windows.Forms.GroupBox();
            this.statusStripHostMessage = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelHost = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripHostMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonValidateAuthentication
            // 
            this.buttonValidateAuthentication.Location = new System.Drawing.Point(350, 7);
            this.buttonValidateAuthentication.Name = "buttonValidateAuthentication";
            this.buttonValidateAuthentication.Size = new System.Drawing.Size(168, 23);
            this.buttonValidateAuthentication.TabIndex = 10;
            this.buttonValidateAuthentication.Text = "Validate Authentication";
            this.buttonValidateAuthentication.UseVisualStyleBackColor = true;
            this.buttonValidateAuthentication.Click += new System.EventHandler(this.buttonValidateAuthentication_Click);
            // 
            // comboBoxAuthenticationProvider
            // 
            this.comboBoxAuthenticationProvider.FormattingEnabled = true;
            this.comboBoxAuthenticationProvider.Location = new System.Drawing.Point(125, 7);
            this.comboBoxAuthenticationProvider.Name = "comboBoxAuthenticationProvider";
            this.comboBoxAuthenticationProvider.Size = new System.Drawing.Size(219, 21);
            this.comboBoxAuthenticationProvider.TabIndex = 7;
            this.comboBoxAuthenticationProvider.SelectedIndexChanged += new System.EventHandler(this.comboBoxAuthenticationProvider_SelectedIndexChanged);
            // 
            // labelAuthenticationProvider
            // 
            this.labelAuthenticationProvider.AutoSize = true;
            this.labelAuthenticationProvider.Location = new System.Drawing.Point(3, 10);
            this.labelAuthenticationProvider.Name = "labelAuthenticationProvider";
            this.labelAuthenticationProvider.Size = new System.Drawing.Size(116, 13);
            this.labelAuthenticationProvider.TabIndex = 6;
            this.labelAuthenticationProvider.Text = "Authentication provider";
            // 
            // groupBoxChild
            // 
            this.groupBoxChild.Location = new System.Drawing.Point(6, 63);
            this.groupBoxChild.Name = "groupBoxChild";
            this.groupBoxChild.Size = new System.Drawing.Size(512, 137);
            this.groupBoxChild.TabIndex = 11;
            this.groupBoxChild.TabStop = false;
            // 
            // statusStripHostMessage
            // 
            this.statusStripHostMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelHost});
            this.statusStripHostMessage.Location = new System.Drawing.Point(0, 233);
            this.statusStripHostMessage.Name = "statusStripHostMessage";
            this.statusStripHostMessage.Size = new System.Drawing.Size(525, 22);
            this.statusStripHostMessage.TabIndex = 17;
            this.statusStripHostMessage.Text = "statusStrip1";
            // 
            // toolStripStatusLabelHost
            // 
            this.toolStripStatusLabelHost.Name = "toolStripStatusLabelHost";
            this.toolStripStatusLabelHost.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabelHost.Text = "Message";
            // 
            // UcHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStripHostMessage);
            this.Controls.Add(this.groupBoxChild);
            this.Controls.Add(this.buttonValidateAuthentication);
            this.Controls.Add(this.comboBoxAuthenticationProvider);
            this.Controls.Add(this.labelAuthenticationProvider);
            this.Name = "UcHost";
            this.Size = new System.Drawing.Size(525, 255);
            this.Load += new System.EventHandler(this.UcHost_Load);
            this.statusStripHostMessage.ResumeLayout(false);
            this.statusStripHostMessage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonValidateAuthentication;
        private System.Windows.Forms.ComboBox comboBoxAuthenticationProvider;
        private System.Windows.Forms.Label labelAuthenticationProvider;
        private System.Windows.Forms.GroupBox groupBoxChild;
        private System.Windows.Forms.StatusStrip statusStripHostMessage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelHost;
    }
}
