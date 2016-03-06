// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_EmbeddedController : Obj_Machinery {

		public Computer_File_EmbeddedProgram program = null;
		public bool on = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
		}

		public Obj_Machinery_EmbeddedController ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: embedded_controller_base.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.program != null ) {
				this.program.process();
			}
			this.update_icon();
			this.updateDialog();
			return null;
		}

		// Function from file: embedded_controller_base.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return 0;
			}

			if ( this.program != null ) {
				this.program.receive_user_command( href_list["command"] );
				Task13.Schedule( 5, (Task13.Closure)(() => {
					this.program.process();
					return;
				}));
			}
			Task13.User.set_machine( this );
			Task13.Schedule( 5, (Task13.Closure)(() => {
				this.updateDialog();
				return;
			}));
			return null;
		}

		// Function from file: embedded_controller_base.dm
		public override bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			
			if ( !( signal != null ) || signal.encryption != 0 ) {
				return false;
			}

			if ( this.program != null ) {
				this.program.receive_signal( signal, receive_method, receive_param );
			}
			return false;
		}

		// Function from file: embedded_controller_base.dm
		public virtual bool post_signal( Signal signal = null, dynamic comm_line = null ) {
			return false;
		}

		// Function from file: embedded_controller_base.dm
		public virtual string return_text(  ) {
			return null;
		}

		// Function from file: embedded_controller_base.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			return false;
		}

		// Function from file: embedded_controller_base.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.interact( a );
			return null;
		}

		// Function from file: embedded_controller_base.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			Browser popup = null;

			((Mob)user).set_machine( this );
			popup = new Browser( user, "computer", this.name );
			popup.set_title_image( ((Mob)user).browse_rsc_icon( this.icon, this.icon_state ) );
			popup.set_content( this.return_text() );
			popup.open();
			return null;
		}

	}

}