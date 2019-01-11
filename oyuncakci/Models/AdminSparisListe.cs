using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oyuncakci.Models;
namespace oyuncakci.Models
{
    public class AdminSparisListe
    {
        public int SEPETID { get; set; }
        public string KULLANICI { get; set; }
        public int ADET { get; set; }
        public  System.Decimal TOPLAMFIYAT { get; set; }
    }
}