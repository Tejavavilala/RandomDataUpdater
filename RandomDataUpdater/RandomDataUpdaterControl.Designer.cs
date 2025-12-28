namespace RandomDataUpdater
{
    partial class RandomDataUpdaterControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private System.Windows.Forms.TextBox txtEntity;
        private System.Windows.Forms.TextBox txtFetchXml;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblEntity;
        private System.Windows.Forms.Label lblFetchXml;

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtEntity = new System.Windows.Forms.TextBox();
            this.txtFetchXml = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lblEntity = new System.Windows.Forms.Label();
            this.lblFetchXml = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // lblEntity
            // 
            this.lblEntity.AutoSize = true;
            this.lblEntity.Location = new System.Drawing.Point(10, 10);
            this.lblEntity.Name = "lblEntity";
            this.lblEntity.Size = new System.Drawing.Size(130, 15);
            this.lblEntity.TabIndex = 0;
            this.lblEntity.Text = "Entity Logical Name";

            // 
            // txtEntity
            // 
            this.txtEntity.Location = new System.Drawing.Point(10, 28);
            this.txtEntity.Name = "txtEntity";
            this.txtEntity.Size = new System.Drawing.Size(300, 23);
            this.txtEntity.TabIndex = 1;

            // 
            // lblFetchXml
            // 
            this.lblFetchXml.AutoSize = true;
            this.lblFetchXml.Location = new System.Drawing.Point(10, 60);
            this.lblFetchXml.Name = "lblFetchXml";
            this.lblFetchXml.Size = new System.Drawing.Size(58, 15);
            this.lblFetchXml.TabIndex = 2;
            this.lblFetchXml.Text = "FetchXML";

            // 
            // txtFetchXml
            // 
            this.txtFetchXml.Location = new System.Drawing.Point(10, 78);
            this.txtFetchXml.Multiline = true;
            this.txtFetchXml.Name = "txtFetchXml";
            this.txtFetchXml.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFetchXml.Size = new System.Drawing.Size(760, 120);
            this.txtFetchXml.TabIndex = 3;

            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(10, 215);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(120, 30);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run Update";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);

            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(150, 215);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(120, 30);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);

            // 
            // RandomDataUpdaterControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEntity);
            this.Controls.Add(this.txtEntity);
            this.Controls.Add(this.lblFetchXml);
            this.Controls.Add(this.txtFetchXml);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnUndo);
            this.Name = "RandomDataUpdaterControl";
            this.Size = new System.Drawing.Size(800, 260);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
