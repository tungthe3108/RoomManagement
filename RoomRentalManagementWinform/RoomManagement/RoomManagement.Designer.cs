namespace RoomRentalManagementWinform.RoomManagement
{
    partial class RoomManagement
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
            this.label3 = new System.Windows.Forms.Label();
            this.roomName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numOfPerson = new System.Windows.Forms.ComboBox();
            this.area = new System.Windows.Forms.ComboBox();
            this.price = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.deleteRoombtn = new System.Windows.Forms.Button();
            this.addRoombtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 223);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(861, 264);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên phòng";
            // 
            // roomName
            // 
            this.roomName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomName.Location = new System.Drawing.Point(119, 26);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(151, 27);
            this.roomName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Giá";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số người ở tối đa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Diện tích";
            // 
            // numOfPerson
            // 
            this.numOfPerson.FormattingEnabled = true;
            this.numOfPerson.Location = new System.Drawing.Point(499, 26);
            this.numOfPerson.Name = "numOfPerson";
            this.numOfPerson.Size = new System.Drawing.Size(151, 28);
            this.numOfPerson.TabIndex = 10;
            // 
            // area
            // 
            this.area.FormattingEnabled = true;
            this.area.Location = new System.Drawing.Point(119, 67);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(151, 28);
            this.area.TabIndex = 11;
            // 
            // price
            // 
            this.price.FormattingEnabled = true;
            this.price.Location = new System.Drawing.Point(499, 67);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(151, 28);
            this.price.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.deleteRoombtn);
            this.groupBox1.Controls.Add(this.addRoombtn);
            this.groupBox1.Location = new System.Drawing.Point(727, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 130);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thao tác";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Làm mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteRoombtn
            // 
            this.deleteRoombtn.Location = new System.Drawing.Point(15, 59);
            this.deleteRoombtn.Name = "deleteRoombtn";
            this.deleteRoombtn.Size = new System.Drawing.Size(123, 29);
            this.deleteRoombtn.TabIndex = 1;
            this.deleteRoombtn.Text = "Xóa phòng";
            this.deleteRoombtn.UseVisualStyleBackColor = true;
            this.deleteRoombtn.Click += new System.EventHandler(this.deleteRoombtn_Click);
            // 
            // addRoombtn
            // 
            this.addRoombtn.Location = new System.Drawing.Point(15, 26);
            this.addRoombtn.Name = "addRoombtn";
            this.addRoombtn.Size = new System.Drawing.Size(123, 29);
            this.addRoombtn.TabIndex = 0;
            this.addRoombtn.Text = "Thêm phòng";
            this.addRoombtn.UseVisualStyleBackColor = true;
            this.addRoombtn.Click += new System.EventHandler(this.addRoombtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(34, 493);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 17;
            this.button2.Text = "Đăng xuất";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 493);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 34;
            this.button3.Text = "Quay lại";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // RoomManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 531);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.price);
            this.Controls.Add(this.area);
            this.Controls.Add(this.numOfPerson);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.roomName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RoomManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phòng";
            this.Load += new System.EventHandler(this.RoomManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView1;
        private Label label3;
        private TextBox roomName;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox numOfPerson;
        private ComboBox area;
        private ComboBox price;
        private GroupBox groupBox1;
        private Button deleteRoombtn;
        private Button addRoombtn;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}