// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Nullrod_Carp : Obj_Item_Weapon_Nullrod {

		public int? used_blessing = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "carp_plushie";
			this.force = 15;
			this.attack_verb = new ByTable(new object [] { "bitten", "eaten", "fin slapped" });
			this.hitsound = "sound/weapons/bite.ogg";
			this.icon = "icons/obj/toy.dmi";
			this.icon_state = "carpplushie";
		}

		public Obj_Item_Weapon_Nullrod_Carp ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: holy_weapons.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( Lang13.Bool( this.used_blessing ) ) {
				return null;
			}

			if ( Lang13.Bool( user.mind ) && user.mind.assigned_role != "Chaplain" ) {
				return null;
			}
			user.WriteMsg( "You are blessed by Carp-Sie. Wild space carp will no longer attack you." );
			user.faction |= "carp";
			this.used_blessing = GlobalVars.TRUE;
			return null;
		}

	}

}