// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Grille : Obj_Structure {

		public double health = 10;
		public bool destroyed = false;
		public Obj_Item_Stack_Rods stored = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.flags = 64;
			this.pressure_resistance = 506.625;
			this.icon_state = "grille";
			this.layer = 2.9;
		}

		// Function from file: grille.dm
		public Obj_Structure_Grille ( dynamic loc = null ) : base( (object)(loc) ) {
			this.stored = new Obj_Item_Stack_Rods( this );
			this.stored.amount = 2;
			return;
		}

		// Function from file: grille.dm
		public override bool storage_contents_dump_act( Obj_Item_Weapon_Storage src_object = null, Mob user = null ) {
			return false;
		}

		// Function from file: grille.dm
		public override bool hitby( Ent_Dynamic AM = null, bool? skipcatch = null, bool? hitpush = null, bool? blocked = null ) {
			int tforce = 0;
			Ent_Dynamic I = null;

			base.hitby( AM, skipcatch, hitpush, blocked );
			tforce = 0;

			if ( AM is Mob ) {
				tforce = 5;
			} else if ( AM is Obj ) {
				I = AM;
				tforce = Num13.MaxInt( 0, Convert.ToInt32( ((dynamic)I).throwforce * 0.5 ) );
			}
			GlobalFuncs.playsound( this.loc, "sound/effects/grillehit.ogg", 80, 1 );
			this.health = Num13.MaxInt( 0, ((int)( this.health - tforce )) );
			this.healthcheck();
			return false;
		}

		// Function from file: grille.dm
		public override dynamic temperature_expose( GasMixture air = null, dynamic exposed_temperature = null, int? exposed_volume = null ) {
			
			if ( !this.destroyed ) {
				
				if ( Convert.ToDouble( exposed_temperature ) > 1773.1500244140625 ) {
					this.health -= 1;
					this.healthcheck();
				}
			}
			base.temperature_expose( air, (object)(exposed_temperature), exposed_volume );
			return null;
		}

		// Function from file: grille.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic R = null;
			dynamic ST = null;
			double? dir_to_set = null;
			Obj_Structure_Window WINDOW = null;
			Obj_Structure_Window WINDOW2 = null;
			Obj_Structure_Window WD = null;

			((Mob)user).changeNext_move( 8 );
			this.add_fingerprint( user );

			if ( A is Obj_Item_Weapon_Wirecutters ) {
				
				if ( !this.shock( user, 100 ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/Wirecutter.ogg", 100, 1 );
					this.Deconstruct();
				}
			} else if ( A is Obj_Item_Weapon_Screwdriver && ( this.loc is Tile_Simulated || Lang13.Bool( this.anchored ) ) ) {
				
				if ( !this.shock( user, 90 ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 100, 1 );
					this.anchored = !Lang13.Bool( this.anchored );
					((Ent_Static)user).visible_message( "<span class='notice'>" + user + " " + ( Lang13.Bool( this.anchored ) ? "fastens" : "unfastens" ) + " " + this + ".</span>", "<span class='notice'>You " + ( Lang13.Bool( this.anchored ) ? "fasten " + this + " to" : "unfasten " + this + " from" ) + " the floor.</span>" );
					return null;
				}
			} else if ( A is Obj_Item_Stack_Rods && this.destroyed ) {
				R = A;

				if ( !this.shock( user, 90 ) ) {
					((Ent_Static)user).visible_message( "<span class='notice'>" + user + " rebuilds the broken grille.</span>", "<span class='notice'>You rebuild the broken grille.</span>" );
					this.health = 10;
					this.density = true;
					this.destroyed = false;
					this.icon_state = "grille";
					R.use( 1 );
					return null;
				}
			} else if ( A is Obj_Item_Weapon_Rcd && this.loc is Tile_Simulated ) {
				return null;
			} else if ( A is Obj_Item_Stack_Sheet_Rglass || A is Obj_Item_Stack_Sheet_Glass ) {
				
				if ( !this.destroyed ) {
					ST = A;

					if ( ( ((Obj_Item_Stack)ST).get_amount() ??0) < 2 ) {
						user.WriteMsg( "<span class='warning'>You need at least two sheets of glass for that!</span>" );
						return null;
					}
					dir_to_set = GlobalVars.SOUTHWEST;

					if ( !Lang13.Bool( this.anchored ) ) {
						user.WriteMsg( "<span class='warning'>" + this + " needs to be fastened to the floor first!</span>" );
						return null;
					}

					foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Structure_Window) )) {
						WINDOW = _a;
						
						user.WriteMsg( "<span class='warning'>There is already a window there!</span>" );
						return null;
					}
					user.WriteMsg( "<span class='notice'>You start placing the window...</span>" );

					if ( GlobalFuncs.do_after( user, 20, null, this ) ) {
						
						if ( !( this.loc != null ) || !Lang13.Bool( this.anchored ) ) {
							return null;
						}

						foreach (dynamic _b in Lang13.Enumerate( this.loc, typeof(Obj_Structure_Window) )) {
							WINDOW2 = _b;
							
							return null;
						}
						WD = null;

						if ( A is Obj_Item_Stack_Sheet_Rglass ) {
							WD = new Obj_Structure_Window_Reinforced_Fulltile( this.loc );
						} else {
							WD = new Obj_Structure_Window_Fulltile( this.loc );
						}
						WD.dir = ((int)( dir_to_set ??0 ));
						WD.ini_dir = dir_to_set;
						WD.anchored = 0;
						WD.state = 0;
						ST.use( 2 );
						user.WriteMsg( "<span class='notice'>You place " + WD + " on " + this + ".</span>" );
					}
					return null;
				}
			} else if ( A is Obj_Item_Weapon_Shard ) {
				GlobalFuncs.playsound( this.loc, "sound/effects/grillehit.ogg", 80, 1 );
				this.health -= Convert.ToDouble( A.force * 0.1 );
			} else if ( !this.shock( user, 70 ) ) {
				
				dynamic _c = A.damtype; // Was a switch-case, sorry for the mess.
				if ( _c=="stamina" ) {
					return null;
				} else if ( _c=="fire" ) {
					GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 80, 1 );
				} else {
					GlobalFuncs.playsound( this.loc, "sound/effects/grillehit.ogg", 80, 1 );
				}
				this.health -= Convert.ToDouble( A.force * 0.3 );
			}
			this.healthcheck();
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: grille.dm
		public bool shock( dynamic user = null, int prb = 0 ) {
			dynamic T = null;
			dynamic C = null;
			EffectSystem_SparkSpread s = null;

			
			if ( !Lang13.Bool( this.anchored ) || this.destroyed ) {
				return false;
			}

			if ( !Rand13.PercentChance( prb ) ) {
				return false;
			}

			if ( !( Map13.GetDistance( this, user ) <= 1 ) ) {
				return false;
			}
			T = GlobalFuncs.get_turf( this );
			C = ((Tile)T).get_cable_node();

			if ( Lang13.Bool( C ) ) {
				
				if ( Lang13.Bool( GlobalFuncs.electrocute_mob( user, C, this ) ) ) {
					s = new EffectSystem_SparkSpread();
					s.set_up( 3, 1, this );
					s.start();
					return true;
				} else {
					return false;
				}
			}
			return false;
		}

		// Function from file: grille.dm
		public void healthcheck(  ) {
			
			if ( this.health <= 0 ) {
				
				if ( !this.destroyed ) {
					this.Break();
				} else if ( this.health <= -6 ) {
					this.Deconstruct();
				}
			}
			return;
		}

		// Function from file: grille.dm
		public void Break(  ) {
			Obj_Item_Stack_Rods newrods = null;

			this.icon_state = "brokengrille";
			this.density = false;
			this.destroyed = true;
			this.stored.amount = 1;

			if ( !Lang13.Bool( this.flags & 128 ) ) {
				newrods = new Obj_Item_Stack_Rods( this.loc );
				this.transfer_fingerprints_to( newrods );
			}
			return;
		}

		// Function from file: grille.dm
		public override void Deconstruct(  ) {
			Ent_Static T = null;

			
			if ( !( this.loc != null ) ) {
				return;
			}

			if ( !Lang13.Bool( this.flags & 128 ) ) {
				this.transfer_fingerprints_to( this.stored );
				T = this.loc;
				this.stored.loc = T;
			}
			base.Deconstruct();
			return;
		}

		// Function from file: grille.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( !Lang13.Bool( P ) ) {
				return null;
			}
			base.bullet_act( (object)(P), (object)(def_zone) );

			if ( P.damage_type != "stamina" ) {
				this.health -= Convert.ToDouble( P.damage * 0.3 );
				this.healthcheck();
			}
			return null;
		}

		// Function from file: grille.dm
		public override bool CanAStarPass( dynamic ID = null, int dir = 0, dynamic caller = null ) {
			bool _default = false;

			Ent_Dynamic mover = null;

			_default = !this.density;

			if ( caller is Ent_Dynamic ) {
				mover = caller;
				_default = _default || mover.checkpass( 4 ) != 0;
			}
			return _default;
		}

		// Function from file: grille.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 0;

			
			if ( height == 0 ) {
				return true;
			}

			if ( mover is Ent_Dynamic && ((Ent_Dynamic)mover).checkpass( 4 ) != 0 ) {
				return true;
			} else if ( mover is Obj_Item_Projectile && this.density ) {
				return Rand13.PercentChance( 30 );
			} else {
				return !this.density;
			}
			return false;
		}

		// Function from file: grille.dm
		public override bool mech_melee_attack( Obj_Mecha M = null ) {
			
			if ( base.mech_melee_attack( M ) ) {
				GlobalFuncs.playsound( this.loc, "sound/effects/grillehit.ogg", 80, 1 );
				this.health -= Convert.ToDouble( M.force * 0.5 );
				this.healthcheck();
			}
			return false;
		}

		// Function from file: grille.dm
		public override bool attack_animal( Mob_Living user = null ) {
			user.changeNext_move( 8 );

			if ( Lang13.Bool( ((dynamic)user).melee_damage_upper ) == false || ((dynamic)user).melee_damage_type != "brute" && ((dynamic)user).melee_damage_type != "fire" ) {
				return false;
			}
			user.do_attack_animation( this );
			GlobalFuncs.playsound( this.loc, "sound/effects/grillehit.ogg", 80, 1 );
			user.visible_message( "<span class='warning'>" + user + " smashes against " + this + ".</span>", "<span class='danger'>You smash against " + this + ".</span>", "<span class='italics'>You hear twisting metal.</span>" );
			this.health -= Convert.ToDouble( ((dynamic)user).melee_damage_upper );
			this.healthcheck();
			return false;
		}

		// Function from file: grille.dm
		public override bool attack_slime( Mob_Living_SimpleAnimal_Slime user = null ) {
			user.changeNext_move( 8 );
			user.do_attack_animation( this );

			if ( !user.is_adult ) {
				return false;
			}
			GlobalFuncs.playsound( this.loc, "sound/effects/grillehit.ogg", 80, 1 );
			user.visible_message( "<span class='warning'>" + user + " smashes against " + this + ".</span>", "<span class='danger'>You smash against " + this + ".</span>", "<span class='italics'>You hear twisting metal.</span>" );
			this.health -= Rand13.Int( 1, 2 );
			this.healthcheck();
			return false;
		}

		// Function from file: grille.dm
		public override bool attack_alien( dynamic user = null ) {
			((Ent_Dynamic)user).do_attack_animation( this );

			if ( user is Mob_Living_Carbon_Alien_Larva ) {
				return false;
			}
			((Mob)user).changeNext_move( 8 );
			GlobalFuncs.playsound( this.loc, "sound/effects/grillehit.ogg", 80, 1 );
			((Ent_Static)user).visible_message( "<span class='warning'>" + user + " mangles " + this + ".</span>", "<span class='danger'>You mangle " + this + ".</span>", "<span class='italics'>You hear twisting metal.</span>" );

			if ( !this.shock( user, 70 ) ) {
				this.health -= 5;
				this.healthcheck();
				return false;
			}
			return false;
		}

		// Function from file: grille.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			((Mob)a).changeNext_move( 8 );
			((Ent_Dynamic)a).do_attack_animation( this );
			GlobalFuncs.playsound( this.loc, "sound/effects/grillehit.ogg", 80, 1 );
			((Ent_Static)a).visible_message( "<span class='warning'>" + a + " hits " + this + ".</span>", "<span class='danger'>You hit " + this + ".</span>", "<span class='italics'>You hear twisting metal.</span>" );

			if ( this.shock( a, 70 ) ) {
				return null;
			} else {
				this.health -= Rand13.Int( 1, 2 );
			}
			this.healthcheck();
			return null;
		}

		// Function from file: grille.dm
		public override bool attack_hulk( Mob_Living_Carbon_Human hulk = null, bool? do_attack_animation = null ) {
			base.attack_hulk( hulk, true );
			this.shock( hulk, 70 );
			this.health -= 5;
			this.healthcheck();
			return false;
		}

		// Function from file: grille.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			this.attack_hand( a );
			return null;
		}

		// Function from file: grille.dm
		public override bool Bumped( dynamic AM = null ) {
			
			if ( AM is Mob ) {
				this.shock( AM, 70 );
			}
			return false;
		}

		// Function from file: grille.dm
		public override bool blob_act( dynamic severity = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: grille.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

	}

}