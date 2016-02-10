// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Overlay_Chain : Obj_Effect_Overlay {

		public dynamic extremity_A = null;
		public Ent_Dynamic extremity_B = null;
		public Chain chain_datum = null;
		public bool rewinding = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/chain.dmi";
		}

		public Obj_Effect_Overlay_Chain ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: hookshot.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.chain_datum != null ) {
				this.chain_datum.links.Remove( this );
			}

			if ( !this.rewinding ) {
				this.chain_datum.snap = true;
				this.chain_datum.Delete_Chain();
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: hookshot.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Dir = Dir ?? 0;
			step_x = step_x ?? 0;
			step_y = step_y ?? 0;

			Ent_Static T = null;
			dynamic CA = null;
			Ent_Dynamic CB = null;

			T = this.loc;

			if ( base.Move( (object)(NewLoc), Dir, step_x, step_y ) ) {
				CA = this.extremity_A;
				CB = this.extremity_B;

				if ( CA is Obj_Effect_Overlay_Chain ) {
					((Obj_Effect_Overlay_Chain)CA).follow( this, T );
					((Obj_Effect_Overlay_Chain)CA).update_overlays( this );
				} else if ( Map13.GetDistance( this.loc, CA.loc ) > 1 ) {
					CA.tether_pull = true;
					CA.Move( T, Map13.GetDistance( CA, T ) );
					CA.tether_pull = false;
				}

				if ( CB is Obj_Effect_Overlay_Chain ) {
					((dynamic)CB).follow( this, T );
					((dynamic)CB).update_overlays( this );
				} else if ( Map13.GetDistance( this.loc, CB.loc ) > 1 ) {
					CB.tether_pull = true;
					CB.Move( T, Map13.GetDistance( CB, T ) );
					CB.tether_pull = false;
				}
			}

			if ( !this.chain_datum.Check_Integrity() ) {
				this.chain_datum.snap = true;
				this.chain_datum.Delete_Chain();
			}
			return false;
		}

		// Function from file: hookshot.dm
		public override dynamic attempt_to_follow( Ent_Dynamic A = null, dynamic T = null ) {
			
			if ( Map13.GetDistance( T, this.loc ) <= 1 ) {
				return 1;
			} else if ( A == this.extremity_A ) {
				return this.extremity_B.attempt_to_follow( this, A.loc );
			} else if ( A == this.extremity_B ) {
				return ((Ent_Dynamic)this.extremity_A).attempt_to_follow( this, A.loc );
			}
			return null;
		}

		// Function from file: hookshot.dm
		public void follow( dynamic A = null, Ent_Static T = null ) {
			dynamic U = null;
			Ent_Static R = null;
			dynamic C = null;
			Ent_Dynamic C2 = null;
			Ent_Dynamic CH = null;
			dynamic C3 = null;
			Ent_Static oldLoc = null;
			int pass_backup = 0;
			dynamic CH2 = null;
			Ent_Dynamic C4 = null;

			U = GlobalFuncs.get_turf( A );

			if ( !( T != null ) || !( this.loc != null ) || T.z != this.loc.z ) {
				this.chain_datum.Delete_Chain();
				return;
			}
			R = this.loc;

			if ( Map13.GetDistance( U, this.loc ) <= 1 ) {
				
				if ( A == this.extremity_A ) {
					C = this.extremity_A;

					if ( C is Obj_Effect_Overlay_Chain ) {
						((Obj_Effect_Overlay_Chain)C).update_overlays( this );
					}
				} else if ( A == this.extremity_B ) {
					C2 = this.extremity_B;

					if ( C2 is Obj_Effect_Overlay_Chain ) {
						((dynamic)C2).update_overlays( this );
					}
				}
				this.update_icon();
				return;
			}
			this.forceMove( T, Map13.GetDistance( this, T ) );

			if ( A == this.extremity_A ) {
				CH = this.extremity_B;

				if ( CH is Obj_Effect_Overlay_Chain ) {
					((Obj_Effect_Overlay_Chain)CH).follow( this, R );
				} else {
					
					if ( !( this.chain_datum.extremity_B != null ) ) {
						CH = null;
						this.extremity_B = null;
					}
					C3 = this.extremity_A;

					if ( C3 is Obj_Effect_Overlay_Chain ) {
						((Obj_Effect_Overlay_Chain)C3).update_overlays( this );
					}

					if ( CH != null && Map13.GetDistance( this.loc, CH.loc ) > 1 ) {
						oldLoc = CH.loc;
						CH.tether_pull = true;
						pass_backup = CH.pass_flags;

						if ( this.chain_datum.rewinding && ( CH is Mob_Living || CH is Obj_Item ) ) {
							CH.pass_flags = 1;
						}
						CH.Move( R, Map13.GetDistance( CH, R ) );
						CH.pass_flags = pass_backup;
						CH.tether_pull = false;

						if ( CH.loc == oldLoc ) {
							CH.tether = null;
							this.extremity_B = null;
							this.chain_datum.extremity_B = null;
						}
					}
				}
				this.update_icon();
			} else if ( A == this.extremity_B ) {
				CH2 = this.extremity_A;

				if ( CH2 is Obj_Effect_Overlay_Chain ) {
					((Obj_Effect_Overlay_Chain)CH2).follow( this, R );
				} else {
					C4 = this.extremity_B;

					if ( C4 is Obj_Effect_Overlay_Chain ) {
						((dynamic)C4).update_overlays( this );
					}

					if ( Lang13.Bool( CH2 ) && Map13.GetDistance( this.loc, CH2.loc ) > 1 ) {
						CH2.tether_pull = true;
						CH2.Move( R, Map13.GetDistance( CH2, R ) );
						CH2.tether_pull = false;
					}
				}
				this.update_icon();
			}
			return;
		}

		// Function from file: hookshot.dm
		public void update_overlays( Ent_Static C = null ) {
			dynamic C1 = null;
			Ent_Dynamic C2 = null;

			C1 = this.extremity_A;
			C2 = this.extremity_B;
			this.update_icon();

			if ( C2 is Obj_Effect_Overlay_Chain && ( !( C != null ) && !( C1 is Obj_Effect_Overlay_Chain ) || C == C1 && C1 is Obj_Effect_Overlay_Chain ) ) {
				((Obj_Effect_Overlay_Chain)C2).update_overlays( this );
			} else if ( C1 is Obj_Effect_Overlay_Chain && ( !( C != null ) && !( C2 is Obj_Effect_Overlay_Chain ) || C == C2 && C2 is Obj_Effect_Overlay_Chain ) ) {
				((Obj_Effect_Overlay_Chain)C1).update_overlays( this );
			}
			return;
		}

		// Function from file: hookshot.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.overlays.len = 0;

			if ( Lang13.Bool( this.extremity_A ) && this.loc != this.extremity_A.loc ) {
				this.overlays.Add( new Image( this.icon, this, "chain", 3.9, Map13.GetDistance( this, this.extremity_A ) ) );
			}

			if ( this.extremity_B != null && this.loc != this.extremity_B.loc ) {
				this.overlays.Add( new Image( this.icon, this, "chain", 3.9, Map13.GetDistance( this, this.extremity_B ) ) );
			}
			return null;
		}

		// Function from file: hookshot.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			return true;
		}

	}

}