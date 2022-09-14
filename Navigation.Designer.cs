namespace PG_System
{
    partial class Navigation
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientsRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelBookingRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeShiftsRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientsRecordsToolStripMenuItem,
            this.hotelBookingRecordsToolStripMenuItem,
            this.employeeShiftsRecordsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientsRecordsToolStripMenuItem
            // 
            this.clientsRecordsToolStripMenuItem.Name = "clientsRecordsToolStripMenuItem";
            this.clientsRecordsToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.clientsRecordsToolStripMenuItem.Text = "Clients records";
            // 
            // hotelBookingRecordsToolStripMenuItem
            // 
            this.hotelBookingRecordsToolStripMenuItem.Name = "hotelBookingRecordsToolStripMenuItem";
            this.hotelBookingRecordsToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.hotelBookingRecordsToolStripMenuItem.Text = "Hotel Booking records";
            // 
            // employeeShiftsRecordsToolStripMenuItem
            // 
            this.employeeShiftsRecordsToolStripMenuItem.Name = "employeeShiftsRecordsToolStripMenuItem";
            this.employeeShiftsRecordsToolStripMenuItem.Size = new System.Drawing.Size(144, 20);
            this.employeeShiftsRecordsToolStripMenuItem.Text = "Employee shifts records";
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Navigation";
            this.Text = "Navigation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientsRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelBookingRecordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeShiftsRecordsToolStripMenuItem;
    }
}