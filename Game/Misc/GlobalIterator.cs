// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GlobalIterator : Game_Data {

		public bool control_switch = false;
		public int delay = 10;
		public ByTable arg_list = new ByTable();
		public double last_exec = 0;
		public bool check_for_null = true;
		public bool forbid_garbage = false;
		public dynamic result = null;
		public bool state = false;

		// Function from file: global_iterator.dm
		public GlobalIterator ( ByTable arguments = null, bool? autostart = null ) {
			autostart = autostart ?? true;

			this.delay = ( this.delay > 0 ? this.delay : 1 );

			if ( this.forbid_garbage ) {
				this.tag = new Txt().Ref( this ).ToString();
			}
			this.set_process_args( arguments );

			if ( autostart == true ) {
				this.start();
			}
			return;
		}

		// Function from file: global_iterator.dm
		public bool toggle(  ) {
			
			if ( !this.stop() ) {
				this.start();
			}
			return this.active();
		}

		// Function from file: global_iterator.dm
		public bool toggle_null_checks(  ) {
			this.check_for_null = !this.check_for_null;
			return this.check_for_null;
		}

		// Function from file: global_iterator.dm
		public bool set_process_args( ByTable arguments = null ) {
			
			if ( arguments != null && arguments is ByTable && arguments.len != 0 ) {
				this.arg_list = arguments;
				return true;
			} else {
				return false;
			}
		}

		// Function from file: global_iterator.dm
		public bool get_last_exec_time_as_text(  ) {
			return Lang13.Bool( String13.FormatTime( this.last_exec, null ) ) || Lang13.Bool( "Wasn't executed yet" );
		}

		// Function from file: global_iterator.dm
		public bool get_last_exec_time(  ) {
			return this.last_exec != 0 || false;
		}

		// Function from file: global_iterator.dm
		public bool set_delay( double new_delay = 0 ) {
			
			if ( Lang13.Bool( Lang13.IsNumber( new_delay ) ) ) {
				this.delay = Num13.MaxInt( 1, Num13.Floor( new_delay ) );
				return true;
			} else {
				return false;
			}
		}

		// Function from file: global_iterator.dm
		public bool has_null_args(  ) {
			
			if ( this.arg_list.Contains( null ) ) {
				return true;
			}
			return false;
		}

		// Function from file: global_iterator.dm
		public bool active(  ) {
			return this.control_switch;
		}

		// Function from file: global_iterator.dm
		public virtual bool process( Obj port = null, dynamic mecha = null ) {
			return false;
		}

		// Function from file: global_iterator.dm
		public bool state_check(  ) {
			int lag = 0;

			lag = 0;

			while (this.state) {
				Task13.Sleep( 1 );

				if ( ++lag > 10 ) {
					Task13.Crash( new Txt( "The global_iterator loop " ).Ref( this ).str( " failed to terminate in designated timeframe. This may be caused by server lagging." ).ToString() );
				}
			}
			return true;
		}

		// Function from file: global_iterator.dm
		public bool stop(  ) {
			
			if ( !this.active() ) {
				return false;
			}
			this.control_switch = false;
			Task13.Schedule( -1, (Task13.Closure)(() => {
				this.state_check();
				return;
			}));
			return true;
		}

		// Function from file: global_iterator.dm
		public bool start( ByTable arguments = null ) {
			
			if ( this.active() ) {
				return false;
			}

			if ( arguments != null ) {
				
				if ( !this.set_process_args( arguments ) ) {
					return false;
				}
			}

			if ( !this.state_check() ) {
				return false;
			}
			this.control_switch = true;
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.state = this.main();
				return;
			}));
			return true;
		}

		// Function from file: global_iterator.dm
		public bool main(  ) {
			int? sleep_time = null;

			this.state = true;

			while (this != null && this.control_switch) {
				this.last_exec = Game13.timeofday;

				if ( this.check_for_null && this.has_null_args() ) {
					this.stop();
					return false;
				}
				this.result = this.arg_list.Apply( Lang13.BindFunc( this, "process" ) );
				sleep_time = null;
				sleep_time = this.delay;

				while (( sleep_time ??0) > 0) {
					
					if ( !this.control_switch ) {
						return false;
					}
					Task13.Sleep( 1 );
					sleep_time--;
				}
			}
			return false;
		}

	}

}