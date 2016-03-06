// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Dough : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cooked_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Bread_Plain);
			this.list_reagents = new ByTable().Set( "nutriment", 6 );
			this.icon = "icons/obj/food/food_ingredients.dmi";
			this.icon_state = "dough";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Dough ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: dough.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Kitchen_Rollingpin ) {
				
				if ( this.loc is Tile ) {
					new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Flatdough( this.loc );
					user.WriteMsg( "<span class='notice'>You flatten " + this + ".</span>" );
					GlobalFuncs.qdel( this );
				} else {
					user.WriteMsg( "<span class='warning'>You need to put " + this + " on a surface to roll it out!</span>" );
				}
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

	}

}