// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SurgeryStep_ExtractCore : SurgeryStep {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "extract core";
			this.implements = new ByTable().Set( typeof(Obj_Item_Weapon_Hemostat), 100 ).Set( typeof(Obj_Item_Weapon_Crowbar), 100 );
			this.time = 16;
		}

		// Function from file: core_removal.dm
		public override bool success( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			Mob slime = null;

			slime = target;

			if ( Convert.ToDouble( ((dynamic)slime).cores ) > 0 ) {
				((dynamic)slime).cores--;
				((Ent_Static)user).visible_message( "" + user + " successfully extracts a core from " + target + "!", new Txt( "<span class='notice'>You successfully extract a core from " ).item( target ).str( ". " ).item( ((dynamic)slime).cores ).str( " core" ).s().str( " remaining.</span>" ).ToString() );
				Lang13.Call( ((dynamic)slime).coretype, slime.loc );

				if ( Convert.ToDouble( ((dynamic)slime).cores ) <= 0 ) {
					slime.icon_state = "" + ((dynamic)slime).colour + " baby slime dead-nocore";
					return true;
				} else {
					return false;
				}
			} else {
				user.WriteMsg( "<span class='warning'>There aren't any cores left in " + target + "!</span>" );
				return true;
			}
			return false;
		}

		// Function from file: core_removal.dm
		public override int preop( dynamic user = null, Mob target = null, string target_zone = null, dynamic tool = null, Surgery surgery = null ) {
			((Ent_Static)user).visible_message( "" + user + " begins to extract a core from " + target + ".", "<span class='notice'>You begin to extract a core from " + target + "...</span>" );
			return 0;
		}

	}

}