using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str; /* Khai bao mot chuoi */
        int l = 0;
        str = "123444";
        foreach (char chr in str)
        {
            l += 1;
        }
        Response.Write(l.ToString());
    }
}