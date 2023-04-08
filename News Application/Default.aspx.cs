using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
	protected string hostURL = "http://localhost:58414";
	protected void Page_Load(object sender, EventArgs e)
    {
		HttpCookie cookie = Request.Cookies["Cookie"];
		if (cookie!=null)
        {
			TextBox1.Text = cookie["input"];
        }

    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
		HttpCookie cookie = new HttpCookie("Cookie");
		cookie["input"] = TextBox1.Text;
		cookie.Expires = DateTime.Now.AddMinutes(1);
		Response.Cookies.Add(cookie);

		string url = @hostURL + "/Service.svc/city?zip=" + TextBox1.Text;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();

		if (responsereader == "\"City not found\"")
		{
			Alert("Wrong zipcode!");
		}
		else
		{

			getNews();
		}
	}

	protected void Alert(string message)
	{
		Page page = HttpContext.Current.Handler as Page;
		ScriptManager.RegisterStartupScript(page, page.GetType(), "ERROR", "alert(' " + message + " ');", true);

	}
	protected void getNews()
	{
		
		string url = @hostURL + "/Service.svc/news?zip=" + TextBox1.Text;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();

		NewsObj newsObject = JsonConvert.DeserializeObject<NewsObj>(responsereader);

		for (int i = 0; i < newsObject.articles.Count; i++)
		{

			HtmlGenericControl container = new HtmlGenericControl("container");
			HtmlGenericControl a = new HtmlGenericControl("a");
			HtmlGenericControl link = new HtmlGenericControl("p");
			HtmlGenericControl source = new HtmlGenericControl("p");

			a.InnerText = newsObject.articles[i].title;
			a.Attributes.Add("href", newsObject.articles[i].url);
			link.Controls.Add(a);

			source.InnerHtml = newsObject.articles[i].source.name;

			container.Controls.Add(source);
			container.Controls.Add(link);
			container.Attributes.Add("style", "background: #ff00aa;");

			outputDiv.Controls.Add(container);
		}
	}



    protected void Button2_Click(object sender, EventArgs e)
    {
		try
		{
			string url = hostURL + "/Service.svc/count?starttime=" + TextBox2.Text + "&endtime=" + TextBox3.Text + "&zip=" + TextBox1.Text;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.ContentType = "application/json";
			WebResponse response = request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader sreader = new StreamReader(dataStream);
			string responsereader = sreader.ReadToEnd();
			TextBox4.Text = responsereader;


		}
		catch (Exception exception)
		{
			TextBox4.Text = ("Error");


		}
	}

    protected void Button2_Click1(object sender, EventArgs e)
    {
        try
        {
			string url = hostURL + "/Service.svc/forecast?zip=" + TextBox1.Text;
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.ContentType = "application/json";
			WebResponse response = request.GetResponse();
			Stream dataStream = response.GetResponseStream();
			StreamReader sreader = new StreamReader(dataStream);
			string responsereader = sreader.ReadToEnd();
			var forecast = JsonConvert.DeserializeObject<List<Periods>>(responsereader);

			int i = 0;
			t3.Text = forecast[i].temperature.ToString();
			t4.Text = forecast[i].isDayTime.ToString();
			t5.Text = forecast[i].detailedForecast;
			t6.Text = forecast[i].number.ToString();
			t7.Text = forecast[i].name;



		}
		catch (Exception ex)
        {

			Alert("Wrong zipcode!");

		}
		
			
		
	}
}