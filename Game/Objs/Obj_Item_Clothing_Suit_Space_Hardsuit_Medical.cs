// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Space_Hardsuit_Medical : Obj_Item_Clothing_Suit_Space_Hardsuit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "medical_hardsuit";
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Device_Flashlight), 
				typeof(Obj_Item_Weapon_Tank_Internals), 
				typeof(Obj_Item_Weapon_Storage_Firstaid), 
				typeof(Obj_Item_Device_Healthanalyzer), 
				typeof(Obj_Item_Stack_Medical)
			 });
			this.armor = new ByTable().Set( "melee", 30 ).Set( "bullet", 5 ).Set( "laser", 10 ).Set( "energy", 5 ).Set( "bomb", 10 ).Set( "bio", 100 ).Set( "rad", 50 );
			this.helmettype = typeof(Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Medical);
			this.icon_state = "hardsuit-medical";
		}

		public Obj_Item_Clothing_Suit_Space_Hardsuit_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}