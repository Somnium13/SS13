// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Newspaper : Obj_Item_Weapon {

		public int screen = 0;
		public int pages = 0;
		public int curr_page = 0;
		public ByTable news_content = new ByTable();
		public FeedMessage important_message = null;
		public string scribble = "";
		public int scribble_page = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 2;
			this.attack_verb = new ByTable(new object [] { "bapped" });
			this.icon = "icons/obj/bureaucracy.dmi";
			this.icon_state = "newspaper";
		}

		public Obj_Item_Weapon_Newspaper ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: newscaster.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string s = null;

			
			if ( a is Obj_Item_Weapon_Pen ) {
				
				if ( this.scribble_page == this.curr_page ) {
					GlobalFuncs.to_chat( b, "<FONT COLOR='blue'>There's already a scribble in this page... You wouldn't want to make things too cluttered, would you?</FONT>" );
				} else {
					s = GlobalFuncs.strip_html( Interface13.Input( b, "Write something", "Newspaper", "", null, InputType.Any ) );
					s = String13.SubStr( GlobalFuncs.sanitize( s ), 1, 1024 );

					if ( !Lang13.Bool( s ) ) {
						return null;
					}

					if ( !GlobalFuncs.in_range( this, Task13.User ) && this.loc != Task13.User ) {
						return null;
					}
					this.scribble_page = this.curr_page;
					this.scribble = s;
					this.attack_self( b );
				}
				return null;
			}
			return null;
		}

		// Function from file: newscaster.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			Mob U = null;

			U = Task13.User;
			Interface13.Stat( null, U.contents.Contains( this ) );

			if ( false || this.loc is Tile && GlobalFuncs.in_range( this, U ) ) {
				U.set_machine( this );

				if ( Lang13.Bool( href_list["next_page"] ) ) {
					
					if ( this.curr_page == this.pages + 1 ) {
						return null;
					}

					if ( this.curr_page == this.pages ) {
						this.screen = 2;
					} else if ( this.curr_page == 0 ) {
						this.screen = 1;
					}
					this.curr_page++;
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "pageturn", 50, 1 );
				} else if ( Lang13.Bool( href_list["prev_page"] ) ) {
					
					if ( this.curr_page == 0 ) {
						return null;
					}

					if ( this.curr_page == 1 ) {
						this.screen = 0;
					} else if ( this.curr_page == this.pages + 1 ) {
						this.screen = 1;
					}
					this.curr_page--;
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "pageturn", 50, 1 );
				}

				if ( this.loc is Mob ) {
					this.attack_self( this.loc );
				}
			}
			return null;
		}

		// Function from file: newscaster.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic dat = null;
			FeedChannel NP = null;
			int temp_page = 0;
			FeedChannel NP2 = null;
			FeedChannel NP3 = null;
			FeedChannel C = null;
			int i = 0;
			FeedMessage MESSAGE = null;
			FeedChannel NP4 = null;

			
			if ( user is Mob_Living_Carbon_Human ) {
				this.pages = 0;

				switch ((int)( this.screen )) {
					case 0:
						dat += "<DIV ALIGN='center'><B><FONT SIZE=6>The Griffon</FONT></B></div>\n					<DIV ALIGN='center'><FONT SIZE=2>Nanotrasen-standard newspaper, for use on Nanotrasen Space Facilities</FONT></div><HR>";

						if ( GlobalFuncs.isemptylist( this.news_content ) ) {
							
							if ( this.important_message != null ) {
								dat += "Contents:<BR><ul><B><FONT COLOR='red'>**</FONT>Important Security Announcement<FONT COLOR='red'>**</FONT></B> <FONT SIZE=2>[page " + ( this.pages + 2 ) + "]</FONT><BR></ul>";
							} else {
								dat += "<I>Other than the title, the rest of the newspaper is unprinted...</I>";
							}
						} else {
							dat += "Contents:<BR><ul>";

							foreach (dynamic _a in Lang13.Enumerate( this.news_content, typeof(FeedChannel) )) {
								NP = _a;
								
								this.pages++;
							}

							if ( this.important_message != null ) {
								dat += "<B><FONT COLOR='red'>**</FONT>Important Security Announcement<FONT COLOR='red'>**</FONT></B> <FONT SIZE=2>[page " + ( this.pages + 2 ) + "]</FONT><BR>";
							}
							temp_page = 0;

							foreach (dynamic _b in Lang13.Enumerate( this.news_content, typeof(FeedChannel) )) {
								NP2 = _b;
								
								temp_page++;
								dat += "<B>" + NP2.channel_name + "</B> <FONT SIZE=2>[page " + ( temp_page + 1 ) + "]</FONT><BR>";
							}
							dat += "</ul>";
						}

						if ( this.scribble_page == this.curr_page ) {
							dat += "<BR><I>There is a small scribble near the end of this page... It reads: \"" + this.scribble + "\"</I>";
						}
						dat += new Txt( "<HR><DIV STYLE='float:right;'><A href='?src=" ).Ref( this ).str( ";next_page=1'>Next Page</A></DIV> <div style='float:left;'><A href='?src=" ).Ref( Task13.User ).str( ";mach_close=newspaper_main'>Done reading</A></DIV>" ).ToString();
						break;
					case 1:
						
						foreach (dynamic _c in Lang13.Enumerate( this.news_content, typeof(FeedChannel) )) {
							NP3 = _c;
							
							this.pages++;
						}
						C = this.news_content[this.curr_page];
						dat += "<FONT SIZE=4><B>" + C.channel_name + "</B></FONT><FONT SIZE=1> [created by: <FONT COLOR='maroon'>" + C.author + "</FONT>]</FONT><BR><BR>";

						if ( C.censored ) {
							dat += "This channel was deemed dangerous to the general welfare of the station and therefore marked with a <B><FONT COLOR='red'>D-Notice</B></FONT>. Its contents were not transferred to the newspaper at the time of printing.";
						} else if ( GlobalFuncs.isemptylist( C.messages ) ) {
							dat += "No Feed stories stem from this channel...";
						} else {
							dat += "<ul>";
							i = 0;

							foreach (dynamic _d in Lang13.Enumerate( C.messages, typeof(FeedMessage) )) {
								MESSAGE = _d;
								
								i++;
								dat += "-" + MESSAGE.body + " <BR>";

								if ( Lang13.Bool( MESSAGE.img ) ) {
									Interface13.CacheBrowseResource( user, MESSAGE.img, "tmp_photo" + i + ".png" );
									dat += "<img src='tmp_photo" + i + ".png' width = '180'><BR>";
								}
								dat += "<FONT SIZE=1>[Story by <FONT COLOR='maroon'>" + MESSAGE.author + "</FONT>]</FONT><BR><BR>";
							}
							dat += "</ul>";
						}

						if ( this.scribble_page == this.curr_page ) {
							dat += "<BR><I>There is a small scribble near the end of this page... It reads: \"" + this.scribble + "\"</I>";
						}
						dat += new Txt( "<BR><HR><DIV STYLE='float:left;'><A href='?src=" ).Ref( this ).str( ";prev_page=1'>Previous Page</A></DIV> <DIV STYLE='float:right;'><A href='?src=" ).Ref( this ).str( ";next_page=1'>Next Page</A></DIV>" ).ToString();
						break;
					case 2:
						
						foreach (dynamic _e in Lang13.Enumerate( this.news_content, typeof(FeedChannel) )) {
							NP4 = _e;
							
							this.pages++;
						}

						if ( this.important_message != null ) {
							dat += "<DIV STYLE='float:center;'><FONT SIZE=4><B>Wanted Issue:</B></FONT SIZE></DIV><BR><BR>\n						<B>Criminal name</B>: <FONT COLOR='maroon'>" + this.important_message.author + "</FONT><BR>\n						<B>Description</B>: " + this.important_message.body + "<BR>\n						<B>Photo:</B>: ";

							if ( Lang13.Bool( this.important_message.img ) ) {
								Interface13.CacheBrowseResource( user, this.important_message.img, "tmp_photow.png" );
								dat += "<BR><img src='tmp_photow.png' width = '180'>";
							} else {
								dat += "None";
							}
						} else {
							dat += "<I>Apart from some uninteresting Classified ads, there's nothing on this page...</I>";
						}

						if ( this.scribble_page == this.curr_page ) {
							dat += "<BR><I>There is a small scribble near the end of this page... It reads: \"" + this.scribble + "\"</I>";
						}
						dat += new Txt( "<HR><DIV STYLE='float:left;'><A href='?src=" ).Ref( this ).str( ";prev_page=1'>Previous Page</A></DIV>" ).ToString();
						break;
					default:
						dat += "I'm sorry to break your immersion. This shit's bugged. Report this bug to Agouri, polyxenitopalidou@gmail.com";
						break;
				}
				dat += "<BR><HR><div align='center'>" + ( this.curr_page + 1 ) + "</div>";
				Interface13.Browse( Task13.User, dat, "window=newspaper_main;size=300x400" );
				GlobalFuncs.onclose( Task13.User, "newspaper_main" );
			} else {
				GlobalFuncs.to_chat( user, "The paper is full of intelligible symbols!" );
			}
			return null;
		}

	}

}