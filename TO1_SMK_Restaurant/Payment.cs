//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TO1_SMK_Restaurant
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int paymentId { get; set; }
        public int orderId { get; set; }
        public string memberId { get; set; }
        public string payMethod { get; set; }
        public Nullable<int> bankId { get; set; }
        public string creditCardNumber { get; set; }
        public Nullable<int> promoId { get; set; }
        public decimal amount { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
    
        public virtual Bank Bank { get; set; }
        public virtual Member Member { get; set; }
        public virtual Order Order { get; set; }
        public virtual Promo Promo { get; set; }
    }
}
