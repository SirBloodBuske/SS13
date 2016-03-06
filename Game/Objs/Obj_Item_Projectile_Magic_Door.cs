// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Magic_Door : Obj_Item_Projectile_Magic {

		public ByTable door_types = new ByTable(new object [] { 
											typeof(Obj_Structure_MineralDoor_Wood), 
											typeof(Obj_Structure_MineralDoor_Iron), 
											typeof(Obj_Structure_MineralDoor_Silver), 
											typeof(Obj_Structure_MineralDoor_Gold), 
											typeof(Obj_Structure_MineralDoor_Uranium), 
											typeof(Obj_Structure_MineralDoor_Sandstone), 
											typeof(Obj_Structure_MineralDoor_Transparent_Plasma), 
											typeof(Obj_Structure_MineralDoor_Transparent_Diamond)
										 });

		public Obj_Item_Projectile_Magic_Door ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: magic.dm
		public void CreateDoor( Ent_Static T = null ) {
			dynamic door_type = null;

			door_type = Rand13.PickFromTable( this.door_types );
			Lang13.Call( door_type, T );
			((dynamic)T).ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
			return;
		}

		// Function from file: magic.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			dynamic _default = null;

			Ent_Static T = null;

			_default = base.on_hit( target, blocked, (object)(hit_zone) );
			T = target.loc;

			if ( target is Tile && target.density ) {
				this.CreateDoor( target );
			} else if ( T is Tile && T.density ) {
				this.CreateDoor( T );
			}
			return _default;
		}

	}

}