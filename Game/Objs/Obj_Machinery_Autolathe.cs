// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Autolathe : Obj_Machinery {

		public bool operating = false;
		public ByTable L = new ByTable();
		public ByTable LL = new ByTable();
		public int? hacked = 0;
		public int? disabled = 0;
		public int? shocked = 0;
		public dynamic hack_wire = null;
		public dynamic disable_wire = null;
		public dynamic shock_wire = null;
		public bool busy = false;
		public double prod_coeff = 0;
		public Design being_built = null;
		public Research_Autolathe files = null;
		public ByTable matching_designs = null;
		public dynamic selected_category = null;
		public double? screen = 1;
		public MaterialContainer materials = null;
		public ByTable categories = new ByTable(new object [] { "Tools", "Electronics", "Construction", "T-Comm", "Security", "Machinery", "Medical", "Misc", "Imported" });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 10;
			this.active_power_usage = 100;
			this.icon_state = "autolathe";
		}

		// Function from file: autolathe.dm
		public Obj_Machinery_Autolathe ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_Autolathe( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_MatterBin( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Manipulator( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_ConsoleScreen( null ) );
			this.materials = new MaterialContainer( this, new ByTable().Set( "$metal", 1 ).Set( "$glass", 1 ) );
			this.RefreshParts();
			this.wires = new Wires_Autolathe( this );
			this.files = new Research_Autolathe(  );
			this.matching_designs = new ByTable();
			return;
		}

		// Function from file: autolathe.dm
		public void adjust_hacked( int? state = null ) {
			Design D = null;

			this.hacked = state;

			foreach (dynamic _a in Lang13.Enumerate( this.files.possible_designs, typeof(Design) )) {
				D = _a;
				

				if ( ( D.build_type & 4 ) != 0 && D.category.Contains( "hacked" ) ) {
					
					if ( Lang13.Bool( this.hacked ) ) {
						this.files.AddDesign2Known( D );
					} else {
						this.files.known_designs.Remove( D.id );
					}
				}
			}
			return;
		}

		// Function from file: autolathe.dm
		public bool shock( dynamic user = null, int prb = 0 ) {
			EffectSystem_SparkSpread s = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return false;
			}

			if ( !Rand13.PercentChance( prb ) ) {
				return false;
			}
			s = new EffectSystem_SparkSpread();
			s.set_up( 5, 1, this );
			s.start();

			if ( Lang13.Bool( GlobalFuncs.electrocute_mob( user, GlobalFuncs.get_area( this ), this, 061 ) ) ) {
				return true;
			} else {
				return false;
			}
		}

		// Function from file: autolathe.dm
		public void reset( dynamic wire = null ) {
			
			dynamic _a = wire; // Was a switch-case, sorry for the mess.
			if ( _a=="hack" ) {
				
				if ( !((Wires)this.wires).is_cut( wire ) ) {
					this.adjust_hacked( GlobalVars.FALSE );
				}
			} else if ( _a=="shock" ) {
				
				if ( !((Wires)this.wires).is_cut( wire ) ) {
					this.shocked = GlobalVars.FALSE;
				}
			} else if ( _a=="disable" ) {
				
				if ( !((Wires)this.wires).is_cut( wire ) ) {
					this.disabled = GlobalVars.FALSE;
				}
			}
			return;
		}

		// Function from file: autolathe.dm
		public dynamic get_design_cost( dynamic D = null ) {
			double coeff = 0;
			dynamic dat = null;

			coeff = ( Lang13.Bool( D.build_path.IsSubclassOf( typeof(Obj_Item_Stack) ) ) ? 1 : Math.Pow( 2, this.prod_coeff ) );

			if ( Lang13.Bool( D.materials["$metal"] ) ) {
				dat += "" + D.materials["$metal"] / coeff + " metal ";
			}

			if ( Lang13.Bool( D.materials["$glass"] ) ) {
				dat += "" + D.materials["$glass"] / coeff + " glass";
			}
			return dat;
		}

		// Function from file: autolathe.dm
		public bool can_build( dynamic D = null ) {
			double coeff = 0;

			coeff = ( Lang13.Bool( D.build_path.IsSubclassOf( typeof(Obj_Item_Stack) ) ) ? 1 : Math.Pow( 2, this.prod_coeff ) );

			if ( Lang13.Bool( D.materials["$metal"] ) && ( this.materials.amount( "$metal" ) ?1:0) < Convert.ToDouble( D.materials["$metal"] / coeff ) ) {
				return false;
			}

			if ( Lang13.Bool( D.materials["$glass"] ) && ( this.materials.amount( "$glass" ) ?1:0) < Convert.ToDouble( D.materials["$glass"] / coeff ) ) {
				return false;
			}
			return true;
		}

		// Function from file: autolathe.dm
		public string search_win( dynamic user = null ) {
			string dat = null;
			dynamic v = null;
			dynamic D = null;
			int max_multiplier = 0;

			dat = new Txt( "<A href='?src=" ).Ref( this ).str( ";menu=" ).item( 1 ).str( "'>Return to main menu</A>" ).ToString();
			dat += "<div class='statusDisplay'><h3>Search results:</h3><br>";
			dat += "<b>Total amount:</b> " + this.materials.total_amount + " / " + this.materials.max_amount + " cm<sup>3</sup><br>";
			dat += "<b>Metal amount:</b> " + this.materials.amount( "$metal" ) + " cm<sup>3</sup><br>";
			dat += "<b>Glass amount:</b> " + this.materials.amount( "$glass" ) + " cm<sup>3</sup><br>";

			foreach (dynamic _a in Lang13.Enumerate( this.matching_designs )) {
				v = _a;
				
				D = v;

				if ( Lang13.Bool( this.disabled ) || !this.can_build( D ) ) {
					dat += "<span class='linkOff'>" + D.name + "</span>";
				} else {
					dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";make=" ).item( D.id ).str( ";multiplier=1'>" ).item( D.name ).str( "</a>" ).ToString();
				}

				if ( Lang13.Bool( D.build_path.IsSubclassOf( typeof(Obj_Item_Stack) ) ) ) {
					max_multiplier = Num13.MinInt( D.maxstack, ((int)( ( Lang13.Bool( D.materials["$metal"] ) ? Num13.Floor( ( this.materials.amount( "$metal" ) ?1:0) / Convert.ToDouble( D.materials["$metal"] ) ) : Double.PositiveInfinity ) )), ((int)( ( Lang13.Bool( D.materials["$glass"] ) ? Num13.Floor( ( this.materials.amount( "$glass" ) ?1:0) / Convert.ToDouble( D.materials["$glass"] ) ) : Double.PositiveInfinity ) )) );

					if ( max_multiplier > 10 && !Lang13.Bool( this.disabled ) ) {
						dat += new Txt( " <a href='?src=" ).Ref( this ).str( ";make=" ).item( D.id ).str( ";multiplier=10'>x10</a>" ).ToString();
					}

					if ( max_multiplier > 25 && !Lang13.Bool( this.disabled ) ) {
						dat += new Txt( " <a href='?src=" ).Ref( this ).str( ";make=" ).item( D.id ).str( ";multiplier=25'>x25</a>" ).ToString();
					}

					if ( max_multiplier > 0 && !Lang13.Bool( this.disabled ) ) {
						dat += new Txt( " <a href='?src=" ).Ref( this ).str( ";make=" ).item( D.id ).str( ";multiplier=" ).item( max_multiplier ).str( "'>x" ).item( max_multiplier ).str( "</a>" ).ToString();
					}
				}
				dat += "" + this.get_design_cost( D ) + "<br>";
			}
			dat += "</div>";
			return dat;
		}

		// Function from file: autolathe.dm
		public string category_win( dynamic user = null, dynamic selected_category = null ) {
			string dat = null;
			dynamic v = null;
			Design D = null;
			int max_multiplier = 0;

			dat = new Txt( "<A href='?src=" ).Ref( this ).str( ";menu=" ).item( 1 ).str( "'>Return to main menu</A>" ).ToString();
			dat += "<div class='statusDisplay'><h3>Browsing " + selected_category + ":</h3><br>";
			dat += "<b>Total amount:</b> " + this.materials.total_amount + " / " + this.materials.max_amount + " cm<sup>3</sup><br>";
			dat += "<b>Metal amount:</b> " + this.materials.amount( "$metal" ) + " cm<sup>3</sup><br>";
			dat += "<b>Glass amount:</b> " + this.materials.amount( "$glass" ) + " cm<sup>3</sup><br>";

			foreach (dynamic _a in Lang13.Enumerate( this.files.known_designs )) {
				v = _a;
				
				D = this.files.known_designs[v];

				if ( !D.category.Contains( selected_category ) ) {
					continue;
				}

				if ( Lang13.Bool( this.disabled ) || !this.can_build( D ) ) {
					dat += "<span class='linkOff'>" + D.name + "</span>";
				} else {
					dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";make=" ).item( D.id ).str( ";multiplier=1'>" ).item( D.name ).str( "</a>" ).ToString();
				}

				if ( Lang13.Bool( D.build_path.IsSubclassOf( typeof(Obj_Item_Stack) ) ) ) {
					max_multiplier = Num13.MinInt( D.maxstack, ((int)( ( Lang13.Bool( D.materials["$metal"] ) ? Num13.Floor( ( this.materials.amount( "$metal" ) ?1:0) / Convert.ToDouble( D.materials["$metal"] ) ) : Double.PositiveInfinity ) )), ((int)( ( Lang13.Bool( D.materials["$glass"] ) ? Num13.Floor( ( this.materials.amount( "$glass" ) ?1:0) / Convert.ToDouble( D.materials["$glass"] ) ) : Double.PositiveInfinity ) )) );

					if ( max_multiplier > 10 && !Lang13.Bool( this.disabled ) ) {
						dat += new Txt( " <a href='?src=" ).Ref( this ).str( ";make=" ).item( D.id ).str( ";multiplier=10'>x10</a>" ).ToString();
					}

					if ( max_multiplier > 25 && !Lang13.Bool( this.disabled ) ) {
						dat += new Txt( " <a href='?src=" ).Ref( this ).str( ";make=" ).item( D.id ).str( ";multiplier=25'>x25</a>" ).ToString();
					}

					if ( max_multiplier > 0 && !Lang13.Bool( this.disabled ) ) {
						dat += new Txt( " <a href='?src=" ).Ref( this ).str( ";make=" ).item( D.id ).str( ";multiplier=" ).item( max_multiplier ).str( "'>x" ).item( max_multiplier ).str( "</a>" ).ToString();
					}
				}
				dat += "" + this.get_design_cost( D ) + "<br>";
			}
			dat += "</div>";
			return dat;
		}

		// Function from file: autolathe.dm
		public string main_win( dynamic user = null ) {
			string dat = null;
			int line_length = 0;
			dynamic C = null;

			dat = "<div class='statusDisplay'><h3>Autolathe Menu:</h3><br>";
			dat += "<b>Total amount:</b> " + this.materials.total_amount + " / " + this.materials.max_amount + " cm<sup>3</sup><br>";
			dat += "<b>Metal amount:</b> " + this.materials.amount( "$metal" ) + " cm<sup>3</sup><br>";
			dat += "<b>Glass amount:</b> " + this.materials.amount( "$glass" ) + " cm<sup>3</sup><br>";
			dat += new Txt( "<form name='search' action='?src=" ).Ref( this ).str( "'><input type='hidden' name='src' value='" ).Ref( this ).str( "'><input type='hidden' name='search' value='to_search'><input type='hidden' name='menu' value='" ).item( 3 ).str( "'><input type='text' name='to_search'><input type='submit' value='Search'></form><hr>" ).ToString();
			line_length = 1;
			dat += "<table style='width:100%' align='center'><tr>";

			foreach (dynamic _a in Lang13.Enumerate( this.categories )) {
				C = _a;
				

				if ( line_length > 2 ) {
					dat += "</tr><tr>";
					line_length = 1;
				}
				dat += new Txt( "<td><A href='?src=" ).Ref( this ).str( ";category=" ).item( C ).str( ";menu=" ).item( 2 ).str( "'>" ).item( C ).str( "</A></td>" ).ToString();
				line_length++;
			}
			dat += "</tr></table></div>";
			return dat;
		}

		// Function from file: autolathe.dm
		public override void RefreshParts(  ) {
			double tot_rating = 0;
			Obj_Item_Weapon_StockParts_MatterBin MB = null;
			Obj_Item_Weapon_StockParts_Manipulator M = null;

			tot_rating = 0;
			this.prod_coeff = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_MatterBin) )) {
				MB = _a;
				
				tot_rating += Convert.ToDouble( MB.rating );
			}
			tot_rating *= 25000;
			this.materials.max_amount = tot_rating * 3;

			foreach (dynamic _b in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Manipulator) )) {
				M = _b;
				
				this.prod_coeff += Convert.ToDouble( M.rating - 1 );
			}
			return;
		}

		// Function from file: autolathe.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Ent_Static T = null;
			double? multiplier = null;
			int max_multiplier = 0;
			dynamic is_stack = null;
			double coeff = 0;
			dynamic metal_cost = null;
			dynamic glass_cost = null;
			double power = 0;
			ByTable materials_used = null;
			dynamic N = null;
			Obj_Item_Stack S = null;
			ByTable materials_used2 = null;
			dynamic new_item = null;
			dynamic v = null;
			dynamic D = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}

			if ( !this.busy ) {
				
				if ( Lang13.Bool( href_list["menu"] ) ) {
					this.screen = String13.ParseNumber( href_list["menu"] );
				}

				if ( Lang13.Bool( href_list["category"] ) ) {
					this.selected_category = href_list["category"];
				}

				if ( Lang13.Bool( href_list["make"] ) ) {
					T = this.loc;
					this.being_built = this.files.FindDesignByID( href_list["make"] );

					if ( !( this.being_built != null ) ) {
						return null;
					}
					multiplier = String13.ParseNumber( href_list["multiplier"] );
					max_multiplier = Num13.MinInt( this.being_built.maxstack, ((int)( ( Lang13.Bool( this.being_built.materials["$metal"] ) ? Num13.Floor( ( this.materials.amount( "$metal" ) ?1:0) / Convert.ToDouble( this.being_built.materials["$metal"] ) ) : Double.PositiveInfinity ) )), ((int)( ( Lang13.Bool( this.being_built.materials["$glass"] ) ? Num13.Floor( ( this.materials.amount( "$glass" ) ?1:0) / Convert.ToDouble( this.being_built.materials["$glass"] ) ) : Double.PositiveInfinity ) )) );
					is_stack = this.being_built.build_path.IsSubclassOf( typeof(Obj_Item_Stack) );

					if ( !Lang13.Bool( is_stack ) && ( multiplier ??0) > 1 ) {
						return null;
					}

					if ( !new ByTable(new object [] { 1, 10, 25, max_multiplier }).Contains( multiplier ) ) {
						return null;
					}
					coeff = ( Lang13.Bool( is_stack ) ? 1 : Math.Pow( 2, this.prod_coeff ) );
					metal_cost = this.being_built.materials["$metal"];
					glass_cost = this.being_built.materials["$glass"];
					power = Num13.MaxInt( 2000, Convert.ToInt32( ( metal_cost + glass_cost ) * multiplier / 5 ) );

					if ( ( this.materials.amount( "$metal" ) ?1:0) >= Convert.ToDouble( metal_cost * multiplier / coeff ) && ( this.materials.amount( "$glass" ) ?1:0) >= Convert.ToDouble( glass_cost * multiplier / coeff ) ) {
						this.busy = true;
						this.f_use_power( power );
						this.icon_state = "autolathe";
						Icon13.Flick( "autolathe_n", this );
						Task13.Schedule( ((int)( 32 / coeff )), (Task13.Closure)(() => {
							this.f_use_power( power );

							if ( Lang13.Bool( is_stack ) ) {
								materials_used = new ByTable().Set( "$metal", metal_cost * multiplier ).Set( "$glass", glass_cost * multiplier );
								this.materials.use_amount( materials_used );
								N = Lang13.Call( this.being_built.build_path, T, multiplier );
								N.update_icon();
								((Obj_Item)N).autolathe_crafted( this );

								foreach (dynamic _a in Lang13.Enumerate( T.contents - N, typeof(Obj_Item_Stack) )) {
									S = _a;
									

									if ( Lang13.Bool( ((dynamic)N.merge_type).IsInstanceOfType( S ) ) ) {
										N.merge( S );
									}
								}
							} else {
								materials_used2 = new ByTable().Set( "$metal", metal_cost / coeff ).Set( "$glass", glass_cost / coeff );
								this.materials.use_amount( materials_used2 );
								new_item = Lang13.Call( this.being_built.build_path, T );
								new_item.materials = materials_used2.Copy();
								((Obj_Item)new_item).autolathe_crafted( this );
							}
							this.busy = false;
							this.updateUsrDialog();
							return;
						}));
					}
				}

				if ( Lang13.Bool( href_list["search"] ) ) {
					this.matching_designs.Cut();

					foreach (dynamic _b in Lang13.Enumerate( this.files.known_designs )) {
						v = _b;
						
						D = this.files.known_designs[v];

						if ( String13.FindIgnoreCase( D.name, href_list["to_search"], 1, 0 ) != 0 ) {
							this.matching_designs.Add( D );
						}
					}
				}
			} else {
				Task13.User.WriteMsg( "<span class=\"alert\">The autolathe is busy. Please wait for completion of previous operation.</span>" );
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: autolathe.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic D = null;
			double? material_amount = null;
			double? inserted = null;

			
			if ( this.busy ) {
				user.WriteMsg( "<span class=\"alert\">The autolathe is busy. Please wait for completion of previous operation.</span>" );
				return 1;
			}

			if ( this.default_deconstruction_screwdriver( user, "autolathe_t", "autolathe", A ) ) {
				this.updateUsrDialog();
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}

			if ( Lang13.Bool( this.panel_open ) ) {
				
				if ( A is Obj_Item_Weapon_Crowbar ) {
					this.materials.retrieve_all();
					this.default_deconstruction_crowbar( A );
					return 1;
				} else if ( Lang13.Bool( GlobalFuncs.is_wire_tool( A ) ) ) {
					this.wires.interact( user );
					return 1;
				}
			}

			if ( this.stat != 0 ) {
				return 1;
			}

			if ( A is Obj_Item_Weapon_Disk_DesignDisk ) {
				((Ent_Static)user).visible_message( new Txt().item( user ).str( " begins to load " ).the( A ).item().str( " in " ).the( this ).item().str( "..." ).ToString(), new Txt( "You begin to load a design from " ).the( A ).item().str( "..." ).ToString(), "You hear the chatter of a floppy drive." );
				this.busy = true;
				D = A;

				if ( GlobalFuncs.do_after( user, 1431, null, this ) ) {
					this.files.AddDesign2Known( D.blueprint );
				}
				this.busy = false;
				return null;
			}
			material_amount = this.materials.get_item_material_amount( A );

			if ( !Lang13.Bool( material_amount ) ) {
				user.WriteMsg( "<span class='warning'>This object does not contain sufficient amounts of metal or glass to be accepted by the autolathe.</span>" );
				return 1;
			}

			if ( !this.materials.has_space( material_amount ) ) {
				user.WriteMsg( "<span class='warning'>The autolathe is full. Please remove metal or glass from the autolathe in order to insert more.</span>" );
				return 1;
			}

			if ( !((Mob)user).unEquip( A ) ) {
				user.WriteMsg( new Txt( "<span class='warning'>" ).The( A ).item().str( " is stuck to you and cannot be placed into the autolathe.</span>" ).ToString() );
				return 1;
			}
			this.busy = true;
			inserted = this.materials.insert_item( A );

			if ( Lang13.Bool( inserted ) ) {
				
				if ( A is Obj_Item_Stack ) {
					
					if ( Lang13.Bool( A.materials["$metal"] ) ) {
						Icon13.Flick( "autolathe_o", this );
					}

					if ( Lang13.Bool( A.materials["$glass"] ) ) {
						Icon13.Flick( "autolathe_r", this );
					}
					user.WriteMsg( "<span class='notice'>You insert " + inserted + " sheet" + ( ( inserted ??0) > 1 ? "s" : "" ) + " to the autolathe.</span>" );
					this.f_use_power( ( inserted ??0) * 100 );
				} else {
					user.WriteMsg( "<span class='notice'>You insert a material total of " + inserted + " to the autolathe.</span>" );
					this.f_use_power( Num13.MaxInt( 500, ((int)( ( inserted ??0) / 10 )) ) );
					GlobalFuncs.qdel( A );
				}
			}
			this.busy = false;
			this.updateUsrDialog();
			return null;
		}

		// Function from file: autolathe.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;
			Browser popup = null;

			
			if ( !this.is_operational() ) {
				return null;
			}

			if ( Lang13.Bool( this.shocked ) && !( ( this.stat & 2 ) != 0 ) ) {
				this.shock( user, 50 );
			}

			switch ((int?)( this.screen )) {
				case 1:
					dat = this.main_win( user );
					break;
				case 2:
					dat = this.category_win( user, this.selected_category );
					break;
				case 3:
					dat = this.search_win( user );
					break;
			}
			popup = new Browser( user, "autolathe", this.name, 400, 500 );
			popup.set_content( dat );
			popup.open();
			return null;
		}

		// Function from file: autolathe.dm
		public override dynamic Destroy(  ) {
			GlobalFuncs.qdel( this.wires );
			this.wires = null;
			GlobalFuncs.qdel( this.materials );
			this.materials = null;
			return base.Destroy();
		}

	}

}