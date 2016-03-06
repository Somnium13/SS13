using System;
using System.Net;
using System.Net.WebSockets;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.IO;

namespace Somnium.Engine.NewLib {

	static class ServiceGame {

		static ConcurrentQueue<EngineClient> clients_new = new ConcurrentQueue<EngineClient>();
		static HashSet<EngineClient> clients = new HashSet<EngineClient>();

		public static void Setup() {
			WebServer.RegisterService("connect", service_connect);
		}

		public static void Process()
		{
			// Add new clients.
			while (clients_new.Count>0)
			{
				EngineClient c;
				if (clients_new.TryDequeue(out c))
				{
					clients.Add(c);
				}
			}

			// Process clients.
			LinkedList<EngineClient> clients_deleted = new LinkedList<EngineClient>();
			foreach (var c in clients) {
				var process_result = c.Process();
				if (process_result != null)
				{
					Logger.LogNet("Dropped " + c + ": "+ process_result);
					clients_deleted.AddLast(c);
				}
			}

			// Delete old clients.
			foreach (var c in clients_deleted)
				clients.Remove(c);
		}

		private static void service_connect(HttpListenerContext context) {
			if (ByImpl.Task13.__IsSchedulerRunning())
			{
				context.AcceptWebSocketAsync("Somnium13").ContinueWith((task) =>
				{
					clients_new.Enqueue(new EngineClient(task.Result.WebSocket));
				});
			}
			else {
				context.Response.StatusCode = 503;
				context.Response.Close();
			}
		}
	}

	class EngineClient
	{
		private const int MAX_RECEIVES_PER_FRAME = 3;
		private const int CHUNK_SIZE = 512;

		private WebSocket websocket;
		private DateTime time_created;
		private bool authed;
		private bool closed;
		private string drop_msg;

		private string username;

		private Task<WebSocketReceiveResult> receive_task;
		private new ArraySegment<byte> receive_buffer = new ArraySegment<byte>(new byte[CHUNK_SIZE]);

		private MemoryStream receive_stream = new MemoryStream();
		private BinaryWriter receive_writer;
		private BinaryReader receive_reader;

		private MemoryStream send_stream = new MemoryStream();
		private BinaryWriter send_writer;

		public EngineClient(WebSocket ws) {
			websocket = ws;

			time_created = DateTime.Now;

			receive_writer = new BinaryWriter(receive_stream);
			receive_reader = new BinaryReader(receive_stream);

			send_writer = new BinaryWriter(send_stream);

			Listen();
		}

		// Returns disconnect reason if should be deleted.
		public string Process()
		{
			if (closed) return drop_msg;

			if (!authed && time_created.AddSeconds(5)<=DateTime.Now)
			{
				Drop("Took too long to auth.");
				return drop_msg;
			}

			int receive_n = 0;
			while (receive_task.IsCompleted && receive_n < MAX_RECEIVES_PER_FRAME)
			{
				WebSocketReceiveResult result = receive_task.Result;

				if (result.MessageType == WebSocketMessageType.Binary)
				{
					receive_writer.Write(receive_buffer.Array, 0, result.Count);

					if (result.EndOfMessage)
					{
						receive_stream.Position = 0;
						try {
							HandleMessage();
						} catch (Exception e)
						{
							var msg = "Client \"" + this + "\" dropped due to protocol error.";
							Logger.Error(msg,e);
							Drop("Protocol error. Bad message.");
							return drop_msg;
						}
						receive_stream.SetLength(0);
					}
					Listen();
				}
				else
				{
					if (result.MessageType == WebSocketMessageType.Text)
					{
						Drop("Protocol error. Attempt to send textual message.");
					}
					// We delete the client if it was a text or close message.
					return drop_msg ?? "Connection closed.";
				}
				receive_n++;
			}

			return null;
		}

		// Drops the client.
		public void Drop(string msg)
		{
			if (closed) return;

			var ct = new System.Threading.CancellationToken();
			websocket.CloseAsync(WebSocketCloseStatus.NormalClosure, msg, ct);

			closed = true;
			drop_msg = msg;
		}

		private void HandleMessage()
		{
			byte msg_type = receive_reader.ReadByte();
			switch (msg_type)
			{
				case 0:
					RxAuth();
					break;
				default:
					throw new Exception("Unknown net message #"+msg_type+".");
			}
		}

		// This is a temporary auth strategy. It doesn nothing. Obviously we need something better.
		private void RxAuth()
		{
			if (authed)
				throw new Exception("Already authed!");

			string n = receive_reader.ReadString();
			if (n.Length<1)
			{
				Drop("Name empty.");
				return;
			}
			else if (n.Length > 32)
			{
				Drop("Name too long.");
				return;
			} 

			username = n;
			authed = true;
			Logger.LogNet("Accepted "+this+".");
			TxAccept();
		}

		private void TxAccept()
		{
			send_writer.Write((byte)0);
			Send();
		}
		
		private void Listen()
		{
			if (closed) return;

			var ct = new System.Threading.CancellationToken();
			
			receive_task = websocket.ReceiveAsync(receive_buffer, ct);
		}

		private void Send()
		{
			if (closed) return;

			var ct = new System.Threading.CancellationToken();
			websocket.SendAsync(new ArraySegment<byte>(send_stream.GetBuffer(), 0, (int)send_stream.Position), WebSocketMessageType.Binary, true, ct);
			send_stream.SetLength(0);
		}

		public override string ToString()
		{
			if (username != null)
				return "client \"" + username + "\"";

			return "unnamed client #"+this.GetHashCode();
		}
	}
}
