//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portfolio_Manager.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class TransactionLog
    {
        public int Id { get; set; }
        public Nullable<int> StockId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<bool> Purchased { get; set; }
        public Nullable<System.DateTime> TransactioNDate { get; set; }
    
        public virtual Stock Stock { get; set; }
    }
}
