// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ObjectiveItem : Game_Data {

		public string name = "A silly bike horn! Honk!";
		public Type targetitem = typeof(Obj_Item_Weapon_Bikehorn);
		public int difficulty = 9001;
		public ByTable excludefromjob = new ByTable();
		public ByTable altitems = new ByTable();
		public ByTable special_equipment = new ByTable();

		// Function from file: objective_items.dm
		public virtual bool check_special_completion( Obj T = null ) {
			return true;
		}

	}

}