// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Emptyvendomatpack : Obj_Item {

		public Type foldable = typeof(Obj_Item_Stack_Sheet_Cardboard);
		public int foldable_amount = 4;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "syringe_kit";
			this.w_class = 4;
			this.autoignition_temperature = 522;
			this.fire_fuel = 2;
			this.icon = "icons/obj/vending_pack.dmi";
			this.icon_state = "generic";
		}

		public Obj_Item_Emptyvendomatpack ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: vending_packs.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			GlobalFuncs.to_chat( Task13.User, "<span class='notice'>You fold " + this + " flat.</span>" );
			Lang13.Call( this.foldable, GlobalFuncs.get_turf( this ), this.foldable_amount );
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}