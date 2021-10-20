using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoreAll;
using Services;

namespace Advertisings
{
    public class Ad_vertisings
    {

        public static string CamNhanKhachHang(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion

                    strb += ("<div class=\"testimonial-item text-center p-4\">");
                    strb += ("<div class=\"image-avata\">");
                    strb += ("<img src=\"" + img + "\" alt=\"" + Name + "\">");
                    strb += ("</div>");
                    strb += ("<p class=\"designation\">" + Contents + "</p>");
                    strb += ("<h4 class=\"name\">" + Name + "</h4>");
                    strb += ("</div>");
                }
            }
            return strb.ToString();
        }



        public static string Showicon2(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion

                    if (i == 0)
                    {
                        strb += ("<li class=\"col_3 large\">");
                        strb += ("<a  target=" + Opentype + " href='/cms/Display/Advertisings/Advertisings.aspx?images=" + images + "' style=\"background:" + Contents + " \">");
                        strb += (" <span class=\"img\">");
                        strb += ("<img   alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    />");
                        strb += (" </span>");
                        strb += ("<span class=\"name\">" + Name + "</span>");
                        strb += ("</a>");
                        strb += ("</li>");
                    }
                    else
                    {
                        strb += ("<li class=\"col_3\">");
                        strb += ("<a  target=" + Opentype + " href='/cms/Display/Advertisings/Advertisings.aspx?images=" + images + "' style=\"background:" + Contents + " \">");
                        strb += (" <span class=\"img\">");
                        strb += ("<img   alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    />");
                        strb += (" </span>");
                        strb += ("<span class=\"name\">" + Name + "</span>");
                        strb += ("</a>");
                        strb += ("</li>");
                    }


                }
            }
            return strb.ToString();
        }
        public static string Showicon1(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion

                    strb += ("<li class=\"col_4\">");
                    strb += ("<a  target=" + Opentype + " href='/cms/Display/Advertisings/Advertisings.aspx?images=" + images + "' style=\"background:" + Contents + " \">");
                    strb += (" <span class=\"img\">");
                    strb += ("<img   alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    />");
                    strb += (" </span>");
                    strb += ("<span class=\"name\">" + Name + "</span>");
                    strb += ("</a>");
                    strb += ("</li>");

                }
            }
            return strb.ToString();
        }


        public static string ShowBanner(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    strb += (" <div class=\"item\"><a  class=\"clearfix\" target=" + Opentype + " href='/cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img   alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a></div>");
                }
            }
            return strb.ToString();
        }


        public static string TheoNhom(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.Name_Text("select * from Advertisings where lang='" + MoreAll.MoreAll.Language + "' and value=" + ID + " and Text=1 and Status=1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion

                    strb += ("<a class=\"banner\" target=" + Opentype + " href='/Cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img    alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a><div style=' clear:both' class='quangcao'>" + Contents + "</div>");

                }
            }
            return strb.ToString();
        }
        public static string Contents(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    #region Type
                    strb += Contents;
                    #endregion
                }
            }
            return strb.ToString();
        }
        public static string Advertisings_A_Images(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    #endregion
                    strb += ("<a target=" + Opentype + " href='/cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img   alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a>");
                }
            }
            return strb.ToString();
        }

        public static string Advertisings(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion
                    #region Type
                    if (dt[i].Text.ToString().Equals("1"))
                    {
                        strb += Contents;
                    }
                    if (Type.Equals("0"))//Text
                    {
                        strb += Contents;
                    }
                    else if (Type.Equals("1"))//Image
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<a target=" + Opentype + " href='/Cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img  alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a><div style=' clear:both' class='quangcao'>" + Contents + "</div>");
                        }
                    }
                    else if (Type.Equals("2"))//VIDeo Youtube
                    {
                        strb += _Youtube(Youtube, Width, Height) + "<div style=' clear:both'  class='quangcao'>" + Contents + "</div>";
                    }
                    else if (Type.Equals("3"))//Flash
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<embed style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    align='mIDdle'  quality='high' wmode='transparent' allowscriptaccess='always' flashvars='alink1=" + Path + "&amp;atar1=_blank' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + img + "'><div style=' clear:both'  class='quangcao'>" + Contents + "</div>");
                        }
                    }
                    #endregion
                }
            }
            return strb.ToString();
        }
        public static string Advertisings_LI(string ID)
        {
            string strb = "";
            List<Entity.Advertisings> dt = SAdvertisings.VALUES(MoreAll.MoreAll.Language, ID, "1");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    #region string
                    string Width = dt[i].Width.ToString();
                    string Height = dt[i].Height.ToString();
                    string img = dt[i].vimg.ToString();
                    string Path = dt[i].Path.ToString();
                    string Opentype = targets(dt[i].Opentype.ToString());
                    string images = dt[i].images.ToString();
                    string Equals = dt[i].Equals.ToString();
                    string Type = dt[i].Type.ToString();
                    string Youtube = dt[i].Youtube.ToString();
                    string Name = dt[i].Name.ToString();
                    string Contents = dt[i].Contents.ToString();
                    string Text = "";
                    #endregion
                    #region Type
                    if (dt[i].Text.ToString().Equals("1"))
                    {
                        strb += Contents;
                    }
                    if (Type.Equals("0"))//Text
                    {
                        strb += Contents;
                    }
                    else if (Type.Equals("1"))//Image
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<li><a target=" + Opentype + " href='/Cms/Display/Advertisings/Advertisings.aspx?images=" + images + "'><img  alt=\"" + Name.Replace("\"", "&rdquo;") + "\"  title=\"" + Name.Replace("\"", "&rdquo;") + "\" src='" + img + "' border=0   style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    /></a></li>");
                        }
                    }
                    else if (Type.Equals("2"))//VIDeo Youtube
                    {
                        strb += _Youtube(Youtube, Width, Height) + Text;
                    }
                    else if (Type.Equals("3"))//Flash
                    {
                        if (img.Length > 0)
                        {
                            strb += ("<li><embed style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'    align='mIDdle'  quality='high' wmode='transparent' allowscriptaccess='always' flashvars='alink1=" + Path + "&amp;atar1=_blank' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='" + img + "'></li>");
                        }
                    }
                    #endregion
                }
            }
            return strb.ToString();
        }


        public static string targets(string target)
        {
            if (target.Equals("0"))
            {
                return "_self";
            }
            return "_blank";
        }

        public static string _Youtube(string url, string Width, string Height)
        {
            #region Youtube
            string FormattedUrl = MoreVideoClip.GetYouTubeID(url);
            string str = "<iframe style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "' src=\"https://www.youtube.com/embed/" + FormattedUrl.Replace("https://www.youtube.com/watch?v=", "") + "\" frameborder=\"0\" allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>";
            return str.ToString();
            #endregion
        }


        public static string label(string ID)
        {
            return Captionlanguage.GetLabel(ID, MoreAll.MoreAll.Language);
        }
    }
}
