// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Dropper : Obj_Item_Weapon_ReagentContainers {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.possible_transfer_amounts = new ByTable(new object [] { 1, 2, 3, 4, 5 });
			this.volume = 5;
			this.icon_state = "dropper0";
		}

		public Obj_Item_Weapon_ReagentContainers_Dropper ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: dropper.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			Image filling = null;

			this.overlays.Cut();

			if ( Lang13.Bool( this.reagents.total_volume ) ) {
				filling = new Image( "icons/obj/reagentfillings.dmi", this, "dropper" );
				filling.color = GlobalFuncs.mix_color_from_reagents( this.reagents.reagent_list );
				this.overlays.Add( filling );
			}
			return false;
		}

		// Function from file: dropper.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic trans = null;
			double? fraction = null;
			dynamic victim = null;
			dynamic safe_thing = null;
			dynamic M = null;
			dynamic R = null;
			Reagent A = null;
			dynamic trans2 = null;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			}

			if ( !Lang13.Bool( target.reagents ) ) {
				return false;
			}

			if ( ( this.reagents.total_volume ??0) > 0 ) {
				
				if ( ( target.reagents.total_volume ??0) >= Convert.ToDouble( target.reagents.maximum_volume ) ) {
					user.WriteMsg( "<span class='notice'>" + target + " is full.</span>" );
					return false;
				}

				if ( !Lang13.Bool( ((Ent_Static)target).is_open_container() ) && !( target is Mob ) && !( target is Obj_Item_Weapon_ReagentContainers_Food ) && !( target is Obj_Item_Clothing_Mask_Cigarette ) ) {
					user.WriteMsg( "<span class='warning'>You cannot directly fill " + target + "!</span>" );
					return false;
				}
				trans = 0;
				fraction = Num13.MinInt( ((int)( ( this.amount_per_transfer_from_this ??0) / ( this.reagents.total_volume ??0) )), 1 );

				if ( target is Mob ) {
					
					if ( target is Mob_Living_Carbon_Human ) {
						victim = target;
						safe_thing = null;

						if ( Lang13.Bool( victim.wear_mask ) ) {
							
							if ( Lang13.Bool( victim.wear_mask.flags_cover & 2 ) ) {
								safe_thing = victim.wear_mask;
							}
						}

						if ( Lang13.Bool( victim.head ) ) {
							
							if ( Lang13.Bool( victim.head.flags_cover & 2 ) ) {
								safe_thing = victim.head;
							}
						}

						if ( Lang13.Bool( victim.glasses ) ) {
							
							if ( !Lang13.Bool( safe_thing ) ) {
								safe_thing = victim.glasses;
							}
						}

						if ( Lang13.Bool( safe_thing ) ) {
							
							if ( !Lang13.Bool( safe_thing.reagents ) ) {
								((Ent_Static)safe_thing).create_reagents( 100 );
							}
							this.reagents.reaction( safe_thing, GlobalVars.TOUCH, fraction );
							trans = this.reagents.trans_to( safe_thing, this.amount_per_transfer_from_this );
							((Ent_Static)target).visible_message( "<span class='danger'>" + user + " tries to squirt something into " + target + "'s eyes, but fails!</span>", "<span class='userdanger'>" + user + " tries to squirt something into " + target + "'s eyes, but fails!</span>" );
							user.WriteMsg( new Txt( "<span class='notice'>You transfer " ).item( trans ).str( " unit" ).s().str( " of the solution.</span>" ).ToString() );
							this.update_icon();
							return false;
						}
					}
					((Ent_Static)target).visible_message( "<span class='danger'>" + user + " squirts something into " + target + "'s eyes!</span>", "<span class='userdanger'>" + user + " squirts something into " + target + "'s eyes!</span>" );
					this.reagents.reaction( target, GlobalVars.TOUCH, fraction );
					M = target;

					if ( this.reagents != null ) {
						
						foreach (dynamic _a in Lang13.Enumerate( this.reagents.reagent_list, typeof(Reagent) )) {
							A = _a;
							
							R += A.id + " (";
							R += String13.NumberToString( A.volume ) + "),";
						}
					}
					GlobalFuncs.add_logs( user, M, "squirted", R );
				}
				trans = this.reagents.trans_to( target, this.amount_per_transfer_from_this );
				user.WriteMsg( new Txt( "<span class='notice'>You transfer " ).item( trans ).str( " unit" ).s().str( " of the solution.</span>" ).ToString() );
				this.update_icon();
			} else {
				
				if ( !Lang13.Bool( ((Ent_Static)target).is_open_container() ) && !( target is Obj_Structure_ReagentDispensers ) ) {
					user.WriteMsg( "<span class='notice'>You cannot directly remove reagents from " + target + ".</span>" );
					return false;
				}

				if ( !Lang13.Bool( target.reagents.total_volume ) ) {
					user.WriteMsg( "<span class='warning'>" + target + " is empty!</span>" );
					return false;
				}
				trans2 = ((Reagents)target.reagents).trans_to( this, this.amount_per_transfer_from_this );
				user.WriteMsg( new Txt( "<span class='notice'>You fill " ).item( this ).str( " with " ).item( trans2 ).str( " unit" ).s().str( " of the solution.</span>" ).ToString() );
				this.update_icon();
			}
			return false;
		}

	}

}