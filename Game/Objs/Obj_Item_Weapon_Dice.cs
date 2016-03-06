// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Dice : Obj_Item_Weapon {

		public int sides = 6;
		public int result = 0;
		public ByTable special_faces = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.icon = "icons/obj/dice.dmi";
			this.icon_state = "d6";
		}

		// Function from file: dice.dm
		public Obj_Item_Weapon_Dice ( dynamic loc = null ) : base( (object)(loc) ) {
			this.result = Rand13.Int( 1, this.sides );
			this.update_icon();
			return;
		}

		// Function from file: tgstation.dme
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.overlays.Cut();
			this.overlays.Add( "" + this.icon_state + this.result );
			return false;
		}

		// Function from file: dice.dm
		public virtual void diceroll( dynamic user = null ) {
			string comment = null;

			this.result = Rand13.Int( 1, this.sides );
			comment = "";

			if ( this.sides == 20 && this.result == 20 ) {
				comment = "Nat 20!";
			} else if ( this.sides == 20 && this.result == 1 ) {
				comment = "Ouch, bad luck.";
			}
			this.update_icon();

			if ( Lang13.Initial( this, "icon_state" ) == "d00" ) {
				this.result = ( this.result - 1 ) * 10;
			}

			if ( this.special_faces.len == this.sides ) {
				this.result = Convert.ToInt32( this.special_faces[this.result] );
			}

			if ( user != null ) {
				((Ent_Static)user).visible_message( "" + user + " has thrown " + this + ". It lands on " + this.result + ". " + comment, "<span class='notice'>You throw " + this + ". It lands on " + this.result + ". " + comment + "</span>", "<span class='italics'>You hear " + this + " rolling.</span>" );
			} else if ( !this.throwing ) {
				this.visible_message( "<span class='notice'>" + this + " rolls to a stop, landing on " + this.result + ". " + comment + "</span>" );
			}
			return;
		}

		// Function from file: dice.dm
		public override bool throw_at( dynamic target = null, double? range = null, dynamic speed = null, dynamic thrower = null, bool? spin = null, bool? diagonals_first = null ) {
			spin = spin ?? true;

			
			if ( !base.throw_at( (object)(target), range, (object)(speed), (object)(thrower), spin, diagonals_first ) ) {
				return false;
			}
			this.diceroll( thrower );
			return false;
		}

		// Function from file: dice.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.diceroll( user );
			return null;
		}

	}

}