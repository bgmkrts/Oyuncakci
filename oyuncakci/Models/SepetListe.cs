using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oyuncakci.Models;
namespace oyuncakci.Models
{
    public class SepetListe
    {
        public int ID { get; set; }
        public string ADI { get; set; }
        public int ADET { get; set; }
        public  System.Decimal BIRIMFIYAT { get; set; }
        public  System.Decimal TOPLAMFIYAT { get; set; }
    }
}