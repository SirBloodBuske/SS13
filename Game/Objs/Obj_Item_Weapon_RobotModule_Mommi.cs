// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_RobotModule_Mommi : Obj_Item_Weapon_RobotModule {

		// Function from file: mommi_modules.dm
		public Obj_Item_Weapon_RobotModule_Mommi ( dynamic R = null ) : base( (object)(R) ) {
			Obj_Item_Stack_CableCoil W = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.languages = new ByTable()
				.Set( "Galactic Common", 0 )
				.Set( "Tradeband", 0 )
				.Set( "Vox-pidgin", 0 )
				.Set( "Rootspeak", 0 )
				.Set( "Grey", 0 )
				.Set( "Clatter", 0 )
				.Set( "Sinta'unathi", 0 )
				.Set( "Siik'tajr", 0 )
				.Set( "Skrellian", 0 )
				.Set( "Gutter", 0 )
				.Set( "Monkey", 0 )
				.Set( "Mouse", 0 )
				.Set( "Sol Common", 0 )
			;
			this.add_languages( R );
			this.emag = new Obj_Item_Borg_Stun( this );
			this.modules.Add( new Obj_Item_Weapon_Weldingtool_Largetank( this ) );
			this.modules.Add( new Obj_Item_Weapon_Screwdriver( this ) );
			this.modules.Add( new Obj_Item_Weapon_Wrench( this ) );
			this.modules.Add( new Obj_Item_Weapon_Crowbar( this ) );
			this.modules.Add( new Obj_Item_Weapon_Wirecutters( this ) );
			this.modules.Add( new Obj_Item_Device_Multitool( this ) );
			this.modules.Add( new Obj_Item_Device_TScanner( this ) );
			this.modules.Add( new Obj_Item_Device_Analyzer( this ) );
			this.modules.Add( new Obj_Item_Weapon_Extinguisher( this ) );
			this.modules.Add( new Obj_Item_Weapon_Extinguisher_Foam( this ) );
			this.modules.Add( new Obj_Item_Device_Rcd_Rpd( this ) );
			this.modules.Add( new Obj_Item_Device_Rcd_TilePainter( this ) );
			this.modules.Add( new Obj_Item_Blueprints_Mommiprints( this ) );
			this.modules.Add( new Obj_Item_Device_MaterialSynth_Robot_Mommi( this ) );
			this.sensor_augs = new ByTable(new object [] { "Mesons", "Disable" });
			W = new Obj_Item_Stack_CableCoil( this );
			W.amount = 50;
			W.max_amount = 50;
			this.modules.Add( W );
			return;
		}

		// Function from file: mommi_modules.dm
		public override void respawn_consumable( Ent_Static R = null ) {
			ByTable what = null;
			dynamic T = null;
			dynamic O = null;

			what = new ByTable(new object [] { typeof(Obj_Item_Stack_CableCoil) });

			foreach (dynamic _a in Lang13.Enumerate( what )) {
				T = _a;
				

				if ( !Lang13.Bool( Lang13.FindIn( T, this.modules ) ) ) {
					this.modules.Remove( null );
					O = Lang13.Call( T, this );

					if ( O is Obj_Item_Stack_CableCoil ) {
						O.max_amount = 50;
					}
					this.modules.Add( O );
					O.amount = 1;
				}
			}
			return;
		}

	}

}