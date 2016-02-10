// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Mushroom : Mob_Living_SimpleAnimal_Hostile {

		public double powerlevel = 0;
		public bool bruised = false;
		public bool recovery_cooldown = false;
		public int faint_ticker = 0;
		public Image cap_living = null;
		public Image cap_dead = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "mushroom_color";
			this.icon_dead = "mushroom_dead";
			this.maxHealth = 10;
			this.health = 10;
			this.meat_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Hugemushroomslice);
			this.size = 2;
			this.response_help = "pets";
			this.response_disarm = "gently pushes aside";
			this.response_harm = "whacks";
			this.harm_intent_damage = 5;
			this.melee_damage_lower = 1;
			this.melee_damage_upper = 1;
			this.attack_same = 2;
			this.attacktext = "chomps";
			this.faction = "mushroom";
			this.stat_attack = 2;
			this.speed = 1;
			this.icon_state = "mushroom_color";
		}

		// Function from file: mushroom.dm
		public Mob_Living_SimpleAnimal_Hostile_Mushroom ( dynamic loc = null ) : base( (object)(loc) ) {
			string cap_color = null;

			this.melee_damage_lower += Rand13.Int( 3, 5 );
			this.melee_damage_upper += Rand13.Int( 10, 20 );
			this.maxHealth += Rand13.Int( 40, 60 );
			this.move_to_delay = Rand13.Int( 2, 10 );
			cap_color = String13.ColorCode( Rand13.Int( 0, 255 ), Rand13.Int( 0, 255 ), Rand13.Int( 0, 255 ) );
			this.cap_living = new Image( "icons/mob/animal.dmi", null, "mushroom_cap" );
			this.cap_dead = new Image( "icons/mob/animal.dmi", null, "mushroom_cap_dead" );
			this.cap_living.color = cap_color;
			this.cap_dead.color = cap_color;
			this.UpdateMushroomCap();
			this.health = this.maxHealth;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: mushroom.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			this.Bruise();
			return null;
		}

		// Function from file: mushroom.dm
		public override void hitby( Ent_Static AM = null, dynamic speed = null, int? dir = null ) {
			Ent_Static T = null;

			base.hitby( AM, (object)(speed), dir );

			if ( AM is Obj_Item ) {
				T = AM;

				if ( Lang13.Bool( ((dynamic)T).throwforce ) ) {
					this.Bruise();
				}
			}
			return;
		}

		// Function from file: mushroom.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			base.attack_hand( (object)(a), (object)(b), (object)(c) );

			if ( a.a_intent == "hurt" ) {
				this.Bruise();
			}
			return null;
		}

		// Function from file: mushroom.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom ) {
				
				if ( this.stat == 2 && !this.recovery_cooldown ) {
					this.Recover();
					GlobalFuncs.qdel( a );
					a = null;
				} else {
					GlobalFuncs.to_chat( b, "<span class='notice'>" + this + " won't eat it!</span>" );
				}
				return null;
			}

			if ( Lang13.Bool( a.force ) ) {
				this.Bruise();
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: mushroom.dm
		public void Bruise(  ) {
			
			if ( !this.bruised && !Lang13.Bool( this.stat ) ) {
				this.visible_message( "<span class='notice'>The " + this.name + " was bruised!</span>" );
				this.bruised = true;
			}
			return;
		}

		// Function from file: mushroom.dm
		public void LevelUp( double level_gain = 0 ) {
			
			if ( this.powerlevel <= 9 ) {
				this.powerlevel += level_gain;

				if ( Rand13.PercentChance( 25 ) ) {
					this.melee_damage_lower += level_gain * Rand13.Int( 1, 5 );
				} else {
					this.melee_damage_upper += level_gain * Rand13.Int( 1, 5 );
				}
				this.maxHealth += level_gain * Rand13.Int( 1, 5 );
			}
			this.health = this.maxHealth;
			return;
		}

		// Function from file: mushroom.dm
		public void Recover(  ) {
			this.visible_message( "<span class='notice'>" + this + " slowly begins to recover.</span>" );
			this.health = 5;
			this.faint_ticker = 0;
			this.icon_state = this.icon_living;
			this.UpdateMushroomCap();
			this.recovery_cooldown = true;
			Task13.Schedule( 300, (Task13.Closure)(() => {
				this.recovery_cooldown = false;
				return;
			}));
			return;
		}

		// Function from file: mushroom.dm
		public void UpdateMushroomCap(  ) {
			this.overlays.len = 0;

			if ( this.health == 0 ) {
				this.overlays.Add( this.cap_dead );
			} else {
				this.overlays.Add( this.cap_living );
			}
			return;
		}

		// Function from file: mushroom.dm
		public override void Die( bool? gore = null ) {
			this.visible_message( "<span class='notice'>" + this + " fainted.</span>" );
			base.Die( gore );
			this.UpdateMushroomCap();
			return;
		}

		// Function from file: mushroom.dm
		public override void revive( bool? animation = null ) {
			base.revive( animation );
			this.icon_state = "mushroom_color";
			this.UpdateMushroomCap();
			return;
		}

		// Function from file: mushroom.dm
		public override dynamic attack_animal( Mob_Living user = null ) {
			Mob_Living M = null;
			double level_gain = 0;

			
			if ( user is Mob_Living_SimpleAnimal_Hostile_Mushroom && this.stat == 2 ) {
				M = user;

				if ( this.faint_ticker < 2 ) {
					M.visible_message( "<span class='notice'>" + M + " chews a bit on " + this + ".</span>" );
					this.faint_ticker++;
					return null;
				}
				M.visible_message( "<span class='notice'>" + M + " devours " + this + "!</span>" );
				level_gain = this.powerlevel - Convert.ToDouble( ((dynamic)M).powerlevel );

				if ( level_gain >= -1 && !this.bruised && !Lang13.Bool( M.ckey ) ) {
					
					if ( level_gain < 1 ) {
						level_gain = 1;
					}
					((Mob_Living_SimpleAnimal_Hostile_Mushroom)M).LevelUp( level_gain );
				}
				M.health = M.maxHealth;
				GlobalFuncs.qdel( this );
				return null;
			}
			base.attack_animal( user );
			return null;
		}

		// Function from file: mushroom.dm
		public override bool adjustBruteLoss( dynamic amount = null, string damage_type = null ) {
			
			if ( !Lang13.Bool( this.retreat_distance ) && Rand13.PercentChance( 33 ) ) {
				this.retreat_distance = 5;
				Task13.Schedule( 30, (Task13.Closure)(() => {
					this.retreat_distance = null;
					return;
				}));
			}
			base.adjustBruteLoss( (object)(amount), damage_type );
			return false;
		}

		// Function from file: mushroom.dm
		public override bool Life(  ) {
			
			if ( this.timestopped ) {
				return false;
			}
			base.Life();

			if ( !Lang13.Bool( this.stat ) ) {
				this.health = Num13.MinInt( Convert.ToInt32( this.health + 2 ), Convert.ToInt32( this.maxHealth ) );
			}
			return false;
		}

		// Function from file: mushroom.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( Convert.ToDouble( this.health ) >= Convert.ToDouble( this.maxHealth ) ) {
				GlobalFuncs.to_chat( user, "<span class='info'>It looks healthy.</span>" );
			} else {
				GlobalFuncs.to_chat( user, "<span class='info'>It looks like it's been roughed up.</span>" );
			}
			return null;
		}

	}

}