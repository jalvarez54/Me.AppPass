namespace Me.AppPass.UI.RFID
{
    partial class UcRFID
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
            this.checkBoxAttached = new System.Windows.Forms.CheckBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxVersion = new System.Windows.Forms.TextBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.labelTag = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxAttached
            // 
            this.checkBoxAttached.AutoSize = true;
            this.checkBoxAttached.Enabled = false;
            this.checkBoxAttached.Location = new System.Drawing.Point(435, 29);
            this.checkBoxAttached.Name = "checkBoxAttached";
            this.checkBoxAttached.Size = new System.Drawing.Size(69, 17);
            this.checkBoxAttached.TabIndex = 0;
            this.checkBoxAttached.TabStop = false;
            this.checkBoxAttached.Text = "Attached";
            this.checkBoxAttached.UseVisualStyleBackColor = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(9, 51);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(50, 47);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(140, 20);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TabStop = false;
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Location = new System.Drawing.Point(244, 47);
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.ReadOnly = true;
            this.textBoxVersion.Size = new System.Drawing.Size(79, 20);
            this.textBoxVersion.TabIndex = 4;
            this.textBoxVersion.TabStop = false;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(196, 50);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(42, 13);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Version";
            // 
            // textBoxTag
            // 
            this.textBoxTag.Location = new System.Drawing.Point(361, 47);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.ReadOnly = true;
            this.textBoxTag.Size = new System.Drawing.Size(143, 20);
            this.textBoxTag.TabIndex = 6;
            this.textBoxTag.TabStop = false;
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Location = new System.Drawing.Point(329, 51);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(26, 13);
            this.labelTag.TabIndex = 5;
            this.labelTag.Text = "Tag";
            // 
            // UcRFID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.textBoxTag);
            this.Controls.Add(this.labelTag);
            this.Controls.Add(this.textBoxVersion);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.checkBoxAttached);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "UcRFID";
            this.Size = new System.Drawing.Size(512, 149);
            this.Controls.SetChildIndex(this.labelName, 0);
            this.Controls.SetChildIndex(this.textBoxName, 0);
            this.Controls.SetChildIndex(this.checkBoxAttached, 0);
            this.Controls.SetChildIndex(this.labelVersion, 0);
            this.Controls.SetChildIndex(this.textBoxVersion, 0);
            this.Controls.SetChildIndex(this.labelTag, 0);
            this.Controls.SetChildIndex(this.textBoxTag, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAttached;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.TextBox textBoxVersion;
        private System.Windows.Forms.Label labelTag;
        private System.Windows.Forms.TextBox textBoxTag;
    }
}
