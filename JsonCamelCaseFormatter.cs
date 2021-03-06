﻿using System;
using System.IO;
using System.Net;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;

namespace JavaScriptWebApp
{
	/*public class JsonCamelCaseFormatter : MediaTypeFormatter
	{
		private readonly JsonSerializerSettings jsonSerializerSettings;

		public JsonCamelCaseFormatter()
		{
			jsonSerializerSettings =
				new JsonSerializerSettings
				{
					ContractResolver =
						new CamelCasePropertyNamesContractResolver()
				};

			// Fill out the mediatype and encoding we support
			SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
			Encoding = new UTF8Encoding(false, true);
		}

		protected override bool CanReadType(Type type)
		{
			return type != typeof(IKeyValueModel);
		}

		protected override bool CanWriteType(Type type)
		{
			return true;
		}

		protected override Task<object> OnReadFromStreamAsync(Type type,
			Stream stream, HttpContentHeaders contentHeaders,
			FormatterContext formatterContext)
		{
			// Create a serializer
			var serializer = JsonSerializer.Create(jsonSerializerSettings);

			// Create task reading the content
			return Task.Factory.StartNew(
				() =>
				{
					using (var streamReader = new StreamReader(stream, Encoding))
					using (var jsonTextReader = new JsonTextReader(streamReader))
						return serializer.Deserialize(jsonTextReader, type);
				});
		}

		protected override Task OnWriteToStreamAsync(Type type, object value,
			Stream stream, HttpContentHeaders contentHeaders,
			FormatterContext formatterContext,
			TransportContext transportContext)
		{
			// Create a serializer
			var serializer = JsonSerializer.Create(jsonSerializerSettings);

			// Create task writing the serialized content
			return Task.Factory.StartNew(
				() =>
				{
					using (var jsonTextWriter =
						new JsonTextWriter(new StreamWriter(stream, Encoding))
						{
							Formatting = Formatting.Indented,
							CloseOutput = false
						})
					{
						serializer.Serialize(jsonTextWriter, value);
						jsonTextWriter.Flush();
					}
				});
		}
	}*/
}