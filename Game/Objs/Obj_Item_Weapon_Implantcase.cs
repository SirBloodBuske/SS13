// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Implantcase : Obj_Item_Weapon {

		public dynamic imp = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "implantcase";
			this.throw_range = 5;
			this.w_class = 1;
			this.origin_tech = "materials=1;biotech=2";
			this.materials = new ByTable().Set( "$glass", 500 );
			this.icon_state = "implantcase-0";

			__RegisterInitialTracked("flags");
			__RegisterInitialTracked("origin_tech");
		}

		// Function from file: implantcase.dm
		public Obj_Item_Weapon_Implantcase ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.update_icon();
			return;
		}

		// Function from file: implantcase.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			string t = null;
			dynamic I = null;

			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Weapon_Pen ) {
				t = GlobalFuncs.stripped_input( user, "What would you like the label to be?", this.name, null );

				if ( ((Mob)user).get_active_hand() != A ) {
					return null;
				}

				if ( !( Map13.GetDistance( this, user ) <= 1 ) && this.loc != user ) {
					return null;
				}

				if ( Lang13.Bool( t ) ) {
					this.name = "implant case - '" + t + "'";
				} else {
					this.name = "implant case";
				}
			} else if ( A is Obj_Item_Weapon_Implanter ) {
				I = A;

				if ( Lang13.Bool( I.imp ) ) {
					
					if ( Lang13.Bool( this.imp ) || Lang13.Bool( I.imp.implanted ) ) {
						return null;
					}
					I.imp.loc = this;
					this.imp = I.imp;
					I.imp = null;
					this.update_icon();
					I.update_icon();
				} else {
					
					if ( Lang13.Bool( this.imp ) ) {
						
						if ( Lang13.Bool( I.imp ) ) {
							return null;
						}
						this.imp.loc = I;
						I.imp = this.imp;
						this.imp = null;
						this.update_icon();
					}
					I.update_icon();
				}
			}
			return null;
		}

		// Function from file: implantcase.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( Lang13.Bool( this.imp ) ) {
				this.icon_state = "implantcase-" + this.imp.item_color;
				this.origin_tech = this.imp.origin_tech;
				this.flags = this.imp.flags;
				this.reagents = this.imp.reagents;
			} else {
				this.icon_state = "implantcase-0";
				this.origin_tech = Lang13.Initial( this, "origin_tech" );
				this.flags = Lang13.Initial( this, "flags" );
				this.reagents = null;
			}
			return false;
		}

	}

}