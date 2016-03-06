// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_ClownShoes_BananaShoes : Obj_Item_Clothing_Shoes_ClownShoes {

		public bool on = false;
		public MaterialContainer bananium = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.action_button_name = "Toggle Shoes";
			this.icon_state = "clown_prototype_off";
		}

		// Function from file: bananashoes.dm
		public Obj_Item_Clothing_Shoes_ClownShoes_BananaShoes ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.bananium = new MaterialContainer( this, new ByTable().Set( "$bananium", 1 ), 200000 );
			return;
		}

		// Function from file: bananashoes.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.on ) {
				this.icon_state = "clown_prototype_on";
			} else {
				this.icon_state = "clown_prototype_off";
			}
			Task13.User.update_inv_shoes();
			return false;
		}

		// Function from file: bananashoes.dm
		public override void ui_action_click(  ) {
			
			if ( this.bananium.amount( "$bananium" ) ) {
				this.on = !this.on;
				this.update_icon();
				((dynamic)this.loc).WriteMsg( "<span class='notice'>You " + ( this.on ? "activate" : "deactivate" ) + " the prototype shoes.</span>" );
			} else {
				((dynamic)this.loc).WriteMsg( "<span class='warning'>You need bananium to turn the prototype shoes on!</span>" );
			}
			return;
		}

		// Function from file: bananashoes.dm
		public override double examine( dynamic user = null ) {
			bool ban_amt = false;

			base.examine( (object)(user) );
			ban_amt = this.bananium.amount( "$bananium" );
			user.WriteMsg( "<span class='notice'>The shoes are " + ( this.on ? "enabled" : "disabled" ) + ". There is " + ( ban_amt ? ((dynamic)( ban_amt )) : ((dynamic)( "no" )) ) + " bananium left.</span>" );
			return 0;
		}

		// Function from file: bananashoes.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic S = null;
			double? sheet_amount = null;

			
			if ( !( A is Obj_Item_Stack_Sheet ) ) {
				return null;
			}

			if ( !( this.bananium.get_item_material_amount( A ) != 0 ) ) {
				user.WriteMsg( "<span class='notice'>This item has no bananium!</span>" );
				return null;
			}

			if ( !((Mob)user).unEquip( A ) ) {
				user.WriteMsg( "<span class='notice'>You can't drop " + A + "!</span>" );
				return null;
			}
			S = A;
			sheet_amount = this.bananium.insert_stack( A, Lang13.DoubleNullable( S.amount ) );

			if ( Lang13.Bool( sheet_amount ) ) {
				user.WriteMsg( "<span class='notice'>You insert " + sheet_amount + " bananium sheets into the prototype shoes.</span>" );
			} else {
				user.WriteMsg( "<span class='notice'>You are unable to insert more bananium!</span>" );
			}
			return null;
		}

		// Function from file: bananashoes.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			double sheet_amount = 0;

			sheet_amount = this.bananium.retrieve_all();

			if ( sheet_amount != 0 ) {
				user.WriteMsg( "<span class='notice'>You retrieve " + sheet_amount + " sheets of bananium from the prototype shoes.</span>" );
			} else {
				user.WriteMsg( "<span class='notice'>You cannot retrieve any bananium from the prototype shoes.</span>" );
			}
			return null;
		}

		// Function from file: bananashoes.dm
		public override void step_action(  ) {
			
			if ( this.on ) {
				
				if ( this.footstep > 1 ) {
					GlobalFuncs.playsound( this, "sound/items/bikehorn.ogg", 75, 1 );
					this.footstep = 0;
				} else {
					this.footstep++;
				}
				new Obj_Item_Weapon_Grown_Bananapeel_Specialpeel( Map13.GetStep( this, Num13.Rotate( Task13.User.dir, 180 ) ), 5 );
				this.bananium.use_amount_type( 100, "$bananium" );

				if ( ( this.bananium.amount( "$bananium" ) ?1:0) < 100 ) {
					this.on = !this.on;
					this.update_icon();
					((dynamic)this.loc).WriteMsg( "<span class='warning'>You ran out of bananium!</span>" );
				}
			} else {
				base.step_action();
			}
			return;
		}

	}

}