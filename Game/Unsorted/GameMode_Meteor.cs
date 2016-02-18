// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Meteor : GameMode {

		public int meteordelay = 2000;
		public bool nometeors = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "meteor";
			this.config_tag = "meteor";
		}

		// Function from file: meteor.dm
		public override bool declare_completion(  ) {
			dynamic text = null;
			int survivors = 0;
			Mob_Living player = null;

			survivors = 0;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living) )) {
				player = _a;
				

				if ( player.stat != 2 ) {
					survivors++;

					if ( player.onCentcom() ) {
						text += "<br><b><font size=2>" + player.real_name + " escaped to the safety of Centcom.</font></b>";
					} else if ( player.onSyndieBase() ) {
						text += "<br><b><font size=2>" + player.real_name + " escaped to the (relative) safety of Syndicate Space.</font></b>";
					} else {
						text += "<br><font size=1>" + player.real_name + " survived but is stranded without any hope of rescue.</font>";
					}
				}
			}

			if ( survivors != 0 ) {
				Game13.WriteMsg( "<span class='boldnotice'>The following survived the meteor storm</span>:" + text );
			} else {
				Game13.WriteMsg( "<span class='boldnotice'>Nobody survived the meteor storm!</span>" );
			}
			GlobalFuncs.feedback_set_details( "round_end_result", "end - evacuation" );
			GlobalFuncs.feedback_set( "round_end_result", survivors );
			base.declare_completion();
			return true;
		}

		// Function from file: meteor.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.nometeors ) {
				return null;
			}
			Task13.Schedule( 0, (Task13.Closure)(() => {
				GlobalFuncs.spawn_meteors( 1, GlobalVars.meteors_normal );
				return;
			}));
			return null;
		}

		// Function from file: meteor.dm
		public override bool post_setup( bool? report = null ) {
			Task13.Schedule( GlobalVars.meteordelay, (Task13.Closure)(() => {
				this.nometeors = false;
				return;
			}));
			base.post_setup( report );
			return false;
		}

		// Function from file: meteor.dm
		public override void announce(  ) {
			Game13.WriteMsg( "<B>The current game mode is - Meteor!</B>" );
			Game13.WriteMsg( "<B>The space station has been stuck in a major meteor shower. You must escape from the station or at least live.</B>" );
			return;
		}

	}

}