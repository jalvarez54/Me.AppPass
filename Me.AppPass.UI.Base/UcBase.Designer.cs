namespace Me.AppPass.UI.Base
{
    partial class UcBase
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
            this.progressBarBase = new System.Windows.Forms.ProgressBar();
            this.checkBoxIsLocked = new System.Windows.Forms.CheckBox();
            this.textBoxAdminUserName = new System.Windows.Forms.TextBox();
            this.labelAdminUserName = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxAdminID = new System.Windows.Forms.TextBox();
            this.labelAdminID = new System.Windows.Forms.Label();
            this.checkBoxAdmin = new System.Windows.Forms.CheckBox();
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.panelAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBarBase
            // 
            this.progressBarBase.Location = new System.Drawing.Point(79, 3);
            this.progressBarBase.Name = "progressBarBase";
            this.progressBarBase.Size = new System.Drawing.Size(357, 20);
            this.progressBarBase.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarBase.TabIndex = 7;
            // 
            // checkBoxIsLocked
            // 
            this.checkBoxIsLocked.AutoSize = true;
            this.checkBoxIsLocked.Enabled = false;
            this.checkBoxIsLocked.Location = new System.Drawing.Point(3, 3);
            this.checkBoxIsLocked.Name = "checkBoxIsLocked";
            this.checkBoxIsLocked.Size = new System.Drawing.Size(70, 17);
            this.checkBoxIsLocked.TabIndex = 8;
            this.checkBoxIsLocked.Text = "IsLocked";
            this.checkBoxIsLocked.UseVisualStyleBackColor = true;
            // 
            // textBoxAdminUserName
            // 
            this.textBoxAdminUserName.Location = new System.Drawing.Point(69, 12);
            this.textBoxAdminUserName.Name = "textBoxAdminUserName";
            this.textBoxAdminUserName.Size = new System.Drawing.Size(73, 20);
            this.textBoxAdminUserName.TabIndex = 20;
            // 
            // labelAdminUserName
            // 
            this.labelAdminUserName.AutoSize = true;
            this.labelAdminUserName.Location = new System.Drawing.Point(6, 15);
            this.labelAdminUserName.Name = "labelAdminUserName";
            this.labelAdminUserName.Size = new System.Drawing.Size(57, 13);
            this.labelAdminUserName.TabIndex = 19;
            this.labelAdminUserName.Text = "UserName";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(386, 11);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(55, 23);
            this.buttonCreate.TabIndex = 23;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(328, 11);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(52, 23);
            this.buttonDecrypt.TabIndex = 22;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(267, 11);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(55, 23);
            this.buttonEncrypt.TabIndex = 21;
            this.buttonEncrypt.Text = "Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(443, 11);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(53, 23);
            this.buttonDelete.TabIndex = 24;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxAdminID
            // 
            this.textBoxAdminID.Location = new System.Drawing.Point(172, 12);
            this.textBoxAdminID.Name = "textBoxAdminID";
            this.textBoxAdminID.Size = new System.Drawing.Size(89, 20);
            this.textBoxAdminID.TabIndex = 26;
            // 
            // labelAdminID
            // 
            this.labelAdminID.AutoSize = true;
            this.labelAdminID.Location = new System.Drawing.Point(148, 15);
            this.labelAdminID.Name = "labelAdminID";
            this.labelAdminID.Size = new System.Drawing.Size(18, 13);
            this.labelAdminID.TabIndex = 25;
            this.labelAdminID.Text = "ID";
            // 
            // checkBoxAdmin
            // 
            this.checkBoxAdmin.AutoSize = true;
            this.checkBoxAdmin.Location = new System.Drawing.Point(442, 6);
            this.checkBoxAdmin.Name = "checkBoxAdmin";
            this.checkBoxAdmin.Size = new System.Drawing.Size(55, 17);
            this.checkBoxAdmin.TabIndex = 27;
            this.checkBoxAdmin.Text = "Admin";
            this.checkBoxAdmin.UseVisualStyleBackColor = true;
            this.checkBoxAdmin.CheckedChanged += new System.EventHandler(this.checkBoxAdmin_CheckedChanged);
            // 
            // panelAdmin
            // 
            this.panelAdmin.Controls.Add(this.labelAdminUserName);
            this.panelAdmin.Controls.Add(this.buttonDelete);
            this.panelAdmin.Controls.Add(this.textBoxAdminID);
            this.panelAdmin.Controls.Add(this.buttonEncrypt);
            this.panelAdmin.Controls.Add(this.labelAdminID);
            this.panelAdmin.Controls.Add(this.buttonDecrypt);
            this.panelAdmin.Controls.Add(this.textBoxAdminUserName);
            this.panelAdmin.Controls.Add(this.buttonCreate);
            this.panelAdmin.Location = new System.Drawing.Point(0, 68);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(499, 40);
            this.panelAdmin.TabIndex = 28;
            // 
            // UcBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAdmin);
            this.Controls.Add(this.checkBoxAdmin);
            this.Controls.Add(this.checkBoxIsLocked);
            this.Controls.Add(this.progressBarBase);
            this.Name = "UcBase";
            this.Size = new System.Drawing.Size(505, 108);
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBarBase;
        private System.Windows.Forms.CheckBox checkBoxIsLocked;
        private System.Windows.Forms.TextBox textBoxAdminUserName;
        private System.Windows.Forms.Label labelAdminUserName;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxAdminID;
        private System.Windows.Forms.Label labelAdminID;
        private System.Windows.Forms.CheckBox checkBoxAdmin;
        private System.Windows.Forms.Panel panelAdmin;
    }
}
