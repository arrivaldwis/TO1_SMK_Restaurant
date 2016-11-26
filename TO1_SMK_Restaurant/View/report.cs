using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TO1_SMK_Restaurant.Class;
using Microsoft.Reporting.WinForms;

namespace TO1_SMK_Restaurant.View
{
    public partial class report : baseView
    {
        public report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainMenu mainView = new mainMenu(int.Parse(par[0]));
            parent.view(mainView, new string[] { });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                var reportData = new List<ReportClass>();
                var payment = data.Payments.Where(x=>x.createdAt >= dateTimePicker1.Value && x.createdAt <= dateTimePicker2.Value).ToList();
                foreach (var pay in payment)
                {
                    decimal modalPrice = 0;
                    decimal sellPrice = 0;
                    double totalDiscount = 0;

                    foreach(var ord in data.OrderDetails.Where(x=>x.orderId.Equals(pay.orderId))) {
                        foreach (var menu in data.MenuIngredients.Where(x => x.menuId.Equals(ord.menuId)))
                        {
                            modalPrice += (menu.qty * menu.Ingredient.price) * ord.qty;
                        }
                        sellPrice += ord.subTotal;
                    }

                    if(pay.Member != null) {
                        try
                        {
                            totalDiscount += 0.1 * double.Parse(sellPrice.ToString());
                        }
                        catch (Exception ex)
                        {
                            totalDiscount += 0;
                        }
                    }

                    if(pay.Promo != null) {
                        try {
                            totalDiscount += (pay.Promo.discountPercent/100) * double.Parse(sellPrice.ToString());
                        }
                        catch (Exception ex)
                        {
                            totalDiscount += 0;
                        }
                    }
                    
                    reportData.Add(new ReportClass
                    {
                        Date = pay.createdAt.Value,
                        Customer = pay.Member.firstName + " " + pay.Member.lastName,
                        DiscountMember = pay.memberId.ToString()!=""||pay.memberId.ToString()!=null?"10%":"-",
                        Payment = pay.Bank!=null?pay.Bank.bankName:"Cash",
                        DiscountPromo = pay.Promo!=null?pay.Promo.discountPercent+"%":"-",
                        ModalPrice = modalPrice,
                        SellPrice = sellPrice,
                        TotalDiscount = decimal.Parse(totalDiscount.ToString()),
                        TotalPrice = sellPrice - decimal.Parse(totalDiscount.ToString()),
                        Profit = (sellPrice - decimal.Parse(totalDiscount.ToString())) - modalPrice
                    });
                }

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "TO1_SMK_Restaurant.Report.reportGeneral.rdlc";
                this.reportViewer1.LocalReport.ReportPath = "Report/reportGeneral.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", reportData));
                this.reportViewer1.RefreshReport();
            }
            else
            {
                var reportData = new List<ReportDetailClass>();
                var orderDetails = data.OrderDetails.Where(x => x.Order.createdAt >= dateTimePicker1.Value && x.Order.createdAt <= dateTimePicker2.Value).ToList();
                foreach (var orderDetail in orderDetails)
                {
                    decimal modalPrice = 0;
                    decimal sellPrice = 0;
                    double totalDiscount = 0;

                    sellPrice += orderDetail.subTotal;
                    foreach (var menu in data.MenuIngredients.Where(x => x.menuId.Equals(orderDetail.menuId)))
                    {
                        modalPrice += (menu.qty * menu.Ingredient.price) * orderDetail.qty;
                    }

                    var pay = data.Payments.Where(x => x.orderId.Equals(orderDetail.orderId)).First();
                    if (pay.Member != null)
                    {
                        try
                        {
                            totalDiscount += 0.1 * double.Parse(sellPrice.ToString());
                        }
                        catch (Exception ex)
                        {
                            totalDiscount += 0;
                        }
                    }

                    if (pay.Promo != null)
                    {
                        try
                        {
                            totalDiscount += (pay.Promo.discountPercent / 100) * double.Parse(sellPrice.ToString());
                        }
                        catch (Exception ex)
                        {
                            totalDiscount += 0;
                        }
                    }

                    reportData.Add(new ReportDetailClass
                    {
                        Date = orderDetail.Order.createdAt,
                        Customer = pay.Member!=null?pay.Member.firstName + " " + pay.Member.lastName:"-",
                        FoodMenu = orderDetail.Menu.menuName,
                        Portion = orderDetail.qty,
                        DiscountMember = pay.Member != null ? "10%" : "-",
                        Payment = pay.Bank != null ? pay.Bank.bankName : "Cash",
                        DiscountPromo = pay.Promo != null ? pay.Promo.discountPercent + "%" : "-",
                        ModalPrice = modalPrice,
                        SellPrice = sellPrice,
                        TotalDiscount = decimal.Parse(totalDiscount.ToString()),
                        TotalPrice = sellPrice - decimal.Parse(totalDiscount.ToString()),
                        Profit = (sellPrice - decimal.Parse(totalDiscount.ToString())) - modalPrice
                    });
                }

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "TO1_SMK_Restaurant.Report.reportDetail.rdlc";
                this.reportViewer1.LocalReport.ReportPath = "Report/reportDetail.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", reportData));
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
