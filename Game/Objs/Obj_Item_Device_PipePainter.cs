// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_PipePainter : Obj_Item_Device {

		public ByTable modes = new ByTable().Set( "grey", "#ffffff" ).Set( "red", "#ff0000" ).Set( "blue", "#0000ff" ).Set( "cyan", "#00fff9" ).Set( "green", "#1eff00" ).Set( "yellow", "#ffc600" ).Set( "purple", "#822bff" );
		public dynamic mode = "grey";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "flight";
			this.materials = new ByTable().Set( "$metal", 5000 ).Set( "$glass", 2000 );
			this.icon = "icons/obj/bureaucracy.dmi";
			this.icon_state = "labeler1";
		}

		public Obj_Item_Device_PipePainter ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: pipe_painter.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			Task13.User.WriteMsg( "It is set to " + this.mode + "." );
			return 0;
		}

		// Function from file: pipe_painter.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.mode = Interface13.Input( "Which colour do you want to use?", "Pipe painter", null, null, this.modes, InputType.Any );
			return null;
		}

		// Function from file: pipe_painter.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic P = null;

			
			if ( proximity_flag != true ) {
				return false;
			}

			if ( !( target is Obj_Machinery_Atmospherics_Pipe_Simple ) && !( target is Obj_Machinery_Atmospherics_Pipe_Manifold ) && !( target is Obj_Machinery_Atmospherics_Pipe_Manifold4w ) ) {
				return false;
			}
			P = target;
			P.color = this.modes[this.mode];
			P.pipe_color = this.modes[this.mode];
			P.stored.color = this.modes[this.mode];
			((Ent_Static)user).visible_message( new Txt( "<span class='notice'>" ).item( user ).str( " paints " ).the( P ).item().str( " " ).item( this.mode ).str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You paint " ).the( P ).item().str( " " ).item( this.mode ).str( ".</span>" ).ToString() );
			((Obj_Machinery_Atmospherics_Pipe)P).update_node_icon();
			return false;
		}

	}

}