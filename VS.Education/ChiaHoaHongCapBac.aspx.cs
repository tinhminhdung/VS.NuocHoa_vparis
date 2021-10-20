using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce
{
    public partial class ChiaHoaHongCapBac : System.Web.UI.Page
    {
        DatalinqDataContext db = new DatalinqDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {


            //string PhanTram = "1, 22, 3, 24, 25, 1 ";
            //string chuoi = "";
            //string[] strArray = PhanTram.ToString().Split(new char[] { ',' });
            //for (int i = 0; i < strArray.Length; i++)
            //{
            //    chuoi += strArray[i].ToString() + "-<br /> ";
            //}
            //Response.Write(chuoi);
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            SMember.Name_Text("delete from HoaHong");
            CapBac.ChiaHoaHongCapBacs(TextBox1.Text, "100", "1");
        }

    }
}