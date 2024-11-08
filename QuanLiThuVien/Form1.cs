using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThuVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //things
        List<Sach> dss = new List<Sach>();
        List<ThanhVien> dstv = new List<ThanhVien>();
        string statusBtn = "";
        int statusNum = -1;
        Sach s1 = new Sach("A01","Why","idk","Miki",DateTime.Now.Date);
        Sach s2 = new Sach("A02", "Why not", "idk", "Miki", DateTime.Now.Date);
        Sach s3 = new Sach("A03", "Why not? ill tell u", "idk", "Miki", DateTime.Now.Date);

        private void loadListM(DataGridView dataView3, List<ThanhVien> dstv)
        {
            dataView3.DataSource = dstv.ToList();
        }
        private void loadListB(DataGridView dataView1,List<Sach> dss)
        {
            dataView1.DataSource = dss.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dss.Add(s1);
            dss.Add(s2);
            dss.Add(s3);
            loadListB(dataView2, dss);
            loadListM(dataView3,dstv);
            
        }


        //enable
        void enableTb(bool enable) {
            int num = tabControl1.SelectedIndex;
            if (num == 1)
            {
                tb_IdB.Enabled = tb_NameB.Enabled = tb_Genre.Enabled = tb_Author.Enabled = dtp_DateP.Enabled = enable;
            }else if(num ==2)
            {
                tb_idM.Enabled = tb_nameM.Enabled = tb_classM.Enabled = tb_phoneM.Enabled = tb_addressM.Enabled = enable;
            }
        }//re-usable
        void enableBtn(bool enable1, bool enable2) {
            int num = tabControl1.SelectedIndex ;
            if (num == 1) {
                btn_Save2.Enabled = enable1;
                btn_Cancel2.Enabled = enable2;
            }
            else if(num==2)
            {
                btn_Save3.Enabled = enable1;
                btn_Cancel3.Enabled = enable2;
            }

        }//re-usaeble
        void enableCtrl(bool a1, bool a2, bool a3, bool a4) {
            int num = tabControl1.SelectedIndex;
            if (num == 1)
            { btn_Add2.Enabled = a1;
                btn_Adjust2.Enabled = a2;
                btn_Search2.Enabled = a3;
                btn_Delete2.Enabled = a4;
            }else if(num == 2)
            {
                btn_Add3.Enabled = a1;
                btn_Adjust3.Enabled = a2;
                btn_Search3.Enabled = a3;
                btn_Delete3.Enabled = a4;

            }
        }//re-usable




        //Nút thêm
        bool checkSameB()
        {
            int num = tabControl1.SelectedIndex;
            if (num == 1)
            {
                for (int i = 0; i < dss.Count; i++)
                {

                    if (dss[i].IdB == tb_IdB.Text && i != statusNum) return true;
                }
                return false;
            }else if( num == 2)
            {
                for(int i = 0;i<dstv.Count; i++)
                {
                    if (dstv[i].IdTV == tb_idM.Text && i != statusNum) return true;
                }
                return false;
            }return false;
        } //re-useable
        bool checkEmpty()
        {
            int num = tabControl1.SelectedIndex;
            if (num == 1)
            {
                if (tb_IdB.Text == "" || tb_NameB.Text == "" || tb_Genre.Text == "" || tb_Author.Text == "")
                {
                    return true;
                }
            }
            else if (num == 2) {
                if (tb_classM.Text == "" || tb_addressM.Text == "" || tb_idM.Text == "" || tb_phoneM.Text == "" || tb_nameM.Text == "")
                {
                    return true;
                }
               
            }
            return false;
        }//re-useable
        private void btn_Add2_Click(object sender, EventArgs e)
        {
            statusBtn = "Add";
            enableBtn(true, true);
            enableTb(true);
            enableCtrl(true, false, false, false);
            dataView2.Enabled = false;


        }
        private void btn_Add3_Click(object sender, EventArgs e)
        {
            statusBtn = "Add";
            enableBtn(true, true);
            enableTb(true);
            enableCtrl(true, false, false, false);
            dataView3.Enabled = false;
        }
        



        //Nút sửa
        private void dataView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (statusBtn == "Search")
            {
                for(int i = 0; i < dss.Count; i++)
                {
                    if (dss[i].IdB == tb_IdB.Text) statusNum = i;
                }
            }
            else { statusNum = e.RowIndex; }  
        }
        private void dataView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (statusBtn == "Search")
            {
                for (int i = 0; i < dstv.Count; i++)
                {
                    if (dstv[i].IdTV == tb_idM.Text) statusNum = i;
                }
            }
            else { statusNum = e.RowIndex; }
        }
        private void btn_Adjust2_Click(object sender, EventArgs e)
        {
            if (statusNum <0)
            {
                MessageBox.Show("Hãy chọn 1 đối tượng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    statusBtn = "Adjust";
                    enableBtn(true, true);
                    enableTb(true);
                    enableCtrl(false, true, false, false);
                    tb_IdB.Text = dss[statusNum].IdB;
                    tb_NameB.Text = dss[statusNum].NameB;
                    tb_Genre.Text = dss[statusNum].Genre;
                    tb_Author.Text = dss[statusNum].Author;
                    dtp_DateP.Value = dss[statusNum].DateP;
                   
                    dataView2.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong!","Hey!Look!Listen!",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearTb();
                    enableBtn(false, false);
                    enableTb(false);
                    dataView2.Enabled = true;
                    statusNum = -1;
                    statusBtn = "";
                }


            }
        }
        private void btn_Adjust3_Click(object sender, EventArgs e)
        {
            if (statusNum < 0)
            {
                MessageBox.Show("Hãy chọn 1 đối tượng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    statusBtn = "Adjust";
                    enableBtn(true, true);
                    enableTb(true);
                    enableCtrl(false, true, false, false);
                    tb_idM.Text = dstv[statusNum].IdTV;
                    tb_nameM.Text=dstv[statusNum].NameTV;
                    tb_classM.Text=dstv[statusNum].ClassTV;
                    tb_phoneM.Text = dstv[statusNum].Phone;
                    tb_addressM.Text = dstv[statusNum].Address;
                    dataView3.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong!", "Hey!Look!Listen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearTb();
                    enableBtn(false, false);
                    enableTb(false);
                    dataView3.Enabled = true;
                    statusNum = -1;
                    statusBtn = "";
                }


            }
        }




        //Nút xoá
        private void btn_Delete2_Click(object sender, EventArgs e)
        {
            try
            {
                if (statusNum < 0) { MessageBox.Show("Hãy chọn 1 đối tượng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    DialogResult kq = MessageBox.Show("Bạn có chắc là muốn xoá đối tượng này?", "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        dss.RemoveAt(statusNum);
                        loadListB(dataView2, dss);
                        MessageBox.Show("Đã xoá thành công!", "Hey!Look!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Something went wrong!", "Hey!Look!Listen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            statusNum = -1;
        }
        private void btn_Delete3_Click(object sender, EventArgs e)
        {
            try
            {
                if (statusNum < 0) { MessageBox.Show("Hãy chọn 1 đối tượng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    DialogResult kq = MessageBox.Show("Bạn có chắc là muốn xoá đối tượng này?", "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        dstv.RemoveAt(statusNum);
                        loadListM(dataView3, dstv);
                        MessageBox.Show("Đã xoá thành công!", "Hey!Look!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong!", "Hey!Look!Listen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            statusNum = -1;
        }


        //Nút tìm kiếm
        private void btn_Search2_Click(object sender, EventArgs e)
        {
            tb_IdB.Enabled = true;
            statusBtn = "Search";
            
            enableBtn(false, true);
        }
        private void btn_Search3_Click(object sender, EventArgs e)
        {
            tb_idM.Enabled = true;
            statusBtn = "Search";
            enableBtn(false, true);
        }
        private void tb_IdB_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<Sach> s1 = new List<Sach>();
                foreach(var item in dss)
                {
                    if (item.IdB.Contains(tb_IdB.Text))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView2, s1);
            }
        }
        private void tb_idM_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<ThanhVien> m1 = new List<ThanhVien>();
                foreach (var item in dstv)
                {
                    if (item.IdTV.Contains(tb_idM.Text))
                    {
                        m1.Add(item);
                    }
                }
                loadListM(dataView3, m1);
            }
        }




        //Nút lưu & huỷ
        private void btn_Save2_Click(object sender, EventArgs e)
        {
            if(statusBtn == "Add")
            {
                if (!checkEmpty())
                {
                    string id = tb_IdB.Text;
                    string name = tb_NameB.Text;
                    string genre = tb_Genre.Text;
                    string author = tb_Author.Text;
                    DateTime date = dtp_DateP.Value.Date;
                    if (!checkSameB())
                    {
                        Sach sach = new Sach(id, name, genre, author, date);
                        dss.Add(sach);
                        loadListB(dataView2, dss);
                        MessageBox.Show("Đã thêm thành công!", "Hey!Look!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        enableBtn(false, false);
                        enableTb(false);
                        enableCtrl(true, true, true, true);
                        dataView2.Enabled = true;
                        
                        statusBtn = "";
                        clearTb();
                    }
                    else
                    {
                        MessageBox.Show("Mã sách bị trùng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else { MessageBox.Show("Có thông tin bị thiếu","Hey!",MessageBoxButtons.OK, MessageBoxIcon.Error); }
               
            }else if(statusBtn == "Adjust")
            {
                if (checkEmpty())
                {
                    MessageBox.Show("Có thông tin bị thiếu", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (checkSameB())
                    {
                        MessageBox.Show("Mã sách bị trùng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dss[statusNum].IdB = tb_IdB.Text;
                        dss[statusNum].NameB = tb_NameB.Text;
                        dss[statusNum].Genre = tb_Genre.Text;
                        dss[statusNum].Author = tb_Author.Text;
                        dss[statusNum].DateP = dtp_DateP.Value.Date;
                        loadListB(dataView2, dss);
                        MessageBox.Show("Đã sửa thành công!", "Hey!Look!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        enableBtn(false, false);
                        enableTb(false);
                        enableCtrl(true, true, true, true);
                        dataView2.Enabled = true;
                      
                        statusBtn = "";
                        statusNum = -1;
                        clearTb();
                    }
                  
                }
              

            }

        }
        private void btn_Save3_Click(object sender, EventArgs e)
        {
            if (statusBtn == "Add")
            {
                ThanhVien tv = new ThanhVien();
                tv.NameTV = tb_nameM.Text;
                tv.IdTV = tb_idM.Text;
                tv.Phone = tb_phoneM.Text;
                tv.Address = tb_addressM.Text;
                tv.ClassTV = tb_classM.Text;
                if (checkEmpty())
                    MessageBox.Show("Có thông tin bị thiếu", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {

                    if (!checkSameB())
                    {
                        dstv.Add(tv);
                        loadListM(dataView3, dstv);
                        MessageBox.Show("Đã thêm thành công!", "Hey!Look!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        enableBtn(false, false);
                        enableTb(false);
                        enableCtrl(true, true, true, true);
                        dataView3.Enabled = true;

                        statusBtn = "";
                        clearTb();

                    }
                    else
                        MessageBox.Show("Mã thành viên bị trùng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if(statusBtn == "Adjust")
            {
                if (checkEmpty())
                {
                    MessageBox.Show("Có thông tin bị thiếu", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (checkSameB())
                    {
                        MessageBox.Show("Mã sách bị trùng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dstv[statusNum].IdTV=tb_idM.Text;
                        dstv[statusNum].NameTV=tb_nameM.Text;
                        dstv[statusNum].ClassTV=tb_classM.Text;
                        dstv[statusNum].Phone=tb_phoneM.Text;
                        dstv[statusNum].Address=tb_addressM.Text;
                        loadListM(dataView3, dstv);
                        MessageBox.Show("Đã sửa thành công!", "Hey!Look!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        enableBtn(false, false);
                        enableTb(false);
                        enableCtrl(true, true, true, true);
                        dataView3.Enabled = true;

                        statusBtn = "";
                        statusNum = -1;
                        clearTb();
                    }

                }

            }
        }


        private void btnHuy()
        {
            int num = tabControl1.SelectedIndex;
            enableBtn(false, false);
            enableTb(false);
            enableCtrl(true,true,true,true);
            if (num == 1)
            {
                dataView2.Enabled = true;
                loadListB(dataView2, dss);
            }else if (num == 2)
            {
                dataView3.Enabled = true;
                loadListM(dataView3, dstv);
            }
            statusBtn = "";
            statusNum = -1;
            clearTb();
        }//re-usable
        private void btn_Cancel2_Click(object sender, EventArgs e)
        {
           btnHuy();
        }
        private void btn_Cancel3_Click(object sender, EventArgs e)
        {
            btnHuy();
        }
        void clearTb()
        {
            int num = tabControl1.SelectedIndex;
            if (num == 1)
            {
                tb_IdB.Text = "";
                tb_NameB.Text = "";
                tb_Genre.Text = "";
                tb_Author.Text = "";
                dtp_DateP.Value = DateTime.Now;
            }
            else if (num == 2) {
                tb_idM.Text = "";
                tb_nameM.Text = "";
                tb_classM.Text = "";
                tb_addressM.Text = "";
                tb_phoneM.Text = "";
            }
           
        }//re-useable






        // Nút thoát
        private void btnThoat()
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc không?", "Hey!Look!Listen!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Close();
            }
        }//re-useable
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            btnThoat();
        }

        private void btn_Exit2_Click(object sender, EventArgs e)
        {
            btnThoat();
        }

        private void btn_Exit3_Click(object sender, EventArgs e)
        {
            btnThoat();
        }

      
    }
}
