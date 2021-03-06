// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_MiningDrone : Mob_Living_SimpleAnimal_Hostile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "mining_drone";
			this.status_flags = 11;
			this.faction = new ByTable(new object [] { "neutral" });
			this.a_intent = "harm";
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.wander = false;
			this.idle_vision_range = 5;
			this.move_to_delay = 10;
			this.retreat_distance = 1;
			this.minimum_distance = 2;
			this.health = 125;
			this.maxHealth = 125;
			this.melee_damage_lower = 15;
			this.melee_damage_upper = 15;
			this.attacktext = "drills";
			this.attack_sound = "sound/weapons/circsawhit.ogg";
			this.ranged = true;
			this.ranged_message = "shoots";
			this.projectiletype = typeof(Obj_Item_Projectile_Kinetic);
			this.projectilesound = "sound/weapons/Gunshot4.ogg";
			this.speak_emote = new ByTable(new object [] { "states" });
			this.wanted_objects = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Ore_Diamond), 
				typeof(Obj_Item_Weapon_Ore_Gold), 
				typeof(Obj_Item_Weapon_Ore_Silver), 
				typeof(Obj_Item_Weapon_Ore_Plasma), 
				typeof(Obj_Item_Weapon_Ore_Uranium), 
				typeof(Obj_Item_Weapon_Ore_Iron), 
				typeof(Obj_Item_Weapon_Ore_Bananium)
			 });
			this.healable = false;
			this.icon = "icons/obj/aibots.dmi";
			this.icon_state = "mining_drone";
		}

		// Function from file: equipment_locker.dm
		public Mob_Living_SimpleAnimal_Hostile_MiningDrone ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.SetCollectBehavior();
			return;
		}

		// Function from file: equipment_locker.dm
		public override dynamic adjustHealth( dynamic amount = null ) {
			dynamic _default = null;

			
			if ( this.search_objects != 0 ) {
				this.SetOffenseBehavior();
			}
			_default = base.adjustHealth( (object)(amount) );
			return _default;
		}

		// Function from file: equipment_locker.dm
		public override bool AttackingTarget(  ) {
			
			if ( this.target is Obj_Item_Weapon_Ore ) {
				this.CollectOre();
				return false;
			}
			base.AttackingTarget();
			return false;
		}

		// Function from file: equipment_locker.dm
		public void DropOre(  ) {
			Obj_Item_Weapon_Ore O = null;

			
			if ( !( this.contents.len != 0 ) ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_Ore) )) {
				O = _a;
				
				this.contents.Remove( O );
				O.loc = this.loc;
			}
			return;
		}

		// Function from file: equipment_locker.dm
		public void CollectOre(  ) {
			Obj_Item_Weapon_Ore O = null;
			dynamic dir = null;
			Tile T = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Item_Weapon_Ore) )) {
				O = _a;
				
				O.loc = this;
			}

			foreach (dynamic _c in Lang13.Enumerate( GlobalVars.alldirs )) {
				dir = _c;
				
				T = Map13.GetStep( this, Convert.ToInt32( dir ) );

				foreach (dynamic _b in Lang13.Enumerate( T, typeof(Obj_Item_Weapon_Ore) )) {
					O = _b;
					
					O.loc = this;
				}
			}
			return;
		}

		// Function from file: equipment_locker.dm
		public void SetOffenseBehavior(  ) {
			this.idle_vision_range = 7;
			this.search_objects = 0;
			this.wander = false;
			this.ranged = true;
			this.retreat_distance = 1;
			this.minimum_distance = 2;
			this.icon_state = "mining_drone_offense";
			return;
		}

		// Function from file: equipment_locker.dm
		public void SetCollectBehavior(  ) {
			this.idle_vision_range = 9;
			this.search_objects = 2;
			this.wander = true;
			this.ranged = false;
			this.minimum_distance = 1;
			this.retreat_distance = null;
			this.icon_state = "mining_drone";
			return;
		}

		// Function from file: equipment_locker.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( a.a_intent == "help" ) {
				
				switch ((int)( this.search_objects )) {
					case 0:
						this.SetCollectBehavior();
						a.WriteMsg( "<span class='info'>" + this + " has been set to search and store loose ore.</span>" );
						break;
					case 2:
						this.SetOffenseBehavior();
						a.WriteMsg( "<span class='info'>" + this + " has been set to attack hostile wildlife.</span>" );
						break;
				}
				return null;
			}
			base.attack_hand( (object)(a), b, c );
			return null;
		}

		// Function from file: equipment_locker.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			base.death( gibbed, toast );
			this.visible_message( "<span class='danger'>" + this + " is destroyed!</span>" );
			new Obj_Effect_Decal_Cleanable_RobotDebris( this.loc );
			this.DropOre();
			GlobalFuncs.qdel( this );
			return false;
		}

		// Function from file: equipment_locker.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic W = null;

			
			if ( A is Obj_Item_Weapon_Weldingtool ) {
				W = A;

				if ( W.welding && !( this.stat != 0 ) ) {
					
					if ( this.AIStatus != 3 && this.AIStatus != 2 ) {
						user.WriteMsg( "<span class='info'>" + this + " is moving around too much to repair!</span>" );
						return null;
					}

					if ( this.maxHealth == this.health ) {
						user.WriteMsg( "<span class='info'>" + this + " is at full integrity.</span>" );
					} else {
						this.adjustBruteLoss( -10 );
						user.WriteMsg( "<span class='info'>You repair some of the armor on " + this + ".</span>" );
					}
					return null;
				}
			}

			if ( A is Obj_Item_Device_MiningScanner || A is Obj_Item_Device_TScanner_AdvMiningScanner ) {
				user.WriteMsg( "<span class='info'>You instruct " + this + " to drop any collected ore.</span>" );
				this.DropOre();
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

	}

}