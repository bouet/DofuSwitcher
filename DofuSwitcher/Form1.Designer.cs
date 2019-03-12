namespace DofuSwitcher
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lstChkDofus = new System.Windows.Forms.CheckedListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblDWL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstProcess = new System.Windows.Forms.ListView();
            this.clnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 372);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(224, 66);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(318, 372);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(224, 66);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // lstChkDofus
            // 
            this.lstChkDofus.FormattingEnabled = true;
            this.lstChkDofus.Location = new System.Drawing.Point(318, 56);
            this.lstChkDofus.Name = "lstChkDofus";
            this.lstChkDofus.Size = new System.Drawing.Size(210, 229);
            this.lstChkDofus.TabIndex = 2;
            this.lstChkDofus.SelectedIndexChanged += new System.EventHandler(this.lstChkDofus_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(169, 291);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(210, 52);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // lblDWL
            // 
            this.lblDWL.AutoSize = true;
            this.lblDWL.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDWL.Location = new System.Drawing.Point(325, 29);
            this.lblDWL.Name = "lblDWL";
            this.lblDWL.Size = new System.Drawing.Size(194, 24);
            this.lblDWL.TabIndex = 4;
            this.lblDWL.Text = "Dofus Windows List :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Windows Process List :";
            // 
            // lstProcess
            // 
            this.lstProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnName,
            this.clnId});
            this.lstProcess.Location = new System.Drawing.Point(32, 56);
            this.lstProcess.Name = "lstProcess";
            this.lstProcess.Size = new System.Drawing.Size(202, 229);
            this.lstProcess.TabIndex = 7;
            this.lstProcess.UseCompatibleStateImageBehavior = false;
            // 
            // clnName
            // 
            this.clnName.Text = "NAME";
            // 
            // clnId
            // 
            this.clnId.Text = "ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 450);
            this.Controls.Add(this.lstProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDWL);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstChkDofus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckedListBox lstChkDofus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblDWL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstProcess;
        private System.Windows.Forms.ColumnHeader clnName;
        private System.Windows.Forms.ColumnHeader clnId;
    }
}

