using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;

namespace MailGun
{
	class Program
	{
		static private readonly string _apikey = "key-0v-08hp3n4xo1ux0gar308u5lfv5kge9";
		static private readonly string _domain = "sandboxafe318142ef54512904e2f9fb1887c11.mailgun.org";


		static void Main(string[] args)
		{
			var restres = GetRoutes();
		}

		#region mailboxes
		public static IRestResponse GetMailboxes()
		{
			RestClient client = new RestClient();
			client.BaseUrl = "https://api.mailgun.net/v2";
			client.Authenticator =
					new HttpBasicAuthenticator("api", _apikey);
			RestRequest request = new RestRequest();
			request.AddParameter("domain", 
								 _domain,
								 ParameterType.UrlSegment);
			request.Resource = "{domain}/mailboxes";
			return client.Execute(request);
		}

		public static IRestResponse CreateMailbox()
		{
			RestClient client = new RestClient();
			client.BaseUrl = "https://api.mailgun.net/v2";
			client.Authenticator =
					new HttpBasicAuthenticator("api",
											   _apikey);
			RestRequest request = new RestRequest();
			request.AddParameter("domain", _domain, ParameterType.UrlSegment);
			request.Resource = "{domain}/mailboxes";
			request.AddParameter("mailbox", "iliya@" + _domain);
			request.AddParameter("password", "password");
			request.Method = Method.POST;
			return client.Execute(request);
		}
		#endregion

		#region routes
		public static IRestResponse CreateRoute()
		{
			RestClient client = new RestClient();
			client.BaseUrl = "https://api.mailgun.net/v2";
			client.Authenticator = new HttpBasicAuthenticator("api",_apikey);
			RestRequest request = new RestRequest();
			request.Resource = "routes";
			request.AddParameter("priority", 0);
			request.AddParameter("description", "created via API");
			request.AddParameter("expression", "match_recipient('iliya')");
			request.AddParameter("action", "store(notify='http://requestb.in/1775q441')");
			request.Method = Method.POST;
			return client.Execute(request);
		}

		public static IRestResponse GetRoutes()
		{
			RestClient client = new RestClient();
			client.BaseUrl = "https://api.mailgun.net/v2";
			client.Authenticator =
					new HttpBasicAuthenticator("api",_apikey );
			RestRequest request = new RestRequest();
			request.Resource = "routes";
			request.AddParameter("skip", 0);
			request.AddParameter("limit", 10);
			return client.Execute(request);
		}
		#endregion


		public static IRestResponse GetLogs()
		{
			RestClient client = new RestClient();
			client.BaseUrl = "https://api.mailgun.net/v2";
			client.Authenticator = new HttpBasicAuthenticator("api", _apikey);
			RestRequest request = new RestRequest();
			request.AddParameter("domain",
								 _domain, ParameterType.UrlSegment);
			request.Resource = "{domain}/logs";
			request.AddParameter("skip", 0);
			request.AddParameter("limit", 1);
			return client.Execute(request);
		}


		public static IRestResponse GetMail()
		{
			RestClient client = new RestClient();
			client.BaseUrl = "https://api.mailgun.net/v2/domains/sandboxafe318142ef54512904e2f9fb1887c11.mailgun.org/messages/WyIyNGZkMzg1YzRiIiwgWyIzYjY4NTRhMi1mNTc2LTExZTMtOWYzOC1iYzc2NGUxMDMzYjIiXSwgIm1haWxndW4iLCAibmV3Y29rZSJd";
			client.Authenticator = new HttpBasicAuthenticator("api", _apikey);
			RestRequest request = new RestRequest();
			return client.Execute(request);
		}

		public static IRestResponse GetEvents()
		{
			RestClient client = new RestClient();
			client.BaseUrl = "https://api.mailgun.net/v2";
			client.Authenticator = new HttpBasicAuthenticator("api", _apikey);
			RestRequest request = new RestRequest();
			request.AddParameter("domain",
								 _domain, ParameterType.UrlSegment);
			request.Resource = "{domain}/events";
			return client.Execute(request);
		}


		public static IRestResponse GetEventsReciveSimpleMessage()
		{
			RestClient client = new RestClient();
			client.BaseUrl = "https://api.mailgun.net/v2";
			client.Authenticator =
					new HttpBasicAuthenticator("api", _apikey);
			RestRequest request = new RestRequest();
			request.AddParameter("domain", _domain, ParameterType.UrlSegment);
			request.Resource = "{domain}/messages";
			return client.Execute(request);
		}


		public static IRestResponse SendSimpleMessage()
		{
			RestClient client = new RestClient();
			client.BaseUrl = "https://api.mailgun.net/v2";
			client.Authenticator =
					new HttpBasicAuthenticator("api", _apikey);
			RestRequest request = new RestRequest();
			request.AddParameter("domain", _domain, ParameterType.UrlSegment);
			request.Resource = "{domain}/messages";

			request.AddParameter("from", "Excited User <me@samples.mailgun.org>");
			request.AddParameter("to", "r.plakhuta@gmail.com");
			request.AddParameter("subject", "Hello");
			request.AddParameter("text", "Testing some Mailgun awesomness!");
			request.Method = Method.POST;
			return client.Execute(request);
		}
	}
}