// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Guardian : Mob_Living_SimpleAnimal_Hostile {

		public int cooldown = 0;
		public double damage_transfer = 1;
		public dynamic summoner = null;
		public int range = 10;
		public string playstyle_string = "You are a standard Guardian. You shouldn't exist!";
		public string magic_fluff_string = " You draw the Coder, symbolizing bugs and errors. This shouldn't happen! Submit a bug report!";
		public string tech_fluff_string = "BOOT SEQUENCE COMPLETE. ERROR MODULE LOADED. THIS SHOULDN'T HAPPEN. Submit a bug report!";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.real_name = "Guardian Spirit";
			this.speak_emote = new ByTable(new object [] { "hisses" });
			this.response_help = "passes through";
			this.response_disarm = "flails at";
			this.response_harm = "punches";
			this.icon_living = "guardianorange";
			this.icon_dead = "stand";
			this.speed = 0;
			this.a_intent = "harm";
			this.stop_automated_movement = true;
			this.floating = true;
			this.attack_sound = "sound/weapons/punch1.ogg";
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.maxbodytemp = Double.PositiveInfinity;
			this.attacktext = "punches";
			this.maxHealth = Double.PositiveInfinity;
			this.health = Double.PositiveInfinity;
			this.melee_damage_lower = 15;
			this.melee_damage_upper = 15;
			this.butcher_results = new ByTable().Set( typeof(Obj_Item_Weapon_Ectoplasm), 1 );
			this.AIStatus = 3;
			this.icon = "icons/mob/guardian.dmi";
			this.icon_state = "guardianorange";
		}

		public Mob_Living_SimpleAnimal_Hostile_Guardian ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: guardian.dm
		public void ToggleLight(  ) {
			
			if ( !( this.luminosity != 0 ) ) {
				this.SetLuminosity( 3 );
			} else {
				this.SetLuminosity( 0 );
			}
			return;
		}

		// Function from file: guardian.dm
		public virtual void ToggleMode(  ) {
			this.WriteMsg( "<span class='danger'><B>You dont have another mode!</span></B>" );
			return;
		}

		// Function from file: guardian.dm
		public void Communicate(  ) {
			string input = null;
			string my_message = null;
			dynamic M = null;

			input = GlobalFuncs.stripped_input( this, "Please enter a message to tell your summoner.", "Guardian", "" );

			if ( !Lang13.Bool( input ) ) {
				return;
			}
			my_message = "<span class='boldannounce'><i>" + this + ":</i> " + input + "</span>";

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.mob_list )) {
				M = _a;
				

				if ( M == this.summoner ) {
					M.WriteMsg( my_message );
				}

				if ( GlobalVars.dead_mob_list.Contains( M ) ) {
					M.WriteMsg( new Txt( "<a href='?src=" ).Ref( M ).str( ";follow=" ).Ref( this ).str( "'>(F)</a> " ).item( my_message ).ToString() );
				}
			}
			this.WriteMsg( "" + my_message );
			GlobalFuncs.log_say( "" + this.real_name + "/" + this.key + " : " + input );
			return;
		}

		// Function from file: guardian.dm
		public void Recall(  ) {
			
			if ( this.cooldown > Game13.time ) {
				return;
			}
			this.loc = this.summoner;
			this.buckled = null;
			this.cooldown = Game13.time + 30;
			return;
		}

		// Function from file: guardian.dm
		public void Manifest(  ) {
			
			if ( this.cooldown > Game13.time ) {
				return;
			}

			if ( this.loc == this.summoner ) {
				this.loc = GlobalFuncs.get_turf( this.summoner );
				this.cooldown = Game13.time + 30;
			}
			return;
		}

		// Function from file: guardian.dm
		public override dynamic gib( dynamic animation = null ) {
			
			if ( Lang13.Bool( this.summoner ) ) {
				this.summoner.WriteMsg( "<span class='danger'><B>Your " + this + " was blown up!</span></B>" );
				((Mob)this.summoner).gib();
			}
			this.ghostize();
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: guardian.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					this.gib();
					return false;
					break;
				case 2:
					this.adjustBruteLoss( 60 );
					break;
				case 3:
					this.adjustBruteLoss( 30 );
					break;
			}
			return false;
		}

		// Function from file: guardian.dm
		public override bool adjustHealth( dynamic amount = null ) {
			dynamic damage = null;

			damage = amount * this.damage_transfer;

			if ( Lang13.Bool( this.summoner ) ) {
				
				if ( this.loc == this.summoner ) {
					return false;
				}
				((Mob_Living)this.summoner).adjustBruteLoss( damage );

				if ( Lang13.Bool( damage ) ) {
					this.summoner.WriteMsg( "<span class='danger'><B>Your " + this.name + " is under attack! You take damage!</span></B>" );
					((Ent_Static)this.summoner).visible_message( "<span class='danger'><B>Blood sprays from " + this.summoner + " as " + this + " takes damage!</B></span>" );
				}

				if ( Lang13.Bool( this.summoner.stat ) == true ) {
					this.summoner.WriteMsg( "<span class='danger'><B>Your body can't take the strain of sustaining " + this + " in this condition, it begins to fall apart!</span></B>" );
					((Mob_Living)this.summoner).adjustCloneLoss( damage / 2 );
				}
			}
			return false;
		}

		// Function from file: guardian.dm
		public override bool death( bool? gibbed = null, bool? toast = null ) {
			base.death( gibbed, toast );
			this.summoner.WriteMsg( "<span class='danger'><B>Your " + this.name + " died somehow!</span></B>" );
			((Mob)this.summoner).death();
			return false;
		}

		// Function from file: guardian.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			base.Move( (object)(NewLoc), Dir, step_x, step_y );

			if ( Lang13.Bool( this.summoner ) ) {
				
				if ( Map13.GetDistance( GlobalFuncs.get_turf( this.summoner ), GlobalFuncs.get_turf( this ) ) <= this.range ) {
					return false;
				} else {
					this.WriteMsg( "You moved out of range, and were pulled back! You can only move " + this.range + " meters from " + this.summoner.real_name );
					this.visible_message( "<span class='danger'>The " + this + " jumps back to its user.</span>" );
					this.loc = GlobalFuncs.get_turf( this.summoner );
				}
			}
			return false;
		}

		// Function from file: guardian.dm
		public override bool Life(  ) {
			Obj_Item W = null;

			base.Life();

			if ( Lang13.Bool( this.summoner ) ) {
				
				if ( Convert.ToInt32( this.summoner.stat ) == 2 ) {
					this.WriteMsg( "<span class='danger'>Your summoner has died!</span>" );
					this.visible_message( "<span class='danger'><B>The " + this + " dies along with its user!</B></span>" );
					((Ent_Static)this.summoner).visible_message( "<span class='danger'><B>" + this.summoner + "'s body is completely consumed by the strain of sustaining " + this + "!</B></span>" );

					foreach (dynamic _a in Lang13.Enumerate( this.summoner, typeof(Obj_Item) )) {
						W = _a;
						

						if ( !((Mob)this.summoner).unEquip( W ) ) {
							GlobalFuncs.qdel( W );
						}
					}
					((Mob)this.summoner).dust();
					this.ghostize();
					GlobalFuncs.qdel( this );
				}
			} else {
				this.WriteMsg( "<span class='danger'>Your summoner has died!</span>" );
				this.visible_message( "<span class='danger'><B>The " + this + " dies along with its user!</B></span>" );
				this.ghostize();
				GlobalFuncs.qdel( this );
			}

			if ( Lang13.Bool( this.summoner ) ) {
				
				if ( Map13.GetDistance( GlobalFuncs.get_turf( this.summoner ), GlobalFuncs.get_turf( this ) ) <= this.range ) {
					return false;
				} else {
					this.WriteMsg( "You moved out of range, and were pulled back! You can only move " + this.range + " meters from " + this.summoner.real_name );
					this.visible_message( "<span class='danger'>The " + this + " jumps back to its user.</span>" );
					this.loc = GlobalFuncs.get_turf( this.summoner );
				}
			}
			return false;
		}

	}

}