// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Animal : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 45 });
		}

		// Function from file: medical.dm
		public Obj_Structure_Closet_SecureCloset_Animal ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Sleep( 2 );
			new Obj_Item_Device_Assembly_Signaler( this );
			new Obj_Item_Device_Radio_Electropack(  );
			new Obj_Item_Device_Radio_Electropack(  );
			new Obj_Item_Device_Radio_Electropack(  );
			return;
		}

	}

}