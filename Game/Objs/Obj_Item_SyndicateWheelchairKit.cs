// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_SyndicateWheelchairKit : Obj_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "syringe_kit";
			this.w_class = 4;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "wheelchair-item";
		}

		public Obj_Item_SyndicateWheelchairKit ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wheelchair.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			new Obj_Structure_Bed_Chair_Vehicle_Wheelchair_Motorized_Syndicate( GlobalFuncs.get_turf( user ) );
			((Ent_Static)user).visible_message( "<span class='warning'>The wheelchair springs into shape!</span>" );
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}