//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace oyuncakci.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class URUN
    {
        public int ID { get; set; }
        public Nullable<int> ALTKATEGORIID { get; set; }
        public string ADI { get; set; }
        public Nullable<int> MARKAID { get; set; }
        public Nullable<short> STOKSAYISI { get; set; }
        public Nullable<decimal> FIYAT { get; set; }
        public int YASARALIKID { get; set; }
        public byte[] FOTO { get; set; }
    }
}
