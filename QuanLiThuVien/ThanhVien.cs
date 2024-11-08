using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiThuVien
{
    internal class ThanhVien
    {
        private string nameTV;
        private string classTV;
        private string idTV;
        private string address;
        private string phone;

        public ThanhVien(string nameTV, string classTV, string idTV, string address, string phone)
        {
            this.nameTV = nameTV;
            this.classTV = classTV;
            this.idTV = idTV;
            this.address = address;
            this.phone = phone;
        }
        public ThanhVien()
        {
            this.idTV = "";
            this.nameTV = "";
            this.classTV = "";
            this.address = "";
            this.phone ="";
        }
        public string NameTV { get { return this.nameTV; } set { this.nameTV = value; } }
        public string IdTV { get { return this.idTV; }set { this.idTV = value; } }
        public string Address { get { return this.address; } set { this.address = value; } }
        public string Phone { get { return this.phone; } set { this.phone = value; } }  

        public string ClassTV { get { return this.classTV; } set { this.classTV = value; } }


    }
}
