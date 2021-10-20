using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Services;

namespace MoreAll.Templates
{
    public class Templates
    {
        public static string WebTitle(string hp, string Modul)
        {
            #region MyRegion
            if (Modul == "21")
            {
                List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Titleseo.ToString().Length > 0)
                    {
                        return dt[0].Titleseo.ToString();
                    }
                    return dt[0].Name.ToString();
                }
            }
            else if (Modul == "2")
            {
                List<Entity.News> dt = SNews.Name_Text("SELECT * FROM [News]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Titleseo.ToString().Length > 0)
                    {
                        return dt[0].Titleseo.ToString();
                    }
                    return dt[0].Title.ToString();
                }
            }
            else if (Modul == "4")
            {
                List<Entity.Nfooter> dt = SNfooter.Name_Text("SELECT * FROM [Nfooter]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Titleseo.ToString().Length > 0)
                    {
                        return dt[0].Titleseo.ToString();
                    }
                    return dt[0].Title.ToString();
                }
            }
            else if (Modul == "6")
            {
                List<Entity.Album> Album = SAlbum.Name_Text("SELECT * FROM [Album]  where TangName='" + hp + "'");
                if (Album.Count > 0)
                {
                    if (Album[0].Titleseo.ToString().Length > 0)
                    {
                        return Album[0].Titleseo.ToString();
                    }
                    return Album[0].Title.ToString();
                }
            }
            else if (Modul == "8")
            {
                List<Entity.VideoClip> Video = SVideoClip.Name_Text("SELECT * FROM [VideoClip]  where TangName='" + hp + "'");
                if (Video.Count > 0)
                {
                    if (Video[0].Titleseo.ToString().Length > 0)
                    {
                        return Video[0].Titleseo.ToString();
                    }
                    return Video[0].Title.ToString();
                }
            }
            else if (Modul == "11")
            {
                List<Entity.Gioithieu> Video = SGioithieu.Name_Text("SELECT * FROM [Gioithieu]  where TangName='" + hp + "'");
                if (Video.Count > 0)
                {
                    if (Video[0].Titleseo.ToString().Length > 0)
                    {
                        return Video[0].Titleseo.ToString();
                    }
                    return Video[0].Title.ToString();
                }
            }
            else if (Modul == "100")
            {
                List<Entity.MNews> dt = SMNews.Name_Text("SELECT * FROM [MNews]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Title.ToString().Length > 0)
                    {
                        return dt[0].Title.ToString();
                    }
                    return dt[0].Title.ToString();
                }
            }
            else if (Modul == "1" || Modul == "3" || Modul == "5" || Modul == "7" || Modul == "20" || Modul == "23" || Modul == "25" || Modul == "0" || Modul == "99")
            {
                List<Entity.Menu> Menu = SMenu.Name_Text("SELECT * FROM [Menu]  where TangName='" + hp + "'");
                if (Menu.Count > 0)
                {
                    if (Menu[0].Titleseo.ToString().Length > 0)
                    {
                        return Menu[0].Titleseo.ToString();
                    }
                    return Menu[0].Name.ToString();
                }
            }
            return (Other.TitleWebname());
            #endregion
        }

        public static string Keyword(string hp, string Modul)
        {
            #region MyRegion
            if (Modul == "21")
            {
                List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Keyword.ToString().Length > 0)
                    {
                        return dt[0].Keyword;
                    }
                    return dt[0].Brief;
                }
            }
            else if (Modul == "2")
            {
                List<Entity.News> dt = SNews.Name_Text("SELECT * FROM [News]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Keyword.ToString().Length > 0)
                    {
                        return dt[0].Keyword;
                    }
                    return dt[0].Brief;
                }
            }
            else if (Modul == "4")
            {
                List<Entity.Nfooter> dt = SNfooter.Name_Text("SELECT * FROM [Nfooter]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Keyword.ToString().Length > 0)
                    {
                        return dt[0].Keyword;
                    }
                    return dt[0].Brief;
                }
            }
            else if (Modul == "6")
            {
                List<Entity.Album> Album = SAlbum.Name_Text("SELECT * FROM [Album]  where TangName='" + hp + "'");
                if (Album.Count > 0)
                {
                    if (Album[0].Keyword.ToString().Length > 0)
                    {
                        return Album[0].Keyword;
                    }
                    return Album[0].Brief;
                }
            }
            else if (Modul == "8")
            {
                List<Entity.VideoClip> Video = SVideoClip.Name_Text("SELECT * FROM [VideoClip]  where TangName='" + hp + "'");
                if (Video.Count > 0)
                {
                    if (Video[0].Keyword.ToString().Length > 0)
                    {
                        return Video[0].Keyword;
                    }
                    return Video[0].Brief;
                }
            }
            else if (Modul == "11")
            {
                List<Entity.Gioithieu> Video = SGioithieu.Name_Text("SELECT * FROM [Gioithieu]  where TangName='" + hp + "'");
                if (Video.Count > 0)
                {
                    if (Video[0].Keyword.ToString().Length > 0)
                    {
                        return Video[0].Keyword;
                    }
                    return Video[0].Brief;
                }
            }
            else if (Modul == "100")
            {
                List<Entity.MNews> dt = SMNews.Name_Text("SELECT * FROM [MNews]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Brief.ToString().Length > 0)
                    {
                        return dt[0].Brief.ToString();
                    }
                    return dt[0].Title.ToString();
                }
            }
            else if (Modul == "1" || Modul == "3" || Modul == "5" || Modul == "7" || Modul == "20" || Modul == "23" || Modul == "25" || Modul == "0" || Modul == "99")
            {
                List<Entity.Menu> Menu = SMenu.Name_Text("SELECT * FROM [Menu]  where TangName='" + hp + "'");
                if (Menu.Count > 0)
                {
                    if (Menu[0].Keyword.ToString().Length > 0)
                    {
                        return Menu[0].Keyword;
                    }
                    return Menu[0].Name.ToString();
                }
            }
            return (Other.Titlesearchkeyword());
            #endregion
        }

        public static string Description(string hp, string Modul)
        {
            #region MyRegion
            if (Modul == "21")
            {
                List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Meta.ToString().Length > 0)
                    {
                        return dt[0].Meta;
                    }
                    return dt[0].Brief;
                }
            }
            else if (Modul == "2")
            {
                List<Entity.News> dt = SNews.Name_Text("SELECT * FROM [News]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Meta.ToString().Length > 0)
                    {
                        return dt[0].Meta;
                    }
                    return dt[0].Brief;
                }
            }
            else if (Modul == "4")
            {
                List<Entity.Nfooter> dt = SNfooter.Name_Text("SELECT * FROM [Nfooter]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Meta.ToString().Length > 0)
                    {
                        return dt[0].Meta;
                    }
                    return dt[0].Brief;
                }
            }
            else if (Modul == "6")
            {
                List<Entity.Album> Album = SAlbum.Name_Text("SELECT * FROM [Album]  where TangName='" + hp + "'");
                if (Album.Count > 0)
                {
                    if (Album[0].Meta.ToString().Length > 0)
                    {
                        return Album[0].Meta;
                    }
                    return Album[0].Brief;
                }
            }
            else if (Modul == "8")
            {
                List<Entity.VideoClip> Video = SVideoClip.Name_Text("SELECT * FROM [VideoClip]  where TangName='" + hp + "'");
                if (Video.Count > 0)
                {
                    if (Video[0].Meta.ToString().Length > 0)
                    {
                        return Video[0].Meta;
                    }
                    return Video[0].Brief;
                }
            }
            else if (Modul == "11")
            {
                List<Entity.Gioithieu> Video = SGioithieu.Name_Text("SELECT * FROM [Gioithieu]  where TangName='" + hp + "'");
                if (Video.Count > 0)
                {
                    if (Video[0].Meta.ToString().Length > 0)
                    {
                        return Video[0].Meta;
                    }
                    return Video[0].Brief;
                }
            }
            else if (Modul == "100")
            {
                List<Entity.MNews> dt = SMNews.Name_Text("SELECT * FROM [MNews]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    if (dt[0].Brief.ToString().Length > 0)
                    {
                        return dt[0].Brief.ToString();
                    }
                    return dt[0].Title.ToString();
                }
            }
            else if (Modul == "1" || Modul == "3" || Modul == "5" || Modul == "7" || Modul == "20" || Modul == "23" || Modul == "25" || Modul == "0" || Modul == "99")
            {
                List<Entity.Menu> Menu = SMenu.Name_Text("SELECT * FROM [Menu]  where TangName='" + hp + "'");
                if (Menu.Count > 0)
                {
                    if (Menu[0].Meta.ToString().Length > 0)
                    {
                        return Menu[0].Meta;
                    }
                    return Menu[0].Name.ToString();
                }
            }
            return (Other.Titlekeyworddescription());
            #endregion
        }

        public static string Facebook(string url, string hp, string Modul)
        {
            #region MyRegion
            if (Modul == "2")
            {
                List<Entity.News> dt = SNews.Name_Text("SELECT * FROM [News]  where TangName='" + hp + "'");
                string chuoi = "";
                if (dt.Count > 0)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt[0].Images.ToString().Length > 0)
                    {
                        Images = dt[0].Images;
                    }
                    if (dt[0].Keyword.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Keyword, 250)); } else { if (dt[0].Brief.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Brief, 250)); } }
                    chuoi += "<meta property=\"fb:app_id\" content=\"" + Other.Giatri("txtfbapp_id") + "\" />";
                    chuoi += "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />";
                    //chuoi += "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />";
                    chuoi += "<meta property=\"og:rich_attachment\" content=\"true\" />";
                    chuoi += "<meta property=\"og:type\" content=\"article\" />";
                    chuoi += "<meta property=\"og:url\" content=\"" + url + "/" + hp + ".html\" />";
                    chuoi += "<meta property=\"og:title\" content=\"" + dt[0].Title + "\" />";
                    chuoi += "<meta property=\"og:description\" content=\"" + Brief + "\" />";
                    chuoi += "<meta property=\"og:image\" content=\"" + url + Images + "\" />";
                    chuoi += "<meta property=\"og:image:width\" content=\"720\" />";
                    chuoi += "<meta property=\"og:image:height\" content=\"480\" />";
                    chuoi += "<meta property=\"article:published_time\" content=\"" + MoreAll.FormatDate(dt[0].Create_Date) + "\" />";
                    chuoi += "<meta property=\"article:modified_time\" content=\"" + MoreAll.FormatDate(dt[0].Modified_Date) + "\" />";
                    chuoi += " <meta property=\"article:section\" content=\"" + More.DetaiName(dt[0].icid.ToString()) + "\" />";

                    chuoi += "<meta name=\"twitter:card\" content=\"summary_large_image\">";
                    chuoi += "<meta name=\"twitter:site\" content=\"" + url + "/" + hp + ".html\"> ";
                    chuoi += " <meta name=\"twitter:title\" content=\"" + dt[0].Title + "\">";
                    chuoi += " <meta name=\"twitter:description\" content=\"" + Brief + "\">";
                    chuoi += "<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">";

                }
                return chuoi;
            }
            if (Modul == "21")
            {
                List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where TangName='" + hp + "'");
                string chuoi = "";
                if (dt.Count > 0)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt[0].Images.ToString().Length > 0)
                    {
                        Images = dt[0].Images;
                    }
                    if (dt[0].Keyword.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Keyword, 250)); } else { if (dt[0].Brief.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Brief, 250)); } }
                    chuoi += "<meta property=\"fb:app_id\" content=\"" + Other.Giatri("txtfbapp_id") + "\" />";
                    chuoi += "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />";
                    chuoi += "<meta property=\"og:rich_attachment\" content=\"true\" />";
                    // chuoi += "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />";
                    chuoi += "<meta property=\"og:type\" content=\"article\" />";
                    chuoi += "<meta property=\"og:url\" content=\"" + url + "/" + hp + ".html\" />";
                    chuoi += "<meta property=\"og:title\" content=\"" + dt[0].Name + "\" />";
                    chuoi += "<meta property=\"og:description\" content=\"" + Brief + "\" />";
                    chuoi += "<meta property=\"og:image\" content=\"" + url + Images + "\" />";
                    chuoi += "<meta property=\"og:image:width\" content=\"720\" />";
                    chuoi += "<meta property=\"og:image:height\" content=\"480\" />";
                    chuoi += "<meta property=\"article:published_time\" content=\"" + MoreAll.FormatDate(dt[0].Create_Date) + "\" />";
                    chuoi += "<meta property=\"article:modified_time\" content=\"" + MoreAll.FormatDate(dt[0].Modified_Date) + "\" />";
                    chuoi += " <meta property=\"article:section\" content=\"" + More.DetaiName(dt[0].icid.ToString()) + "\" />";

                    chuoi += "<meta name=\"twitter:card\" content=\"summary_large_image\">";
                    chuoi += "<meta name=\"twitter:site\" content=\"" + url + "/" + hp + ".html\"> ";
                    chuoi += " <meta name=\"twitter:title\" content=\"" + dt[0].Name + "\">";
                    chuoi += " <meta name=\"twitter:description\" content=\"" + Brief + "\">";
                    chuoi += "<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">";

                }
                return chuoi;
            }
            else if (Modul == "8")
            {
                List<Entity.VideoClip> dt = SVideoClip.Name_Text("SELECT * FROM [VideoClip]  where TangName='" + hp + "'");
                string chuoi = "";
                if (dt.Count > 0)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt[0].Images.ToString().Length > 0)
                    {
                        Images = dt[0].Images;
                    }
                    if (dt[0].Keyword.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Keyword, 250)); } else { if (dt[0].Brief.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Brief, 250)); } }
                    chuoi += "<meta property=\"fb:app_id\" content=\"" + Other.Giatri("txtfbapp_id") + "\" />";
                    chuoi += "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />";
                    chuoi += "<meta property=\"og:rich_attachment\" content=\"true\" />";
                    //chuoi += "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />";
                    chuoi += "<meta property=\"og:type\" content=\"article\" />";
                    chuoi += "<meta property=\"og:url\" content=\"" + url + "/" + hp + ".html\" />";
                    chuoi += "<meta property=\"og:title\" content=\"" + dt[0].Title + "\" />";
                    chuoi += "<meta property=\"og:description\" content=\"" + Brief + "\" />";
                    chuoi += "<meta property=\"og:image\" content=\"" + url + Images + "\" />";
                    chuoi += "<meta property=\"og:image:width\" content=\"720\" />";
                    chuoi += "<meta property=\"og:image:height\" content=\"480\" />";
                    chuoi += "<meta property=\"article:published_time\" content=\"" + MoreAll.FormatDate(dt[0].Create_Date) + "\" />";
                    chuoi += "<meta property=\"article:modified_time\" content=\"" + MoreAll.FormatDate(dt[0].Modified_Date) + "\" />";
                    chuoi += " <meta property=\"article:section\" content=\"" + More.DetaiName(dt[0].Menu_ID.ToString()) + "\" />";

                    chuoi += "<meta name=\"twitter:card\" content=\"summary_large_image\">";
                    chuoi += "<meta name=\"twitter:site\" content=\"" + url + "/" + hp + ".html\"> ";
                    chuoi += " <meta name=\"twitter:title\" content=\"" + dt[0].Title + "\">";
                    chuoi += " <meta name=\"twitter:description\" content=\"" + Brief + "\">";
                    chuoi += "<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">";

                }
                return chuoi;
            }
            else if (Modul == "6")
            {
                List<Entity.Album> dt = SAlbum.Name_Text("SELECT * FROM [Album]  where TangName='" + hp + "'");
                string chuoi = "";
                if (dt.Count > 0)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt[0].Images.ToString().Length > 0)
                    {
                        Images = dt[0].Images;
                    }
                    if (dt[0].Keyword.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Keyword, 250)); } else { if (dt[0].Brief.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Brief, 250)); } }
                    chuoi += "<meta property=\"fb:app_id\" content=\"" + Other.Giatri("txtfbapp_id") + "\" />";
                    chuoi += "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />";
                    chuoi += "<meta property=\"og:rich_attachment\" content=\"true\" />";
                    //chuoi += "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />";
                    chuoi += "<meta property=\"og:type\" content=\"article\" />";
                    chuoi += "<meta property=\"og:url\" content=\"" + url + "/" + hp + ".html\" />";
                    chuoi += "<meta property=\"og:title\" content=\"" + dt[0].Title + "\" />";
                    chuoi += "<meta property=\"og:description\" content=\"" + Brief + "\" />";
                    chuoi += "<meta property=\"og:image\" content=\"" + url + Images + "\" />";
                    chuoi += "<meta property=\"og:image:width\" content=\"720\" />";
                    chuoi += "<meta property=\"og:image:height\" content=\"480\" />";
                    chuoi += "<meta property=\"article:published_time\" content=\"" + MoreAll.FormatDate(dt[0].Create_Date) + "\" />";
                    chuoi += "<meta property=\"article:modified_time\" content=\"" + MoreAll.FormatDate(dt[0].Modified_Date) + "\" />";
                    chuoi += " <meta property=\"article:section\" content=\"" + More.DetaiName(dt[0].Menu_ID.ToString()) + "\" />";

                    chuoi += "<meta name=\"twitter:card\" content=\"summary_large_image\">";
                    chuoi += "<meta name=\"twitter:site\" content=\"" + url + "/" + hp + ".html\"> ";
                    chuoi += " <meta name=\"twitter:title\" content=\"" + dt[0].Title + "\">";
                    chuoi += " <meta name=\"twitter:description\" content=\"" + Brief + "\">";
                    chuoi += "<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">";

                }
                return chuoi;
            }
            else if (Modul == "1" || Modul == "3" || Modul == "5" || Modul == "7" || Modul == "20")
            {
                string chuoi = "";
                List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where TangName='" + hp + "'");
                if (dt.Count > 0)
                {
                    string Images = "";
                    string Brief = "";
                    if (dt[0].Images.ToString().Length > 0)
                    {
                        Images = dt[0].Images;
                    }
                    if (dt[0].Keyword.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Keyword, 250)); } else { if (dt[0].Description.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Description, 250)); } }
                    chuoi += "<meta property=\"fb:app_id\" content=\"" + Other.Giatri("txtfbapp_id") + "\" />";
                    chuoi += "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />";
                    chuoi += "<meta property=\"og:rich_attachment\" content=\"true\" />";
                    // chuoi += "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />";
                    chuoi += "<meta property=\"og:type\" content=\"article\" />";
                    chuoi += "<meta property=\"og:url\" content=\"" + url + "/" + hp + ".html\" />";
                    chuoi += "<meta property=\"og:title\" content=\"" + dt[0].Name + "\" />";
                    chuoi += "<meta property=\"og:description\" content=\"" + Brief + "\" />";
                    chuoi += "<meta property=\"og:image\" content=\"" + url + Images + "\" />";
                    chuoi += "<meta property=\"og:image:width\" content=\"720\" />";
                    chuoi += "<meta property=\"og:image:height\" content=\"480\" />";

                    chuoi += "<meta name=\"twitter:card\" content=\"summary_large_image\">";
                    chuoi += "<meta name=\"twitter:site\" content=\"" + url + "/" + hp + ".html\"> ";
                    chuoi += " <meta name=\"twitter:title\" content=\"" + dt[0].Name + "\">";
                    chuoi += " <meta name=\"twitter:description\" content=\"" + Brief + "\">";
                    chuoi += "<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">";

                }
                return chuoi;
            }
            else if (Modul == "11")
            {
                List<Entity.Gioithieu> dt = SGioithieu.Name_Text("SELECT * FROM [Gioithieu]  where TangName='" + hp + "'");
                string chuoi = "";
                string Images = "";
                string Brief = "";
                if (dt.Count > 0)
                {
                    if (dt[0].Images.ToString().Length > 0)
                    {
                        Images = dt[0].Images;
                    }
                    if (dt[0].Keyword.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Keyword, 250)); } else { if (dt[0].Brief.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Brief, 250)); } }
                    chuoi += "<meta property=\"fb:app_id\" content=\"" + Other.Giatri("txtfbapp_id") + "\" />";
                    chuoi += "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />";
                    chuoi += "<meta property=\"og:rich_attachment\" content=\"true\" />";
                    //chuoi += "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />";
                    chuoi += "<meta property=\"og:type\" content=\"article\" />";
                    chuoi += "<meta property=\"og:url\" content=\"" + url + "/" + hp + ".html\" />";
                    chuoi += "<meta property=\"og:title\" content=\"" + dt[0].Title + "\" />";
                    chuoi += "<meta property=\"og:description\" content=\"" + Brief + "\" />";
                    chuoi += "<meta property=\"og:image\" content=\"" + url + Images + "\" />";
                    chuoi += "<meta property=\"og:image:width\" content=\"720\" />";
                    chuoi += "<meta property=\"og:image:height\" content=\"480\" />";
                    chuoi += "<meta property=\"article:published_time\" content=\"" + MoreAll.FormatDate(dt[0].Create_Date) + "\" />";
                    chuoi += "<meta property=\"article:modified_time\" content=\"" + MoreAll.FormatDate(dt[0].Modified_Date) + "\" />";

                    chuoi += "<meta name=\"twitter:card\" content=\"summary_large_image\">";
                    chuoi += "<meta name=\"twitter:site\" content=\"" + url + "/" + hp + ".html\"> ";
                    chuoi += " <meta name=\"twitter:title\" content=\"" + dt[0].Title + "\">";
                    chuoi += " <meta name=\"twitter:description\" content=\"" + Brief + "\">";
                    chuoi += "<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">";

                }
                return chuoi;
            }
            else if (Modul == "100")
            {
                List<Entity.MNews> dt = SMNews.Name_Text("SELECT * FROM [MNews]  where TangName='" + hp + "'");
                string chuoi = "";
                string Images = "";
                string Brief = "";
                if (dt.Count > 0)
                {
                    if (dt[0].Images.ToString().Length > 0) { Images = dt[0].Images; } if (dt[0].Brief.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Brief, 250)); } else { if (dt[0].Title.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Title, 250)); } }
                    chuoi += "<meta property=\"fb:app_id\" content=\"" + Other.Giatri("txtfbapp_id") + "\" />";
                    chuoi += "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />";
                    chuoi += "<meta property=\"og:rich_attachment\" content=\"true\" />";
                    //  chuoi += "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />";
                    chuoi += "<meta property=\"og:type\" content=\"article\" />";
                    chuoi += "<meta property=\"og:url\" content=\"" + url + "/" + hp + ".html\" />";
                    chuoi += "<meta property=\"og:title\" content=\"" + dt[0].Title + "\" />";
                    chuoi += "<meta property=\"og:description\" content=\"" + Brief + "\" />";
                    chuoi += "<meta property=\"og:image\" content=\"" + url + Images + "\" />";
                    chuoi += "<meta property=\"og:image:height\" content=\"480\" />";
                    chuoi += "<meta property=\"article:published_time\" content=\"" + MoreAll.FormatDate(dt[0].Create_Date) + "\" />";
                    chuoi += "<meta property=\"article:modified_time\" content=\"" + MoreAll.FormatDate(dt[0].Modified_Date) + "\" />";

                    chuoi += "<meta name=\"twitter:card\" content=\"summary_large_image\">";
                    chuoi += "<meta name=\"twitter:site\" content=\"" + url + "/" + hp + ".html\"> ";
                    chuoi += " <meta name=\"twitter:title\" content=\"" + dt[0].Title + "\">";
                    chuoi += " <meta name=\"twitter:description\" content=\"" + Brief + "\">";
                    chuoi += "<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">";

                }
                return chuoi;
            }
            else if (Modul == "99")
            {
                List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where TangName='" + hp + "'");
                string chuoi = "";
                string Images = "";
                string Brief = "";
                string str3 = Banner.path();
                if (dt.Count > 0)
                {
                    if (dt[0].Images.ToString().Length > 0)
                    {
                        Images = dt[0].Images;
                    }
                    else
                    {
                        if (str3.Length > 4)
                        {
                            string str4 = str3.Substring(str3.IndexOf(".")).ToLower();
                            if ((str4.Equals(".jpg") || str4.Equals(".gif")) || str4.Equals(".png"))
                            {
                                Images = str3;
                            }
                        }
                    }
                    if (dt[0].Description.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Description, 250)); } else { if (dt[0].Name.ToString().Length > 0) { Brief = MoreAll.RemoveHTMLTags(MoreAll.Substring(dt[0].Name, 250)); } }
                    chuoi += "<meta property=\"fb:app_id\" content=\"" + Other.Giatri("txtfbapp_id") + "\" />";
                    chuoi += "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />";
                    chuoi += "<meta property=\"og:rich_attachment\" content=\"true\" />";
                    chuoi += "<meta property=\"og:type\" content=\"article\" />";
                    chuoi += "<meta property=\"og:url\" content=\"" + url + "/" + hp + ".html\" />";
                    chuoi += "<meta property=\"og:title\" content=\"" + dt[0].Name + "\" />";
                    chuoi += "<meta property=\"og:description\" content=\"" + Brief + "\" />";
                    chuoi += "<meta property=\"og:image\" content=\"" + url + Images + "\" />";
                    chuoi += "<meta property=\"og:image:height\" content=\"480\" />";

                    chuoi += "<meta name=\"twitter:card\" content=\"summary_large_image\">";
                    chuoi += "<meta name=\"twitter:site\" content=\"" + url + "/" + hp + ".html\"> ";
                    chuoi += " <meta name=\"twitter:title\" content=\"" + dt[0].Name + "\">";
                    chuoi += " <meta name=\"twitter:description\" content=\"" + Brief + "\">";
                    chuoi += "<meta name=\"twitter:image:src\" content=\"" + url + Images + "\">";

                }
                return chuoi;
            }
            else
            {
                string chuoi = "";
                string item = Other.Giatri("ImagesFacebook");

                chuoi += "<meta name=\"twitter:card\" content=\"summary_large_image\">";
                chuoi += "<meta name=\"twitter:site\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\"> ";
                chuoi += " <meta name=\"twitter:title\" content=\"" + Other.TitleWebname() + "\">";
                chuoi += " <meta name=\"twitter:description\" content=\"" + MoreAll.RemoveHTMLTags(Other.Titlekeyworddescription()) + "\">";
                chuoi += "<meta name=\"twitter:image:src\" content=\"" + url + item + "\">";

                chuoi += "<meta property=\"fb:app_id\" content=\"" + Other.Giatri("txtfbapp_id") + "\" />";
                chuoi += "<meta property=\"og:site_name\" content=\"" + url.Replace("http://", "").Replace("https://", "") + "\" />";
                chuoi += "<meta property=\"og:rich_attachment\" content=\"true\" />";
                //chuoi += "<meta property=\"article:publisher\" content=\"" + Other.Giatri("txtfacebook") + "\" />";
                chuoi += "<meta property=\"og:type\" content=\"article\" />";
                chuoi += "<meta property=\"og:url\" content=\"" + url + "\" />";
                chuoi += "<meta property=\"og:title\" content=\"" + Other.TitleWebname() + "\" />";
                chuoi += "<meta property=\"og:description\" content=\"" + MoreAll.RemoveHTMLTags(Other.Titlekeyworddescription()) + "\" />";
                chuoi += "<meta property=\"og:image\" content=\"" + url + item + "\" />";
                chuoi += "<meta property=\"og:image:width\" content=\"720\" />";
                chuoi += "<meta property=\"og:image:height\" content=\"480\" />";
                return chuoi;
            }
            return "";
            #endregion
        }
    }
}
