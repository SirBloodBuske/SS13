// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Crowbar : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.hitsound = "sound/weapons/toolhit.ogg";
			this.slot_flags = 512;
			this.force = 5;
			this.throwforce = 7;
			this.item_state = "crowbar";
			this.w_class = 2;
			this.starting_materials = new ByTable().Set( "$iron", 50 );
			this.w_type = 4;
			this.melt_temperature = 1783.1500244140625;
			this.origin_tech = "engineering=1";
			this.attack_verb = new ByTable(new object [] { "attacked", "bashed", "battered", "bludgeoned", "whacked" });
			this.icon_state = "crowbar";
		}

		public Obj_Item_Weapon_Crowbar ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tools.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			GlobalFuncs.to_chat( Map13.FetchViewers( null, user ), new Txt( "<span class='danger'>" ).item( user ).str( " is smashing " ).his_her_its_their().str( " head in with the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s  trying to commit suicide!</span>" ).ToString() );
			return 1;
		}

	}

}