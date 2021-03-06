// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Hud_Ghost : Hud {

		// Function from file: ghost.dm
		public Hud_Ghost ( Mob_Dead_Observer owner = null ) : base( owner ) {
			Mob G = null;
			Obj_Screen_Ghost _using = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			G = this.mymob;

			if ( !G.client.prefs.ghost_hud ) {
				this.mymob.client.screen = null;
				return;
			}
			_using = new Obj_Screen_Ghost_Jumptomob();
			_using.screen_loc = "SOUTH:6,CENTER-2:16";
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Ghost_Orbit();
			_using.screen_loc = "SOUTH:6,CENTER-1:16";
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Ghost_ReenterCorpse();
			_using.screen_loc = "SOUTH:6,CENTER:16";
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Ghost_Teleport();
			_using.screen_loc = "SOUTH:6,CENTER+1:16";
			this.static_inventory.Add( _using );
			return;
		}

		// Function from file: ghost.dm
		public override bool show_hud( int? version = null ) {
			Mob G = null;

			G = this.mymob;
			this.mymob.client.screen = new ByTable();

			if ( !G.client.prefs.ghost_hud ) {
				return false;
			}
			this.mymob.client.screen.Add( this.static_inventory );
			return false;
		}

	}

}