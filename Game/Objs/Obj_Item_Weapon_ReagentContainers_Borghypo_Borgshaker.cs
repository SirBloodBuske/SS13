// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Borghypo_Borgshaker : Obj_Item_Weapon_ReagentContainers_Borghypo {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.possible_transfer_amounts = new ByTable(new object [] { 5, 10, 20 });
			this.charge_cost = 20;
			this.recharge_time = 3;
			this.reagent_ids = new ByTable(new object [] { 
				"beer", 
				"orangejuice", 
				"limejuice", 
				"tomatojuice", 
				"cola", 
				"tonic", 
				"sodawater", 
				"ice", 
				"cream", 
				"whiskey", 
				"vodka", 
				"rum", 
				"gin", 
				"tequila", 
				"vermouth", 
				"wine", 
				"kahlua", 
				"cognac", 
				"ale"
			 });
			this.icon = "icons/obj/drinks.dmi";
			this.icon_state = "shaker";
		}

		public Obj_Item_Weapon_ReagentContainers_Borghypo_Borgshaker ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

		// Function from file: borghydro.dm
		public override void DescribeContents(  ) {
			bool empty = false;
			dynamic RS = null;
			dynamic R = null;

			empty = true;
			RS = this.reagent_list[this.mode];
			R = Lang13.FindIn( typeof(Reagent), RS.reagent_list );

			if ( Lang13.Bool( R ) ) {
				Task13.User.WriteMsg( new Txt( "<span class='notice'>It currently has " ).item( R.volume ).str( " unit" ).s().str( " of " ).item( R.name ).str( " stored.</span>" ).ToString() );
				empty = false;
			}

			if ( empty ) {
				Task13.User.WriteMsg( "<span class='warning'>It is currently empty! Please allow some time for the synthesizer to produce more.</span>" );
			}
			return;
		}

		// Function from file: borghydro.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			Reagents R = null;
			dynamic trans = null;

			
			if ( !( proximity_flag == true ) ) {
				return false;
			} else if ( Lang13.Bool( ((Ent_Static)target).is_open_container() ) && Lang13.Bool( target.reagents ) ) {
				R = this.reagent_list[this.mode];

				if ( !Lang13.Bool( R.total_volume ) ) {
					user.WriteMsg( "<span class='warning'>" + this + " is currently out of this ingredient! Please allow some time for the synthesizer to produce more.</span>" );
					return false;
				}

				if ( ( target.reagents.total_volume ??0) >= Convert.ToDouble( target.reagents.maximum_volume ) ) {
					user.WriteMsg( "<span class='notice'>" + target + " is full.</span>" );
					return false;
				}
				trans = R.trans_to( target, this.amount_per_transfer_from_this );
				user.WriteMsg( new Txt( "<span class='notice'>You transfer " ).item( trans ).str( " unit" ).s().str( " of the solution to " ).item( target ).str( ".</span>" ).ToString() );
			}
			return false;
		}

		// Function from file: borghydro.dm
		public override void regenerate_reagents(  ) {
			Ent_Static R = null;
			dynamic i = null;
			dynamic valueofi = null;
			Reagents RG = null;

			
			if ( this.loc is Mob_Living_Silicon_Robot ) {
				R = this.loc;

				if ( R != null && Lang13.Bool( ((dynamic)R).cell ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.modes )) {
						i = _a;
						
						valueofi = this.modes[i];
						RG = this.reagent_list[valueofi];

						if ( ( RG.total_volume ??0) < Convert.ToDouble( RG.maximum_volume ) ) {
							((Obj_Item_Weapon_StockParts_Cell)((dynamic)R).cell).use( this.charge_cost );
							RG.add_reagent( this.reagent_ids[valueofi], 5 );
						}
					}
				}
			}
			return;
		}

		// Function from file: borghydro.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			return false;
		}

	}

}