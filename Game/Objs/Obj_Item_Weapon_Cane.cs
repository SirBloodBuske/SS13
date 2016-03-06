// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cane : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "stick";
			this.force = 5;
			this.throwforce = 5;
			this.w_class = 2;
			this.materials = new ByTable().Set( "$metal", 50 );
			this.attack_verb = new ByTable(new object [] { "bludgeoned", "whacked", "disciplined", "thrashed" });
			this.icon_state = "cane";
		}

		public Obj_Item_Weapon_Cane ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}