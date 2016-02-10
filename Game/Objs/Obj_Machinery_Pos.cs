// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Pos : Obj_Machinery {

		public int id = 0;
		public int sales = 0;
		public dynamic department = null;
		public dynamic logged_in = null;
		public double? credits_held = 0;
		public double? credits_needed = 0;
		public ByTable products = new ByTable();
		public ByTable line_items = new ByTable();
		public double? screen = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.machine_flags = 256;
			this.icon = "icons/obj/machines/pos.dmi";
			this.icon_state = "pos";
		}

		// Function from file: POS.dm
		public Obj_Machinery_Pos ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.id = GlobalVars.current_pos_id++;

			if ( GlobalVars.ticker != null ) {
				this.initialize();
			}
			this.update_icon();
			return;
		}

		// Function from file: POS.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic I = null;
			MoneyAccount acct = null;
			dynamic C = null;
			Obj_Item_Weapon_Storage_Box B = null;

			
			if ( a is Obj_Item_Weapon_Card_Id ) {
				I = a;

				if ( !Lang13.Bool( this.logged_in ) ) {
					((Ent_Static)b).visible_message( "<span class='notice'>The machine beeps, and logs you in</span>", "You hear a beep." );
					this.logged_in = b;
					this.screen = 1;
					this.update_icon();
					this.attack_hand( b );
					return null;
				} else {
					
					if ( !( this.linked_account != null ) ) {
						this.visible_message( "<span class='warning'>The machine buzzes, and flashes \"NO LINKED ACCOUNT\" on the screen.</span>", "You hear a buzz." );
						Icon13.Flick( this, "pos-error" );
						return null;
					}

					if ( this.screen != 2 ) {
						this.visible_message( "<span class='notice'>The machine buzzes.</span>", "<span class='warning'>You hear a buzz.</span>" );
						Icon13.Flick( this, "pos-error" );
						return null;
					}
					acct = this.get_card_account( I );

					if ( !( acct != null ) ) {
						this.visible_message( "<span class='warning'>The machine buzzes, and flashes \"NO ACCOUNT\" on the screen.</span>", "You hear a buzz." );
						Icon13.Flick( this, "pos-error" );
						return null;
					}

					if ( ( this.credits_needed ??0) > ( acct.money ??0) ) {
						this.visible_message( "<span class='warning'>The machine buzzes, and flashes \"NOT ENOUGH FUNDS\" on the screen.</span>", "You hear a buzz." );
						Icon13.Flick( this, "pos-error" );
						return null;
					}
					this.visible_message( "<span class='notice'>The machine beeps, and begins printing a receipt</span>", "You hear a beep." );
					this.PrintReceipt();
					this.NewOrder();
					acct.charge( this.credits_needed, this.linked_account, "Purchase at POS #" + this.id + "." );
					this.credits_needed = 0;
					this.screen = 1;
				}
			} else if ( a is Obj_Item_Weapon_Spacecash ) {
				
				if ( !( this.linked_account != null ) ) {
					this.visible_message( "<span class='warning'>The machine buzzes, and flashes \"NO LINKED ACCOUNT\" on the screen.</span>", "You hear a buzz." );
					Icon13.Flick( this, "pos-error" );
					return null;
				}

				if ( !Lang13.Bool( this.logged_in ) || this.screen != 2 ) {
					this.visible_message( "<span class='notice'>The machine buzzes.</span>", "<span class='warning'>You hear a buzz.</span>" );
					Icon13.Flick( this, "pos-error" );
					return null;
				}
				C = a;
				this.credits_held += Convert.ToDouble( C.worth * C.amount );

				if ( ( this.credits_held ??0) >= ( this.credits_needed ??0) ) {
					this.visible_message( "<span class='notice'>The machine beeps, and begins printing a receipt</span>", "You hear a beep and the sound of paper being shredded." );
					this.PrintReceipt();
					this.NewOrder();
					this.credits_held -= this.credits_needed ??0;
					this.credits_needed = 0;
					this.screen = 1;

					if ( Lang13.Bool( this.credits_held ) ) {
						B = new Obj_Item_Weapon_Storage_Box( this.loc );
						GlobalFuncs.dispense_cash( this.credits_held, B );
						B.name = "change";
						B.desc = "A box of change.";
					}
					this.credits_held = 0;
				}
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: POS.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double subtotal = 0;
			int? i = null;
			LineItem LI = null;
			double taxes = 0;
			LineItem LI2 = null;
			ByTable line = null;
			ByTable cells = null;
			LineItem LI3 = null;
			MoneyAccount new_linked_account = null;
			double? lid = null;
			dynamic newunits = null;
			LineItem LI4 = null;
			string newtext = null;
			dynamic pid = null;
			dynamic LI5 = null;
			dynamic newprice = null;
			dynamic pid2 = null;
			dynamic LI6 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return null;
			}
			Interface13.Stat( null, href_list.Contains( "logout" ) );

			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				
				if ( Interface13.Alert( this, "You sure you want to log out?", "Confirm", "Yes", "No" ) != "Yes" ) {
					return null;
				}
				this.logged_in = null;
				this.screen = 0;
				this.update_icon();
				this.attack_hand( Task13.User );
				return null;
			}

			if ( Task13.User != this.logged_in ) {
				
				if ( Lang13.Bool( this.logged_in ) ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>" + this.logged_in.name + " is already logged in.  You cannot use this machine until they log out.</span>" );
				}
				return null;
			}
			Interface13.Stat( null, href_list.Contains( "act" ) );

			if ( Task13.User != this.logged_in ) {
				
				dynamic _b = href_list["act"]; // Was a switch-case, sorry for the mess.
				if ( _b=="Reset" ) {
					this.NewOrder();
					this.screen = 1;
				} else if ( _b=="Finalize Sale" ) {
					subtotal = 0;

					if ( this.line_items.len > 0 ) {
						i = null;
						i = 1;

						while (( i ??0) <= this.line_items.len) {
							LI = this.line_items[i];
							subtotal += Convert.ToDouble( LI.units * LI.price );
							i++;
						}
					}
					taxes = subtotal * 0.1;
					this.credits_needed = taxes + subtotal;
					this.say( "Your total is $" + GlobalFuncs.num2septext( this.credits_needed ) + ".  Please insert credit chips or swipe your ID." );
					this.screen = 2;
				} else if ( _b=="Add Product" ) {
					LI2 = new LineItem();
					LI2.name = GlobalFuncs.sanitize( href_list["name"] );
					LI2.price = String13.ParseNumber( href_list["price"] );
					this.products["" + ( this.products.len + 1 )] = LI2;
				} else if ( _b=="Add to Order" ) {
					this.AddToOrder( href_list["preset"], String13.ParseNumber( href_list["units"] ) );
				} else if ( _b=="Add Products" ) {
					
					foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.text2list( href_list["csv"], "\n" ), typeof(ByTable) )) {
						line = _a;
						
						cells = GlobalFuncs.text2list( line, "," );

						if ( cells.len < 2 ) {
							GlobalFuncs.to_chat( Task13.User, "<span class='warning'>The CSV must have at least two columns: Product Name, followed by Price (as a number).</span>" );
							this.attack_hand( Task13.User );
							return null;
						}
						LI3 = new LineItem();
						LI3.name = GlobalFuncs.sanitize( cells[1] );
						LI3.price = String13.ParseNumber( cells[2] );
						this.products["" + ( this.products.len + 1 )] = LI3;
					}
				} else if ( _b=="Export Products" ) {
					this.screen = 5;
				} else if ( _b=="Import Products" ) {
					this.screen = 4;
				} else if ( _b=="Save Settings" ) {
					new_linked_account = GlobalFuncs.get_money_account( String13.ParseNumber( href_list["payableto"] ), this.z );

					if ( !( new_linked_account != null ) ) {
						GlobalFuncs.to_chat( Task13.User, "<span class='warning'>Unable to link new account.</span>" );
					} else {
						this.linked_account = new_linked_account;
					}
					this.screen = 6;
				}
			} else {
				Interface13.Stat( null, href_list.Contains( "screen" ) );

				if ( Task13.User != this.logged_in ) {
					this.screen = String13.ParseNumber( href_list["screen"] );
				} else {
					Interface13.Stat( null, href_list.Contains( "rmproduct" ) );

					if ( Task13.User != this.logged_in ) {
						this.products.Remove( href_list["rmproduct"] );
					} else {
						Interface13.Stat( null, href_list.Contains( "removefromorder" ) );

						if ( Task13.User != this.logged_in ) {
							this.RemoveFromOrder( String13.ParseNumber( href_list["removefromorder"] ) );
						} else {
							Interface13.Stat( null, href_list.Contains( "setunits" ) );

							if ( Task13.User != this.logged_in ) {
								lid = String13.ParseNumber( href_list["setunits"] );
								newunits = Interface13.Input( Task13.User, "Enter the units sold.", null, null, null, InputType.Num );

								if ( !Lang13.Bool( newunits ) ) {
									return null;
								}
								LI4 = this.line_items[lid];
								LI4.units = newunits;
								this.line_items[lid] = LI4;
							} else {
								Interface13.Stat( null, href_list.Contains( "setpname" ) );

								if ( Task13.User != this.logged_in ) {
									newtext = GlobalFuncs.sanitize( Interface13.Input( Task13.User, "Enter the product's name.", null, null, null, InputType.Any ) );

									if ( !Lang13.Bool( newtext ) ) {
										return null;
									}
									pid = href_list["setpname"];
									LI5 = this.products[pid];

									if ( Lang13.Bool( LI5 ) ) {
										LI5.name = newtext;
										this.products[pid] = LI5;
									}
								} else {
									Interface13.Stat( null, href_list.Contains( "setprice" ) );

									if ( Task13.User != this.logged_in ) {
										newprice = Interface13.Input( Task13.User, "Enter the product's price.", null, null, null, InputType.Num );

										if ( !Lang13.Bool( newprice ) ) {
											return null;
										}
										pid2 = href_list["setprice"];
										LI6 = this.products[pid2];
										LI6.price = newprice;
										this.products[pid2] = LI6;
									}
								}
							}
						}
					}
				}
			}
			this.attack_hand( Task13.User );
			return null;
		}

		// Function from file: POS.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string logindata = null;
			string dat = null;

			((Mob)a).set_machine( this );
			logindata = "";

			if ( Lang13.Bool( this.logged_in ) ) {
				logindata = new Txt( "<a href=\"?src=" ).Ref( this ).str( ";logout=1\">" ).item( this.logged_in.name ).str( "</a>" ).ToString();
			}
			dat = GlobalVars.POS_HEADER + new Txt( "\n	<div class=\"navbar\">\n		" ).item( GlobalFuncs.worldtime2text() ).str( ", " ).item( GlobalVars.current_date_string ).str( "<br />\n		" ).item( logindata ).str( "\n		<a href=\"?src=" ).Ref( this ).str( ";screen=" ).item( 1 ).str( "\">Order</a> |\n		<a href=\"?src=" ).Ref( this ).str( ";screen=" ).item( 3 ).str( "\">Products</a> |\n		<a href=\"?src=" ).Ref( this ).str( ";screen=" ).item( 6 ).str( "\">Settings</a>\n	</div>" ).ToString();

			switch ((double?)( this.screen )) {
				case 0:
					dat += this.LoginScreen();
					break;
				case 1:
					dat += this.OrderScreen();
					break;
				case 2:
					dat += this.FinalizeScreen();
					break;
				case 3:
					dat += this.ProductsScreen();
					break;
				case 5:
					dat += this.ExportScreen();
					break;
				case 4:
					dat += this.ImportScreen();
					break;
				case 6:
					dat += this.SettingsScreen();
					break;
			}
			dat += "</body></html>";
			Interface13.Browse( a, dat, "window=pos" );
			GlobalFuncs.onclose( a, "pos" );
			return null;
		}

		// Function from file: POS.dm
		public override dynamic attack_robot( Mob_Living_Silicon_Robot user = null ) {
			
			if ( user is Mob_Living_Silicon_Robot_Mommi ) {
				return this.attack_hand( user );
			}
			return base.attack_robot( user );
		}

		// Function from file: POS.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.overlays = 0;

			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}

			if ( Lang13.Bool( this.logged_in ) ) {
				this.overlays.Add( "pos-working" );
			} else {
				this.overlays.Add( "pos-standby" );
			}
			return null;
		}

		// Function from file: POS.dm
		public string SettingsScreen(  ) {
			string dat = null;

			dat = new Txt( "<form action=\"?src=" ).Ref( this ).str( "\" method=\"get\">\n		<input type=\"hidden\" name=\"src\" value=\"" ).Ref( this ).str( @""" />
		<fieldset>
			<legend>Account Settings</legend>
			<div>
				<b>Payable Account:</b> <input type=""textbox"" name=""payableto"" value=""" ).item( this.linked_account.account_number ).str( @""" />
			</div>
		</fieldset>
		<fieldset>
			<legend>Locality Settings</legend>
			<div>
				<b>Tax Rate:</b> <input type=""textbox"" name=""taxes"" value=""" ).item( 10 ).str( @""" disabled=""disabled"" />% (LOCKED)
			</div>
		</fieldset>
		<input type=""submit"" name=""act"" value=""Save Settings"" />
		</form>" ).ToString();
			return dat;
		}

		// Function from file: POS.dm
		public string FinalizeScreen(  ) {
			return new Txt( "<center><b>Waiting for Credit</b><br /><a href=\"?src=" ).Ref( this ).str( ";act=Reset\">Cancel</a></center>" ).ToString();
		}

		// Function from file: POS.dm
		public string ImportScreen(  ) {
			string dat = null;

			dat = new Txt( "<fieldset>\n		<legend>Import Products as CSV</legend>\n		<form action=\"?src=" ).Ref( this ).str( "\" method=\"get\">\n			<input type=\"hidden\" name=\"src\" value=\"" ).Ref( this ).str( @""" />
			<textarea name=""csv""></textarea>
			<p>Data must be in the form of a CSV, with no headers or quotation marks.</p>
			<p>First column must be product names, second must be prices as an unformatted number (####.##)</p>
			<p>Deviations from this format will result in your import being rejected.</p>
			<input type=""submit"" name=""act"" value=""Add Products"" />
		</form>
		</fieldset>" ).ToString();
			return dat;
		}

		// Function from file: POS.dm
		public string ExportScreen(  ) {
			string dat = null;
			dynamic i = null;
			dynamic LI = null;

			dat = "<fieldset><legend>Export Products as CSV</legend>\n		<textarea>";

			foreach (dynamic _a in Lang13.Enumerate( this.products )) {
				i = _a;
				
				LI = this.products[i];
				dat += "" + LI.name + "," + LI.price + "\n";
			}
			dat += new Txt( "</textarea>\n		<a href=\"?src=" ).Ref( this ).str( ";screen=" ).item( 3 ).str( "\">OK</a>\n		</fieldset>" ).ToString();
			return dat;
		}

		// Function from file: POS.dm
		public string ProductsScreen(  ) {
			string dat = null;
			dynamic i = null;
			LineItem LI = null;

			dat = new Txt( "<fieldset><legend>Product List</legend>\n		<form action=\"?src=" ).Ref( this ).str( "\" method=\"get\">\n		<input type=\"hidden\" name=\"src\" value=\"" ).Ref( this ).str( @""" />
		<table>
			<tr class=""first"">
				<th class=""first"">Item</th>
				<th>Unit Price</th>
				<th># Sold</th>
				<th>...</th>
			</tr>" ).ToString();

			foreach (dynamic _a in Lang13.Enumerate( this.products )) {
				i = _a;
				
				LI = this.products[i];
				dat += new Txt( "<tr class=\"" ).item( ( Lang13.Bool( i % 2 ) ? "even" : "odd" ) ).str( "\">\n			<th><a href=\"?src=" ).Ref( this ).str( ";setpname=" ).item( i ).str( "\">" ).item( LI.name ).str( "</a></th>\n			<td><a href=\"?src=" ).Ref( this ).str( ";setprice=" ).item( i ).str( "\">$" ).item( GlobalFuncs.num2septext( LI.price ) ).str( "</a></td>\n			<td>" ).item( LI.units ).str( "</td>\n			<td><a href=\"?src=" ).Ref( this ).str( ";rmproduct=" ).item( i ).str( "\" style=\"color:red;\">&times;</a></td>\n		</tr>" ).ToString();
			}
			dat += new Txt( @"</table>
		<b>New Product:</b><br />
		<label for=""name"">Name:</label> <input type=""textbox"" name=""name"" value=""""/><br />
		<label for=""name"">Price:</label> $<input type=""textbox"" name=""price"" value=""0.00"" /><br />
		<input type=""submit"" name=""act"" value=""Add Product"" /><br />
		<a href=""?src=" ).Ref( this ).str( ";screen=" ).item( 4 ).str( "\">Import</a> | <a href=\"?src=" ).Ref( this ).str( ";screen=" ).item( 5 ).str( "\">Export</a>\n		</form>\n		</fieldset>" ).ToString();
			return dat;
		}

		// Function from file: POS.dm
		public string OrderScreen(  ) {
			string receipt = null;
			double subtotal = 0;
			int? i = null;
			LineItem LI = null;
			dynamic linetotal = null;
			double taxes = 0;
			string presets = null;
			dynamic pid = null;
			dynamic product = null;

			receipt = "<fieldset>\n		<legend>POS Info</legend>\n			POINT OF SALE #" + this.id + "<br />\n			Paying to: " + this.linked_account.owner_name + "<br />\n			Cashier: " + this.logged_in + "<br />";
			receipt += this.areaMaster.name;
			receipt += "</fieldset>";
			receipt += new Txt( "<fieldset><legend>Order Data</legend>\n		<form action=\"?src=" ).Ref( this ).str( "\" method=\"get\">\n		<input type=\"hidden\" name=\"src\" value=\"" ).Ref( this ).str( @""" />
		<table>
			<tr class=""first"">
				<th class=""first"">Item</th>
				<th>Amount</th>
				<th>Unit Price</th>
				<th>Line Total</th>
				<th>...</th>
			</tr>" ).ToString();
			subtotal = 0;

			if ( this.line_items.len > 0 ) {
				i = null;
				i = 1;

				while (( i ??0) <= this.line_items.len) {
					LI = this.line_items[i];
					linetotal = LI.units * LI.price;
					receipt += new Txt( "<tr class=\"" ).item( ( ( i ??0) % 2 != 0 ? "even" : "odd" ) ).str( "\">\n				<th>" ).item( LI.name ).str( "</th>\n				<td><a href=\"?src=" ).Ref( this ).str( ";setunits=" ).item( i ).str( "\">" ).item( LI.units ).str( "</a></td>\n				<td>$" ).item( GlobalFuncs.num2septext( LI.price ) ).str( "</td>\n				<td>$" ).item( GlobalFuncs.num2septext( linetotal ) ).str( "</td>\n				<td><a href=\"?src=" ).Ref( this ).str( ";removefromorder=" ).item( i ).str( "\" style=\"color:red;\">&times;</a></td>\n			</tr>" ).ToString();
					subtotal += Convert.ToDouble( linetotal );
					i++;
				}
			}
			taxes = subtotal * 0.1;
			presets = "<i>(No presets available)</i>";

			if ( this.products.len > 0 ) {
				presets = "<select name=\"preset\">\"";

				foreach (dynamic _a in Lang13.Enumerate( this.products )) {
					pid = _a;
					
					product = this.products[pid];
					presets += "<option value=\"" + pid + "\">" + product.name + "</option>";
				}
				presets += "</select>";
			}
			receipt += "\n		<tr>\n			<td class=\"first\">" + presets + @"</td>
			<td><input type=""textbox"" name=""units"" value=""1.0"" /> units</td>
			<td colspan=""2""><input type=""submit"" name=""act"" value=""Add to Order"" /></td>
		</tr>
		<tr class=""calculated"">
			<th colspan=""3"">SUBTOTAL</th><td>$" + GlobalFuncs.num2septext( subtotal ) + "</td>\n		</tr>\n		<tr>\n			<th colspan=\"3\">TAXES</th><td>$" + GlobalFuncs.num2septext( taxes ) + "</td>\n		</tr>";
			receipt += "\n		<tr class=\"calculated total\">\n			<th colspan=\"3\">TOTAL</th><td>$" + GlobalFuncs.num2septext( taxes + subtotal ) + "</th>\n		</tr>";
			receipt += @"</table>
		<input type=""submit"" name=""act"" value=""Finalize Sale"" />
		<input type=""submit"" name=""act"" value=""Reset"" />
		</form>
	</fieldset>";
			return receipt;
		}

		// Function from file: POS.dm
		public string LoginScreen(  ) {
			return "<center><b>Please swipe ID to log in.</b></center>";
		}

		// Function from file: POS.dm
		public void PrintReceipt( dynamic order_id = null ) {
			string receipt = null;
			double subtotal = 0;
			int? i = null;
			LineItem LI = null;
			dynamic linetotal = null;
			double taxes = 0;
			Obj_Item_Weapon_Paper P = null;

			receipt = "" + GlobalVars.RECEIPT_HEADER + "<div>POINT OF SALE #" + this.id + "<br />\n			Paying to: " + this.linked_account.owner_name + "<br />\n			Cashier: " + this.logged_in + "<br />";
			receipt += this.areaMaster.name;
			receipt += "</div>";
			receipt += "<br />\n		<div>" + GlobalFuncs.worldtime2text() + ", " + GlobalVars.current_date_string + @"</div>
		<table>
			<tr class=""first"">
				<th class=""first"">Item</th>
				<th>Amount</th>
				<th>Unit Price</th>
				<th>Line Total</th>
			</tr>";
			subtotal = 0;
			i = null;
			i = 1;

			while (( i ??0) <= this.line_items.len) {
				LI = this.line_items[i];
				linetotal = LI.units * LI.price;
				receipt += "<tr class=\"" + ( ( i ??0) % 2 != 0 ? "even" : "odd" ) + "\"><th>" + LI.name + "</th><td>" + LI.units + "</td><td>$" + GlobalFuncs.num2septext( LI.price ) + "</td><td>$" + GlobalFuncs.num2septext( linetotal ) + "</td></tr>";
				subtotal += Convert.ToDouble( linetotal );
				i++;
			}
			taxes = subtotal * 0.1;
			receipt += "\n		<tr class=\"calculated\">\n			<th colspan=\"3\">SUBTOTAL</th><td>$" + GlobalFuncs.num2septext( subtotal ) + "</td>\n		</tr>\n		<tr>\n			<th colspan=\"3\">TAXES</th><td>$" + GlobalFuncs.num2septext( taxes ) + "</td>\n		</tr>";
			receipt += "\n		<tr class=\"calculated total\">\n			<th colspan=\"3\">TOTAL</th><td>$" + GlobalFuncs.num2septext( taxes + subtotal ) + "</th>\n		</tr>";
			receipt += "</table></body></html>";
			P = new Obj_Item_Weapon_Paper( this.loc );
			P.name = "Receipt #" + this.id + "-" + ++this.sales;
			P.info = receipt;
			P = new Obj_Item_Weapon_Paper( this.loc );
			P.name = "Receipt #" + this.id + "-" + this.sales + " (Cashier Copy)";
			P.info = receipt;
			return;
		}

		// Function from file: POS.dm
		public void NewOrder(  ) {
			this.line_items.len = 0;
			return;
		}

		// Function from file: POS.dm
		public void RemoveFromOrder( double? order_id = null ) {
			this.line_items.Cut( ((int?)( order_id )), ((int)( ( order_id ??0) + 1 )) );
			return;
		}

		// Function from file: POS.dm
		public bool AddToOrder( dynamic name = null, double? units = null ) {
			dynamic LI = null;
			LineItem LIC = null;

			Interface13.Stat( null, this.products.Contains( name ) );

			if ( !false ) {
				return false;
			}
			LI = this.products[name];
			LIC = new LineItem();
			LIC.name = LI.name;
			LIC.price = Lang13.DoubleNullable( LI.price );
			LIC.units = units;
			this.line_items.Add( LIC );
			return false;
		}

		// Function from file: POS.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			base.initialize( suppress_icon_check );

			if ( Lang13.Bool( this.department ) ) {
				this.linked_account = GlobalVars.department_accounts[this.department];
			} else {
				this.linked_account = GlobalVars.station_account;
			}
			return false;
		}

		// Function from file: trash_machinery.dm
		public override dynamic cultify(  ) {
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}