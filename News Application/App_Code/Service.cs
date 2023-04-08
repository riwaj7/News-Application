using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public static string json = new WebClient().DownloadString("https://github.com/millbj92/US-Zip-Codes-JSON/blob/master/USCities.json?raw=true");

	public string GetCity(string zip)
	{
		try
		{
			int zipcode = int.Parse(zip);
			var zipcodes = JsonConvert.DeserializeObject<List<CityCodes>>(json);
			for (int i = 0; i < zipcodes.Count; i++)
			{
				if (zipcode == zipcodes[i].zip_code)
				{
					return zipcodes[i].city;
				}
			}
			return "Check ZipCode, City not found";
		}
		catch (Exception)
		{
			return "City not found";
		}
	}
	public string GetState(string zip)
	{
		try
		{
			int zipcode = int.Parse(zip);
			var zipcodes = JsonConvert.DeserializeObject<List<CityCodes>>(json);
			for (int i = 0; i < zipcodes.Count; i++)
			{
				if (zipcode == zipcodes[i].zip_code)
				{
					return zipcodes[i].state;
				}
			}
			return "State not found";
		}
		catch (Exception)
		{
			return "City not found";
		}
	}

	public NewsObj GetNews(string zip)
	{
		string myApiKey = "3f0dd3695c53498495d165abbaa0b127";
		string city = GetCity(zip);
		string state = GetState(zip);
		string url = @"https://newsapi.org/v2/everything?q=" + city + "%20" + state + "&sortBy=publishedAt&apiKey=" + myApiKey;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();
		response.Close();
		NewsObj newsObject = JsonConvert.DeserializeObject<NewsObj>(responsereader);
		return newsObject;
	}

	public float GetLat(string zip)
	{
		int zipcode = int.Parse(zip);
		var zipcodes = JsonConvert.DeserializeObject<List<CityCodes>>(json);
		for (int i = 0; i < zipcodes.Count; i++)
		{
			if (zipcode == zipcodes[i].zip_code)
			{
				return float.Parse(zipcodes[i].latitude);
			}
		}
		return -1;
	}
	public float GetLon(string zip)
	{
		int zipcode = int.Parse(zip);
		var zipcodes = JsonConvert.DeserializeObject<List<CityCodes>>(json);
		for (int i = 0; i < zipcodes.Count; i++)
		{
			if (zipcode == zipcodes[i].zip_code)
			{
				return float.Parse(zipcodes[i].longitude);
			}
		}
		return -1;
	}

	public int earthQuakeCOunt(string startDate, string endDate, string zip)
	{
		float lat = GetLat(zip);
		float lon = GetLon(zip);
		string url = "https://earthquake.usgs.gov/fdsnws/event/1/count?starttime=1917-09-23&endtime=" + startDate + "&latitude=" + lat + "&longitude=" + lon + "&maxradiuskm=100&minmagnitude=2.5&eventtype=earthquake&orderby=time";
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		string responsereader = sreader.ReadToEnd();
		response.Close();
		return Convert.ToInt32(responsereader);


	}
	public float GetLatitude(string zip)
	{

		int zipcode = int.Parse(zip);
		var zipcodes = JsonConvert.DeserializeObject<List<CityCodes>>(json);
		for (int i = 0; i < zipcodes.Count; i++)
		{
			if (zipcode == zipcodes[i].zip_code)
			{
				return float.Parse(zipcodes[i].latitude);
			}

		}
		return -1;

	}
	public float GetLongitude(string zip)
	{

		int zipcode = int.Parse(zip);
		var zipcodes = JsonConvert.DeserializeObject<List<CityCodes>>(json);
		for (int i = 0; i < zipcodes.Count; i++)
		{
			if (zipcode == zipcodes[i].zip_code)
			{
				return float.Parse(zipcodes[i].longitude);
			}

		}
		return -1;

	}


	public List<Periods> GetForecast(string zip)
	{
		float lat = GetLatitude(zip);
		float lon = GetLongitude(zip);
		string url = @"https://api.weather.gov/points/" + lat + "," + lon;
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.Method = "GET";
		request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
		request.Credentials = CredentialCache.DefaultCredentials;
		WebResponse response = request.GetResponse();
		Stream dataStream = response.GetResponseStream();
		StreamReader sreader = new StreamReader(dataStream);
		var responsereader = sreader.ReadToEnd();
		response.Close();

		var weather = JsonConvert.DeserializeObject<weatherData>(responsereader);
		url = weather.properties.forecast;
		request = (HttpWebRequest)WebRequest.Create(url);
		request.Method = "GET";
		request.UserAgent = @"Mozilla/5.0 (Windows NT 10.0; Win64; x64)";
		request.Credentials = CredentialCache.DefaultCredentials;
		response = request.GetResponse();
		dataStream = response.GetResponseStream();
		sreader = new StreamReader(dataStream);
		responsereader = sreader.ReadToEnd();
		response.Close();
		var forecast = JsonConvert.DeserializeObject<weatherData>(responsereader);
		return forecast.properties.periods;



	}


}
public class CityCodes
{
	public int zip_code { get; set; }
	public string latitude { get; set; }
	public string longitude { get; set; }
	public string city { get; set; }
	public string state { get; set; }
	public string county { get; set; }
}
