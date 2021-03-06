// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Implant : Obj_Item_Weapon {

		public bool activated = true;
		public dynamic implanted = null;
		public dynamic imp_in = null;
		public bool allow_multiple = false;
		public int uses = -1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.action_button_is_hands_free = true;
			this.origin_tech = "materials=2;biotech=3;programming=2";
			this.item_color = "b";
			this.icon = "icons/obj/implants.dmi";
			this.icon_state = "generic";
		}

		public Obj_Item_Weapon_Implant ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: implant.dm
		public override bool dropped( dynamic user = null ) {
			bool _default = false;

			_default = true;
			GlobalFuncs.qdel( this );
			return _default;
		}

		// Function from file: implant.dm
		public override dynamic Destroy(  ) {
			
			if ( Lang13.Bool( this.imp_in ) ) {
				this.removed( this.imp_in );
			}
			return base.Destroy();
		}

		// Function from file: implant.dm
		public override void ui_action_click(  ) {
			this.activate( "action_button" );
			return;
		}

		// Function from file: implant.dm
		public virtual string get_data(  ) {
			return "No information available";
		}

		// Function from file: implant.dm
		public virtual bool removed( dynamic target = null, bool? silent = null ) {
			dynamic H = null;

			this.loc = null;
			this.imp_in = null;
			this.implanted = 0;

			if ( target is Mob_Living_Carbon_Human ) {
				H = target;
				((Mob_Living_Carbon_Human)H).sec_hud_set_implants();
			}
			return true;
		}

		// Function from file: implant.dm
		public virtual int implant( dynamic source = null, dynamic user = null ) {
			dynamic imp_e = null;
			dynamic H = null;

			imp_e = Lang13.FindIn( this.type, source );

			if ( !this.allow_multiple && Lang13.Bool( imp_e ) && imp_e != this ) {
				
				if ( Convert.ToDouble( imp_e.uses ) < Convert.ToDouble( Lang13.Initial( imp_e, "uses" ) * 2 ) ) {
					
					if ( this.uses == -1 ) {
						imp_e.uses = -1;
					} else {
						imp_e.uses = Num13.MinInt( Convert.ToInt32( imp_e.uses + this.uses ), Convert.ToInt32( Lang13.Initial( imp_e, "uses" ) * 2 ) );
					}
					GlobalFuncs.qdel( this );
					return 1;
				} else {
					return 0;
				}
			}

			if ( this.activated ) {
				this.action_button_name = "Activate " + this.name;
			}
			this.loc = source;
			this.imp_in = source;
			this.implanted = 1;

			if ( source is Mob_Living_Carbon_Human ) {
				H = source;
				((Mob_Living_Carbon_Human)H).sec_hud_set_implants();
			}

			if ( Lang13.Bool( user ) ) {
				GlobalFuncs.add_logs( user, source, "implanted", "" + this.name );
			}
			return 1;
		}

		// Function from file: implant.dm
		public virtual bool activate( dynamic cause = null ) {
			return false;
		}

		// Function from file: implant.dm
		public virtual void trigger( string emote = null, Mob_Living_Carbon_Human source = null ) {
			return;
		}

	}

}