// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Tool_Rcd : Obj_Item_MechaParts_MechaEquipment_Tool {

		public double? mode = 0;
		public bool disabled = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=4;bluespace=3;magnets=4;powerstorage=4";
			this.equip_cooldown = 10;
			this.energy_drain = 250;
			this.range = 3;
			this.icon_state = "mecha_rcd";
		}

		public Obj_Item_MechaParts_MechaEquipment_Tool_Rcd ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tools.dm
		public override string get_equip_info(  ) {
			return new Txt().item( base.get_equip_info() ).str( " [<a href='?src=" ).Ref( this ).str( ";mode=0'>D</a>|<a href='?src=" ).Ref( this ).str( ";mode=1'>C</a>|<a href='?src=" ).Ref( this ).str( ";mode=2'>A</a>]" ).ToString();
		}

		// Function from file: tools.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( href_list["mode"] ) ) {
				this.mode = String13.ParseNumber( href_list["mode"] );

				switch ((double?)( this.mode )) {
					case 0:
						this.occupant_message( "Switched RCD to Deconstruct." );
						break;
					case 1:
						this.occupant_message( "Switched RCD to Construct." );
						break;
					case 2:
						this.occupant_message( "Switched RCD to Construct Airlock." );
						break;
				}
			}
			return null;
		}

		// Function from file: tools.dm
		public override bool action( dynamic target = null ) {
			Obj_Machinery_Door_Airlock T = null;

			
			if ( target is Zone_Shuttle || target is Tile_Space_Transit ) {
				this.disabled = true;
			} else {
				this.disabled = false;
			}

			if ( !( target is Tile ) && !( target is Obj_Machinery_Door_Airlock ) ) {
				target = GlobalFuncs.get_turf( target );
			}

			if ( !this.action_checks( target ) || this.disabled || Map13.GetDistance( this.chassis, target ) > 3 ) {
				return false;
			}
			GlobalFuncs.playsound( this.chassis, "sound/machines/click.ogg", 50, 1 );

			switch ((double?)( this.mode )) {
				case 0:
					
					if ( target is Tile_Simulated_Wall ) {
						this.occupant_message( "Deconstructing " + target + "..." );
						this.set_ready_state( false );

						if ( this.do_after_cooldown( target ) ) {
							
							if ( this.disabled ) {
								return false;
							}
							this.chassis.spark_system.start();
							((Tile)target).ChangeTurf( typeof(Tile_Simulated_Floor_Plating) );
							GlobalFuncs.playsound( target, "sound/items/Deconstruct.ogg", 50, 1 );
							this.chassis.use_power( this.energy_drain );
						}
					} else if ( target is Tile_Simulated_Floor ) {
						this.occupant_message( "Deconstructing " + target + "..." );
						this.set_ready_state( false );

						if ( this.do_after_cooldown( target ) ) {
							
							if ( this.disabled ) {
								return false;
							}
							this.chassis.spark_system.start();
							((Tile)target).ChangeTurf( GlobalFuncs.get_base_turf( target.z ) );
							GlobalFuncs.playsound( target, "sound/items/Deconstruct.ogg", 50, 1 );
							this.chassis.use_power( this.energy_drain );
						}
					} else if ( target is Obj_Machinery_Door_Airlock ) {
						this.occupant_message( "Deconstructing " + target + "..." );
						this.set_ready_state( false );

						if ( this.do_after_cooldown( target ) ) {
							
							if ( this.disabled ) {
								return false;
							}
							this.chassis.spark_system.start();
							GlobalFuncs.qdel( target );
							target = null;
							GlobalFuncs.playsound( target, "sound/items/Deconstruct.ogg", 50, 1 );
							this.chassis.use_power( this.energy_drain );
						}
					}
					break;
				case 1:
					
					if ( target is Tile_Space ) {
						this.occupant_message( "Building Floor..." );
						this.set_ready_state( false );

						if ( this.do_after_cooldown( target ) ) {
							
							if ( this.disabled ) {
								return false;
							}
							((Tile)target).ChangeTurf( typeof(Tile_Simulated_Floor_Plating_Airless) );
							GlobalFuncs.playsound( target, "sound/items/Deconstruct.ogg", 50, 1 );
							this.chassis.spark_system.start();
							this.chassis.use_power( this.energy_drain * 2 );
						}
					} else if ( target is Tile_Simulated_Floor ) {
						this.occupant_message( "Building Wall..." );
						this.set_ready_state( false );

						if ( this.do_after_cooldown( target ) ) {
							
							if ( this.disabled ) {
								return false;
							}
							((Tile)target).ChangeTurf( typeof(Tile_Simulated_Wall) );
							GlobalFuncs.playsound( target, "sound/items/Deconstruct.ogg", 50, 1 );
							this.chassis.spark_system.start();
							this.chassis.use_power( this.energy_drain * 2 );
						}
					}
					break;
				case 2:
					
					if ( target is Tile_Simulated_Floor ) {
						this.occupant_message( "Building Airlock..." );
						this.set_ready_state( false );

						if ( this.do_after_cooldown( target ) ) {
							
							if ( this.disabled ) {
								return false;
							}
							this.chassis.spark_system.start();
							T = new Obj_Machinery_Door_Airlock( target );
							T.autoclose = true;
							GlobalFuncs.playsound( target, "sound/items/Deconstruct.ogg", 50, 1 );
							GlobalFuncs.playsound( target, "sound/effects/sparks2.ogg", 50, 1 );
							this.chassis.use_power( this.energy_drain * 2 );
						}
					}
					break;
			}
			return false;
		}

	}

}