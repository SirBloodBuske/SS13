// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Shield : Obj_Machinery {

		public int max_health = 200;
		public double health = 200;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.ghost_read = false;
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "shield-old";
		}

		// Function from file: shieldgen.dm
		public Obj_Machinery_Shield ( dynamic loc = null ) : base( (object)(loc) ) {
			this.dir = Convert.ToInt32( Rand13.Pick(new object [] { 1, 2, 3, 4 }) );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.update_nearby_tiles();
			return;
		}

		// Function from file: shieldgen.dm
		public override void hitby( Ent_Static AM = null, dynamic speed = null, int? dir = null ) {
			int tforce = 0;

			this.visible_message( "<span class='danger'>" + this + " was hit by " + AM + ".</span>" );
			tforce = 0;

			if ( AM is Mob ) {
				tforce = 40;
			} else {
				tforce = Convert.ToInt32( ((dynamic)AM).throwforce );
			}
			this.health -= tforce;
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/EMPulse.ogg", 100, 1 );

			if ( this.health <= 0 ) {
				this.visible_message( "<span class='notice'>The " + this + " dissapates</span>" );
				GlobalFuncs.qdel( this );
				return;
			}
			this.opacity = true;
			Task13.Schedule( 20, (Task13.Closure)(() => {
				
				if ( this != null ) {
					this.opacity = false;
				}
				return;
			}));
			base.hitby( AM, (object)(speed), dir ); return;
		}

		// Function from file: shieldgen.dm
		public override bool blob_act( dynamic severity = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: shieldgen.dm
		public override dynamic emp_act( int severity = 0 ) {
			
			switch ((int)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return null;
		}

		// Function from file: shieldgen.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {

			switch ((int?)(severity)) {
				case 1:
					
					if ( Rand13.PercentChance( 75 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 25 ) ) {
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

		// Function from file: shieldgen.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.health -= Convert.ToDouble( Proj.damage );
			base.bullet_act( (object)(Proj), (object)(def_zone) );

			if ( this.health <= 0 ) {
				this.visible_message( "<span class='notice'>The " + this + " dissapates</span>" );
				GlobalFuncs.qdel( this );
				return null;
			}
			this.opacity = true;
			Task13.Schedule( 20, (Task13.Closure)(() => {
				
				if ( this != null ) {
					this.opacity = false;
				}
				return;
			}));
			return null;
		}

		// Function from file: shieldgen.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic aforce = null;

			
			if ( !( a is Obj_Item_Weapon ) ) {
				return null;
			}
			aforce = a.force;

			if ( a.damtype == "brute" || a.damtype == "fire" ) {
				this.health -= Convert.ToDouble( aforce );
			}
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/EMPulse.ogg", 75, 1 );

			if ( this.health <= 0 ) {
				this.visible_message( "<span class='notice'>The " + this + " dissapates</span>" );
				GlobalFuncs.qdel( this );
				return null;
			}
			this.opacity = true;
			Task13.Schedule( 20, (Task13.Closure)(() => {
				
				if ( this != null ) {
					this.opacity = false;
				}
				return;
			}));

			if ( this.health <= 0 ) {
				this.visible_message( "<span class='notice'>The " + this + " dissapates</span>" );
				GlobalFuncs.qdel( this );
				return null;
			}
			this.opacity = true;
			Task13.Schedule( 20, (Task13.Closure)(() => {
				
				if ( this != null ) {
					this.opacity = false;
				}
				return;
			}));
			return null;
		}

		// Function from file: shieldgen.dm
		public bool update_nearby_tiles(  ) {
			Ent_Static T = null;

			
			if ( GlobalVars.air_master == null ) {
				return false;
			}
			T = this.loc;

			if ( T is Tile ) {
				GlobalVars.air_master.mark_for_update( T );
			}
			return true;
		}

		// Function from file: shieldgen.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			
			if ( !Lang13.Bool( height ) || air_group == true ) {
				return false;
			} else {
				return base.CanPass( (object)(mover), (object)(target), height, air_group );
			}
		}

		// Function from file: shieldgen.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			this.opacity = false;
			this.density = false;
			this.update_nearby_tiles();
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}