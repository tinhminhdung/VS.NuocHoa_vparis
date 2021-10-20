using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.E_Commerce.cms.Display.News
{
    public partial class Detail1 : System.Web.UI.UserControl
    {
        #region string
        string cid = "";
        string nid = "";
        string hp = "";
        int iEmptyIndex = 0;
        private string language = Captionlanguage.Language;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            #region #
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
            #endregion
            if (!IsPostBack)
            {
                #region Detail_ID
                List<Entity.News> dt = SNews.Name_Text("SELECT * FROM [News]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    nid = dt[0].inid.ToString();
                    cid = dt[0].icid.ToString();

                    ltcatename.Text = More.Name(dt[0].icid.ToString());
                    lttitle.Text = dt[0].Title;
                    ltdesc.Text = dt[0].Brief;
                    this.ltTinlienquan.Text = MoreNews.AllRelated("nwsd", nid);
                    ltcontent.Text = dt[0].Contents;

                    //#region Tag
                    //string[] strArray = SNews.GET_DETAIL_BYID(nid)[0].Tags.ToString().Split(new char[] { ';' });
                    //for (int i = 0; i < strArray.Length; i++)
                    //{
                    //    string text = this.lttag.Text;
                    //    this.lttag.Text = text + "<a rel='tag' href='/nwsd/" + strArray[i].ToString() + "/homepage.aspx'>" + strArray[i].ToString() + "</a>";
                    //    this.lttag.Text = this.lttag.Text + "&nbsp;&nbsp; , ";
                    //}
                    //#endregion


                    #region Facebook
                    if (Other.NFacebook().Equals("1"))
                    {
                        ltFacebook.Text = "<div class='fb-like' data-href='" + MoreAll.MoreAll.RequestUrl(Request.Url.ToString()) + "' data-send='true' data-width='450' data-show-faces='false'></div>";
                    }
                    if (Other.NFacebook().Equals("2"))
                    {
                        ltFacebook.Text = "<div class='fb-like' data-href='" + MoreAll.MoreAll.RequestUrl(Request.Url.ToString()) + "' data-send='true' data-width='450' data-show-faces='true' data-font='arial'></div>";
                    }
                    #endregion


                    #region Other
                    dt = SNews.OTHERFIRST(nid, int.Parse(MoreNews.Newsother()), language, cid);
                    if (dt.Count > 0)
                    {
                        rpitems.DataSource = dt;
                        rpitems.DataBind();
                    }
                    else
                    {
                        rpitems.Visible = false;
                    }
                    dt = SNews.OTHERLAST(nid, int.Parse(MoreNews.Newsother()), language, cid);
                    if (dt.Count > 0)
                    {
                        rpitems2.DataSource = dt;
                        rpitems2.DataBind();
                    }
                    else
                    {
                        rpitems2.Visible = false;
                    }
                    #endregion
                }

                #region views
                if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(this.nid))
                {
                    SNews.UPDATEVIEWS_TIMES(this.nid);
                    MoreAll.MoreAll.SetCookie("views", this.nid);
                }

                #endregion

                #region Facebook
                if (MoreNews.Newschiase().Equals("1"))
                {
                    ltchiase.Text = "<div class='addthis_toolbox addthis_default_style '><a class='addthis_button_preferred_1'></a><a class='addthis_button_preferred_2'></a><a class='addthis_button_preferred_3'></a><a class='addthis_button_preferred_4'></a><a class='addthis_button_compact'></a><a class='addthis_counter addthis_bubble_style'></a></div><script type='text/javascript' src='http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4e2a6c617ab55718'></script>";
                }
                #endregion
                #endregion
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}