using System;
using System.Net;

namespace Somnium.Engine.NewLib {
	static class ServiceAuth {

		public static void Setup() {
			WebServer.RegisterService("login", service_login);
		}

		private static void service_login(HttpListenerContext context) {
			
		}
	}
}
