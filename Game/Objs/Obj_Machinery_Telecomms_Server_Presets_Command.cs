// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Server_Presets_Command : Obj_Machinery_Telecomms_Server_Presets {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "Command Server";
			this.freq_listening = new ByTable(new object [] { 1353 });
			this.autolinkers = new ByTable(new object [] { "command" });
		}

		public Obj_Machinery_Telecomms_Server_Presets_Command ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}