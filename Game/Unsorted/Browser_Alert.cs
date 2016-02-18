// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Browser_Alert : Browser {

		public double? selectedbutton = 0;
		public int opentime = 0;
		public int? timeout = null;
		public bool? stealfocus = null;

		// Function from file: browser.dm
		public Browser_Alert ( dynamic User = null, string Message = null, string Title = null, string Button1 = null, string Button2 = null, string Button3 = null, bool? StealFocus = null, int? Timeout = null ) : base( (object)(User), /* Bad Super Arg: [String13.CKey( "" + User + "-" + Message + "-" + Title + "-" + Game13.time + "-" + Rand13.Int( 1, 10000 ) )] */ null, Title, /* Bad Super Arg: [350] */ null, /* Bad Super Arg: [150] */ null, /* Bad Super Arg: [this] */ null ) {
			Button1 = Button1 ?? "Ok";
			StealFocus = StealFocus ?? true;
			Timeout = Timeout ?? 6000;

			string output = null;

			
			if ( !Lang13.Bool( User ) ) {
				return;
			}
			output = new Txt( "<center><b>" ).item( Message ).str( "</b></center><br />\n		<div style=\"text-align:center\">\n		<a style=\"font-size:large;float:" ).item( ( Lang13.Bool( Button2 ) ? "left" : "right" ) ).str( "\" href=\"?src=" ).Ref( this ).str( ";button=1\">" ).item( Button1 ).str( "</a>" ).ToString();

			if ( Lang13.Bool( Button2 ) ) {
				output += new Txt( "<a style=\"font-size:large;" ).item( ( Lang13.Bool( Button3 ) ? "" : "float:right" ) ).str( "\" href=\"?src=" ).Ref( this ).str( ";button=2\">" ).item( Button2 ).str( "</a>" ).ToString();
			}

			if ( Lang13.Bool( Button3 ) ) {
				output += new Txt( "<a style=\"font-size:large;float:right\" href=\"?src=" ).Ref( this ).str( ";button=3\">" ).item( Button3 ).str( "</a>" ).ToString();
			}
			output += "</div>";
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.set_content( output );
			this.stealfocus = StealFocus;

			if ( !( StealFocus == true ) ) {
				this.window_options += "focus=false;";
			}
			this.timeout = Timeout;
			return;
		}

		// Function from file: browser.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			double? button = null;

			
			if ( Lang13.Bool( href_list["close"] ) || !Lang13.Bool( this.user ) || !Lang13.Bool( this.user.client ) ) {
				this.opentime = 0;
				return null;
			}

			if ( Lang13.Bool( href_list["button"] ) ) {
				button = String13.ParseNumber( href_list["button"] );

				if ( ( button ??0) <= 3 && ( button ??0) >= 1 ) {
					this.selectedbutton = button;
				}
			}
			this.opentime = 0;
			this.close();
			return null;
		}

		// Function from file: browser.dm
		public void wait(  ) {
			
			while (this.opentime != 0 && ( this.selectedbutton ??0) <= 0 && ( !Lang13.Bool( this.timeout ) || this.opentime + ( this.timeout ??0) >= Game13.time )) {
				Task13.Sleep( 1 );
			}
			return;
		}

		// Function from file: browser.dm
		public override dynamic close(  ) {
			dynamic _default = null;

			_default = base.close();
			this.opentime = 0;
			return _default;
		}

		// Function from file: browser.dm
		public override dynamic open( bool? use_onclose = null ) {
			dynamic _default = null;

			string focusedwindow = null;
			double i = 0;

			this.opentime = Game13.time;

			if ( this.stealfocus == true ) {
				_default = base.open( true );
			} else {
				focusedwindow = Interface13.WindowGet( this.user, null, "focus" );
				_default = base.open( true );

				foreach (dynamic _a in Lang13.IterateRange( 1, 10 )) {
					i = _a;
					

					if ( Lang13.Bool( this.user ) && Interface13.WindowExists( this.user, this.window_id ) ) {
						
						if ( Lang13.Bool( focusedwindow ) ) {
							Interface13.WindowSet( this.user, focusedwindow, "focus=true" );
						} else {
							Interface13.WindowSet( this.user, "mapwindow", "focus=true" );
						}
						break;
					}
				}
			}

			if ( Lang13.Bool( this.timeout ) ) {
				Task13.Schedule( this.timeout ??0, (Task13.Closure)(() => {
					this.close();
					return;
				}));
			}
			return _default;
		}

	}

}