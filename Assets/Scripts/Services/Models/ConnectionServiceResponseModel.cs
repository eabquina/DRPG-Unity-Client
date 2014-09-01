using System.Collections.Generic;

public class ConnectionServiceResponseModel : WebServiceResponseModel
{
	public string sessid { get; set; }
	public string session_name { get; set; }
	public string token { get; set; }
	public Dictionary<object, object> user { get; set; }
}
