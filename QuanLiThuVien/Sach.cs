using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuanLiThuVien
{
    [Serializable]
    internal class Sach
    {
        private string idB;
        private string nameB;
        private string genre;
        private string author;
        private DateTime dateP;

        public Sach()
        {
            this.idB = "";
            this.nameB = "";
            this.genre = "";
            this.author = "";
            this.dateP = DateTime.Now;
        }

        public Sach(string id, string name, string genre, string author, DateTime dateP)
        {
            this.idB = id;
            this.nameB = name;
            this.genre = genre;
            this.author = author;
            this.dateP = dateP;
        }
        public string IdB
        {
            get { return idB; }
            set { idB = value; }
        }
        public string NameB
        {
            get { return nameB; }
            set { nameB = value; }
        }
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public DateTime DateP
        {
            get { return dateP; }
            set { dateP = value; }
        }
    }
}
