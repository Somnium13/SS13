using System;
using System.Net;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace Somnium.Engine.NewLib {
	class WebServer {
		private static HttpListener server;
		private static Dictionary<string, ServiceCallback> service_callbacks = new Dictionary<string,ServiceCallback>();

		public delegate void ServiceCallback(HttpListenerContext context);

		public static void Start(string addr, int port) {
			if (server != null)
				throw new Exception("WebServer already running!");

			server = new HttpListener();
			server.Prefixes.Add("http://" + addr + ":" + port + "/");
			server.Start();

			new Thread(run_server_loop).Start();
		}

		// WARNING, NOT THREAD SAFE! SERVICES SHOULD BE REGISTERED BEFORE THE SERVER STARTS!
		public static void RegisterService(string key, ServiceCallback callback) {
			if (server != null)
				throw new Exception("Can not register a service while the server is running.");

			service_callbacks.Add(key, callback);
		}
		
		// I'm sure theres some "correct" rails-ass way to do this but this project already has thousands of lines of shitcode so a few more couldn't hurt.
		private static void run_server_loop() {
			while (true) {
				var c = server.GetContext();
				
				string method = c.Request.HttpMethod;
				Uri path = c.Request.Url;

				var output = c.Response.OutputStream;
				var output_writer = new StreamWriter(c.Response.OutputStream);

				// Set when we want to return a file's contents.
				string serve_path = null;

				if (c.Request.HttpMethod != "GET")
				{   // KEEP IT NICE AND SIMPLE.
					c.Response.StatusCode = 400;
				}
				else if (path.Segments.Length == 1)
				{
					serve_path = Config.DIR_WWW+"client/index.html";
				}
				else if (path.AbsolutePath == "/favicon.ico")
				{
					serve_path = Config.DIR_WWW+"favicon.ico";
				}
				else {
					switch (path.Segments[1])
					{
						case "content/":
							if (path.Segments.Length < 3)
							{
								c.Response.StatusCode = 400;
								break;
							}
							switch (path.Segments[2])
							{
								// This acts as a whitelist, so clients can't grab code or other stuff you potentially don't want them to see.
								case "icons/":
								case "sound/":
									serve_path = Config.DIR_CONTENT;
									for (int i = 2; i < path.Segments.Length; i++)
									{
										serve_path += path.Segments[i];
									}
									break;
								default:
									c.Response.StatusCode = 400;
									break;
							}
							break;
						case "dev/":
							if (!Config.DEVMODE)
							{
								c.Response.StatusCode = 400;
								break;
							}
							goto case "client/";
						case "client/":
							serve_path = Config.DIR_WWW;
							for (int i = 1; i < path.Segments.Length; i++)
							{
								serve_path += path.Segments[i];
							}
							break;
						case "service/":
							if (path.Segments.Length < 3)
							{
								c.Response.StatusCode = 400;
								break;
							}

							ServiceCallback callback;
							if (service_callbacks.TryGetValue(path.Segments[2], out callback))
							{
								callback(c);
								continue;
							}
							else {
								c.Response.StatusCode = 400;
								break;
							}
						default:
							c.Response.StatusCode = 400;
							break;
					}
				}

				if (serve_path != null) {
					try {
						FileAttributes attr = File.GetAttributes(serve_path);
						if (attr.HasFlag(FileAttributes.Directory)) {
							c.Response.StatusCode = 400;
						}
						else {
							// This is not how this should be dealt with but I couldn't really give a shit.
							var file_data = File.ReadAllBytes(serve_path);
							output.Write(file_data, 0, file_data.Length);
						}
					} catch (FileNotFoundException) {
						c.Response.StatusCode = 400;
					} catch (DirectoryNotFoundException) {
						c.Response.StatusCode = 400;
					}
				}
				
				if (c.Response.StatusCode == 400) {
					output_writer.WriteLine("ERROR 400 -- BAD REQUEST!");
				}

				output_writer.Close();
			}
		}
	}
}
