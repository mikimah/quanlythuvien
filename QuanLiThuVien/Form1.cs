using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace QuanLiThuVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Things
        List<Sach> dss = new List<Sach>();
        List<ThanhVien> dstv = new List<ThanhVien>();
        List<DangKi> dsdk = new List<DangKi>();
        string statusBtn = "";
        int statusNum = -1;
        private void Form1_Load(object sender, EventArgs e)
        {
         
            loadFileSach("dss.bin");
            loadFileThanhVien("dstv.bin");
            loadFileDangKi("dsdk.bin");
            loadListB(dataView2, dss);
            loadListM(dataView3,dstv);
            loadListDK(dataView1, dsdk);
            
        }

        private void loadListM(DataGridView dataView3, List<ThanhVien> dstv)
        {
            dataView3.DataSource = dstv.ToList();
        }
        private void loadListB(DataGridView dataView1, List<Sach> dss)
        {
            dataView1.DataSource = dss.ToList();
        }
        private void loadListDK(DataGridView dataView1, List<DangKi> dsdk)
        {
            dataView1.DataSource = dsdk.ToList();
        }




        //Chức năng phụ
        void enableTb(bool enable)
        { 
            //Bật tắt textbox
            int num = tabControl1.SelectedIndex;//Dùng được nhiều lần dựa vào thứ tự tab
            if (num == 1)
            {
                tb_IdB.Enabled = tb_NameB.Enabled = tb_Genre.Enabled = tb_Author.Enabled = dtp_DateP.Enabled = tb_Amount.Enabled = enable;
            }else if(num ==2)
            {
                tb_idM.Enabled = tb_nameM.Enabled = tb_classM.Enabled = tb_phoneM.Enabled = tb_addressM.Enabled = enable;
            }else if (num == 0)
            {
                tb_IdB_DK.Enabled=tb_IdTV_DK.Enabled=tb_NameB_DK.Enabled=tb_NameTV_DK.Enabled=tb_NumOfDate.Enabled=enable;
            }
        }//re-usable
        void enableBtn(bool enable1, bool enable2) {
            //Bật tắt nút Lưu & Huỷ
            int num = tabControl1.SelectedIndex ;
            if (num == 1) {
                btn_Save2.Enabled = enable1;
                btn_Cancel2.Enabled = enable2;
            }
            else if(num==2)
            {
                btn_Save3.Enabled = enable1;
                btn_Cancel3.Enabled = enable2;
            }else if (num == 0)
            {
                btn_Save1.Enabled = enable1;
                btn_Cancel1.Enabled = enable2;
            }

        }//re-usaeble
        void enableCtrl(bool a1, bool a2, bool a3, bool a4) {
            //Bật tắt nút Thêm Xoá Sửa Tìm kiếm
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

            }else if (num == 0)
            {
                btn_Add1.Enabled = a1;
                btn_Adjust1.Enabled = a2;
                btn_Search1.Enabled = a3;
                btn_Delete1.Enabled = a4;
            }
        }//re-usable
        bool checkSameB()
        {
            //Kiểm tra trùng mã
            int num = tabControl1.SelectedIndex;
            if (num == 1)
            {
                for (int i = 0; i < dss.Count; i++)
                {

                    if (dss[i].IdB == tb_IdB.Text && i != statusNum) return true;
                }
                return false;
            }
            else if (num == 2)
            {
                for (int i = 0; i < dstv.Count; i++)
                {
                    if (dstv[i].IdTV == tb_idM.Text && i != statusNum) return true;
                }
                return false;
            }
            else if (num == 0)
            {
                for (int i = 0; i < dsdk.Count; i++)
                {
                    if (dsdk[i].IdB_DK == tb_IdB_DK.Text && i != statusNum) return true;
                }
                return false;
            }
            return false;
        } //re-useable
        bool checkEmpty()
        {//Kiểm tra có bỏ sót thành phần nào không
            int num = tabControl1.SelectedIndex;
            if (num == 1)
            {
                if (tb_NameB.Text == "" || tb_Genre.Text == "" || tb_Author.Text == ""||tb_IdB.Text=="")
                {
                    return true;
                }
            }
            else if (num == 2)
            {
                if (tb_classM.Text == "" || tb_addressM.Text == "" || tb_idM.Text == "" || tb_phoneM.Text == "" || tb_nameM.Text == "")
                {
                    return true;
                }

            }
            else if (num == 0)
            {
                if (tb_IdB_DK.Text == "" || tb_IdTV_DK.Text == "" || tb_NameB_DK.Text == "" || tb_NameTV_DK.Text == ""||tb_NumOfDate.Text=="")
                {
                    return true;
                }
            }
            return false;
        }//re-useable
        bool checkLength(string id)
        {//Kiểm tra độ dài của mã số
            int num = tabControl1.SelectedIndex;
            switch (num){
                case 1:
                    if (id.Length == 7)
                    {   //got lazy :P
                        if(id.Substring(0,1)=="A"|| id.Substring(0, 1) == "B"|| id.Substring(0, 1) == "C"|| id.Substring(0, 1) == "D"|| id.Substring(0, 1) == "E"|| id.Substring(0, 1) == "F"|| id.Substring(0, 1) == "G")
                        {
                            return true;
                        }

                    }
                    return false;
                case 2:
                    if(id.Length == 10)
                    {
                        if(id.Substring(0,2)=="DH") return true;
                    }return false;
                default:
                    return false;
            }
            
        }// re-useable
        bool checkGenre(string id,string genre)
        {
            //kiểm tra xem thể loại có đúng với cái kí tự đầu hay ko *phòng trường hợp*
            string firstLetter = id.Substring(0, 1);
            switch (firstLetter)
            {
                case "A":
                    if(genre== "Tiểu thuyết") { return true; }
                    return false;
                case "B":
                    if(genre == "Phi tiểu thuyết")return true;
                    return false;
                case "C":
                    if (genre == "Giáo dục") return true;
                    return false;
                case "D":
                    if (genre == "Nghệ thuật") return true;
                    return false;
                case "E":
                    if (genre == "Thiếu nhi") return true;
                    return false;
                case "F":
                    if (genre == "Tạp chí và báo chí") return true;
                    return false;
                case "G":
                    if (genre == "Khác...") return true;
                    return false;

            }
            return false;
        }
        bool checkSameOnlyIdB(string id)
        {//Kiểm tra xem có bị trùng mã hay ko dùng riêng cho kiểm tra mã sách
            foreach (var item in dss)
            {
                if (item.IdB == id) return true;
            }
            return false;
        }// id book only
        string randomId(string id)
        {
            //Tạo mã sách ngãu nhiên
            Random random = new Random(); //dùng random từ lớp random
            string nums = "0123456789"; // dùng string để dễ lấy thành phần hơn
            bool flag = true;
            string test = id;
            do
            {
                test = id;
                for (int i = 0; i < 6; i++)
                {
                    int num = random.Next(0, 9); //ở đây nums có độ dài là 10 (từ 0 đến 9) nên chức năng next sẽ lấy ngẫu nhiên từ 0 đến 9 
                    test = test + nums[num]; //lấy string + string 

                }
                if (!checkSameOnlyIdB(test)) flag = false;
            } while (flag);
            return test;
        }// id book only
        bool checkExist()
        {
            //kiểm tra mã số tv + mã số sách có tồn tại hay ko
            int num = 0;
            foreach (var item in dstv)
            {
                if (item.IdTV == tb_IdTV_DK.Text) num++;
            }
            foreach (var item in dss)
            {
                if (item.IdB == tb_IdB_DK.Text) num++;
            }
            if (num == 2)
            {
                return true;
            }
            else { return false; }

        }
        bool timB(string a, string b)
        {
            foreach (Sach s in dss)
            {
                if (s.IdB == a && s.NameB == b)
                    return true;
            }
            return false;
        }
        bool timTV(string a, string b)
        {
            foreach (ThanhVien s in dstv)
            {
                if (s.IdTV == a && s.NameTV == b)
                    return true;
            }
            return false;
        }
        void clearTb()
        {
            //làm mới textbox mỗi lần dùng
            int num = tabControl1.SelectedIndex;
            if (num == 1)
            {
                tb_IdB.Text = "";
                tb_NameB.Text = "";
                tb_Genre.Text = "Khác...";
                tb_Author.Text = "";
                tb_Amount.Text = "1";
                dtp_DateP.Value = DateTime.Now;
            }
            else if (num == 2)
            {
                tb_idM.Text = "DH";
                tb_nameM.Text = "";
                tb_classM.Text = "";
                tb_addressM.Text = "";
                tb_phoneM.Text = "";
            }
            else if (num == 0)
            {
                tb_IdB_DK.Text = "";
                tb_IdTV_DK.Text = "";
                tb_NameB_DK.Text = "";
                tb_NameTV_DK.Text = "";
                tb_NumOfDate.Text = "1 tuần";
            }

        }//re-useable
        private void tb_NumOfDate_SelectedIndexChanged(object sender, EventArgs e)
        {//tự động chọn ngày mượn ngày trả
            string test = tb_NumOfDate.Text.Substring(0,1);
            int num = int.Parse(test)*7;
            DateTime dt = dtp_DateS.Value;
            dtp_DateE.Value= dt.AddDays(num);
        }





        //Nút thêm

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
        private void btn_Add1_Click(object sender, EventArgs e)
        {
            statusBtn = "Add";
            enableBtn(true, true);
            enableTb(true);
            enableCtrl(true, false, false, false);
            dataView1.Enabled = false;
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(statusBtn == "Search")
            {
                for(int i = 0; i < dsdk.Count; i++)
                {
                    if (dsdk[i].IdB_DK==tb_IdB_DK.Text) statusNum = i;
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
                    tb_IdB.Enabled = false;
                    tb_Amount.Enabled = false;
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
                    tb_idM.Enabled = false;
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
        private void btn_Adjust1_Click(object sender, EventArgs e)
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
                    tb_NumOfDate.Enabled = false;
                    enableCtrl(false, true, false, false);
                    tb_IdB_DK.Text = dsdk[statusNum].IdB_DK;
                    tb_IdTV_DK.Text = dsdk[statusNum].IdTV_DK;
                    tb_NameB_DK.Text = dsdk[statusNum].NameB_DK;
                    tb_NameTV_DK.Text = dsdk[statusNum].NameTV_DK;
                    dtp_DateS.Value = dsdk[statusNum].DateS;
                    dtp_DateE.Value = dsdk[statusNum].DateE;

                    dataView2.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong!", "Hey!Look!Listen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearTb();
                    enableBtn(false, false);
                    enableTb(false);
                    dataView1.Enabled = true;
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
        private void btn_Delete1_Click(object sender, EventArgs e)
        {
            try
            {
                if (statusNum < 0) { MessageBox.Show("Hãy chọn 1 đối tượng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    DialogResult kq = MessageBox.Show("Bạn có chắc là muốn xoá đối tượng này?", "Hey!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        dsdk.RemoveAt(statusNum);
                        loadListDK(dataView1, dsdk);
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
            tb_NameB.Enabled = true;
            tb_Author.Enabled = true;
            tb_Genre.Enabled = true;
            statusBtn = "Search";
            
            enableBtn(false, true);
        }
        private void btn_Search3_Click(object sender, EventArgs e)
        {
            tb_idM.Enabled = true;
            tb_nameM.Enabled = true;
            statusBtn = "Search";
            enableBtn(false, true);
        }
        private void btn_Search1_Click(object sender, EventArgs e)
        {
            tb_IdB_DK.Enabled = true;
            tb_IdTV_DK.Enabled = true;
            tb_NameB_DK.Enabled = true;
            tb_NameTV_DK.Enabled = true;
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
                    if (item.IdB.Contains(tb_IdB.Text.Trim().ToUpper()))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView2, s1);
            }
        }//textchanged mỗi khi có sự thay đổi trong textbox thì kêu gọi event này, và chạy foreach cứ mỗi thành phần có thông tin trùng với textbox thì sẽ add vào ds tạm r hiện thị lên
        private void tb_idM_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<ThanhVien> m1 = new List<ThanhVien>();
                foreach (var item in dstv)
                {
                    if (item.IdTV.Contains(tb_idM.Text.Trim().ToUpper()))
                    {
                        m1.Add(item);
                    }
                }
                loadListM(dataView3, m1);
            }
        }
        private void tb_nameM_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<ThanhVien> m1 = new List<ThanhVien>();
                foreach (var item in dstv)
                {
                    if (item.NameTV.ToUpper().Contains(tb_nameM.Text.Trim().ToUpper()))
                    {
                        m1.Add(item);
                    }
                }
                loadListM(dataView3, m1);
            }
        }
        private void tb_IdB_DK_TextChanged(object sender, EventArgs e)
        {
            if(statusBtn == "Search")
            {
                List<DangKi> dk1 = new List<DangKi>();
                foreach(var item in dsdk)
                {
                    if (item.IdB_DK.Contains(tb_IdB_DK.Text.Trim().ToUpper()))
                    {
                        dk1.Add(item);
                    }
                }loadListDK(dataView1, dk1);
            }else if(statusBtn == "Add")
            {
                foreach (var item in dss)
                {
                    if (item.IdB==tb_IdB_DK.Text.Trim().ToUpper())
                    {
                        tb_NameB_DK.Text = item.NameB;
                    }
                }
                
            }
        }
        private void tb_IdTV_DK_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<DangKi> dk1 = new List<DangKi>();
                foreach (var item in dsdk)
                {
                    if (item.IdTV_DK.Contains(tb_IdTV_DK.Text.Trim().ToUpper()))
                    {
                        dk1.Add(item);
                    }
                }
                loadListDK(dataView1, dk1);
            }
            else if (statusBtn == "Add")
            {
                foreach (var item in dstv)
                {
                    if (item.IdTV == tb_IdTV_DK.Text.Trim().ToUpper())
                    {
                        tb_NameTV_DK.Text = item.NameTV;
                    }
                }

            }
        }
        private void tb_NameB_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<Sach> s1 = new List<Sach>();
                foreach (var item in dss)
                {
                    if (item.NameB.ToUpper().Contains(tb_NameB.Text.Trim().ToUpper()))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView2, s1);
            }
        }
        private void tb_Author_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<Sach> s1 = new List<Sach>();
                foreach (var item in dss)
                {
                    if (item.Author.ToUpper().Contains(tb_Author.Text.Trim().ToUpper()))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView2, s1);
            }
        }
        private void tb_NameB_DK_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<DangKi> dk1 = new List<DangKi>();
                foreach (var item in dsdk)
                {
                    if (item.NameB_DK.ToUpper().Contains(tb_NameB_DK.Text.Trim().ToUpper()))
                    {
                        dk1.Add(item);
                    }
                }
                loadListDK(dataView1, dk1);
            }
        }
        private void tb_NameTV_DK_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<DangKi> dk1 = new List<DangKi>();
                foreach (var item in dsdk)
                {
                    if (item.NameTV_DK.ToUpper().Contains(tb_NameTV_DK.Text.Trim().ToUpper()))
                    {
                        dk1.Add(item);
                    }
                }
                loadListDK(dataView1, dk1);
            }
        }

        //Nút lưu & huỷ


        private void tb_Genre_SelectedIndexChanged(object sender, EventArgs e)
        {//mỗi khi chọn thể loại thì kí tự đầu sẽ tự xuất hiện dưới mã sách cho tiện lợi và cho ngta bik
            if(statusBtn == "Search")
            {
                List<Sach> s1 = new List<Sach>();
                foreach (var item in dss)
                {
                    if (item.Genre.Contains(tb_Genre.Text.Trim()))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView2, s1);
            }
            else
            {
                string genre = tb_Genre.Text.Trim();
                switch (genre)
                {
                    case "Tiểu thuyết":
                        tb_IdB.Text = "A";
                        break;
                    case "Phi tiểu thuyết":
                        tb_IdB.Text = "B";
                        break;
                    case "Giáo dục":
                        tb_IdB.Text = "C";
                        break;
                    case "Nghệ thuật":
                        tb_IdB.Text = "D";
                        break;
                    case "Thiếu nhi":
                        tb_IdB.Text = "E";
                        break;
                    case "Tạp chí và báo chí":
                        tb_IdB.Text = "F";
                        break;
                    default:
                        tb_IdB.Text = "G";
                        break;
                }
            }
            
        }
        private void btn_Save2_Click(object sender, EventArgs e)
        {
            if(statusBtn == "Add")
            {
                if (!checkEmpty())
                {
                    string id = "";
                    string firstChar = tb_IdB.Text.Substring(0, 1);
                    string name = tb_NameB.Text.Trim();
                    string genre = tb_Genre.Text.Trim();
                    string author = tb_Author.Text.Trim();
                    DateTime date = dtp_DateP.Value.Date;
                    if (tb_IdB.Text.Trim().Length == 1)
                    {
                        
                        id = randomId(firstChar);
                       
                    }
                    else
                    {
                        id = tb_IdB.Text.Trim();
                        
                    }
                
                    if (checkLength(id)&&checkGenre(id,genre))
                    {
                        if (!checkSameB())
                        {
                            if (tb_Amount.Text.Trim() == "1"|| tb_Amount.Text.Trim() == "")
                            {
                                Sach sach = new Sach(id, name, genre, author, date);
                                dss.Add(sach);
                                MessageBox.Show("Đã thêm thành công!", "Hey!Look!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {

                                int n = int.Parse(tb_Amount.Text);
                                id = "";
                                for (int i = 0; i < n; i++)
                                {
                                    id = randomId(firstChar);
                                    Sach sach = new Sach(id, name, genre, author, date);
                                    dss.Add(sach);
                                }
                                MessageBox.Show("Đã thêm thành công!", "Hey!Look!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            loadListB(dataView2, dss);
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
                    else
                    {
                        MessageBox.Show("Mã sách phải 7 kí tự và phải có 1 kí tự từ A đến G!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        dss[statusNum].IdB = tb_IdB.Text.Trim();
                        dss[statusNum].NameB = tb_NameB.Text.Trim();
                        dss[statusNum].Genre = tb_Genre.Text.Trim();
                        dss[statusNum].Author = tb_Author.Text.Trim();
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
                tv.NameTV = tb_nameM.Text.Trim();
                tv.IdTV = tb_idM.Text.Trim();
                tv.Phone = tb_phoneM.Text.Trim();
                tv.Address = tb_addressM.Text.Trim();
                tv.ClassTV = tb_classM.Text.Trim();
                if (checkEmpty())
                    MessageBox.Show("Có thông tin bị thiếu", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (!checkLength(tv.IdTV))
                    {
                        MessageBox.Show("Mã thành viên phải 10 kí tự và phải có DH!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                        dstv[statusNum].IdTV=tb_idM.Text.Trim();
                        dstv[statusNum].NameTV=tb_nameM.Text.Trim();
                        dstv[statusNum].ClassTV=tb_classM.Text.Trim();
                        dstv[statusNum].Phone=tb_phoneM.Text.Trim();
                        dstv[statusNum].Address=tb_addressM.Text.Trim();
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
        private void btn_Save1_Click(object sender, EventArgs e)
        {
            if (statusBtn == "Adjust")
            {
                if (checkEmpty()) { MessageBox.Show("Có thông tin bị thiếu", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    if (checkSameB())
                    {
                        MessageBox.Show("Mã sách bị trùng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (checkExist()) { MessageBox.Show("Thông tin không tồn tại trong dữ liệu", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error); } else
                        {
                            dsdk[statusNum].IdB_DK = tb_IdB_DK.Text.Trim().ToUpper();
                            dsdk[statusNum].IdTV_DK = tb_IdTV_DK.Text.Trim().ToUpper();
                            dsdk[statusNum].NameB_DK = tb_NameB_DK.Text.Trim();
                            dsdk[statusNum].NameTV_DK = tb_NameTV_DK.Text.Trim();
                            dsdk[statusNum].DateS = dtp_DateS.Value.Date;
                            dsdk[statusNum].DateE=dtp_DateE.Value.Date;
                            loadListDK(dataView1, dsdk);
                            MessageBox.Show("Đã sửa thành công!", "Hey!Look!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            enableBtn(false, false);
                            enableTb(false);
                            enableCtrl(true, true, true, true);
                            dataView1.Enabled = true;
                            statusBtn = "";
                            statusNum = -1;
                            clearTb();
                        }
                    }
                }
            }else if (statusBtn == "Add")
            {
                if (checkEmpty()) { MessageBox.Show("Có thông tin bị thiếu", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    if (checkSameB())
                        {
                            MessageBox.Show("Cuốn sách này đã có người mượn!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DangKi k = new DangKi();
                        k.IdB_DK = tb_IdB_DK.Text.Trim().ToUpper();
                        k.IdTV_DK = tb_IdTV_DK.Text.Trim().ToUpper();
                        k.NameB_DK = tb_NameB_DK.Text.Trim();
                        k.NameTV_DK = tb_NameTV_DK.Text.Trim();
                        k.DateS = dtp_DateS.Value.Date;
                        k.DateE=dtp_DateE.Value.Date;
                        if (timB(k.IdB_DK, k.NameB_DK) && timTV(k.IdTV_DK, k.NameTV_DK))
                        {
                            dsdk.Add(k);
                            loadListDK(dataView1, dsdk);
                            MessageBox.Show("Đã thêm thành công!", "Hey!Look!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            enableBtn(false, false);
                            enableTb(false);
                            enableCtrl(true, true, true, true);
                            dataView3.Enabled = true;
                            statusBtn = "";
                            clearTb();
                        }
                        else
                        {
                            MessageBox.Show("Kiểm tra lại thông tin! ", "Hey!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }

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
            }else if (num == 0)
            {
                dataView1.Enabled = true;
                loadListDK(dataView1,dsdk);
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
        private void btn_Cancel1_Click(object sender, EventArgs e)
        {
            btnHuy();
        }
 

        //Lưu file & đọc
        private bool saveFileSach(string filename)
        {
            try
            {
                using (Stream f = File.Open(filename, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(f, dss);
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        private bool saveFileThanhVien(string filename)
        {
            try
            {
                using (Stream f = File.Open(filename, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(f, dstv);
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        private bool saveFileDangKi(string filename)
        {
            try
            {
                using (Stream f = File.Open(filename, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(f, dsdk);
                    return true;
                }
            }
            catch (Exception ex) { return false; }
        }
        private bool loadFileSach(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filename))
            {
                using(FileStream f = new FileStream(filename, FileMode.Open, System.IO.FileAccess.Read))
                {
                    dss = bf.Deserialize(f) as List<Sach>;
                    return true;
                }
            }else { return false; }
        }
        private bool loadFileThanhVien(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filename))
            {
                using (FileStream f = new FileStream(filename, FileMode.Open, System.IO.FileAccess.Read))
                {
                    dstv = bf.Deserialize(f) as List<ThanhVien>;
                    return true;
                }
            }
            else { return false; }
        }
        private bool loadFileDangKi(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filename))
            {
                using (FileStream f = new FileStream(filename, FileMode.Open, System.IO.FileAccess.Read))
                {
                    dsdk = bf.Deserialize(f) as List<DangKi>;
                    return true;
                }
            }
            else { return false; }
        }







        // Nút thoát
        private void btnThoat()
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc không?", "Hey!Look!Listen!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                saveFileSach("dss.bin");
                saveFileThanhVien("dstv.bin");
                saveFileDangKi("dsdk.bin");
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
        private void btn_Exit1_Click(object sender, EventArgs e)
        {
            btnThoat();
        }








        //testing
        private void tb_IdB_DK_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
