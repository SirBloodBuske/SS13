// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Plasmaman_Miner : Obj_Item_Clothing_Head_Helmet_Space_Plasmaman {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_state = "plasmamanMiner_helmet";
			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 5 ).Set( "laser", 15 ).Set( "energy", 5 ).Set( "bomb", 30 ).Set( "bio", 100 ).Set( "rad", 20 );
			this.icon_state = "plasmamanMiner_helmet0";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Plasmaman_Miner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}