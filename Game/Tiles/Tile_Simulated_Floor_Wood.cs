// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Wood : Tile_Simulated_Floor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.floor_tile = typeof(Obj_Item_Stack_Tile_Wood);
			this.broken_states = new ByTable(new object [] { "wood-broken", "wood-broken2", "wood-broken3", "wood-broken4", "wood-broken5", "wood-broken6", "wood-broken7" });
			this.icon_state = "wood";
		}

		public Tile_Simulated_Floor_Wood ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: fancy_floor.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( Lang13.Bool( base.attackby( (object)(A), (object)(user), _params, silent, replace_spent ) ) ) {
				return null;
			}

			if ( A is Obj_Item_Weapon_Screwdriver ) {
				
				if ( this.broken || this.burnt ) {
					return null;
				}
				user.WriteMsg( "<span class='danger'>You unscrew the planks.</span>" );
				Lang13.Call( this.floor_tile, this );
				this.make_plating();
				GlobalFuncs.playsound( this, "sound/items/Screwdriver.ogg", 80, 1 );
				return null;
			}
			return null;
		}

	}

}