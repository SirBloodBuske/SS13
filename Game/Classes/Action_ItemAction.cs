// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_ItemAction : Action {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.check_flags = 31;
		}

		public Action_ItemAction ( dynamic Target = null ) : base( (object)(Target) ) {
			
		}

		// Function from file: action.dm
		public override void ApplyIcon( Obj_Screen_Movable_ActionButton current_button = null ) {
			dynamic I = null;
			dynamic old = null;

			current_button.overlays.Cut();

			if ( Lang13.Bool( this.target ) ) {
				I = this.target;
				old = I.layer;
				I.layer = GlobalVars.FLOAT_LAYER;
				current_button.overlays.Add( I );
				I.layer = old;
			}
			return;
		}

		// Function from file: action.dm
		public override bool CheckRemoval( dynamic user = null ) {
			return !Lang13.Bool( user.Contains( this.target ) );
		}

		// Function from file: action.dm
		public override bool Trigger(  ) {
			dynamic item = null;

			
			if ( !base.Trigger() ) {
				return false;
			}

			if ( Lang13.Bool( this.target ) ) {
				item = this.target;
				((Obj_Item)item).ui_action_click();
			}
			return true;
		}

	}

}