// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Rack : Obj_Structure {

		public Type parts = typeof(Obj_Item_Weapon_RackParts);
		public int offset_step = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.throwpass = true;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "rack";
		}

		public Obj_Structure_Rack ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tables_racks.dm
		public override void attack_tk( Mob user = null ) {
			return;
		}

		// Function from file: tables_racks.dm
		public override dynamic attack_animal( Mob_Living user = null ) {
			
			if ( Convert.ToDouble( ((dynamic)user).environment_smash ) > 0 ) {
				this.visible_message( "<span class='danger'>" + user + " smashes " + this + " apart!</span>" );
				this.destroy();
			}
			return null;
		}

		// Function from file: tables_racks.dm
		public override dynamic attack_alien( Mob user = null ) {
			this.visible_message( "<span class='danger'>" + user + " slices " + this + " apart!</span>" );
			this.destroy();
			return null;
		}

		// Function from file: tables_racks.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			Interface13.Stat( null, a.mutations.Contains( 4 ) );

			if ( false ) {
				a.say( Rand13.Pick(new object [] { ";RAAAAAAAARGH!", ";HNNNNNNNNNGGGGGGH!", ";GWAAAAAAAARRRHHH!", "NNNNNNNNGGGGGGGGHH!", ";AAAAAAARRRGH!" }) );
				this.visible_message( "<span class='danger'>" + a + " smashes " + this + " apart!</span>" );
				this.destroy();
			}
			return null;
		}

		// Function from file: tables_racks.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Wrench ) {
				new Obj_Item_Weapon_RackParts( this.loc );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Ratchet.ogg", 50, 1 );
				Lang13.Delete( this );
				Task13.Source = null;
				return null;
				return null;
			}

			if ( Lang13.Bool( b.drop_item( a, this.loc ) ) ) {
				
				if ( a.loc == this.loc ) {
					
					switch ((int)( this.offset_step )) {
						case 1:
							a.pixel_x = -3;
							a.pixel_y = 3;
							break;
						case 2:
							a.pixel_x = 0;
							a.pixel_y = 0;
							break;
						case 3:
							a.pixel_x = 3;
							a.pixel_y = -3;
							this.offset_step = 0;
							break;
					}
					this.offset_step++;
				}
			}
			return 1;
		}

		// Function from file: tables_racks.dm
		public override bool MouseDrop_T( Ent_Static O = null, dynamic user = null, bool? needs_opened = null, bool? show_message = null, bool? move_them = null ) {
			
			if ( !( O is Obj_Item_Weapon ) || ((Mob)user).get_active_hand() != O ) {
				return false;
			}

			if ( Lang13.Bool( user.drop_item( O ) ) ) {
				
				if ( O.loc != this.loc ) {
					Map13.Step( (Ent_Dynamic)(O), Map13.GetDistance( O, this ) );
				}
			}
			return false;
		}

		// Function from file: tables_racks.dm
		public override bool Bumped( Ent_Static AM = null, dynamic yes = null ) {
			
			if ( AM is Obj_Structure_Bed_Chair_Vehicle_Wizmobile ) {
				this.destroy();
			}
			return base.Bumped( AM, (object)(yes) );
		}

		// Function from file: tables_racks.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			
			if ( air_group == true || height == 0 ) {
				return true;
			}

			if ( !this.density ) {
				return true;
			}

			if ( mover is Ent_Dynamic && ((Ent_Static)mover).checkpass( 1 ) != 0 ) {
				return true;
			} else {
				return false;
			}
		}

		// Function from file: tables_racks.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( Rand13.PercentChance( 75 ) ) {
				Lang13.Delete( this );
				Task13.Source = null;
				return false;
				return false;
			} else if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_Weapon_RackParts( this.loc );
				Lang13.Delete( this );
				Task13.Source = null;
				return false;
				return false;
			}
			return false;
		}

		// Function from file: tables_racks.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {

			switch ((int?)(severity)) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					GlobalFuncs.qdel( this );

					if ( Rand13.PercentChance( 50 ) ) {
						new Obj_Item_Weapon_RackParts( this.loc );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 25 ) ) {
						GlobalFuncs.qdel( this );
						new Obj_Item_Weapon_RackParts( this.loc );
					}
					break;
			}
			return false;
		}

		// Function from file: tables_racks.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			
			if ( Proj.destroy ) {
				this.ex_act( 1 );
			}
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			return 0;
		}

		// Function from file: tables_racks.dm
		public void destroy(  ) {
			Lang13.Call( this.parts, this.loc );
			this.density = false;
			GlobalFuncs.qdel( this );
			return;
		}

	}

}