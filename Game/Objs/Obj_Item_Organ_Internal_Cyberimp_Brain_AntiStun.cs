// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_Cyberimp_Brain_AntiStun : Obj_Item_Organ_Internal_Cyberimp_Brain {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.implant_color = "#FFFF00";
			this.slot = "brain_antistun";
			this.origin_tech = "materials=6;programming=4;biotech=5";
		}

		public Obj_Item_Organ_Internal_Cyberimp_Brain_AntiStun ( dynamic M = null ) : base( (object)(M) ) {
			
		}

		// Function from file: augments_internal.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( this.crit_fail ) {
				return 0;
			}
			this.crit_fail = true;
			Task13.Schedule( ((int)( 90 / severity )), (Task13.Closure)(() => {
				this.crit_fail = false;
				return;
			}));
			return 0;
		}

		// Function from file: augments_internal.dm
		public override void on_life(  ) {
			base.on_life();

			if ( this.crit_fail ) {
				return;
			}

			if ( this.owner.stunned > 2 ) {
				this.owner.stunned = 2;
			}

			if ( this.owner.weakened > 2 ) {
				this.owner.weakened = 2;
			}
			return;
		}

	}

}