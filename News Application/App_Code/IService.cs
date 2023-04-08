using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	[WebGet(UriTemplate = "state?zip={zip}", ResponseFormat = WebMessageFormat.Json)]
	string GetState(string zip);

	[OperationContract]
	[WebGet(UriTemplate = "city?zip={zip}", ResponseFormat = WebMessageFormat.Json)]
	string GetCity(string zip);

	[OperationContract]
	[WebGet(UriTemplate = "news?zip={zip}", ResponseFormat = WebMessageFormat.Json)]
	NewsObj GetNews(string zip);

	[OperationContract]
	[WebGet(UriTemplate = "lat?zip={zip}", ResponseFormat = WebMessageFormat.Json)]
	float GetLat(string zip);

	[OperationContract]
	[WebGet(UriTemplate = "long?zip={zip}", ResponseFormat = WebMessageFormat.Json)]
	float GetLon(string zip);

	[OperationContract]
	[WebGet(UriTemplate = "count?startDate={startDate}&endDate={endDate}&zip={zip}", ResponseFormat = WebMessageFormat.Json)]
	int earthQuakeCOunt(string startDate, string endDate, string zip);

	[OperationContract]
	[WebGet(UriTemplate = "forecast?zip={zip}", ResponseFormat = WebMessageFormat.Json)]
	List<Periods> GetForecast(string zip);

	[OperationContract]
	[WebGet(UriTemplate = "latitude?zip={zip}", ResponseFormat = WebMessageFormat.Json)]
	float GetLatitude(string zip);

	[OperationContract]
	[WebGet(UriTemplate = "longitude?zip={zip}", ResponseFormat = WebMessageFormat.Json)]
	float GetLongitude(string zip);




	// TODO: Add your service operations here

}
public class Articles
{
	public Source source { get; set; }
	public string author { get; set; }
	public string title { get; set; }
	public string url { get; set; }
	public string urlToImage { get; set; }
}

public class Source
{
	public string name { get; set; }
}

public class NewsObj
{
	public List<Articles> articles { get; set; }
}

public class weatherData
{
	public Properties properties { get; set; }
}

public class Properties
{
	public string forecast { get; set; }

	public List<Periods> periods { get; set; }
}

public class Periods
{
	public int number { get; set; }

	public string name { get; set; }

	public bool isDayTime { get; set; }

	public int temperature { get; set; }

	public string detailedForecast { get; set; }

	public string icon { get; set; }
}