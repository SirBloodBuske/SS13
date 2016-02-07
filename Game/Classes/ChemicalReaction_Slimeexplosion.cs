// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimeexplosion : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Explosion";
			this.id = "m_explosion";
			this.required_reagents = new ByTable().Set( "plasma", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Oil);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic O = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, GlobalFuncs.get_turf( holder.my_atom ) ) )) {
				O = _a;
				
				O.show_message( "<span class='danger'>The slime extract begins to vibrate violently !</span>", 1 );
			}
			Task13.Schedule( 50, (Task13.Closure)(() => {
				
				if ( holder != null && Lang13.Bool( holder.my_atom ) ) {
					GlobalFuncs.explosion( GlobalFuncs.get_turf( holder.my_atom ), 1, 3, 6 );
				}
				return;
			}));
			return;
		}

	}

}