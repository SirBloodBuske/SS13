// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Anomaly_Flux : Obj_Effect_Anomaly {

		public bool canshock = false;
		public int shockdamage = 20;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "electricity2";
		}

		// Function from file: anomalies.dm
		public Obj_Effect_Anomaly_Flux ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.aSignal.origin_tech = "powerstorage=6;programming=4;plasmatech=4";
			return;
		}

		// Function from file: anomalies.dm
		public void mobShock( dynamic M = null ) {
			
			if ( this.canshock && M is Mob_Living ) {
				this.canshock = false;

				if ( M is Mob_Living_Carbon ) {
					
					if ( M is Mob_Living_Carbon_Human ) {
						((Mob_Living)M).electrocute_act( this.shockdamage, "" + this.name, null, true );
						return;
					}
					((Mob_Living)M).electrocute_act( this.shockdamage, "" + this.name );
					return;
				} else {
					((Mob_Living)M).adjustFireLoss( this.shockdamage );
					((Ent_Static)M).visible_message( new Txt( "<span class='danger'>" ).item( M ).str( " was shocked by " ).the( this.name ).item().str( "!</span>" ).ToString(), "<span class='userdanger'>You feel a powerful shock coursing through your body!</span>", "<span class='italics'>You hear a heavy electrical crack.</span>" );
				}
			}
			return;
		}

		// Function from file: anomalies.dm
		public override bool Bumped( dynamic AM = null ) {
			this.mobShock( AM );
			return false;
		}

		// Function from file: anomalies.dm
		public override dynamic Bump( Ent_Static Obstacle = null, dynamic yes = null ) {
			this.mobShock( Obstacle );
			return null;
		}

		// Function from file: anomalies.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			this.mobShock( O );
			return null;
		}

		// Function from file: anomalies.dm
		public override void anomalyEffect(  ) {
			Mob_Living M = null;

			base.anomalyEffect();
			this.canshock = true;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this, 0 ), typeof(Mob_Living) )) {
				M = _a;
				
				this.mobShock( M );
			}
			return;
		}

	}

}