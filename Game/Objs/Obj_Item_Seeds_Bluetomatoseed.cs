// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Bluetomatoseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "bluetomato";
			this.plantname = "Blue-Tomato Plants";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato_Blue);
			this.lifespan = 25;
			this.endurance = 15;
			this.maturation = 8;
			this.production = 6;
			this.yield = 2;
			this.potency = 10;
			this.growthstages = 6;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Bluespacetomatoseed) });
			this.rarity = 20;
			this.icon_state = "seed-bluetomato";
		}

		public Obj_Item_Seeds_Bluetomatoseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}