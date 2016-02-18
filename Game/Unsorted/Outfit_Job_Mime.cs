// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Job_Mime : Outfit_Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mime";
			this.belt = typeof(Obj_Item_Device_Pda_Mime);
			this.uniform = typeof(Obj_Item_Clothing_Under_Rank_Mime);
			this.mask = typeof(Obj_Item_Clothing_Mask_Gas_Mime);
			this.gloves = typeof(Obj_Item_Clothing_Gloves_Color_White);
			this.head = typeof(Obj_Item_Clothing_Head_Beret);
			this.suit = typeof(Obj_Item_Clothing_Suit_Suspenders);
			this.backpack_contents = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Bottleofnothing), 1 ).Set( typeof(Obj_Item_Toy_Crayon_Mime), 1 );
			this.backpack = typeof(Obj_Item_Weapon_Storage_Backpack_Mime);
			this.satchel = typeof(Obj_Item_Weapon_Storage_Backpack_Mime);
		}

		// Function from file: civilian.dm
		public override void post_equip( Mob H = null, int? visualsOnly = null ) {
			visualsOnly = visualsOnly ?? GlobalVars.FALSE;

			base.post_equip( H, visualsOnly );

			if ( Lang13.Bool( visualsOnly ) ) {
				return;
			}

			if ( H.mind != null ) {
				H.mind.AddSpell( new Obj_Effect_ProcHolder_Spell_AoeTurf_Conjure_MimeWall( null ) );
				H.mind.AddSpell( new Obj_Effect_ProcHolder_Spell_Targeted_Mime_Speak( null ) );
				H.mind.miming = true;
			}
			H.rename_self( "mime" );
			return;
		}

	}

}