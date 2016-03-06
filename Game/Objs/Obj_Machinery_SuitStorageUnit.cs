// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_SuitStorageUnit : Obj_Machinery {

		public dynamic suit = null;
		public dynamic helmet = null;
		public dynamic mask = null;
		public dynamic storage = null;
		public Type suit_type = null;
		public Type helmet_type = null;
		public Type mask_type = null;
		public Type storage_type = null;
		public int? locked = 0;
		public bool safeties = true;
		public int? uv = 0;
		public bool uv_super = false;
		public dynamic uv_cycles = 6;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/suitstorage.dmi";
			this.icon_state = "close";
		}

		// Function from file: suit_storage_unit.dm
		public Obj_Machinery_SuitStorageUnit ( dynamic loc = null ) : base( (object)(loc) ) {
			this.wires = new Wires_SuitStorageUnit( this );

			if ( this.suit_type != null ) {
				this.suit = Lang13.Call( this.suit_type, this );
			}

			if ( this.helmet_type != null ) {
				this.helmet = Lang13.Call( this.helmet_type, this );
			}

			if ( this.mask_type != null ) {
				this.mask = Lang13.Call( this.mask_type, this );
			}

			if ( this.storage_type != null ) {
				this.storage = Lang13.Call( this.storage_type, this );
			}
			this.update_icon();
			return;
		}

		// Function from file: suit_storage_unit.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			int? _default = null;

			
			if ( Lang13.Bool( base.ui_act( action, _params, ui, state ) ) || Lang13.Bool( this.uv ) ) {
				return _default;
			}

			switch ((string)( action )) {
				case "door":
					
					if ( Lang13.Bool( this.state_open ) ) {
						this.close_machine();
					} else {
						this.open_machine( !( !Lang13.Bool( this.occupant ) ) ?1:0 );
					}
					_default = GlobalVars.TRUE;
					break;
				case "lock":
					this.locked = !Lang13.Bool( this.locked ) ?1:0;
					_default = GlobalVars.TRUE;
					break;
				case "uv":
					
					if ( Lang13.Bool( this.occupant ) && this.safeties ) {
						return _default;
					} else if ( !Lang13.Bool( this.helmet ) && !Lang13.Bool( this.mask ) && !Lang13.Bool( this.suit ) && !Lang13.Bool( this.storage ) && !Lang13.Bool( this.occupant ) ) {
						return _default;
					} else {
						this.cook();
						_default = GlobalVars.TRUE;
					}
					break;
				case "dispense":
					
					if ( !Lang13.Bool( this.state_open ) ) {
						return _default;
					}

					dynamic _a = _params["item"]; // Was a switch-case, sorry for the mess.
					if ( _a=="helmet" ) {
						this.helmet.loc = this.loc;
						this.helmet = null;
					} else if ( _a=="suit" ) {
						this.suit.loc = this.loc;
						this.suit = null;
					} else if ( _a=="mask" ) {
						this.mask.loc = this.loc;
						this.mask = null;
					} else if ( _a=="storage" ) {
						this.storage.loc = this.loc;
						this.storage = null;
					}
					_default = GlobalVars.TRUE;
					break;
			}
			this.update_icon();
			return _default;
		}

		// Function from file: suit_storage_unit.dm
		public override ByTable ui_data( dynamic user = null ) {
			ByTable data = null;

			data = new ByTable();
			data["locked"] = this.locked;
			data["open"] = this.state_open;
			data["safeties"] = this.safeties;
			data["uv_active"] = this.uv;
			data["uv_super"] = this.uv_super;

			if ( Lang13.Bool( this.helmet ) ) {
				data["helmet"] = this.helmet.name;
			}

			if ( Lang13.Bool( this.suit ) ) {
				data["suit"] = this.suit.name;
			}

			if ( Lang13.Bool( this.mask ) ) {
				data["mask"] = this.mask.name;
			}

			if ( Lang13.Bool( this.storage ) ) {
				data["storage"] = this.storage.name;
			}

			if ( Lang13.Bool( this.occupant ) ) {
				data["occupied"] = 1;
			}
			return data;
		}

		// Function from file: suit_storage_unit.dm
		public override int ui_interact( dynamic user = null, string ui_key = null, Tgui ui = null, bool? force_open = null, Tgui master_ui = null, UiState state = null ) {
			ui_key = ui_key ?? "main";
			force_open = force_open ?? false;
			state = state ?? GlobalVars.notcontained_state;

			ui = GlobalVars.SStgui.try_update_ui( user, this, ui_key, ui, force_open );

			if ( !( ui != null ) ) {
				ui = new Tgui( user, this, ui_key, "suit_storage_unit", this.name, 400, 305, master_ui, state );
				ui.open();
			}
			return 0;
		}

		// Function from file: suit_storage_unit.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( Lang13.Bool( this.state_open ) && this.is_operational() ) {
				
				if ( A is Obj_Item_Clothing_Suit_Space ) {
					
					if ( Lang13.Bool( this.suit ) ) {
						user.WriteMsg( "<span class='warning'>The unit already contains a suit!.</span>" );
						return null;
					}

					if ( !Lang13.Bool( user.drop_item() ) ) {
						return null;
					}
					this.suit = A;
				} else if ( A is Obj_Item_Clothing_Head_Helmet ) {
					
					if ( Lang13.Bool( this.helmet ) ) {
						user.WriteMsg( "<span class='warning'>The unit already contains a helmet!</span>" );
						return null;
					}

					if ( !Lang13.Bool( user.drop_item() ) ) {
						return null;
					}
					this.helmet = A;
				} else if ( A is Obj_Item_Clothing_Mask ) {
					
					if ( Lang13.Bool( this.mask ) ) {
						user.WriteMsg( "<span class='warning'>The unit already contains a mask!</span>" );
						return null;
					}

					if ( !Lang13.Bool( user.drop_item() ) ) {
						return null;
					}
					this.mask = A;
				} else if ( A is Obj_Item ) {
					
					if ( Lang13.Bool( this.storage ) ) {
						user.WriteMsg( "<span class='warning'>The auxiliary storage compartment is full!</span>" );
						return null;
					}

					if ( !Lang13.Bool( user.drop_item() ) ) {
						return null;
					}
					this.storage = A;
				}
				A.loc = this;
				this.visible_message( "<span class='notice'>" + user + " inserts " + A + " into " + this + "</span>", "<span class='notice'>You load " + A + " into " + this + ".</span>" );
			}

			if ( Lang13.Bool( this.panel_open ) && Lang13.Bool( GlobalFuncs.is_wire_tool( A ) ) ) {
				this.wires.interact( user );
			}

			if ( !Lang13.Bool( this.state_open ) ) {
				
				if ( this.default_deconstruction_screwdriver( user, "panel", "close", A ) ) {
					return null;
				}
			}

			if ( this.default_pry_open( A ) ) {
				return null;
			}
			this.update_icon();
			return null;
		}

		// Function from file: suit_storage_unit.dm
		public override void container_resist( Mob user = null ) {
			Mob user2 = null;

			user2 = Task13.User;
			this.add_fingerprint( user2 );

			if ( Lang13.Bool( this.locked ) ) {
				this.visible_message( "<span class='notice'>You see " + user2 + " kicking against the doors of " + this + "!</span>", "<span class='notice'>You start kicking against the doors...</span>" );
				GlobalFuncs.addtimer( this, "resist_open", 300, GlobalVars.FALSE, user2 );
			} else {
				this.open_machine( GlobalVars.TRUE );
			}
			return;
		}

		// Function from file: suit_storage_unit.dm
		public override bool relaymove( Mob user = null, int? direction = null ) {
			this.container_resist();
			return false;
		}

		// Function from file: suit_storage_unit.dm
		public void resist_open( dynamic user = null ) {
			
			if ( !Lang13.Bool( this.state_open ) && Lang13.Bool( this.occupant ) && Lang13.Bool( ((dynamic)this).Contains( user ) ) && Lang13.Bool( user.stat ) == false ) {
				this.visible_message( "<span class='notice'>You see " + user + " bursts out of " + this + "!</span>", "<span class='notice'>You escape the cramped confines of " + this + "!</span>" );
				this.open_machine();
			}
			return;
		}

		// Function from file: suit_storage_unit.dm
		public bool shock( dynamic user = null, int prb = 0 ) {
			EffectSystem_SparkSpread s = null;

			
			if ( !Rand13.PercentChance( prb ) ) {
				s = new EffectSystem_SparkSpread();
				s.set_up( 5, 1, this );
				s.start();

				if ( Lang13.Bool( GlobalFuncs.electrocute_mob( user, this, this ) ) ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: suit_storage_unit.dm
		public void cook(  ) {
			Obj_Item I = null;

			
			if ( Lang13.Bool( this.uv_cycles ) ) {
				this.uv_cycles--;
				this.uv = GlobalVars.TRUE;
				this.locked = GlobalVars.TRUE;
				this.update_icon();

				if ( Lang13.Bool( this.occupant ) ) {
					
					if ( this.uv_super ) {
						((Mob_Living)this.occupant).adjustFireLoss( Rand13.Int( 20, 36 ) );
					} else {
						((Mob_Living)this.occupant).adjustFireLoss( Rand13.Int( 10, 16 ) );
					}

					if ( this.occupant is Mob_Living_Carbon ) {
						((Mob)this.occupant).emote( "scream" );
					}
				}
				GlobalFuncs.addtimer( this, "cook", 50, GlobalVars.FALSE );
			} else {
				this.uv_cycles = Lang13.Initial( this, "uv_cycles" );
				this.uv = GlobalVars.FALSE;
				this.locked = GlobalVars.FALSE;

				if ( this.uv_super ) {
					this.visible_message( "<span class='warning'>With a loud whining noise, " + this + "'s door grinds open. A foul cloud of smoke emanates from the chamber.</span>" );
					this.helmet = null;
					GlobalFuncs.qdel( this.helmet );
					this.suit = null;
					GlobalFuncs.qdel( this.suit );
					this.mask = null;
					GlobalFuncs.qdel( this.mask );
					this.storage = null;
					GlobalFuncs.qdel( this.storage );
					((Wires)this.wires).cut_all();
				} else {
					this.visible_message( "<span class='warning'>With a loud whining noise, " + this + "'s door grinds open. A light cloud of steam escapes from the chamber.</span>" );

					foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Item) )) {
						I = _a;
						
						I.clean_blood();
					}
				}
				this.open_machine( !( !Lang13.Bool( this.occupant ) ) ?1:0 );
			}
			return;
		}

		// Function from file: suit_storage_unit.dm
		public override bool MouseDrop_T( Ent_Static dropping = null, Mob user = null ) {
			
			if ( user.stat != 0 || Lang13.Bool( user.lying ) || !this.Adjacent( user ) || !this.Adjacent( dropping ) ) {
				return false;
			}

			if ( !Lang13.Bool( this.state_open ) ) {
				user.WriteMsg( "<span class='warning'>The unit's doors are shut!</span>" );
				return false;
			}

			if ( !this.is_operational() ) {
				user.WriteMsg( "<span class='warning'>The unit is not operational!</span>" );
				return false;
			}

			if ( Lang13.Bool( this.occupant ) || Lang13.Bool( this.helmet ) || Lang13.Bool( this.suit ) || Lang13.Bool( this.storage ) ) {
				user.WriteMsg( "<span class='warning'>It's too cluttered inside to fit in!</span>" );
				return false;
			}

			if ( dropping == user ) {
				this.visible_message( "<span class='warning'>" + user + " squeezes into " + this + "!</span>", "<span class='notice'>You squeeze into " + this + ".</span>" );
			} else {
				this.visible_message( "<span class='warning'>" + user + " starts putting " + dropping + " into " + this + "!</span>", "<span class='userdanger'>" + user + " starts shoving you into " + this + "!</span>" );
			}

			if ( GlobalFuncs.do_mob( user, dropping, 10 ) ) {
				this.close_machine( dropping );
				this.add_fingerprint( user );
			}
			return false;
		}

		// Function from file: suit_storage_unit.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.open_machine( GlobalVars.TRUE );
					}
					GlobalFuncs.qdel( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						this.open_machine( GlobalVars.TRUE );
						GlobalFuncs.qdel( this );
					}
					break;
			}
			return false;
		}

		// Function from file: suit_storage_unit.dm
		public override bool open_machine( int? dump = null ) {
			dump = dump ?? GlobalVars.FALSE;

			this.state_open = GlobalVars.TRUE;

			if ( Lang13.Bool( dump ) ) {
				this.dropContents();
				this.helmet = null;
				this.suit = null;
				this.mask = null;
				this.storage = null;
				this.occupant = null;
			}
			this.update_icon();
			return false;
		}

		// Function from file: suit_storage_unit.dm
		public override void power_change(  ) {
			base.power_change();

			if ( !this.is_operational() && Lang13.Bool( this.state_open ) ) {
				this.open_machine( GlobalVars.TRUE );
			}
			this.update_icon();
			return;
		}

		// Function from file: suit_storage_unit.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.overlays.Cut();

			if ( Lang13.Bool( this.uv ) ) {
				
				if ( this.uv_super ) {
					this.overlays.Add( "super" );
				} else if ( Lang13.Bool( this.occupant ) ) {
					this.overlays.Add( "uvhuman" );
				} else {
					this.overlays.Add( "uv" );
				}
			} else if ( Lang13.Bool( this.state_open ) ) {
				
				if ( ( this.stat & 1 ) != 0 ) {
					this.overlays.Add( "broken" );
				} else {
					this.overlays.Add( "open" );

					if ( Lang13.Bool( this.suit ) ) {
						this.overlays.Add( "suit" );
					}

					if ( Lang13.Bool( this.helmet ) ) {
						this.overlays.Add( "helm" );
					}

					if ( Lang13.Bool( this.storage ) ) {
						this.overlays.Add( "storage" );
					}
				}
			} else if ( Lang13.Bool( this.occupant ) ) {
				this.overlays.Add( "human" );
			}
			return false;
		}

	}

}