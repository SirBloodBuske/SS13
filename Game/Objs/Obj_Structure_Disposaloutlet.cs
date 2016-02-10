// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Disposaloutlet : Obj_Structure {

		public bool active = false;
		public Tile target = null;
		public bool mode = false;
		public dynamic trunk = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/pipes/disposal.dmi";
			this.icon_state = "outlet";
		}

		// Function from file: disposal.dm
		public Obj_Structure_Disposaloutlet ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 1, (Task13.Closure)(() => {
				this.target = GlobalFuncs.get_ranged_target_turf( this, this.dir, 10 );
				this.trunk = Lang13.FindIn( typeof(Obj_Structure_Disposalpipe_Trunk), this.loc );

				if ( Lang13.Bool( this.trunk ) ) {
					
					if ( this.trunk.disposaloutlet != this ) {
						this.trunk.disposaloutlet = this;
					}

					if ( this.trunk.linked != this.trunk.disposaloutlet ) {
						this.trunk.linked = this.trunk.disposaloutlet;
					}
				}
				return;
			}));
			return;
		}

		// Function from file: disposal.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic W = null;
			Obj_Structure_Disposalconstruct C = null;

			
			if ( !Lang13.Bool( a ) || !Lang13.Bool( b ) ) {
				return null;
			}
			this.add_fingerprint( b );

			if ( a is Obj_Item_Weapon_Screwdriver ) {
				
				if ( !this.mode ) {
					this.mode = true;
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Screwdriver.ogg", 50, 1 );
					GlobalFuncs.to_chat( b, "You remove the screws around the power connection." );
					return null;
				} else if ( this.mode ) {
					this.mode = false;
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Screwdriver.ogg", 50, 1 );
					GlobalFuncs.to_chat( b, "You attach the screws around the power connection." );
					return null;
				}
			} else if ( a is Obj_Item_Weapon_Weldingtool && this.mode ) {
				W = a;

				if ( Lang13.Bool( W.remove_fuel( 0, b ) ) ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/welder2.ogg", 100, 1 );
					GlobalFuncs.to_chat( b, "You start slicing the floorweld off the disposal outlet." );

					if ( GlobalFuncs.do_after( b, this, 20 ) ) {
						
						if ( !( this != null ) || !((Obj_Item_Weapon_Weldingtool)W).isOn() ) {
							return null;
						}
						GlobalFuncs.to_chat( b, "You sliced the floorweld off the disposal outlet." );
						C = new Obj_Structure_Disposalconstruct( this.loc );
						this.transfer_fingerprints_to( C );
						C.ptype = 7;
						C.update();
						C.anchored = 1;
						C.density = true;
						GlobalFuncs.qdel( this );
					}
					return null;
				} else {
					GlobalFuncs.to_chat( b, "You need more welding fuel to complete this task." );
					return null;
				}
			}
			return null;
		}

		// Function from file: disposal.dm
		public void expel( Obj_Structure_Disposalholder H = null ) {
			Ent_Dynamic AM = null;

			Icon13.Flick( "outlet-open", this );
			GlobalFuncs.playsound( this, "sound/machines/warning-buzzer.ogg", 50, 0, 0 );
			Task13.Sleep( 20 );
			GlobalFuncs.playsound( this, "sound/machines/hiss.ogg", 50, 0, 0 );

			if ( H != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( H, typeof(Ent_Dynamic) )) {
					AM = _a;
					
					AM.forceMove( this.loc );
					AM.pipe_eject( this.dir );
					Task13.Schedule( 5, (Task13.Closure)(() => {
						
						if ( AM != null ) {
							AM.throw_at( this.target, 3, 1 );
						}
						return;
					}));
				}
				H.vent_gas( this.loc );
				GlobalFuncs.qdel( H );
			}
			return;
		}

		// Function from file: disposal.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( Lang13.Bool( this.trunk ) ) {
				
				if ( Lang13.Bool( this.trunk.disposaloutlet ) ) {
					this.trunk.disposaloutlet = null;
				}

				if ( Lang13.Bool( this.trunk.linked ) ) {
					this.trunk.linked = null;
				}
				this.trunk = null;
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}