
namespace WinFormsApp2.GUI
{
    partial class BookingGUI
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.booking = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbnumber = new System.Windows.Forms.Label();
            this.numberRow = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1097, 188);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellClick_DetailDelete);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(323, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 219);
            this.panel1.TabIndex = 1;
            // 
            // booking
            // 
            this.booking.Location = new System.Drawing.Point(29, 173);
            this.booking.Name = "booking";
            this.booking.Size = new System.Drawing.Size(129, 38);
            this.booking.TabIndex = 2;
            this.booking.Text = "booking";
            this.booking.UseVisualStyleBackColor = true;
            this.booking.Click += new System.EventHandler(this.booking_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of booking:";
            // 
            // lbnumber
            // 
            this.lbnumber.AutoSize = true;
            this.lbnumber.Location = new System.Drawing.Point(163, 219);
            this.lbnumber.Name = "lbnumber";
            this.lbnumber.Size = new System.Drawing.Size(0, 20);
            this.lbnumber.TabIndex = 4;
            // 
            // numberRow
            // 
            this.numberRow.AutoSize = true;
            this.numberRow.Location = new System.Drawing.Point(163, 219);
            this.numberRow.Name = "numberRow";
            this.numberRow.Size = new System.Drawing.Size(50, 20);
            this.numberRow.TabIndex = 5;
            this.numberRow.Text = "label2";
            // 
            // BookingGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 450);
            this.Controls.Add(this.numberRow);
            this.Controls.Add(this.lbnumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.booking);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BookingGUI";
            this.Text = "BookingGUI";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button booking;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbnumber;
        private System.Windows.Forms.Label numberRow;
    }
}