// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Dartgun : Obj_Item_Weapon_Gun {

		public ByTable beakers = new ByTable();
		public ByTable mixing = new ByTable();
		public dynamic cartridge = null;
		public int max_beakers = 3;
		public int dart_reagent_amount = 15;
		public Type container_type = typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker);
		public ByTable starting_chems = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.inhand_states = new ByTable().Set( "left_hand", "icons/mob/in-hand/left/guninhands_left.dmi" ).Set( "right_hand", "icons/mob/in-hand/right/guninhands_right.dmi" );
			this.icon_state = "dartgun-empty";
		}

		// Function from file: dartgun.dm
		public Obj_Item_Weapon_Gun_Dartgun ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic chem = null;
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker B = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.starting_chems != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.starting_chems )) {
					chem = _a;
					
					B = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker( this );
					((Reagents)B.reagents).add_reagent( chem, 50 );
					this.beakers.Add( B );
				}
			}
			this.cartridge = new Obj_Item_Weapon_DartCartridge( this );
			this.update_icon();
			return;
		}

		// Function from file: dartgun.dm
		public override void Fire( dynamic target = null, dynamic user = null, dynamic _params = null, bool? reflex = null, bool? struggle = null ) {
			reflex = reflex ?? false;
			struggle = struggle ?? false;

			
			if ( Lang13.Bool( this.cartridge ) ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.fire_dart( target, user );
					return;
				}));
			} else {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>" + this + " is empty.</span>" );
			}
			return;
		}

		// Function from file: dartgun.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? index = null;
			Obj_Item M = null;
			double? index2 = null;
			double? index3 = null;
			Ent_Static B = null;

			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["stop_mix"] ) ) {
				index = String13.ParseNumber( href_list["stop_mix"] );

				if ( ( index ??0) <= this.beakers.len ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.mixing, typeof(Obj_Item) )) {
						M = _a;
						

						if ( M == this.beakers[index] ) {
							this.mixing.Remove( M );
							break;
						}
					}
				}
			} else if ( Lang13.Bool( href_list["mix"] ) ) {
				index2 = String13.ParseNumber( href_list["mix"] );

				if ( ( index2 ??0) <= this.beakers.len ) {
					this.mixing.Add( this.beakers[index2] );
				}
			} else if ( Lang13.Bool( href_list["eject"] ) ) {
				index3 = String13.ParseNumber( href_list["eject"] );

				if ( ( index3 ??0) <= this.beakers.len ) {
					
					if ( Lang13.Bool( this.beakers[index3] ) ) {
						B = this.beakers[index3];
						GlobalFuncs.to_chat( Task13.User, "You remove " + B + " from " + this + "." );
						this.mixing.Remove( B );
						this.beakers.Remove( B );
						B.loc = GlobalFuncs.get_turf( this );
					}
				}
			} else if ( Lang13.Bool( href_list["eject_cart"] ) ) {
				this.remove_cartridge();
			} else if ( Lang13.Bool( href_list["close"] ) ) {
				this.in_use = false;
				Task13.User.unset_machine(  );
				return null;
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: dartgun.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			string dat = null;
			int i = 0;
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker B = null;
			Reagent R = null;

			((Mob)user).set_machine( this );
			this.in_use = true;
			dat = "<b>" + this + " mixing control:</b><br><br>";

			if ( this.beakers.len != 0 ) {
				i = 1;

				foreach (dynamic _b in Lang13.Enumerate( this.beakers, typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker) )) {
					B = _b;
					
					dat += "Beaker " + i + " contains: ";

					if ( Lang13.Bool( B.reagents ) && B.reagents.reagent_list.len != 0 ) {
						
						foreach (dynamic _a in Lang13.Enumerate( B.reagents.reagent_list, typeof(Reagent) )) {
							R = _a;
							
							dat += "<br>    " + R.volume + " units of " + R.name + ", ";
						}

						if ( this.check_beaker_mixing( B ) ) {
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";stop_mix=" ).item( i ).str( "'><font color='green'>Mixing</font></A> " ).ToString();
						} else {
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";mix=" ).item( i ).str( "'><font color='red'>Not mixing</font></A> " ).ToString();
						}
					} else {
						dat += "nothing.";
					}
					dat += new Txt( " [<A href='?src=" ).Ref( this ).str( ";eject=" ).item( i ).str( "'>Eject</A>]<br>" ).ToString();
					i++;
				}
			} else {
				dat += "There are no beakers inserted!<br><br>";
			}

			if ( Lang13.Bool( this.cartridge ) ) {
				
				if ( this.cartridge.darts != 0 ) {
					dat += "The dart cartridge has " + this.cartridge.darts + " shots remaining.";
				} else {
					dat += "<font color='red'>The dart cartridge is empty!</font>";
				}
				dat += new Txt( " [<A href='?src=" ).Ref( this ).str( ";eject_cart=1'>Eject</A>]" ).ToString();
			}
			Interface13.Browse( user, dat, "window=dartgun" );
			GlobalFuncs.onclose( user, "dartgun", this );
			return null;
		}

		// Function from file: dartgun.dm
		public override void updateUsrDialog(  ) {
			bool is_in_use = false;

			
			if ( this.in_use ) {
				is_in_use = false;

				if ( Task13.User.client != null && Task13.User.machine == this && this.loc == Task13.User ) {
					is_in_use = true;
					this.attack_self( Task13.User );
				}

				if ( Task13.User is Mob_Living_Silicon_Robot_Mommi ) {
					
					if ( Task13.User.client != null && Task13.User.machine == this && this.loc == Task13.User ) {
						is_in_use = true;
						this.attack_self( Task13.User );
					}
				}
				this.in_use = is_in_use;
			}
			return;
		}

		// Function from file: dartgun.dm
		public override dynamic can_hit( Mob_Living target = null, Mob user = null ) {
			return 1;
		}

		// Function from file: dartgun.dm
		public override bool afterattack( dynamic A = null, dynamic user = null, bool? flag = null, dynamic _params = null, bool? struggle = null ) {
			
			if ( !( A.loc is Tile ) || A == user ) {
				return false;
			}
			base.afterattack( (object)(A), (object)(user), flag, (object)(_params), struggle );
			return false;
		}

		// Function from file: dartgun.dm
		public bool check_beaker_mixing( Obj_Item_Weapon_ReagentContainers_Glass_Beaker B = null ) {
			Obj_Item M = null;

			
			if ( !( this.mixing != null ) || !( this.beakers != null ) ) {
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.mixing, typeof(Obj_Item) )) {
				M = _a;
				

				if ( M == B ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: dartgun.dm
		public void fire_dart( dynamic target = null, dynamic user = null ) {
			dynamic trg = null;
			Obj_Effect_SyringeGunDummy D = null;
			dynamic S = null;
			int? i = null;
			Mob_Living_Carbon M = null;
			dynamic R = null;
			Mob_Living_Carbon H = null;
			Reagent A = null;
			Ent_Static A2 = null;

			
			if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Table), this.loc ) ) ) {
				return;
			} else {
				trg = GlobalFuncs.get_turf( target );
				D = new Obj_Effect_SyringeGunDummy( GlobalFuncs.get_turf( this ) );
				S = this.get_mixed_syringe();

				if ( !Lang13.Bool( S ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>There are no darts in " + this + "!</span>" );
					return;
				}

				if ( !Lang13.Bool( S.reagents ) ) {
					GlobalFuncs.to_chat( user, "<span class='warning'>There are no reagents available!</span>" );
					return;
				}
				this.cartridge.darts--;
				this.update_icon();
				((Reagents)S.reagents).trans_to( D, S.reagents.total_volume );
				GlobalFuncs.qdel( S );
				S = null;
				D.icon_state = "syringeproj";
				D.name = "syringe";
				D.flags |= 16384;
				GlobalFuncs.playsound( user.loc, "sound/weapons/dartgun.ogg", 50, 1 );
				i = null;
				i = 0;

				while (( i ??0) < 6) {
					
					if ( !( D != null ) ) {
						break;
					}

					if ( D.loc == trg ) {
						break;
					}
					Map13.StepTowardsSimple( D, trg );

					if ( D != null ) {
						
						foreach (dynamic _b in Lang13.Enumerate( D.loc, typeof(Mob_Living_Carbon) )) {
							M = _b;
							

							if ( !( M is Mob_Living_Carbon ) ) {
								continue;
							}

							if ( M == user ) {
								continue;
							}
							R = null;

							if ( M is Mob_Living_Carbon_Human ) {
								H = M;

								if ( Lang13.Bool( ((dynamic)H).species ) && ( ((dynamic)H).species.chem_flags & 8 ) != 0 ) {
									H.visible_message( new Txt( "<span class='warning'>" ).The( D ).item().str( " bounces harmlessly off of " ).item( H ).str( ".</span>" ).ToString(), new Txt( "<span class='notice'>" ).The( D ).item().str( " bounces off you harmlessly and breaks as it hits the ground.</span>" ).ToString() );
									GlobalFuncs.qdel( D );
									return;
								}
							}

							if ( Lang13.Bool( D.reagents ) ) {
								
								foreach (dynamic _a in Lang13.Enumerate( D.reagents.reagent_list, typeof(Reagent) )) {
									A = _a;
									
									R += A.id + " (";
									R += String13.NumberToString( A.volume ??0 ) + "),";
								}
							}

							if ( M is Mob ) {
								M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <b>" + user + "/" + user.ckey + "</b> shot <b>" + M + "/" + M.ckey + "</b> with a <b>dartgun</b> (" + R + ")" );
								user.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <b>" + user + "/" + user.ckey + "</b> shot <b>" + M + "/" + M.ckey + "</b> with a <b>dartgun</b> (" + R + ")" );
								GlobalFuncs.msg_admin_attack( "" + user + " (" + user.ckey + ") shot " + M + " (" + M.ckey + ") with a dartgun (" + R + ") (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + user.x + ";Y=" + user.y + ";Z=" + user.z + "'>JMP</a>)" );

								if ( !( user is Mob_Living_Carbon ) ) {
									M.LAssailant = null;
								} else {
									M.LAssailant = user;
								}
							} else {
								M.attack_log.Add( "[" + GlobalFuncs.time_stamp() + "] <b>UNKNOWN SUBJECT (No longer exists)</b> shot <b>" + M + "/" + M.ckey + "</b> with a <b>dartgun</b> (" + R + ")" );
								GlobalFuncs.msg_admin_attack( "UNKNOWN shot " + M + " (" + M.ckey + ") with a <b>dartgun</b> (" + R + ") (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + user.x + ";Y=" + user.y + ";Z=" + user.z + "'>JMP</a>)" );
							}

							if ( Lang13.Bool( D.reagents ) ) {
								((Reagents)D.reagents).trans_to( M, 15 );
							}
							GlobalFuncs.to_chat( M, "<span class='danger'>You feel a slight prick.</span>" );
							GlobalFuncs.qdel( D );
							D = null;
							break;
						}
					}

					if ( D != null ) {
						
						foreach (dynamic _c in Lang13.Enumerate( D.loc, typeof(Ent_Static) )) {
							A2 = _c;
							

							if ( A2 == user ) {
								continue;
							}

							if ( A2.density ) {
								GlobalFuncs.qdel( D );
								D = null;
							}
						}
					}
					Task13.Sleep( 1 );
					i++;
				}

				if ( D != null ) {
					Task13.Schedule( 10, (Task13.Closure)(() => {
						GlobalFuncs.qdel( D );
						return;
					}));
					D = null;
				}
				return;
			}
		}

		// Function from file: dartgun.dm
		public dynamic get_mixed_syringe(  ) {
			Obj_Item_Weapon_ReagentContainers_Syringe dart = null;
			double? mix_amount = null;
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker B = null;

			
			if ( !Lang13.Bool( this.cartridge ) ) {
				return 0;
			}

			if ( !( this.cartridge.darts != 0 ) ) {
				return 0;
			}
			dart = new Obj_Item_Weapon_ReagentContainers_Syringe( this );

			if ( this.mixing.len != 0 ) {
				mix_amount = 5;

				foreach (dynamic _a in Lang13.Enumerate( this.mixing, typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker) )) {
					B = _a;
					
					((Reagents)B.reagents).trans_to( dart, mix_amount );
				}
			}
			return dart;
		}

		// Function from file: dartgun.dm
		public void remove_cartridge(  ) {
			dynamic C = null;

			
			if ( Lang13.Bool( this.cartridge ) ) {
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'>You pop the cartridge out of " + this + ".</span>" );
				C = this.cartridge;
				C.loc = GlobalFuncs.get_turf( this );
				C.update_icon();
				this.cartridge = null;
				this.update_icon();
			}
			return;
		}

		// Function from file: dartgun.dm
		public bool has_selected_beaker_reagents(  ) {
			return false;
		}

		// Function from file: dartgun.dm
		public override int can_fire(  ) {
			
			if ( !Lang13.Bool( this.cartridge ) ) {
				return 0;
			} else {
				return this.cartridge.darts;
			}
		}

		// Function from file: dartgun.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic D = null;
			dynamic B = null;

			
			if ( a is Obj_Item_Weapon_DartCartridge ) {
				D = a;

				if ( !( D.darts != 0 ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>" + D + " is empty.</span>" );
					return 0;
				}

				if ( Lang13.Bool( this.cartridge ) ) {
					
					if ( this.cartridge.darts <= 0 ) {
						this.remove_cartridge();
					} else {
						GlobalFuncs.to_chat( b, "<span class='notice'>There's already a cartridge in " + this + ".</span>" );
						return 0;
					}
				}

				if ( Lang13.Bool( b.drop_item( D, this ) ) ) {
					this.cartridge = D;
					GlobalFuncs.to_chat( b, "<span class='notice'>You slot " + D + " into " + this + ".</span>" );
					this.update_icon();
					return null;
				}
			}

			if ( a is Obj_Item_Weapon_ReagentContainers_Glass ) {
				
				if ( !Lang13.Bool( ((dynamic)this.container_type).IsInstanceOfType( a ) ) ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>" + a + " doesn't seem to fit into " + this + ".</span>" );
					return null;
				}

				if ( this.beakers.len >= this.max_beakers ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>" + this + " already has " + this.max_beakers + " beakers in it - another one isn't going to fit!</span>" );
					return null;
				}
				B = a;

				if ( Lang13.Bool( b.drop_item( B, this ) ) ) {
					this.beakers.Add( B );
					GlobalFuncs.to_chat( b, "<span class='notice'>You slot " + B + " into " + this + ".</span>" );
					this.updateUsrDialog();
				}
			}
			return null;
		}

		// Function from file: dartgun.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker B = null;
			Reagent R = null;

			base.examine( (object)(user), size );

			if ( this.beakers.len != 0 ) {
				GlobalFuncs.to_chat( user, "<span class='info'>" + this + " contains:</span>" );

				foreach (dynamic _b in Lang13.Enumerate( this.beakers, typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker) )) {
					B = _b;
					

					if ( Lang13.Bool( B.reagents ) && B.reagents.reagent_list.len != 0 ) {
						
						foreach (dynamic _a in Lang13.Enumerate( B.reagents.reagent_list, typeof(Reagent) )) {
							R = _a;
							
							GlobalFuncs.to_chat( user, "<span class='info'>" + R.volume + " units of " + R.name + "</span>" );
						}
					}
				}
			}
			return null;
		}

		// Function from file: dartgun.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( !Lang13.Bool( this.cartridge ) ) {
				this.icon_state = "dartgun-empty";
				return true;
			}

			if ( !( this.cartridge.darts != 0 ) ) {
				this.icon_state = "dartgun-0";
			} else if ( this.cartridge.darts > 5 ) {
				this.icon_state = "dartgun-5";
			} else {
				this.icon_state = "dartgun-" + this.cartridge.darts;
			}
			return true;
		}

	}

}