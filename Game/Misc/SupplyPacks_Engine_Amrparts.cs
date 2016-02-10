// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Engine_Amrparts : SupplyPacks_Engine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "AMR Parts crate";
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer), 
				typeof(Obj_Item_Device_AmShieldingContainer)
			 });
			this.cost = 30;
			this.containertype = typeof(Obj_Structure_Closet_Crate_Secure_Engisec);
			this.containername = "packaged antimatter reactor crate";
			this.access = 10;
		}

	}

}