// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MartialArt : Game_Data {

		public string name = "Martial Art";
		public string streak = "";
		public int max_streak_length = 6;
		public Ent_Static current_target = null;
		public bool temporary = false;
		public MartialArt v_base = null;
		public int deflection_chance = 0;
		public System.Reflection.MethodInfo help_verb = null;

		// Function from file: martial.dm
		public void remove( dynamic H = null ) {
			
			if ( H.martial_art != this ) {
				return;
			}
			H.martial_art = this.v_base;

			if ( this.help_verb != null ) {
				H.verbs -= this.help_verb;
			}
			return;
		}

		// Function from file: martial.dm
		public void teach( dynamic H = null, bool? make_temporary = null ) {
			make_temporary = make_temporary ?? false;

			
			if ( this.help_verb != null ) {
				H.verbs += this.help_verb;
			}

			if ( make_temporary == true ) {
				this.temporary = true;
			}

			if ( H.martial_art != null && H.martial_art.temporary ) {
				
				if ( this.temporary ) {
					this.v_base = H.martial_art.v_base;
				} else {
					H.martial_art.v_base = this;
					return;
				}
			}
			H.martial_art = this;
			return;
		}

		// Function from file: martial.dm
		public bool basic_hit( dynamic A = null, Ent_Static D = null ) {
			double damage = 0;
			string atk_verb = null;
			dynamic affecting = null;
			dynamic armor_block = null;

			((Ent_Dynamic)A).do_attack_animation( D );
			damage = Rand13.Int( A.dna.species.punchdamagelow, A.dna.species.punchdamagehigh );
			atk_verb = A.dna.species.attack_verb;

			if ( Lang13.Bool( ((dynamic)D).lying ) ) {
				atk_verb = "kick";
			}

			if ( !( damage != 0 ) ) {
				GlobalFuncs.playsound( D.loc, A.dna.species.miss_sound, 25, 1, -1 );
				D.visible_message( "<span class='warning'>" + A + " has attempted to " + atk_verb + " " + D + "!</span>" );
				GlobalFuncs.add_logs( A, D, "attempted to " + atk_verb );
				return false;
			}
			affecting = ((dynamic)D).get_organ( GlobalFuncs.ran_zone( A.zone_selected ) );
			armor_block = ((dynamic)D).run_armor_check( affecting, "melee" );
			GlobalFuncs.playsound( D.loc, A.dna.species.attack_sound, 25, 1, -1 );
			D.visible_message( "<span class='danger'>" + A + " has " + atk_verb + "ed " + D + "!</span>", "<span class='userdanger'>" + A + " has " + atk_verb + "ed " + D + "!</span>" );
			((dynamic)D).apply_damage( damage, "brute", affecting, armor_block );
			GlobalFuncs.add_logs( A, D, "punched" );

			if ( Convert.ToInt32( ((dynamic)D).stat ) != 2 && damage >= A.dna.species.punchstunthreshold ) {
				D.visible_message( "<span class='danger'>" + A + " has weakened " + D + "!!</span>", "<span class='userdanger'>" + A + " has weakened " + D + "!</span>" );
				((dynamic)D).apply_effect( 4, "weaken", armor_block );
				((dynamic)D).forcesay( GlobalVars.hit_appends );
			} else if ( Lang13.Bool( ((dynamic)D).lying ) ) {
				((dynamic)D).forcesay( GlobalVars.hit_appends );
			}
			return true;
		}

		// Function from file: martial.dm
		public void add_to_streak( string element = null, Ent_Static D = null ) {
			
			if ( D != this.current_target ) {
				this.current_target = D;
				this.streak = "";
			}
			this.streak = this.streak + element;

			if ( Lang13.Length( this.streak ) > this.max_streak_length ) {
				this.streak = String13.SubStr( this.streak, 2, 0 );
			}
			return;
		}

		// Function from file: martial.dm
		public virtual bool grab_act( dynamic A = null, Mob_Living_Carbon_Human D = null ) {
			return false;
		}

		// Function from file: martial.dm
		public virtual bool harm_act( dynamic A = null, Mob_Living D = null ) {
			return false;
		}

		// Function from file: martial.dm
		public virtual bool disarm_act( dynamic A = null, Mob_Living_Carbon_Human D = null ) {
			return false;
		}

	}

}