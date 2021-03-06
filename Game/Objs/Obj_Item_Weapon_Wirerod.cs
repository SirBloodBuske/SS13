// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Wirerod : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "rods";
			this.flags = 64;
			this.force = 9;
			this.throwforce = 10;
			this.materials = new ByTable().Set( "$metal", 1000 );
			this.attack_verb = new ByTable(new object [] { "hit", "bludgeoned", "whacked", "bonked" });
			this.icon_state = "wiredrod";
		}

		public Obj_Item_Weapon_Wirerod ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: weaponry.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			Obj_Item_Weapon_Twohanded_Spear S = null;
			Obj_Item_Weapon_Melee_Baton_Cattleprod P = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Weapon_Shard ) {
				S = new Obj_Item_Weapon_Twohanded_Spear();

				if ( !this.remove_item_from_storage( user ) ) {
					((Mob)user).unEquip( this );
				}
				((Mob)user).unEquip( A );
				((Mob)user).put_in_hands( S );
				user.WriteMsg( "<span class='notice'>You fasten the glass shard to the top of the rod with the cable.</span>" );
				GlobalFuncs.qdel( A );
				GlobalFuncs.qdel( this );
			} else if ( A is Obj_Item_Device_Assembly_Igniter && !Lang13.Bool( A.flags & 2 ) ) {
				P = new Obj_Item_Weapon_Melee_Baton_Cattleprod();

				if ( !this.remove_item_from_storage( user ) ) {
					((Mob)user).unEquip( this );
				}
				((Mob)user).unEquip( A );
				((Mob)user).put_in_hands( P );
				user.WriteMsg( "<span class='notice'>You fasten " + A + " to the top of the rod with the cable.</span>" );
				GlobalFuncs.qdel( A );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

	}

}