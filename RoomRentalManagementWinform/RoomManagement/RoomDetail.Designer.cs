namespace RoomRentalManagementWinform.RoomManagement
{
    partial class RoomDetail
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
            this.roomID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roomName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numOfLiving = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.floor = new System.Windows.Forms.ComboBox();
            this.area = new System.Windows.Forms.ComboBox();
            this.maxPerson = new System.Windows.Forms.ComboBox();
            this.price = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // roomID
            // 
            this.roomID.Location = new System.Drawing.Point(160, 38);
            this.roomID.Name = "roomID";
            this.roomID.ReadOnly = true;
            this.roomID.Size = new System.Drawing.Size(156, 27);
            this.roomID.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã phòng";
            // 
            // roomName
            // 
            this.roomName.Location = new System.Drawing.Point(160, 83);
            this.roomName.Name = "roomName";
            this.roomName.Size = new System.Drawing.Size(156, 27);
            this.roomName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên phòng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tầng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số người ở tối đa";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Diện tích";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Giá";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Số người đang ở";
            // 
            // numOfLiving
            // 
            this.numOfLiving.Location = new System.Drawing.Point(540, 83);
            this.numOfLiving.Name = "numOfLiving";
            this.numOfLiving.Size = new System.Drawing.Size(156, 27);
            this.numOfLiving.TabIndex = 13;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 258);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(678, 138);
            this.dataGridView1.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(380, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 17;
            this.button1.Text = "Cập nhật";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(265, 409);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 18;
            this.button2.Text = "Hủy";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // floor
            // 
            this.floor.FormattingEnabled = true;
            this.floor.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.floor.Location = new System.Drawing.Point(160, 133);
            this.floor.Name = "floor";
            this.floor.Size = new System.Drawing.Size(156, 28);
            this.floor.TabIndex = 19;
            // 
            // area
            // 
            this.area.FormattingEnabled = true;
            this.area.Items.AddRange(new object[] {
            "20",
            "25",
            "30"});
            this.area.Location = new System.Drawing.Point(160, 183);
            this.area.Name = "area";
            this.area.Size = new System.Drawing.Size(156, 28);
            this.area.TabIndex = 20;
            // 
            // maxPerson
            // 
            this.maxPerson.FormattingEnabled = true;
            this.maxPerson.Location = new System.Drawing.Point(540, 35);
            this.maxPerson.Name = "maxPerson";
            this.maxPerson.Size = new System.Drawing.Size(156, 28);
            this.maxPerson.TabIndex = 21;
            // 
            // price
            // 
            this.price.FormattingEnabled = true;
            this.price.Items.AddRange(new object[] {
            "2000000",
            "2500000",
            "3000000"});
            this.price.Location = new System.Drawing.Point(540, 137);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(156, 28);
            this.price.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Danh sách người thuê";
            // 
            // RoomDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.price);
            this.Controls.Add(this.maxPerson);
            this.Controls.Add(this.area);
            this.Controls.Add(this.floor);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.numOfLiving);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.roomName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roomID);
            this.Name = "RoomDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết phòng";
            this.Load += new System.EventHandler(this.RoomDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox roomID;
        private Label label1;
        private TextBox roomName;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private TextBox numOfLiving;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private ComboBox floor;
        private ComboBox area;
        private ComboBox maxPerson;
        private ComboBox price;
        private Label label7;
    }
}