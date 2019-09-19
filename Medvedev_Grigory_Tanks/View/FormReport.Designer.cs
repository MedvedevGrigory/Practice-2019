namespace View
{
    partial class FormReport
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
            this.timerReport = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.Player = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apples = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tanks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bullets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).BeginInit();
            this.SuspendLayout();
            // 
            // timerReport
            // 
            this.timerReport.Tick += new System.EventHandler(this.TimerReport_Tick);
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.AllowUserToDeleteRows = false;
            this.dataGridViewReport.AllowUserToResizeColumns = false;
            this.dataGridViewReport.AllowUserToResizeRows = false;
            this.dataGridViewReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Player,
            this.Apples,
            this.Tanks,
            this.Bullets});
            this.dataGridViewReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReport.Enabled = false;
            this.dataGridViewReport.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewReport.Name = "dataGridViewReport";
            this.dataGridViewReport.RowHeadersVisible = false;
            this.dataGridViewReport.Size = new System.Drawing.Size(800, 811);
            this.dataGridViewReport.TabIndex = 1;
            // 
            // Player
            // 
            this.Player.HeaderText = "Player";
            this.Player.Name = "Player";
            // 
            // Apples
            // 
            this.Apples.HeaderText = "Apples";
            this.Apples.Name = "Apples";
            // 
            // Tanks
            // 
            this.Tanks.HeaderText = "Tanks";
            this.Tanks.Name = "Tanks";
            // 
            // Bullets
            // 
            this.Bullets.HeaderText = "Bullets";
            this.Bullets.Name = "Bullets";
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 811);
            this.Controls.Add(this.dataGridViewReport);
            this.Name = "FormReport";
            this.Opacity = 0.7D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormReport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerReport;
        private System.Windows.Forms.DataGridView dataGridViewReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Player;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apples;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tanks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bullets;
    }
}