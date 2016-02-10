// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Rig_Syndi : Obj_Item_Clothing_Head_Helmet_Space_Rig {

		public Obj_Machinery_Camera camera = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "syndie_helm";
			this.species_fit = new ByTable(new object [] { "Vox" });
			this._color = "syndi";
			this.armor = new ByTable().Set( "melee", 60 ).Set( "bullet", 50 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 35 ).Set( "bio", 100 ).Set( "rad", 60 );
			this.action_button_name = "Toggle Helmet Camera";
			this.siemens_coefficient = 0.6;
			this.pressure_resistance = 4053;
			this.icon_state = "rig0-syndi";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Rig_Syndi ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: rig.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( Map13.GetDistance( user, this ) <= 1 ) {
				GlobalFuncs.to_chat( user, "<span class='info'>This helmet has a built-in camera. It's " + ( this.camera != null ? "" : "in" ) + "active.</span>" );
			}
			return null;
		}

		// Function from file: rig.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.camera != null ) {
				base.attack_self( (object)(user), (object)(flag), emp );
			} else {
				this.camera = new Obj_Machinery_Camera( this );
				this.camera.network = new ByTable(new object [] { "NUKE" });
				GlobalVars.cameranet.removeCamera( this.camera );
				this.camera.c_tag = user.name;
				GlobalFuncs.to_chat( user, "<span class='notice'>User scanned as " + this.camera.c_tag + ". Camera activated.</span>" );
			}
			return null;
		}

	}

}