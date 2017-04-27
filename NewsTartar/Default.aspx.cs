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
        public static List<Feeds> detikNews = new List<Feeds>();
        public static List<Feeds> vivaNews = new List<Feeds>();
        public static List<Feeds> result = new List<Feeds>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                keyword = Request["keyword"];
                algorithm = Int32.Parse(Request["algorithm"]);

                result = RSSLoader.getSearchResult(antaraNews, keyword, algorithm);
                antara.DataSource = result;
                antara.DataBind();
                countAntara.Text = result.Count + " search result(s)";
                
                result = RSSLoader.getSearchResult(detikNews, keyword, algorithm);
                detik.DataSource = result;
                detik.DataBind();
                countDetik.Text = result.Count + " search result(s)";

                result = RSSLoader.getSearchResult(vivaNews, keyword, algorithm);
                viva.DataSource = result;
                viva.DataBind();
                countViva.Text = result.Count + " search result(s)";
            }
            else
            {
                antaraNews = RSSLoader.loadFeedList(1);
                detikNews = RSSLoader.loadFeedList(2);
                vivaNews = RSSLoader.loadFeedList(3);
            }
        }
    }
}