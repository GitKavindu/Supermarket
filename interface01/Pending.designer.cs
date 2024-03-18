namespace interface01
{
    partial class Pending
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridRequests = new System.Windows.Forms.DataGridView();
            this.dataGridReleases = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReleases)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1688, 140);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(400, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(748, 54);
            this.label5.TabIndex = 1;
            this.label5.Text = "Supermarket Managment System";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(553, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(341, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pending Requests";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dataGridRequests
            // 
            this.dataGridRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRequests.Location = new System.Drawing.Point(760, 190);
            this.dataGridRequests.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridRequests.Name = "dataGridRequests";
            this.dataGridRequests.RowHeadersWidth = 51;
            this.dataGridRequests.Size = new System.Drawing.Size(645, 417);
            this.dataGridRequests.TabIndex = 9;
            // 
            // dataGridReleases
            // 
            this.dataGridReleases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridReleases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReleases.Location = new System.Drawing.Point(35, 190);
            this.dataGridReleases.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridReleases.Name = "dataGridReleases";
            this.dataGridReleases.RowHeadersWidth = 51;
            this.dataGridReleases.Size = new System.Drawing.Size(697, 417);
            this.dataGridReleases.TabIndex = 9;
            // 
            // Pending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(1688, 801);
            this.Controls.Add(this.dataGridReleases);
            this.Controls.Add(this.dataGridRequests);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pending";
            this.Text = "users";
            this.Load += new System.EventHandler(this.Pending_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReleases)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridRequests;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridReleases;
    }
}