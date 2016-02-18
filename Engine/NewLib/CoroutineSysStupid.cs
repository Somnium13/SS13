using System;
using System.Collections.Generic;
using System.Threading;

using Somnium.Engine.ByImpl;

// This is a stupid coroutine implemenentation.
// It uses threads. I know this is a bad idea, and I know enough to know that I don't know all the reasons why it's a bad idea!
// Enjoy

namespace Somnium.Engine.NewLib {
	class CoroutineSysStupid : ICoroutineSystem {

		private Queue<Thread> idle_threads = new Queue<Thread>();
		private Dictionary<Thread, string> paused_threads = new Dictionary<Thread, string>();
		
		// Get a closure that can be used to resume the current routine.
		// The closure should mark the routine that it PAUSES as idle, so it can be re-used later.
		public Task13.Closure GetResumeTask() {
			var resume_thread = Thread.CurrentThread;
			
			return () => {
				idle_threads.Enqueue(Thread.CurrentThread);

				if (!paused_threads.Remove(resume_thread)) {
					throw new Exception("TRIED TO RESUME NON-PAUSED THREAD!");
				}

				resume_thread.Interrupt();

				try {
					Thread.Sleep(Timeout.Infinite);
				}
				catch (ThreadInterruptedException) { };
			};
		}

		// Pause the routine. You better have submitted the resume task somewhere or the routine will just hang forever.
		// Once the routine is paused, the system should automatically switch to a new or pooled routine running the scheduler loop.
		// Info should explain WHY the routine was paused.
		public void Pause(string info) {
			paused_threads.Add(Thread.CurrentThread, info);

			if (idle_threads.Count > 0) {
				var t = idle_threads.Dequeue();
				t.Interrupt();
			}
			else {
				var t = new Thread(Task13.__RunSchedulerLoop);
				t.Name = "[Shitty Coroutine]";
				t.Start();
			}

			try {
				Thread.Sleep(Timeout.Infinite);
			}
			catch (ThreadInterruptedException) { };
		}

		// Details not worked out, this should probably return something other than string.
		public string GetStats() {
			return "";
		}
	}
}
