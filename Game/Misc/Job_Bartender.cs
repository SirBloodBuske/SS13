// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Bartender : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Bartender";
			this.flag = 2;
			this.department_flag = 4;
			this.faction = "Station";
			this.total_positions = 1;
			this.spawn_positions = 1;
			this.supervisors = "the head of personnel";
			this.selection_color = "#dddddd";
			this.access = new ByTable(new object [] { 35, 25, 28, 6, 66 });
			this.minimal_access = new ByTable(new object [] { 25, 66 });
			this.pdatype = typeof(Obj_Item_Device_Pda_Bar);
			this.department = "Civilian";
		}

		// Function from file: civilian.dm
		public override bool equip( dynamic H = null ) {
			dynamic Barpack = null;

			
			if ( !Lang13.Bool( H ) ) {
				return false;
			}

			dynamic _a = H.backbag; // Was a switch-case, sorry for the mess.
			if ( _a==2 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack( H ), 1 );
			} else if ( _a==3 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_SatchelNorm( H ), 1 );
			} else if ( _a==4 ) {
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Weapon_Storage_Backpack_Satchel( H ), 1 );
			}
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Device_Radio_Headset_HeadsetService(  ), 8 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Shoes_Black( H ), 12 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Suit_Armor_Vest( H ), 13 );
			((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_Clothing_Under_Rank_Bartender( H ), 14 );

			if ( Lang13.Bool( H.backbag ) == true ) {
				Barpack = Lang13.Call( H.species.survival_gear, H );
				((Mob_Living_Carbon_Human)H).equip_or_collect( Barpack, 5 );
				new Obj_Item_AmmoCasing_Shotgun_Beanbag( Barpack );
				new Obj_Item_AmmoCasing_Shotgun_Beanbag( Barpack );
				new Obj_Item_AmmoCasing_Shotgun_Beanbag( Barpack );
				new Obj_Item_AmmoCasing_Shotgun_Beanbag( Barpack );
			} else {
				((Mob_Living_Carbon_Human)H).equip_or_collect( Lang13.Call( H.species.survival_gear, H ), 18 );
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_AmmoCasing_Shotgun_Beanbag( H ), 18 );
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_AmmoCasing_Shotgun_Beanbag( H ), 18 );
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_AmmoCasing_Shotgun_Beanbag( H ), 18 );
				((Mob_Living_Carbon_Human)H).equip_or_collect( new Obj_Item_AmmoCasing_Shotgun_Beanbag( H ), 18 );
			}
			((Dna)H.dna).SetSEState( GlobalVars.SOBERBLOCK, true );
			H.mutations += 203;
			H.check_mutations = true;
			return true;
		}

	}

}