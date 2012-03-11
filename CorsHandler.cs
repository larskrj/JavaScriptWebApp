﻿using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace Api
{
	public class CorsHandler : DelegatingHandler
	{
		const string Origin = "Origin";
		const string AccessControlRequestMethod = "Access-Control-Request-Method";
		const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
		const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
		const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
		const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";

		protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			bool isCorsRequest = request.Headers.Contains(Origin);
			bool isPreflightRequest = request.Method == HttpMethod.Options;
			if (isCorsRequest)
			{
				if (isPreflightRequest)
				{
					return Task.Factory.StartNew(() =>
					{
						var response = new HttpResponseMessage(HttpStatusCode.OK);
						response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());

						string accessControlRequestMethod = request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
						if (accessControlRequestMethod != null)
						{
							response.Headers.Add(AccessControlAllowMethods, accessControlRequestMethod);
						}

						IEnumerable<string> accessRequestHeader;
						
						if (request.Headers.TryGetValues(AccessControlRequestHeaders, out accessRequestHeader))
						{
							string requestedHeaders = string.Join(", ", accessRequestHeader);
							response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);
						}

						return response;
					}, cancellationToken);
				}
				else
				{
					return base.SendAsync(request, cancellationToken).ContinueWith(t =>
					{
						HttpResponseMessage resp = t.Result;
						resp.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());
						return resp;
					});
				}
			}
			else
			{
				return base.SendAsync(request, cancellationToken);
			}
		}
	}
}