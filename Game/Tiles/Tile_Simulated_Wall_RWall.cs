// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_RWall : Tile_Simulated_Wall {

		public int d_state = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.walltype = "rwall";
			this.hardness = 10;
			this.sheet_type = typeof(Obj_Item_Stack_Sheet_Plasteel);
			this.explosion_block = 2;
			this.icon = "icons/turf/walls/reinforced_wall.dmi";
			this.icon_state = "r_wall";
		}

		public Tile_Simulated_Wall_RWall ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: walls_reinforced.dm
		public override void singularity_pull( Obj_Singularity S = null, int? current_size = null ) {
			
			if ( ( current_size ??0) >= 9 ) {
				
				if ( Rand13.PercentChance( 30 ) ) {
					this.dismantle_wall();
				}
			}
			return;
		}

		// Function from file: walls_reinforced.dm
		public void update_icon(  ) {
			
			if ( this.d_state != 0 ) {
				this.icon_state = "r_wall-" + this.d_state;
				this.smooth = 0;
				this.clear_smooth_overlays();
			} else {
				this.smooth = 1;
				this.icon_state = "";
			}
			return;
		}

		// Function from file: walls_reinforced.dm
		public override bool try_decon( dynamic W = null, dynamic user = null, Ent_Static T = null ) {
			dynamic O = null;
			dynamic WT = null;
			dynamic WT2 = null;

			
			switch ((int)( this.d_state )) {
				case 0:
					
					if ( W is Obj_Item_Weapon_Wirecutters ) {
						GlobalFuncs.playsound( this, "sound/items/Wirecutter.ogg", 100, 1 );
						this.d_state = 1;
						this.update_icon();
						user.WriteMsg( "<span class='notice'>You cut the outer grille.</span>" );
						return true;
					}
					break;
				case 1:
					
					if ( W is Obj_Item_Weapon_Screwdriver ) {
						user.WriteMsg( "<span class='notice'>You begin removing the support lines...</span>" );
						GlobalFuncs.playsound( this, "sound/items/Screwdriver.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
							
							if ( !( this is Tile_Simulated_Wall_RWall ) || !Lang13.Bool( user ) || !Lang13.Bool( W ) || !( T != null ) ) {
								return true;
							}

							if ( this.d_state == 1 && user.loc == T && ((Mob)user).get_active_hand() == W ) {
								this.d_state = 2;
								this.update_icon();
								user.WriteMsg( "<span class='notice'>You remove the support lines.</span>" );
							}
						}
						return true;
					} else if ( W is Obj_Item_Stack_Sheet_Metal ) {
						O = W;

						if ( ((Obj_Item_Stack)O).use( 1 ) != 0 ) {
							this.d_state = 0;
							this.update_icon();
							this.icon_state = "r_wall";
							user.WriteMsg( "<span class='notice'>You replace the outer grille.</span>" );
						} else {
							user.WriteMsg( "<span class='warning'>Report this to a coder: metal stack had less than one sheet in it when trying to repair wall</span>" );
							return true;
						}
						return true;
					}
					break;
				case 2:
					
					if ( W is Obj_Item_Weapon_Weldingtool ) {
						WT = W;

						if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, user ) ) {
							user.WriteMsg( "<span class='notice'>You begin slicing through the metal cover...</span>" );
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

							if ( GlobalFuncs.do_after( user, 60, null, this ) ) {
								
								if ( !( this is Tile_Simulated_Wall_RWall ) || !Lang13.Bool( user ) || !Lang13.Bool( WT ) || !((Obj_Item_Weapon_Weldingtool)WT).isOn() || !( T != null ) ) {
									return false;
								}

								if ( this.d_state == 2 && user.loc == T && ((Mob)user).get_active_hand() == WT ) {
									this.d_state = 3;
									this.update_icon();
									user.WriteMsg( "<span class='notice'>You press firmly on the cover, dislodging it.</span>" );
								}
							}
						}
						return true;
					}

					if ( W is Obj_Item_Weapon_Gun_Energy_Plasmacutter ) {
						user.WriteMsg( "<span class='notice'>You begin slicing through the metal cover...</span>" );
						GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( user, 60, null, this ) ) {
							
							if ( !( this is Tile_Simulated_Wall_RWall ) || !Lang13.Bool( user ) || !Lang13.Bool( W ) || !( T != null ) ) {
								return true;
							}

							if ( this.d_state == 2 && user.loc == T && ((Mob)user).get_active_hand() == W ) {
								this.d_state = 3;
								this.update_icon();
								user.WriteMsg( "<span class='notice'>You press firmly on the cover, dislodging it.</span>" );
							}
						}
						return true;
					}
					break;
				case 3:
					
					if ( W is Obj_Item_Weapon_Crowbar ) {
						user.WriteMsg( "<span class='notice'>You struggle to pry off the cover...</span>" );
						GlobalFuncs.playsound( this, "sound/items/Crowbar.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( user, 100, null, this ) ) {
							
							if ( !( this is Tile_Simulated_Wall_RWall ) || !Lang13.Bool( user ) || !Lang13.Bool( W ) || !( T != null ) ) {
								return true;
							}

							if ( this.d_state == 3 && user.loc == T && ((Mob)user).get_active_hand() == W ) {
								this.d_state = 4;
								this.update_icon();
								user.WriteMsg( "<span class='notice'>You pry off the cover.</span>" );
							}
						}
						return true;
					}
					break;
				case 4:
					
					if ( W is Obj_Item_Weapon_Wrench ) {
						user.WriteMsg( "<span class='notice'>You start loosening the anchoring bolts which secure the support rods to their frame...</span>" );
						GlobalFuncs.playsound( this, "sound/items/ratchet.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( user, 40, null, this ) ) {
							
							if ( !( this is Tile_Simulated_Wall_RWall ) || !Lang13.Bool( user ) || !Lang13.Bool( W ) || !( T != null ) ) {
								return true;
							}

							if ( this.d_state == 4 && user.loc == T && ((Mob)user).get_active_hand() == W ) {
								this.d_state = 5;
								this.update_icon();
								user.WriteMsg( "<span class='notice'>You remove the bolts anchoring the support rods.</span>" );
							}
						}
						return true;
					}
					break;
				case 5:
					
					if ( W is Obj_Item_Weapon_Weldingtool ) {
						WT2 = W;

						if ( ((Obj_Item_Weapon_Weldingtool)WT2).remove_fuel( 0, user ) ) {
							user.WriteMsg( "<span class='notice'>You begin slicing through the support rods...</span>" );
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

							if ( GlobalFuncs.do_after( user, 100, null, this ) ) {
								
								if ( !( this is Tile_Simulated_Wall_RWall ) || !Lang13.Bool( user ) || !Lang13.Bool( WT2 ) || !((Obj_Item_Weapon_Weldingtool)WT2).isOn() || !( T != null ) ) {
									return true;
								}

								if ( this.d_state == 5 && user.loc == T && ((Mob)user).get_active_hand() == WT2 ) {
									this.d_state = 6;
									this.update_icon();
									user.WriteMsg( "<span class='notice'>You slice through the support rods.</span>" );
								}
							}
						}
						return true;
					}

					if ( W is Obj_Item_Weapon_Gun_Energy_Plasmacutter ) {
						user.WriteMsg( "<span class='notice'>You begin slicing through the support rods...</span>" );
						GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( user, 70, null, this ) ) {
							
							if ( !( this is Tile_Simulated_Wall_RWall ) || !Lang13.Bool( user ) || !Lang13.Bool( W ) || !( T != null ) ) {
								return true;
							}

							if ( this.d_state == 5 && user.loc == T && ((Mob)user).get_active_hand() == W ) {
								this.d_state = 6;
								this.update_icon();
								user.WriteMsg( "<span class='notice'>You slice through the support rods.</span>" );
							}
						}
						return true;
					}
					break;
				case 6:
					
					if ( W is Obj_Item_Weapon_Crowbar ) {
						user.WriteMsg( "<span class='notice'>You struggle to pry off the outer sheath...</span>" );
						GlobalFuncs.playsound( this, "sound/items/Crowbar.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( user, 100, null, this ) ) {
							
							if ( !( this is Tile_Simulated_Wall_RWall ) || !Lang13.Bool( user ) || !Lang13.Bool( W ) || !( T != null ) ) {
								return true;
							}

							if ( user.loc == T && ((Mob)user).get_active_hand() == W ) {
								user.WriteMsg( "<span class='notice'>You pry off the outer sheath.</span>" );
								this.dismantle_wall();
							}
						}
						return true;
					}
					break;
			}
			return false;
		}

		// Function from file: walls_reinforced.dm
		public override bool try_destroy( dynamic W = null, dynamic user = null, Ent_Static T = null ) {
			dynamic D = null;
			dynamic MS = null;

			
			if ( W is Obj_Item_Weapon_Pickaxe_Drill_Jackhammer ) {
				D = W;
				user.WriteMsg( "<span class='notice'>You begin to smash though the " + this.name + "...</span>" );

				if ( GlobalFuncs.do_after( user, 50, null, this ) ) {
					
					if ( !( this is Tile_Simulated_Wall_RWall ) || !Lang13.Bool( user ) || !Lang13.Bool( W ) || !( T != null ) ) {
						return true;
					}

					if ( user.loc == T && ((Mob)user).get_active_hand() == W ) {
						((Obj_Item_Weapon_Pickaxe)D).playDigSound();
						this.visible_message( "<span class='warning'>" + user + " smashes through the " + this.name + " with the " + D.name + "!</span>", "<span class='italics'>You hear the grinding of metal.</span>" );
						this.dismantle_wall();
						return true;
					}
				}
			} else if ( W is Obj_Item_Stack_Sheet_Metal && this.d_state != 0 ) {
				MS = W;

				if ( ( ((Obj_Item_Stack)MS).get_amount() ??0) < 1 ) {
					user.WriteMsg( "<span class='warning'>You need one sheet of metal to repair the wall!</span>" );
					return true;
				}
				user.WriteMsg( new Txt( "<span class='notice'>You begin patching-up the wall with " ).a( MS ).item().str( "...</span>" ).ToString() );

				if ( GlobalFuncs.do_after( user, Num13.MaxInt( this.d_state * 20, 100 ), null, this ) ) {
					
					if ( this.loc == null || ( ((Obj_Item_Stack)MS).get_amount() ??0) < 1 ) {
						return true;
					}
					((Obj_Item_Stack)MS).use( 1 );
					this.d_state = 0;
					this.icon_state = "r_wall";
					GlobalFuncs.smooth_icon_neighbors( this );
					user.WriteMsg( "<span class='notice'>You repair the last of the damage.</span>" );
					return true;
				}
			}
			return false;
		}

		// Function from file: walls_reinforced.dm
		public override bool attack_animal( Mob_Living user = null ) {
			user.changeNext_move( 8 );
			user.do_attack_animation( this );

			if ( Convert.ToInt32( ((dynamic)user).environment_smash ) == 3 ) {
				this.dismantle_wall( true );
				GlobalFuncs.playsound( this, "sound/effects/meteorimpact.ogg", 100, 1 );
				user.WriteMsg( "<span class='notice'>You smash through the wall.</span>" );
			} else {
				user.WriteMsg( "<span class='warning'>This wall is far too strong for you to destroy.</span>" );
			}
			return false;
		}

		// Function from file: walls_reinforced.dm
		public override void devastate_wall(  ) {
			this.builtin_sheet.loc = this;
			new Obj_Item_Stack_Sheet_Metal( this, 2 );
			return;
		}

		// Function from file: walls_reinforced.dm
		public override Obj_Structure break_wall(  ) {
			this.builtin_sheet.loc = this;
			return new Obj_Structure_Girder_Reinforced( this );
		}

	}

}