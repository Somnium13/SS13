using System;
using System.Collections.Generic;

using System.Diagnostics;

using Somnium.Engine.NewLib;

namespace Somnium.Engine.ByImpl {
	// Was previously called Thread13. This actually implements coroutines.
	// How? I have no clue.
	// Probably via threads since the options are limited without tons of wonky syntax.
	// Using generators, you can't go deeper than one level.
	// Fibers would be cool, but I'm not sure how they play with .NET
	// I'm still not exactly sure how async and await work and if they could even be useful.
	// Maybe this can help? http://blogs.msdn.com/b/pfxteam/archive/2011/01/13/10115642.aspx

	static class Task13 {
		// this is a verbs 'usr' var
		public static Somnium.Game.Mob User;
		
		// used when a static function tries to access 'this'
		// also used when any function tries to assign to 'this'
		// note that other occurances of 'this' in a function will not be replaced -- this is purely an emergancy measure
		public static dynamic Source;

		public static void Crash(string msg) {
			throw new Exception("Task crashed! "+msg);
		}

		public static void Sleep(int t) {
			// Don't sleep if the scheduler hasn't started!
			if (!__IsSchedulerRunning())
				return;
			
			if (t == -1) {
				if (frame_ms_remaining >= BG_MIN_MS) {
					return; // We can continue, we have enough time.
				}
				// Otherwise, throw pause and go into the BG queue. TODO would it be better to schedule for next frame instead of BG?
			}

			var f = coroutines.GetResumeTask();

			Schedule(t, f);

			coroutines.Pause("sleeping or some shit!");
		}

		public delegate void Closure();

		// VALUES: (NOT VERIFIED BUT SHOULD WORK!)
		// -1 -> Background
		//  0 -> End of current frame
		//  1 -> End of next frame
		//  etc

		// TODO ACCORDING TO DOC, SCHEDULED EVENTS ARE IGNORED IF THEIR SRC/'THIS' OBJECT WAS DELETED! HOW TO HANDLE THIS?
		// TODO SRC AND USR SHOULD BE THE SAME AS WHEN THE SCHEDULING FUNCTION TERMINATED?
		public static void Schedule(int t, Closure f) {

			if (t == 0) {
				frame_tasks.AddLast(f);
			}
			else if (t==-1) {
				background_tasks.AddLast(f);
			}
			else if (t < 0) {
				throw new Exception("Task13.schedule() called with invalid param: " + t);
			}
			else {

				int schedule_time = (int)((frame_number + t) / Game13.tick_lag);

				LinkedList<Closure> tasks;

				if (!task_pq.TryGetValue(schedule_time, out tasks)) {
					tasks = new LinkedList<Closure>();
					task_pq.Add(schedule_time, tasks);
				}
				
				tasks.AddLast(f);
			}
		}

		// INTERNAL SHIT
		private static int BG_MIN_MS = 50;

		private static ICoroutineSystem coroutines = new CoroutineSysStupid();

		// This is a priority queue of tasks to be run. A heap might be better for this, not sure.
		// The keys are the decisecond, in gametime, when the task should execute. Part of me worries that a resolution of a decisecond isn't enough
		// A much larger part of me doesn't give a goddamn.
		private static SortedDictionary<int, LinkedList<Closure>> task_pq = new SortedDictionary<int, LinkedList<Closure>>();

		// This holds all the tasks scheduled for "background" execution, which we probably won't bother to implement correctly...
		private static LinkedList<Closure> background_tasks = new LinkedList<Closure>();

		private static int frame_number = 0;
		private static LinkedList<Closure> frame_tasks = new LinkedList<Closure>(); // TODO we should be able to just cache an empty list to use for this!

		private static Stopwatch frame_timer = new Stopwatch();
		private static int frame_ms_remaining {
			get {
				return (int)(Game13.tick_lag * 100) - (int)frame_timer.ElapsedMilliseconds;
			}
		}

		public static void __RunSchedulerLoop() {
			frame_timer.Start(); // start the goddamn timer if it hasn't started yet
			
			while (true) {
				// Load up a new set of frame tasks, if necessary.


				do {
					while (frame_tasks.Count > 0) {
						var t = frame_tasks.First.Value;
						frame_tasks.RemoveFirst();
						try {
							t();
						}
						catch (Exception e) {
							Logger.Error("Scheduled task crashed!", e);
						}
					}

					while (background_tasks.Count > 0 && frame_ms_remaining>=BG_MIN_MS) {
						var t = background_tasks.First.Value;
						background_tasks.RemoveFirst();
						try {
							t();
						}
						catch (Exception e) {
							Logger.Error("Scheduled task crashed!",e);
						}
					}
				} while (frame_tasks.Count > 0);

				// ENGINE SHIT GOES HERE

				ServiceDev.Process();

				// Increment frame, load tasks for next frame.

				frame_number++;

				LinkedList<Closure> temp_tasks;

				if (task_pq.TryGetValue(frame_number, out temp_tasks)) {
					frame_tasks = temp_tasks;
				}

				// Sleep until next frame time, or print a warning if we're over budget.

				int sleep_ms = frame_ms_remaining;

				if (sleep_ms < 0) {
					Logger.LogScheduler("FRAME "+(frame_number-1)+" WAS OVER BUDGET ("+(-sleep_ms)+"MS)");
				}
				else if (sleep_ms > 0) {
					System.Threading.Thread.Sleep(sleep_ms);
				}
				
				frame_timer.Restart();
			}
		}

		public static bool __IsSchedulerRunning() {
			return frame_timer.IsRunning;
		}
	}
	
	// This is what a coroutine system should look like.
	// Details, including pooling, are left to the implementation.
	interface ICoroutineSystem {
		
		// Get a closure that can be used to resume the current routine.
		// The closure should mark the routine that it PAUSES as idle, so it can be re-used later.
		Task13.Closure GetResumeTask();

		// Pause the routine. You better have submitted the resume task somewhere or the routine will just hang forever.
		// Once the routine is paused, the system should automatically switch to a new or pooled routine running the scheduler loop.
		// Info should explain WHY the routine was paused.
		void Pause(string info);

		// Details not worked out, this should probably return something other than string.
		string GetStats();
	}

}
