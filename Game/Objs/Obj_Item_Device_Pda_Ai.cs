// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Pda_Ai : Obj_Item_Device_Pda {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ttone = "data";
			this.detonate = false;
			this.icon_state = "NONE";
		}

		// Function from file: PDA.dm
		public Obj_Item_Device_Pda_Ai ( dynamic loc = null ) : base( (object)(loc) ) {
			PdaApp_SpamFilter app = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			app = new PdaApp_SpamFilter();
			app.onInstall( this );
			return;
		}

		// Function from file: PDA.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.honkamt > 0 && Rand13.PercentChance( 60 ) ) {
				this.honkamt--;
				GlobalFuncs.playsound( this.loc, "sound/items/bikehorn.ogg", 30, 1 );
			}
			return null;
		}

		// Function from file: PDA.dm
		public void set_name_and_job( dynamic newname = null, string newjob = null ) {
			this.owner = newname;
			this.ownjob = newjob;
			this.name = newname + " (" + this.ownjob + ")";
			return;
		}

		// Function from file: PDA.dm
		[Verb]
		[VerbInfo( name: "Show Message Log", group: "AI Commands", access: VerbAccess.InUserContents, range: 127 )]
		public void cmd_show_message_log(  ) {
			string HTML = null;

			
			if ( Task13.User.isDead() ) {
				GlobalFuncs.to_chat( Task13.User, "You can't do that because you are dead!" );
				return;
			}
			HTML = "<html><head><title>AI PDA Message Log</title></head><body>" + this.tnote + "</body></html>";
			Interface13.Browse( Task13.User, HTML, "window=log;size=400x444;border=1;can_resize=1;can_close=1;can_minimize=0" );
			return;
		}

		// Function from file: PDA.dm
		[Verb]
		[VerbInfo( name: "Toggle Ringer", group: "AI Commands", access: VerbAccess.InUserContents, range: 127 )]
		public void cmd_toggle_pda_silent(  ) {
			
			if ( Task13.User.isDead() ) {
				GlobalFuncs.to_chat( Task13.User, "You can't do that because you are dead!" );
				return;
			}
			this.silent = !this.silent;
			GlobalFuncs.to_chat( Task13.User, "<span class='notice'>PDA ringer toggled " + ( this.silent ? "Off" : "On" ) + "!</span>" );
			return;
		}

		// Function from file: PDA.dm
		[Verb]
		[VerbInfo( name: "Toggle Sender/Receiver", group: "AI Commands", access: VerbAccess.InUserContents, range: 127 )]
		public void cmd_toggle_pda_receiver(  ) {
			
			if ( Task13.User.isDead() ) {
				GlobalFuncs.to_chat( Task13.User, "You can't do that because you are dead!" );
				return;
			}
			this.toff = !this.toff;
			GlobalFuncs.to_chat( Task13.User, "<span class='notice'>PDA sender/receiver toggled " + ( this.toff ? "Off" : "On" ) + "!</span>" );
			return;
		}

		// Function from file: PDA.dm
		[Verb]
		[VerbInfo( name: "Send Message", group: "AI Commands", access: VerbAccess.InUserContents, range: 127 )]
		public void cmd_send_pdamesg(  ) {
			ByTable plist = null;
			dynamic c = null;
			dynamic selected = null;

			
			if ( Task13.User.isDead() ) {
				GlobalFuncs.to_chat( Task13.User, "You can't send PDA messages because you are dead!" );
				return;
			}
			plist = this.available_pdas();

			if ( plist != null ) {
				c = Interface13.Input( Task13.User, "Please select a PDA", null, null, GlobalFuncs.sortList( plist ), InputType.Null | InputType.Any );

				if ( !Lang13.Bool( c ) ) {
					return;
				}
				selected = plist[c];
				this.create_message( Task13.User, selected );
			}
			return;
		}

	}

}