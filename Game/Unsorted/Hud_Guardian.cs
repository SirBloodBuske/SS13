// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Hud_Guardian : Hud {

		// Function from file: guardian.dm
		public Hud_Guardian ( Mob_Living_SimpleAnimal_Hostile_Guardian owner = null ) : base( owner ) {
			Obj_Screen_Guardian _using = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.healths = new Obj_Screen_Healths_Guardian();
			this.infodisplay.Add( this.healths );
			_using = new Obj_Screen_Guardian_Manifest();
			_using.screen_loc = "CENTER:-16,SOUTH:5";
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Guardian_Recall();
			_using.screen_loc = "CENTER: 16,SOUTH:5";
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Guardian_ToggleMode();
			_using.screen_loc = "CENTER+1:18,SOUTH:5";
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Guardian_ToggleLight();
			_using.screen_loc = "WEST:6,SOUTH:5";
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Guardian_Communicate();
			_using.screen_loc = "CENTER-2:14,SOUTH:5";
			this.static_inventory.Add( _using );
			return;
		}

	}

}