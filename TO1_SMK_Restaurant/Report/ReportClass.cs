using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TO1_SMK_Restaurant.Class
{
    public class ReportClass
    {
        public DateTime Date { set; get; }
        public string Customer { set; get; }
        public string Payment { get; set; }
        public string DiscountMember { get; set; }
        public string DiscountPromo { get; set; }
        public decimal ModalPrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Profit { get; set; }
    }

    public class ReportDetailClass
    {
        public DateTime Date { set; get; }
        public string Customer { set; get; }
        public string FoodMenu { set; get; }
        public int Portion { set; get; }
        public string Payment { get; set; }
        public string DiscountMember { get; set; }
        public string DiscountPromo { get; set; }
        public decimal ModalPrice { get; set; }
        public decimal SellPrice { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Profit { get; set; }
    }

    public class ReportMenuClass
    {
        public string FoodMenu { set; get; }
        public int TotalPortion { set; get; }
    }
}
