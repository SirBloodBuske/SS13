// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Retaliate_Clown : Mob_Living_SimpleAnimal_Hostile_Retaliate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "clown";
			this.icon_dead = "clown_dead";
			this.icon_gib = "clown_gib";
			this.speak_chance = 1;
			this.turns_per_move = 5;
			this.response_disarm = "gently pushes aside";
			this.speak = new ByTable(new object [] { "HONK", "Honk!", "Welcome to clown planet!" });
			this.emote_see = new ByTable(new object [] { "honks" });
			this.a_intent = "harm";
			this.maxHealth = 75;
			this.health = 75;
			this.speed = 0;
			this.harm_intent_damage = 8;
			this.melee_damage_lower = 10;
			this.melee_damage_upper = 10;
			this.attack_sound = "sound/items/bikehorn.ogg";
			this.del_on_death = true;
			this.loot = new ByTable(new object [] { typeof(Obj_Effect_Landmark_Mobcorpse_Clown) });
			this.atmos_requirements = new ByTable().Set( "min_oxy", 5 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 1 ).Set( "min_co2", 0 ).Set( "max_co2", 5 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 270;
			this.maxbodytemp = 370;
			this.unsuitable_atmos_damage = 10;
			this.icon_state = "clown";
		}

		public Mob_Living_SimpleAnimal_Hostile_Retaliate_Clown ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: clown.dm
		public override void handle_temperature_damage(  ) {
			
			if ( Convert.ToDouble( this.bodytemperature ) < this.minbodytemp ) {
				this.adjustBruteLoss( 10 );
			} else if ( Convert.ToDouble( this.bodytemperature ) > this.maxbodytemp ) {
				this.adjustBruteLoss( 15 );
			}
			return;
		}

	}

}