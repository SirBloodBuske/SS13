// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Crayons : Obj_Item_Weapon_Storage {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 2;
			this.storage_slots = 6;
			this.can_hold = new ByTable(new object [] { typeof(Obj_Item_Toy_Crayon) });
			this.icon = "icons/obj/crayons.dmi";
			this.icon_state = "crayonbox";
		}

		// Function from file: crayons.dm
		public Obj_Item_Weapon_Storage_Crayons ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Toy_Crayon_Red( this );
			new Obj_Item_Toy_Crayon_Orange( this );
			new Obj_Item_Toy_Crayon_Yellow( this );
			new Obj_Item_Toy_Crayon_Green( this );
			new Obj_Item_Toy_Crayon_Blue( this );
			new Obj_Item_Toy_Crayon_Purple( this );
			this.update_icon();
			return;
		}

		// Function from file: crayons.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Toy_Crayon ) {
				
				switch ((string)( A.colourName )) {
					case "mime":
						Task13.User.WriteMsg( "This crayon is too sad to be contained in this box." );
						return null;
						break;
					case "rainbow":
						Task13.User.WriteMsg( "This crayon is too powerful to be contained in this box." );
						return null;
						break;
				}
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: crayons.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			Obj_Item_Toy_Crayon crayon = null;

			this.overlays.Cut();

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_Toy_Crayon) )) {
				crayon = _a;
				
				this.overlays.Add( new Image( "icons/obj/crayons.dmi", crayon.colourName ) );
			}
			return false;
		}

	}

}