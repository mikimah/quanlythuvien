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
    public partial class TimKiemTV : Form
    {
        List<ThanhVien> tkdstv = new List<ThanhVien>();
        string statusBtn = "Search";
        int statusNum = -1;
        string id_tam = "";

        public delegate void GETDATA(string data);
        public GETDATA mydata;

        public TimKiemTV()
        {
            InitializeComponent();
        }
        private bool loadFileThanhVien(string filename)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(filename))
            {
                using (FileStream f = new FileStream(filename, FileMode.Open, System.IO.FileAccess.Read))
                {
                    tkdstv = bf.Deserialize(f) as List<ThanhVien>;
                    return true;
                }
            }
            else { return false; }
        }
        private void loadListM(DataGridView dataView3, List<ThanhVien> dstv)
        {
            dataView3.DataSource = dstv.ToList();
        }
        private void TimKiemTV_Load(object sender, EventArgs e)
        {
            loadFileThanhVien("dstv.bin");
            loadListM(dataView1, tkdstv);
        }

        private void btn_Save1_Click(object sender, EventArgs e)
        {
            if (statusNum == -1)
            {
                MessageBox.Show("Hãy chọn 1 đối tượng!", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mydata(tkdstv[statusNum].IdTV);
                this.Close();

            }
        }
        private void btn_Cancel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    

        private void tb_idM_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<ThanhVien> m1 = new List<ThanhVien>();
                foreach (var item in tkdstv)
                {
                    if (item.IdTV.Contains(tb_idM.Text.Trim().ToUpper()))
                    {
                        m1.Add(item);
                    }
                }
                loadListM(dataView1, m1);
            }
            //statusNum = -1;
        }

        private void tb_nameM_TextChanged(object sender, EventArgs e)
        {
            if (statusBtn == "Search")
            {
                List<ThanhVien> m1 = new List<ThanhVien>();
                foreach (var item in tkdstv)
                {
                    if (item.NameTV.ToUpper().Contains(tb_nameM.Text.Trim().ToUpper()))
                    {
                        m1.Add(item);
                    }
                }
                loadListM(dataView1, m1);
            }//statusNum = -1;
           
        }

        

        private void dataView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (statusBtn == "Search")
            {
                int searchNum = e.RowIndex;
                for (int i = 0; i < tkdstv.Count; i++)
                {
                    if (tkdstv[i].IdTV == dataView1.Rows[searchNum].Cells[1].Value.ToString())
                    {
                        tb_idM.Text = tkdstv[i].IdTV;
                        tb_nameM.Text = tkdstv[i].NameTV;
                        tb_addressM.Text = tkdstv[i].Address;
                        tb_classM.Text = tkdstv[i].ClassTV;
                        tb_phoneM.Text = tkdstv[i].Phone;
                        statusNum = i;
                        break;
                    }
                }
            }
            //int i = e.RowIndex;

            //tb_idM.Text = tkdstv[i].IdTV;
            //tb_nameM.Text = tkdstv[i].NameTV;
            //tb_addressM.Text = tkdstv[i].Address;
            //tb_classM.Text = tkdstv[i].ClassTV;
            //tb_phoneM.Text = tkdstv[i].Phone;
            //statusNum = i;
        }
    }
}
