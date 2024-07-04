using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Latih8_WinformEvent
{
    public class SiswaModel
    {
        public string NIS {  get; set; }
        public SiswaModel(string nIS,string nama,DateTime tglLahir,string gender, string alamat,string jurusan)
        {
            NIS = nIS;
            Nama = nama;
            TglLahir = tglLahir;
            Gender = gender;
            Alamat = alamat;
            Jurusan = jurusan;
        }
        public string Nama { get; set; }
        public DateTime TglLahir { get; set; }
        public string Gender { get; set; }
        public string Alamat { get; set; }
        public string Jurusan { get; set; }
    }
}
