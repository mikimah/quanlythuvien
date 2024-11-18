using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien
{
    [Serializable]
    internal class DangKi
    {
        private string idB_DK;
        private string idTV_DK;
        private string nameB_DK;
        private string nameTV_DK;
        private DateTime dateS;
        private DateTime dateE;

        public DangKi() {
            idB_DK = "";
            idTV_DK = "";
            nameB_DK = "";
            nameTV_DK = "";
            dateS = DateTime.Now;
            dateE = DateTime.Now;
        }
        public DangKi(string idB_DK, string idTV_DK, string nameB_DK, string nameTV_DK, DateTime dateS, DateTime dateE)
        {
            this.idB_DK = idB_DK;
            this.idTV_DK = idTV_DK;
            this.nameB_DK = nameB_DK;
            this.nameTV_DK = nameTV_DK;
            this.dateS = dateS;
            this.dateE = dateE;
        }
        public string IdB_DK
        {
            get { return idB_DK; }
            set { idB_DK = value; }
        }
        public DateTime DateS
        {
            get { return dateS; }
            set { dateS = value; }
        }
        public DateTime DateE
        {
            get { return dateE; }
            set { dateE = value; }
        }
        public string IdTV_DK
        {
            get { return idTV_DK; }
            set { idTV_DK = value; }
        }
        public string NameB_DK
        {
            get { return nameB_DK; }
            set { nameB_DK = value; }
        }
        public string NameTV_DK
        {
            get { return nameTV_DK; }
            set { nameTV_DK = value; }
        }
    }
}
