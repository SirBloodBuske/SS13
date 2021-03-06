// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_Flashbang : Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher {

		public int det_time = 20;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile = typeof(Obj_Item_Weapon_Grenade_Flashbang);
			this.fire_sound = "sound/weapons/grenadelaunch.ogg";
			this.projectiles = 6;
			this.missile_speed = 1.5;
			this.projectile_energy_cost = 800;
			this.equip_cooldown = 60;
			this.icon_state = "mecha_grenadelnchr";
		}

		public Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_Flashbang ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: weapons.dm
		public override void proj_init( dynamic O = null ) {
			dynamic T = null;

			T = GlobalFuncs.get_turf( this );
			GlobalFuncs.message_admins( new Txt().item( GlobalFuncs.key_name( this.chassis.occupant, ((dynamic)this.chassis.occupant).client ) ).str( "(<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( this.chassis.occupant ).str( "'>?</A>) fired a " ).item( this ).str( " in (" ).item( T.x ).str( "," ).item( T.y ).str( "," ).item( T.z ).str( " - <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( T.x ).str( ";Y=" ).item( T.y ).str( ";Z=" ).item( T.z ).str( "'>JMP</a>)" ).ToString() );
			GlobalFuncs.log_game( "" + GlobalFuncs.key_name( this.chassis.occupant ) + " fired a " + this + " (" + T.x + "," + T.y + "," + T.z + ")" );
			Task13.Schedule( this.det_time, (Task13.Closure)(() => {
				
				if ( Lang13.Bool( O ) ) {
					((Obj_Item_Weapon_Grenade)O).prime();
				}
				return;
			}));
			return;
		}

	}

}