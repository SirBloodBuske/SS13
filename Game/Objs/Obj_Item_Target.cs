// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Target : Obj_Item {

		public double hp = 1800;
		public Obj_Structure_TargetStake pinnedLoc = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "target_h";
		}

		public Obj_Item_Target ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shooting_range.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			double? p_x = null;
			double? p_y = null;
			int decaltype = 0;
			Icon C = null;
			Image I = null;

			p_x = ( P.p_x ??0) + Convert.ToDouble( Rand13.Pick(new object [] { 0, 0, 0, 0, 0, -1, 1 }) );
			p_y = ( P.p_y ??0) + Convert.ToDouble( Rand13.Pick(new object [] { 0, 0, 0, 0, 0, -1, 1 }) );
			decaltype = 1;

			if ( Lang13.Bool( P.IsInstanceOfType( typeof(Obj_Item_Projectile_Bullet) ) ) ) {
				decaltype = 2;
			}
			C = new Icon( this.icon, this.icon_state );

			if ( Lang13.Bool( C.GetPixel( p_x, p_y ) ) && P.original == this && this.overlays.len <= 35 ) {
				this.hp -= Convert.ToDouble( P.damage );

				if ( this.hp <= 0 ) {
					this.visible_message( "<span class='danger'>" + this + " breaks into tiny pieces and collapses!</span>" );
					GlobalFuncs.qdel( this );
				}
				I = new Image( "icons/effects/effects.dmi", null, "scorch", 3.5 );
				I.pixel_x = ((int)( ( p_x ??0) - 1 ));
				I.pixel_y = ((int)( ( p_y ??0) - 1 ));

				if ( decaltype == 1 ) {
					((dynamic)I).dir = Rand13.Pick(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST });

					if ( Convert.ToDouble( P.damage ) >= 20 || P is Obj_Item_Projectile_Beam_Practice ) {
						((dynamic)I).dir = Rand13.Pick(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST });
					} else {
						I.icon_state = "light_scorch";
					}
				} else {
					I.icon_state = "dent";
				}
				this.overlays.Add( I );
				return null;
			}
			return -1;
		}

		// Function from file: shooting_range.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( this.pinnedLoc != null ) {
				this.pinnedLoc.removeTarget( a );
			}
			base.attack_hand( (object)(a), b, c );
			return null;
		}

		// Function from file: shooting_range.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic WT = null;

			
			if ( A is Obj_Item_Weapon_Weldingtool ) {
				WT = A;

				if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
					this.removeOverlays();
					Task13.User.WriteMsg( "<span class='notice'>You slice off " + this + "'s uneven chunks of aluminium and scorch marks.</span>" );
				}
			}
			return null;
		}

		// Function from file: shooting_range.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			base.Move( (object)(NewLoc), Dir, step_x, step_y );

			if ( this.pinnedLoc != null ) {
				this.pinnedLoc.loc = this.loc;
			}
			return false;
		}

		// Function from file: shooting_range.dm
		public void removeOverlays(  ) {
			this.overlays.Cut();
			return;
		}

		// Function from file: shooting_range.dm
		public void nullPinnedLoc(  ) {
			this.pinnedLoc = null;
			this.density = false;
			return;
		}

		// Function from file: shooting_range.dm
		public override dynamic Destroy(  ) {
			this.removeOverlays();

			if ( this.pinnedLoc != null ) {
				this.pinnedLoc.nullPinnedTarget();
			}
			return base.Destroy();
		}

	}

}