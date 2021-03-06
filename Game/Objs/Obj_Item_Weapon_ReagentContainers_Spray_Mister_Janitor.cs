// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Spray_Mister_Janitor : Obj_Item_Weapon_ReagentContainers_Spray_Mister {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "misterjani";
			this.possible_transfer_amounts = new ByTable();
			this.icon_state = "misterjani";
		}

		public Obj_Item_Weapon_ReagentContainers_Spray_Mister_Janitor ( dynamic parent_tank = null, int? vol = null ) : base( (object)(parent_tank), vol ) {
			
		}

		// Function from file: watertank.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.amount_per_transfer_from_this = ( this.amount_per_transfer_from_this == 10 ? 5 : 10 );
			user.WriteMsg( "<span class='notice'>You " + ( this.amount_per_transfer_from_this == 10 ? "remove" : "fix" ) + " the nozzle. You'll now use " + this.amount_per_transfer_from_this + " units per spray.</span>" );
			return null;
		}

	}

}