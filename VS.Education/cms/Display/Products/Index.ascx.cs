using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class Index : System.Web.UI.UserControl
    {
        private string cid = "-1";
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            #region Requesthp
            if (Request["hp"] != null && !Request["hp"].Equals(""))
            {
                hp = Request["hp"].ToString();
            }
            iEmptyIndex = hp.IndexOf("?");
            if (iEmptyIndex != -1)
            {
                hp = hp.Substring(0, iEmptyIndex);
            }
            #endregion
            if (!IsPostBack)
            {
                CollectionPager1.FirstText = label("FirstText");
                CollectionPager1.LastText = label("LastText");
            }
            LoadItems();
        }

        protected void LoadItems()
        {
            List<Entity.Products> dt = new List<Entity.Products>();
            dt = SProducts.Name_Text("select  * from  products where  lang='" + language + "' and Status=1  order by Create_Date desc");
            if (dt.Count > 0)
            {
                CollectionPager1.DataSource = dt;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.BindToControl = rpcates;
                CollectionPager1.PageSize = int.Parse(MorePro.Pages());
                rpcates.DataSource = CollectionPager1.DataSourcePaged;
                rpcates.DataBind();
            }
            else lterr.Text = "<div style='color:Red; font-weight:bold; text-align:center; margin-bottom:10px; padding-top:10px'>" + this.label("I_dulieuchuadccapnhat") + "</div>";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}