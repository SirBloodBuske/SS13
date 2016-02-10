// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cell : Obj_Item_Weapon {

		public double charge = 0;
		public double maxcharge = 1000;
		public bool rigged = false;
		public int minor_fault = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cell";
			this.origin_tech = "powerstorage=1";
			this.force = 5;
			this.throwforce = 5;
			this.throw_speed = 3;
			this.throw_range = 5;
			this.starting_materials = new ByTable().Set( "$iron", 700 ).Set( "$glass", 50 );
			this.w_type = 5;
			this.melt_temperature = 1783.1500244140625;
			this.icon = "icons/obj/power.dmi";
			this.icon_state = "cell";
		}

		// Function from file: cell.dm
		public Obj_Item_Weapon_Cell ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.charge = this.maxcharge;

			if ( this.maxcharge <= 2500 ) {
				this.desc = "The manufacturer's label states this cell has a power rating of " + this.maxcharge + ", and that you should not swallow it.";
			} else {
				this.desc = "This power cell has an exciting chrome finish, as it is an uber-capacity cell type! It has a power rating of " + this.maxcharge + "!";
			}
			Task13.Schedule( 5, (Task13.Closure)(() => {
				this.updateicon();
				return;
			}));
			return;
		}

		// Function from file: cell.dm
		public override dynamic get_rating(  ) {
			return this.maxcharge / 10000;
		}

		// Function from file: cell.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 75 ) ) {
				this.explode();
			}
			return false;
		}

		// Function from file: cell.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
						return false;
					}

					if ( Rand13.PercentChance( 50 ) ) {
						this.corrupt();
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 25 ) ) {
						GlobalFuncs.qdel( this );
						return false;
					}

					if ( Rand13.PercentChance( 25 ) ) {
						this.corrupt();
					}
					break;
			}
			return false;
		}

		// Function from file: cell.dm
		public override dynamic emp_act( int severity = 0 ) {
			this.charge -= 1000 / severity;

			if ( this.charge < 0 ) {
				this.charge = 0;
			}

			if ( this.reliability != 100 && Rand13.PercentChance( ((int)( 50 / severity )) ) ) {
				this.reliability -= 10 / severity;
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: cell.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic S = null;

			base.attackby( (object)(a), (object)(b), (object)(c) );

			if ( a is Obj_Item_Weapon_ReagentContainers_Syringe ) {
				S = a;
				GlobalFuncs.to_chat( b, "You inject the solution into the power cell." );

				if ( ((Reagents)S.reagents).has_reagent( "plasma", 5 ) ) {
					this.rigged = true;
					GlobalFuncs.log_admin( "LOG: " + b.name + " (" + b.ckey + ") injected a power cell with plasma, rigging it to explode." );
					GlobalFuncs.message_admins( "LOG: " + b.name + " (" + b.ckey + ") injected a power cell with plasma, rigging it to explode." );
				}
				((Reagents)S.reagents).clear_reagents();
			}
			return null;
		}

		// Function from file: cell.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.add_fingerprint( user );
			return null;
		}

		// Function from file: cell.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( this.crit_fail ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>This power cell seems to be faulty.</span>" );
			} else {
				GlobalFuncs.to_chat( user, "<span class='info'>The charge meter reads " + Num13.Floor( this.percent() ) + "%.</span>" );
			}
			return null;
		}

		// Function from file: cell.dm
		public int get_electrocute_damage(  ) {
			return Num13.Floor( Math.Pow( this.charge, 0.3333333432674408 ) * ( Rand13.Int( 100, 125 ) / 100 ) );
		}

		// Function from file: cell.dm
		public void corrupt(  ) {
			this.charge /= 2;
			this.maxcharge /= 2;

			if ( Rand13.PercentChance( 10 ) ) {
				this.rigged = true;
			}
			return;
		}

		// Function from file: cell.dm
		public void explode(  ) {
			dynamic T = null;
			int devastation_range = 0;
			int heavy_impact_range = 0;
			int light_impact_range = 0;
			int flash_range = 0;

			T = GlobalFuncs.get_turf( this.loc );

			if ( this.charge == 0 ) {
				return;
			}
			devastation_range = -1;
			heavy_impact_range = Num13.Floor( Math.Sqrt( this.charge ) / 60 );
			light_impact_range = Num13.Floor( Math.Sqrt( this.charge ) / 30 );
			flash_range = light_impact_range;

			if ( light_impact_range == 0 ) {
				this.rigged = false;
				this.corrupt();
				return;
			}
			GlobalFuncs.log_admin( "LOG: Rigged power cell explosion, last touched by " + this.fingerprintslast );
			GlobalFuncs.message_admins( "LOG: Rigged power cell explosion, last touched by " + this.fingerprintslast );
			GlobalFuncs.explosion( T, devastation_range, heavy_impact_range, light_impact_range, flash_range );
			Task13.Schedule( 1, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: cell.dm
		public int give( dynamic amount = null ) {
			int power_used = 0;

			
			if ( this.rigged && Convert.ToDouble( amount ) > 0 ) {
				this.explode();
				return 0;
			}

			if ( this.maxcharge < Convert.ToDouble( amount ) ) {
				return 0;
			}
			power_used = Num13.MinInt( ((int)( this.maxcharge - this.charge )), Convert.ToInt32( amount ) );

			if ( this.crit_fail ) {
				return 0;
			}

			if ( !Rand13.PercentChance( ((int)( this.reliability )) ) ) {
				this.minor_fault++;

				if ( Rand13.PercentChance( this.minor_fault ) ) {
					this.crit_fail = true;
					return 0;
				}
			}
			this.charge += power_used;
			return power_used;
		}

		// Function from file: cell.dm
		public virtual bool use( double amount = 0 ) {
			
			if ( this.rigged && amount > 0 ) {
				this.explode();
				return false;
			}

			if ( this.charge < amount ) {
				return false;
			}
			this.charge = Num13.MaxInt( 0, ((int)( this.charge - amount )) );
			return true;
		}

		// Function from file: cell.dm
		public double percent(  ) {
			return this.charge * 100 / this.maxcharge;
		}

		// Function from file: cell.dm
		public void updateicon(  ) {
			this.overlays.len = 0;

			if ( this.charge < 0.01 ) {
				return;
			} else if ( this.charge / this.maxcharge >= 0.995 ) {
				this.overlays.Add( new Image( "icons/obj/power.dmi", "cell-o2" ) );
			} else {
				this.overlays.Add( new Image( "icons/obj/power.dmi", "cell-o1" ) );
			}
			return;
		}

		// Function from file: power_cells.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			GlobalFuncs.to_chat( Map13.FetchViewers( null, user ), new Txt( "<span class='danger'>" ).item( user ).str( " is licking the electrodes of the " ).item( this.name ).str( "! It looks like " ).he_she_it_they().str( "'s trying to commit suicide.</span>" ).ToString() );
			return 2;
		}

	}

}