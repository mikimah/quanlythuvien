using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiThuVien
{
    public partial class TimKiemSach : Form
    {
        List<Sach> tam = new List<Sach>();
        List<Sach> tkdss = new List<Sach>();
        List<DangKi> tkdsdk = new List<DangKi>();
        string statusBtn = "Search";
        int statusNum = -1;
        string id_tam = "";

        public delegate void GETDATA(string data);
        public GETDATA mydata;
      
        
        
        public TimKiemSach()
        {
            InitializeComponent();
        }

      

        private void TimKiemSach_Load(object sender, EventArgs e)
        {
            loadFileSach("dss.bin");
            loadFileDangKi("dsdk.bin");
            foreach(var item in tam)
            {
                bool flag = true;
                foreach (var item2 in tkdsdk)
                {
                    if (item2.IdB_DK == item.IdB) flag = false;
                }
                if (flag)
                {
                   tkdss.Add(item);
                }
                flag = true;

            }
            loadListB(dataView1, tkdss);
        }
        private bool loadFileDangKi(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filename))
            {
                using (FileStream f = new FileStream(filename, FileMode.Open, System.IO.FileAccess.Read))
                {
                    tkdsdk = bf.Deserialize(f) as List<DangKi>;
                    return true;
                }
            }
            else { return false; }
        }
        private bool loadFileSach(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filename))
            {
                using (FileStream f = new FileStream(filename, FileMode.Open, System.IO.FileAccess.Read))
                {
                   tam = bf.Deserialize(f) as List<Sach>;
                    return true;
                }
            }
            else { return false; }
        }
        private void loadListB(DataGridView dataView1, List<Sach> dss)
        {
            dataView1.DataSource = dss.ToList();
        }
        private void btn_Save1_Click(object sender, EventArgs e)
        {
            if (statusNum == -1)
            {
                MessageBox.Show("Hãy chọn 1 đối tượng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
             
                mydata(tkdss[statusNum].IdB);
                this.Close();

            }
        }

        private void btn_Cancel1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }

        private void dataView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (statusBtn == "Search")
            {
                int searchNum = e.RowIndex;
                for (int i = 0; i < tkdss.Count; i++)
                {
                    if (tkdss[i].IdB == dataView1.Rows[searchNum].Cells[0].Value.ToString())
                    {
                        tb_IdB.Text = tkdss[i].IdB;
                        tb_NameB.Text = tkdss[i].NameB;
                        tb_Genre.Text = tkdss[i].Genre;
                        tb_Author.Text = tkdss[i].Author;
                        dtp_DateP.Value = tkdss[i].DateP;
                        tb_Shelf.Text = tkdss[i].Shelf;
                        statusNum = i;
                        break;
                    }
                }
            }
            
        }

        private void tb_NameB_TextChanged(object sender, EventArgs e)
        {
          

            if (statusBtn == "Search")
            {
                List<Sach> s1 = new List<Sach>();
                foreach (var item in tkdss)
                {
                    if (item.NameB.ToUpper().Contains(tb_NameB.Text.Trim().ToUpper()))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView1, s1);
            }
            statusNum = -1;
        }
        private void tb_Genre_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (statusBtn == "Search")
            {
                List<Sach> s1 = new List<Sach>();
                foreach (var item in tkdss)
                {
                    if (item.Genre.Contains(tb_Genre.Text.Trim()))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView1, s1);
            }
            statusNum = -1;


            string genre = tb_Genre.Text.Trim();
            //switch (genre)
            //{
            //    case "Tiểu thuyết":
            //        tb_IdB.Text = "A";
            //        break;
            //    case "Phi tiểu thuyết":
            //        tb_IdB.Text = "B";
            //        break;
            //    case "Giáo dục":
            //        tb_IdB.Text = "C";
            //        break;
            //    case "Nghệ thuật":
            //        tb_IdB.Text = "D";
            //        break;
            //    case "Thiếu nhi":
            //        tb_IdB.Text = "E";
            //        break;
            //    case "Tạp chí và báo chí":
            //        tb_IdB.Text = "F";
            //        break;
            //    default:
            //        tb_IdB.Text = "G";
            //        break;
            //}
        }
        private void tb_IdB_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<Sach> s1 = new List<Sach>();
                foreach (var item in tkdss)
                {
                    if (item.IdB.Contains(tb_IdB.Text.Trim().ToUpper()))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView1, s1);
            }
            statusNum = -1;
        }
        private void tb_Author_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<Sach> s1 = new List<Sach>();
                foreach (var item in tkdss)
                {
                    if (item.Author.ToUpper().Contains(tb_Author.Text.Trim().ToUpper()))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView1, s1);
            }
            statusNum = -1;
        }
        private void tb_Shelf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<Sach> s1 = new List<Sach>();
                foreach (var item in tkdss)
                {
                    if (item.Shelf.Contains(tb_Shelf.Text.Trim()))
                    {
                        s1.Add(item);
                    }
                }
                loadListB(dataView1, s1);
            }
            statusNum = -1;
        }

    
    }
}
