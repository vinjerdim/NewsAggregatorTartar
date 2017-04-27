using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewsTartar
{
    public partial class _Default : Page
    {
        public string keyword = "";
        public int algorithm = 0;
        public static List<Feeds> antaraNews = new List<Feeds>();
        public static List<Feeds> tempoNews = new List<Feeds>();
        public static List<Feeds> detikNews = new List<Feeds>();
        public static List<Feeds> vivaNews = new List<Feeds>();
        public static List<Feeds> result = new List<Feeds>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                keyword = Request["keyword"];
                algorithm = Int32.Parse(Request["algorithm"]);
               // result = RSSLoader.getSearchResult(antaraNews, keyword, algorithm);
                antara.DataSource = antaraNews;
                antara.DataBind();
                /**
                result = RSSLoader.getSearchResult(tempoNews, keyword, algorithm);
                tempo.DataSource = result;
                tempo.DataBind();
                result = RSSLoader.getSearchResult(vivaNews, keyword, algorithm);
                viva.DataSource = result;
                viva.DataBind();
                result = RSSLoader.getSearchResult(detikNews, keyword, algorithm);
                detik.DataSource = result;
                detik.DataBind();
                 * */
            }
            else
            {
                antaraNews = RSSLoader.loadFeedList(2);
            }
        }
    }
}