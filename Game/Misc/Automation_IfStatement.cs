// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Automation_IfStatement : Automation {

		public dynamic condition = null;
		public ByTable valid_conditions = new ByTable(new object [] { 1 });
		public ByTable children_then = new ByTable();
		public ByTable children_else = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "IF statement";
			this.valid_child_returntypes = new ByTable(new object [] { 0 });
		}

		public Automation_IfStatement ( Obj_Machinery_Computer_GeneralAirControl_AtmosAutomation aa = null ) : base( aa ) {
			
		}

		// Function from file: statements.dm
		public override bool process(  ) {
			Automation stmt = null;
			Automation stmt2 = null;

			
			if ( Lang13.Bool( this.condition ) ) {
				
				if ( Lang13.Bool( this.condition.Evaluate() ) ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.children_then, typeof(Automation) )) {
						stmt = _a;
						
						stmt.process();
					}
				} else {
					
					foreach (dynamic _b in Lang13.Enumerate( this.children_else, typeof(Automation) )) {
						stmt2 = _b;
						
						stmt2.process();
					}
				}
			}
			return false;
		}

		// Function from file: statements.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic _default = null;

			bool new_child = false;
			dynamic confirm = null;
			Automation A = null;
			Automation A2 = null;
			dynamic A3 = null;
			dynamic confirm2 = null;
			Automation A4 = null;
			Automation A5 = null;
			dynamic A6 = null;
			bool new_condition = false;

			_default = base.Topic( href, href_list - new ByTable(new object [] { "add", "remove", "reset" }), (object)(hclient) );

			if ( Lang13.Bool( href_list["add"] ) ) {
				new_child = this.selectValidChildFor( Task13.User );

				if ( !new_child ) {
					return 1;
				}

				dynamic _a = href_list["add"]; // Was a switch-case, sorry for the mess.
				if ( _a=="then" ) {
					this.children_then.Add( new_child );
				} else if ( _a=="else" ) {
					this.children_else.Add( new_child );
				} else {
					Game13.log.WriteMsg( "## WARNING: " + ( "Unknown add value given to " + this.type + "/Topic():" + 343 + ": " + href ) );
					return 1;
				}
				this.parent.updateUsrDialog();
				return 1;
			}

			if ( Lang13.Bool( href_list["remove"] ) ) {
				
				if ( href_list["remove"] == "*" ) {
					confirm = Interface13.Input( "Are you sure you want to remove ALL automations?", "Automations", "No", null, new ByTable(new object [] { "Yes", "No" }), InputType.Any );

					if ( confirm == "No" ) {
						return 0;
					}

					foreach (dynamic _b in Lang13.Enumerate( this.children_then, typeof(Automation) )) {
						A = _b;
						
						A.OnRemove();
						this.children_then.Remove( A );
					}

					foreach (dynamic _c in Lang13.Enumerate( this.children_else, typeof(Automation) )) {
						A2 = _c;
						
						A2.OnRemove();
						this.children_else.Remove( A2 );
					}
				} else {
					A3 = Lang13.FindObj( href_list["remove"] );

					if ( !Lang13.Bool( A3 ) ) {
						return 1;
					}
					confirm2 = Interface13.Input( "Are you sure you want to remove this automation?", "Automations", "No", null, new ByTable(new object [] { "Yes", "No" }), InputType.Any );

					if ( confirm2 == "No" ) {
						return 0;
					}
					((Automation)A3).OnRemove();

					dynamic _d = href_list["context"]; // Was a switch-case, sorry for the mess.
					if ( _d=="then" ) {
						this.children_then.Remove( A3 );
					} else if ( _d=="else" ) {
						this.children_else.Remove( A3 );
					}
				}
				this.parent.updateUsrDialog();
				return 1;
			}

			if ( Lang13.Bool( href_list["reset"] ) ) {
				
				if ( href_list["reset"] == "*" ) {
					
					foreach (dynamic _e in Lang13.Enumerate( this.children_then, typeof(Automation) )) {
						A4 = _e;
						
						A4.OnReset();
					}

					foreach (dynamic _f in Lang13.Enumerate( this.children_else, typeof(Automation) )) {
						A5 = _f;
						
						A5.OnReset();
					}
				} else {
					A6 = Lang13.FindObj( href_list["reset"] );

					if ( !Lang13.Bool( A6 ) ) {
						return 1;
					}
					((Automation)A6).OnReset();
				}
				this.parent.updateUsrDialog();
				return 1;
			}

			if ( Lang13.Bool( href_list["set_condition"] ) ) {
				new_condition = this.selectValidChildFor( Task13.User, this.valid_conditions );
				Game13.log.WriteMsg( "## TESTING: " + ( "Selected condition: " + new_condition ) );

				if ( !new_condition ) {
					return 1;
				}
				this.condition = new_condition;
				this.parent.updateUsrDialog();
				return 1;
			}
			return _default;
		}

		// Function from file: statements.dm
		public override string GetText(  ) {
			string _default = null;

			Automation stmt = null;
			Automation stmt2 = null;

			_default = new Txt( "<b>IF</b> (<a href=\"?src=" ).Ref( this ).str( ";set_condition=1\">SET</a>):<blockquote>" ).ToString();

			if ( Lang13.Bool( this.condition ) ) {
				_default += ((Automation)this.condition).GetText();
			} else {
				_default += "<i>Not set</i>";
			}
			_default += "</blockquote>";
			_default += new Txt( "<b>THEN:</b> (<a href=\"?src=" ).Ref( this ).str( ";add=then\">Add</a>)" ).ToString();

			if ( this.children_then.len != 0 ) {
				_default += "<ul>";

				foreach (dynamic _a in Lang13.Enumerate( this.children_then, typeof(Automation) )) {
					stmt = _a;
					
					_default += new Txt( "<li>\n						[<a href=\"?src=" ).Ref( this ).str( ";reset=" ).Ref( stmt ).str( ";context=then\">Reset</a> |\n						<a href=\"?src=" ).Ref( this ).str( ";remove=" ).Ref( stmt ).str( ";context=then\">&times;</a>]\n						" ).item( stmt.GetText() ).str( "\n					</li>" ).ToString();
				}
				_default += "</ul>";
			} else {
				_default += "<blockquote><i>(No statements to run)</i></blockquote>";
			}
			_default += new Txt( "<b>ELSE:</b> (<a href=\"?src=" ).Ref( this ).str( ";add=else\">Add</a>)" ).ToString();

			if ( this.children_then.len != 0 ) {
				_default += "<ul>";

				foreach (dynamic _b in Lang13.Enumerate( this.children_else, typeof(Automation) )) {
					stmt2 = _b;
					
					_default += new Txt( "<li>\n						[<a href=\"?src=" ).Ref( this ).str( ";reset=" ).Ref( stmt2 ).str( ";context=else\">Reset</a> |\n						<a href=\"?src=" ).Ref( this ).str( ";remove=" ).Ref( stmt2 ).str( ";context=else\">&times;</a>]\n						" ).item( stmt2.GetText() ).str( "\n					</li>" ).ToString();
				}
				_default += "</ul>";
			} else {
				_default += "<blockquote><i>(No statements to run)</i></blockquote>";
			}
			return _default;
		}

		// Function from file: statements.dm
		public override void Import( ByTable json = null ) {
			base.Import( json );
			Interface13.Stat( null, json.Contains( "then" ) );

			if ( false ) {
				this.children_then = this.unpackChildren( json["then"] );
			}
			Interface13.Stat( null, json.Contains( "else" ) );

			if ( false ) {
				this.children_else = this.unpackChildren( json["else"] );
			}
			Interface13.Stat( null, json.Contains( "condition" ) );

			if ( false ) {
				this.condition = this.unpackChild( json["condition"] );
			}
			return;
		}

		// Function from file: statements.dm
		public override ByTable Export(  ) {
			ByTable R = null;

			R = base.Export();

			if ( this.children_then.len > 0 ) {
				R["then"] = this.packChildren( this.children_then );
			}

			if ( this.children_else.len > 0 ) {
				R["else"] = this.packChildren( this.children_else );
			}

			if ( Lang13.Bool( this.condition ) ) {
				R["condition"] = ((Automation)this.condition).Export();
			}
			return R;
		}

	}

}