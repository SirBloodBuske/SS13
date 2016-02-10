// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Unpowered : Obj_Machinery_Door {

		public bool locked = false;

		public Obj_Machinery_Door_Unpowered ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: unpowered.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Mob_Dead_Observer ) {
				return null;
			}
			base.attack_hand( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: unpowered.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Card_Emag ) {
				return null;
			}

			if ( this.locked ) {
				return null;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: unpowered.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			
			if ( this.locked ) {
				return false;
			}
			base.Bumped( AM, (object)(yes) );
			return false;
		}

	}

}