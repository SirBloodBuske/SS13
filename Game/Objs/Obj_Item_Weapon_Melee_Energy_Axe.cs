// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Melee_Energy_Axe : Obj_Item_Weapon_Melee_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 40;
			this.throwforce = 25;
			this.throw_speed = 1;
			this.throw_range = 5;
			this.origin_tech = "combat=3";
			this.attack_verb = new ByTable(new object [] { "attacked", "chopped", "cleaved", "torn", "cut" });
			this.icon_state = "axe0";
		}

		public Obj_Item_Weapon_Melee_Energy_Axe ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: energy.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			GlobalFuncs.to_chat( Map13.FetchViewers( null, user ), new Txt( "<span class='danger'>" ).item( user ).str( " swings the " ).item( this.name ).str( " towards /his head! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			return 3;
		}

		// Function from file: swords_axes_etc.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.active = !this.active;

			if ( this.active ) {
				GlobalFuncs.to_chat( user, "<span class='notice'>The axe is now energised.</span>" );
				this.force = 150;
				this.icon_state = "axe1";
				this.w_class = 5;
				this.sharpness = 1.5;
			} else {
				GlobalFuncs.to_chat( user, "<span class='notice'>The axe can now be concealed.</span>" );
				this.force = 40;
				this.icon_state = "axe0";
				this.w_class = 5;
				this.sharpness = 1;
			}
			this.add_fingerprint( user );
			return null;
		}

		// Function from file: swords_axes_etc.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			base.attack( (object)(M), (object)(user), def_zone, eat_override );
			return null;
		}

	}

}