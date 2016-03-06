// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Drill : Obj_Item_MechaParts_MechaEquipment {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.equip_cooldown = 30;
			this.energy_drain = 10;
			this.force = 15;
			this.icon_state = "mecha_drill";
		}

		public Obj_Item_MechaParts_MechaEquipment_Drill ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mining_tools.dm
		public void drill_mob( dynamic target = null, Ent_Static user = null, int? drill_damage = null ) {
			drill_damage = drill_damage ?? 80;

			dynamic H = null;
			dynamic affecting = null;

			((Ent_Static)target).visible_message( "<span class='danger'>" + this.chassis + " drills " + target + " with " + this + ".</span>", "<span class='userdanger'>" + this.chassis + " drills " + target + " with " + this + ".</span>" );
			GlobalFuncs.add_logs( user, target, "attacked", "" + this.name, "(INTENT: " + String13.ToUpper( ((dynamic)user).a_intent ) + ") (DAMTYPE: " + String13.ToUpper( this.damtype ) + ")" );

			if ( target is Mob_Living_Carbon_Human ) {
				H = target;
				affecting = ((Mob_Living_Carbon_Human)H).get_organ( "chest" );
				affecting.take_damage( drill_damage );
				((Mob_Living)H).update_damage_overlays(  );
			} else {
				((Mob_Living)target).take_organ_damage( drill_damage );
			}

			if ( Lang13.Bool( target ) ) {
				((Mob)target).Paralyse( 10 );
				((Mob_Living)target).updatehealth();
			}
			return;
		}

		// Function from file: mining_tools.dm
		public override bool can_attach( Obj_Mecha M = null ) {
			
			if ( base.can_attach( M ) ) {
				
				if ( M is Obj_Mecha_Working || M is Obj_Mecha_Combat ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: mining_tools.dm
		[VerbInfo( name: "action" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj | InputType.Tile | InputType.Zone )]
		public override bool f_action( dynamic target = null ) {
			dynamic target_obj = null;
			Tile_Simulated_Mineral M = null;
			dynamic ore_box = null;
			Obj_Item_Weapon_Ore ore = null;
			Tile_Simulated_Floor_Plating_Asteroid M2 = null;
			dynamic ore_box2 = null;
			Obj_Item_Weapon_Ore ore2 = null;

			
			if ( !this.action_checks( target ) ) {
				return false;
			}

			if ( target is Tile && !( target is Tile_Simulated ) ) {
				return false;
			}

			if ( target is Obj ) {
				target_obj = target;

				if ( target_obj.unacidable ) {
					return false;
				}
			}
			((Ent_Static)target).visible_message( "<span class='warning'>" + this.chassis + " starts to drill " + target + ".</span>", "<span class='userdanger'>" + this.chassis + " starts to drill " + target + "...</span>", "<span class='italics'>You hear drilling.</span>" );

			if ( this.do_after_cooldown( target ) ) {
				
				if ( target is Tile_Simulated_Wall_RWall ) {
					
					if ( this is Obj_Item_MechaParts_MechaEquipment_Drill_Diamonddrill ) {
						
						if ( this.do_after_cooldown( target ) ) {
							this.log_message( "Drilled through " + target );
							((Ent_Static)target).ex_act( 3 );
						}
					} else {
						this.occupant_message( "<span class='danger'>" + target + " is too durable to drill through.</span>" );
					}
				} else if ( target is Tile_Simulated_Mineral ) {
					
					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( 1, this.chassis ), typeof(Tile_Simulated_Mineral) )) {
						M = _a;
						

						if ( ( Map13.GetDistance( this.chassis, M ) & this.chassis.dir ) != 0 ) {
							M.gets_drilled( this.chassis.occupant );
						}
					}
					this.log_message( "Drilled through " + target );

					if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Item_MechaParts_MechaEquipment_HydraulicClamp), this.chassis.equipment ) ) ) {
						ore_box = Lang13.FindIn( typeof(Obj_Structure_OreBox), ((dynamic)this.chassis).cargo );

						if ( Lang13.Bool( ore_box ) ) {
							
							foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRange( this.chassis, 1 ), typeof(Obj_Item_Weapon_Ore) )) {
								ore = _b;
								

								if ( ( Map13.GetDistance( this.chassis, ore ) & this.chassis.dir ) != 0 ) {
									ore.Move( ore_box );
								}
							}
						}
					}
				} else if ( target is Tile_Simulated_Floor_Plating_Asteroid ) {
					
					foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInRange( this.chassis, 1 ), typeof(Tile_Simulated_Floor_Plating_Asteroid) )) {
						M2 = _c;
						

						if ( ( Map13.GetDistance( this.chassis, M2 ) & this.chassis.dir ) != 0 ) {
							M2.gets_dug();
						}
					}
					this.log_message( "Drilled through " + target );

					if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Item_MechaParts_MechaEquipment_HydraulicClamp), this.chassis.equipment ) ) ) {
						ore_box2 = Lang13.FindIn( typeof(Obj_Structure_OreBox), ((dynamic)this.chassis).cargo );

						if ( Lang13.Bool( ore_box2 ) ) {
							
							foreach (dynamic _d in Lang13.Enumerate( Map13.FetchInRange( this.chassis, 1 ), typeof(Obj_Item_Weapon_Ore) )) {
								ore2 = _d;
								

								if ( ( Map13.GetDistance( this.chassis, ore2 ) & this.chassis.dir ) != 0 ) {
									ore2.Move( ore_box2 );
								}
							}
						}
					}
				} else {
					this.log_message( "Drilled through " + target );

					if ( target is Mob_Living ) {
						
						if ( this is Obj_Item_MechaParts_MechaEquipment_Drill_Diamonddrill ) {
							this.drill_mob( target, this.chassis.occupant, 120 );
						} else {
							this.drill_mob( target, this.chassis.occupant );
						}
					} else {
						((Ent_Static)target).ex_act( 2 );
					}
				}
			}
			return false;
		}

	}

}