// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Tree_Festivus : Mob_Living_SimpleAnimal_Hostile_Tree {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "festivus_pole";
			this.icon_dead = "festivus_pole";
			this.icon_gib = "festivus_pole";
			this.loot = new ByTable(new object [] { typeof(Obj_Item_Stack_Rods) });
			this.speak_emote = new ByTable(new object [] { "polls" });
			this.icon_state = "festivus_pole";
		}

		public Mob_Living_SimpleAnimal_Hostile_Tree_Festivus ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}