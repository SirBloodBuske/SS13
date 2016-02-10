// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_Rnd : Wires {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.holder_type = typeof(Obj_Machinery_RND);
			this.wire_count = 5;
		}

		public Wires_Rnd ( Obj holder = null ) : base( holder ) {
			
		}

		// Function from file: rnd_wires.dm
		public override void UpdateCut( double? index = null, bool mended = false ) {
			Obj rnd = null;

			rnd = this.holder;

			switch ((int?)( index )) {
				case 1:
					((dynamic)rnd).disabled = !mended;
					break;
				case 2:
					((dynamic)rnd).shocked = ( mended ? 0 : -1 );
					break;
				case 4:
					((dynamic)rnd).hacked = 0;
					((dynamic)rnd).update_hacked();
					break;
			}
			return;
		}

		// Function from file: rnd_wires.dm
		public override void UpdatePulsed( double? index = null ) {
			Obj rnd = null;

			rnd = this.holder;

			switch ((int?)( index )) {
				case 1:
					((dynamic)rnd).disabled = !Lang13.Bool( ((dynamic)rnd).disabled );
					break;
				case 2:
					((dynamic)rnd).shocked += 30;
					break;
				case 4:
					((dynamic)rnd).hacked = !Lang13.Bool( ((dynamic)rnd).hacked );
					((dynamic)rnd).update_hacked();
					break;
			}
			return;
		}

		// Function from file: rnd_wires.dm
		public override string GetInteractWindow(  ) {
			string _default = null;

			Obj rnd = null;

			rnd = this.holder;
			_default += base.GetInteractWindow();
			_default += "The red light is " + ( Lang13.Bool( ((dynamic)rnd).disabled ) ? "off" : "on" ) + ".<BR>";
			_default += "The green light is " + ( Lang13.Bool( ((dynamic)rnd).shocked ) ? "off" : "on" ) + ".<BR>";
			_default += "The blue light is " + ( Lang13.Bool( ((dynamic)rnd).hacked ) ? "off" : "on" ) + ".<BR>";
			return _default;
		}

		// Function from file: rnd_wires.dm
		public override bool CanUse( dynamic L = null ) {
			Obj rnd = null;

			rnd = this.holder;

			if ( Lang13.Bool( ((dynamic)rnd).panel_open ) ) {
				return true;
			}
			return false;
		}

	}

}