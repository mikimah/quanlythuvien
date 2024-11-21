namespace QuanLiThuVien
{
    partial class TimKiemSach
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
            this.dataView1 = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGenre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShelf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel21 = new System.Windows.Forms.FlowLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.tb_Shelf = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_Author = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_DateP = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_Genre = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_IdB = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_NameB = new System.Windows.Forms.TextBox();
            this.btn_Cancel1 = new System.Windows.Forms.Button();
            this.btn_Save1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel21.SuspendLayout();
            this.flowLayoutPanel11.SuspendLayout();
            this.flowLayoutPanel10.SuspendLayout();
            this.flowLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel8.SuspendLayout();
            this.flowLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataView1
            // 
            this.dataView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colGenre,
            this.colAuthor,
            this.colDateP,
            this.colShelf});
            this.dataView1.Location = new System.Drawing.Point(12, 238);
            this.dataView1.Name = "dataView1";
            this.dataView1.RowHeadersWidth = 51;
            this.dataView1.RowTemplate.Height = 24;
            this.dataView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataView1.Size = new System.Drawing.Size(829, 200);
            this.dataView1.TabIndex = 2;
            this.dataView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView1_CellClick_1);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "IdB";
            this.colId.HeaderText = "Mã sách";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.Width = 125;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "NameB";
            this.colName.HeaderText = "Tên sách";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.Width = 125;
            // 
            // colGenre
            // 
            this.colGenre.DataPropertyName = "Genre";
            this.colGenre.HeaderText = "Thể loại";
            this.colGenre.MinimumWidth = 6;
            this.colGenre.Name = "colGenre";
            this.colGenre.Width = 125;
            // 
            // colAuthor
            // 
            this.colAuthor.DataPropertyName = "Author";
            this.colAuthor.HeaderText = "Tác giả";
            this.colAuthor.MinimumWidth = 6;
            this.colAuthor.Name = "colAuthor";
            this.colAuthor.Width = 125;
            // 
            // colDateP
            // 
            this.colDateP.DataPropertyName = "DateP";
            this.colDateP.HeaderText = "Ngày xuất bản";
            this.colDateP.MinimumWidth = 6;
            this.colDateP.Name = "colDateP";
            this.colDateP.Width = 125;
            // 
            // colShelf
            // 
            this.colShelf.DataPropertyName = "Shelf";
            this.colShelf.HeaderText = "Giá sách";
            this.colShelf.MinimumWidth = 6;
            this.colShelf.Name = "colShelf";
            this.colShelf.Width = 125;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.flowLayoutPanel21);
            this.panel2.Controls.Add(this.flowLayoutPanel11);
            this.panel2.Controls.Add(this.flowLayoutPanel10);
            this.panel2.Controls.Add(this.flowLayoutPanel9);
            this.panel2.Controls.Add(this.flowLayoutPanel8);
            this.panel2.Controls.Add(this.flowLayoutPanel7);
            this.panel2.Controls.Add(this.btn_Cancel1);
            this.panel2.Controls.Add(this.btn_Save1);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(829, 220);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 56;
            this.label1.Text = "Sách hiện có:";
            // 
            // flowLayoutPanel21
            // 
            this.flowLayoutPanel21.Controls.Add(this.label22);
            this.flowLayoutPanel21.Controls.Add(this.tb_Shelf);
            this.flowLayoutPanel21.Location = new System.Drawing.Point(468, 106);
            this.flowLayoutPanel21.Name = "flowLayoutPanel21";
            this.flowLayoutPanel21.Size = new System.Drawing.Size(177, 36);
            this.flowLayoutPanel21.TabIndex = 55;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 20);
            this.label22.TabIndex = 0;
            this.label22.Text = "Giá sách:";
            // 
            // tb_Shelf
            // 
            this.tb_Shelf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tb_Shelf.FormattingEnabled = true;
            this.tb_Shelf.Items.AddRange(new object[] {
            "A1",
            "A2",
            "B1",
            "B2",
            "C1",
            "C2",
            "D1",
            "D2",
            "E1",
            "E2",
            "F1",
            "F2",
            "G1",
            "G2"});
            this.tb_Shelf.Location = new System.Drawing.Point(90, 3);
            this.tb_Shelf.Name = "tb_Shelf";
            this.tb_Shelf.Size = new System.Drawing.Size(61, 24);
            this.tb_Shelf.TabIndex = 1;
            this.tb_Shelf.SelectedIndexChanged += new System.EventHandler(this.tb_Shelf_SelectedIndexChanged);
            // 
            // flowLayoutPanel11
            // 
            this.flowLayoutPanel11.Controls.Add(this.label11);
            this.flowLayoutPanel11.Controls.Add(this.tb_Author);
            this.flowLayoutPanel11.Location = new System.Drawing.Point(468, 22);
            this.flowLayoutPanel11.Name = "flowLayoutPanel11";
            this.flowLayoutPanel11.Size = new System.Drawing.Size(338, 36);
            this.flowLayoutPanel11.TabIndex = 54;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tác giả:";
            // 
            // tb_Author
            // 
            this.tb_Author.Location = new System.Drawing.Point(78, 3);
            this.tb_Author.Name = "tb_Author";
            this.tb_Author.Size = new System.Drawing.Size(225, 22);
            this.tb_Author.TabIndex = 1;
            this.tb_Author.TextChanged += new System.EventHandler(this.tb_Author_TextChanged);
            // 
            // flowLayoutPanel10
            // 
            this.flowLayoutPanel10.Controls.Add(this.label10);
            this.flowLayoutPanel10.Controls.Add(this.dtp_DateP);
            this.flowLayoutPanel10.Location = new System.Drawing.Point(468, 64);
            this.flowLayoutPanel10.Name = "flowLayoutPanel10";
            this.flowLayoutPanel10.Size = new System.Drawing.Size(258, 36);
            this.flowLayoutPanel10.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ngày xuất bản:";
            // 
            // dtp_DateP
            // 
            this.dtp_DateP.Enabled = false;
            this.dtp_DateP.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DateP.Location = new System.Drawing.Point(129, 3);
            this.dtp_DateP.Name = "dtp_DateP";
            this.dtp_DateP.Size = new System.Drawing.Size(109, 22);
            this.dtp_DateP.TabIndex = 1;
            // 
            // flowLayoutPanel9
            // 
            this.flowLayoutPanel9.Controls.Add(this.label9);
            this.flowLayoutPanel9.Controls.Add(this.tb_Genre);
            this.flowLayoutPanel9.Location = new System.Drawing.Point(16, 67);
            this.flowLayoutPanel9.Name = "flowLayoutPanel9";
            this.flowLayoutPanel9.Size = new System.Drawing.Size(257, 36);
            this.flowLayoutPanel9.TabIndex = 52;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Thể loại:";
            // 
            // tb_Genre
            // 
            this.tb_Genre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tb_Genre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tb_Genre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tb_Genre.FormattingEnabled = true;
            this.tb_Genre.Items.AddRange(new object[] {
            "Tiểu thuyết",
            "Phi tiểu thuyết",
            "Giáo dục",
            "Nghệ thuật",
            "Thiếu nhi",
            "Tạp chí và báo chí",
            "Khác..."});
            this.tb_Genre.Location = new System.Drawing.Point(82, 3);
            this.tb_Genre.Name = "tb_Genre";
            this.tb_Genre.Size = new System.Drawing.Size(155, 24);
            this.tb_Genre.TabIndex = 43;
            this.tb_Genre.SelectedIndexChanged += new System.EventHandler(this.tb_Genre_SelectedIndexChanged);
            // 
            // flowLayoutPanel8
            // 
            this.flowLayoutPanel8.Controls.Add(this.label8);
            this.flowLayoutPanel8.Controls.Add(this.tb_IdB);
            this.flowLayoutPanel8.Location = new System.Drawing.Point(16, 106);
            this.flowLayoutPanel8.Name = "flowLayoutPanel8";
            this.flowLayoutPanel8.Size = new System.Drawing.Size(317, 36);
            this.flowLayoutPanel8.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mã sách:";
            // 
            // tb_IdB
            // 
            this.tb_IdB.Location = new System.Drawing.Point(87, 3);
            this.tb_IdB.Name = "tb_IdB";
            this.tb_IdB.Size = new System.Drawing.Size(213, 22);
            this.tb_IdB.TabIndex = 1;
            this.tb_IdB.TextChanged += new System.EventHandler(this.tb_IdB_TextChanged);
            // 
            // flowLayoutPanel7
            // 
            this.flowLayoutPanel7.Controls.Add(this.label7);
            this.flowLayoutPanel7.Controls.Add(this.tb_NameB);
            this.flowLayoutPanel7.Location = new System.Drawing.Point(16, 25);
            this.flowLayoutPanel7.Name = "flowLayoutPanel7";
            this.flowLayoutPanel7.Size = new System.Drawing.Size(338, 36);
            this.flowLayoutPanel7.TabIndex = 51;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tên sách:";
            // 
            // tb_NameB
            // 
            this.tb_NameB.Location = new System.Drawing.Point(92, 3);
            this.tb_NameB.Name = "tb_NameB";
            this.tb_NameB.Size = new System.Drawing.Size(225, 22);
            this.tb_NameB.TabIndex = 1;
            this.tb_NameB.TextChanged += new System.EventHandler(this.tb_NameB_TextChanged);
            // 
            // btn_Cancel1
            // 
            this.btn_Cancel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel1.Location = new System.Drawing.Point(733, 177);
            this.btn_Cancel1.Name = "btn_Cancel1";
            this.btn_Cancel1.Size = new System.Drawing.Size(93, 40);
            this.btn_Cancel1.TabIndex = 49;
            this.btn_Cancel1.Text = "Huỷ";
            this.btn_Cancel1.UseVisualStyleBackColor = true;
            this.btn_Cancel1.Click += new System.EventHandler(this.btn_Cancel1_Click);
            // 
            // btn_Save1
            // 
            this.btn_Save1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save1.Location = new System.Drawing.Point(634, 177);
            this.btn_Save1.Name = "btn_Save1";
            this.btn_Save1.Size = new System.Drawing.Size(93, 40);
            this.btn_Save1.TabIndex = 48;
            this.btn_Save1.Text = "Xác nhận";
            this.btn_Save1.UseVisualStyleBackColor = true;
            this.btn_Save1.Click += new System.EventHandler(this.btn_Save1_Click);
            // 
            // TimKiemSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(853, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataView1);
            this.Name = "TimKiemSach";
            this.Text = "Tìm kiếm sách";
            this.Load += new System.EventHandler(this.TimKiemSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel21.ResumeLayout(false);
            this.flowLayoutPanel21.PerformLayout();
            this.flowLayoutPanel11.ResumeLayout(false);
            this.flowLayoutPanel11.PerformLayout();
            this.flowLayoutPanel10.ResumeLayout(false);
            this.flowLayoutPanel10.PerformLayout();
            this.flowLayoutPanel9.ResumeLayout(false);
            this.flowLayoutPanel9.PerformLayout();
            this.flowLayoutPanel8.ResumeLayout(false);
            this.flowLayoutPanel8.PerformLayout();
            this.flowLayoutPanel7.ResumeLayout(false);
            this.flowLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Save1;
        private System.Windows.Forms.Button btn_Cancel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel11;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_Author;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_DateP;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel9;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox tb_Genre;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_IdB;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_NameB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGenre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShelf;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox tb_Shelf;
        private System.Windows.Forms.Label label1;
    }
}