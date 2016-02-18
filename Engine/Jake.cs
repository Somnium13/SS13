using System;
using System.Collections;

using Somnium.Game;

using Somnium.Engine.ByImpl;
using Somnium.Engine.NewLib;

namespace Somnium.Engine {
	static class Jake {
		static void Main(string[] args) {
			try { // The goddamn debugger can't seem to handle TypeInitializationExceptions so we'll just handle it ourselves.
				Logger.Announce("Hello, world!");
				object x = GlobalVars._preloader; // This forces global initialization ASAP

				ServiceDev.Setup();
				WebServer.Start("localhost", 80);

				Logger.Announce("Loading Map!");
				var maploader = new DMMLoader();
				maploader.LoadMap("_maps/map_files/TgStation/tgstation.2.1.3.dmm", 0, 0, 1);
				//maploader.LoadMap("maps/tgstation.dmm", 0, 0, 1);

				//DMMLoader.Load("../../../-tg-station/_maps/map_files/TgStation/tgstation.2.1.3.dmm");

				Logger.Announce("Initializing Game!");
				Game13.New();

				Logger.Announce("Starting Scheduler!");
				Task13.__RunSchedulerLoop();
			}
			catch (Exception e) {
				Logger.Error("Fatal Error in Main!", e);
				Console.ReadLine();
			}
		}
	}
}