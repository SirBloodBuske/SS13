// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GameMode_Wizard : GameMode {

		public bool use_huds = false;
		public bool finished = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "wizard";
			this.config_tag = "wizard";
			this.antag_flag = "wizard";
			this.required_players = 20;
			this.required_enemies = 1;
			this.recommended_enemies = 1;
			this.enemy_minimum_age = 14;
			this.round_ends_with_antag_death = true;
		}

		// Function from file: wizard.dm
		public override bool declare_completion(  ) {
			
			if ( this.finished ) {
				GlobalFuncs.feedback_set_details( "round_end_result", "loss - wizard killed" );
				Game13.WriteMsg( "<span class='userdanger'>The wizard" + ( this.wizards.len > 1 ? "s" : "" ) + " has been killed by the crew! The Space Wizards Federation has been taught a lesson they will not soon forget!</span>" );
			}
			base.declare_completion();
			return true;
		}

		// Function from file: wizard.dm
		public override bool check_finished(  ) {
			Mind wizard = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.wizards, typeof(Mind) )) {
				wizard = _a;
				

				if ( wizard.current is Mob_Living && Convert.ToInt32( wizard.current.stat ) != 2 ) {
					return base.check_finished();
				}
			}

			if ( GlobalVars.SSevent.wizardmode ) {
				GlobalVars.SSevent.toggleWizardmode();
				GlobalVars.SSevent.resetFrequency();
			}
			return base.check_finished();
		}

		// Function from file: wizard.dm
		public override bool post_setup( bool? report = null ) {
			Mind wizard = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.wizards, typeof(Mind) )) {
				wizard = _a;
				
				GlobalFuncs.log_game( "" + wizard.key + " (ckey) has been selected as a Wizard" );
				this.equip_wizard( wizard.current );
				this.forge_wizard_objectives( wizard );

				if ( this.use_huds ) {
					this.update_wiz_icons_added( wizard );
				}
				this.greet_wizard( wizard );
				this.name_wizard( wizard.current );
			}
			base.post_setup( report );
			return false;
		}

		// Function from file: wizard.dm
		public override bool pre_setup(  ) {
			dynamic wizard = null;
			Mind wiz = null;

			wizard = Rand13.PickFromTable( this.antag_candidates );
			this.wizards.Add( wizard );
			this.modePlayer.Add( wizard );
			wizard.assigned_role = "Wizard";
			wizard.special_role = "Wizard";

			if ( GlobalVars.wizardstart.len == 0 ) {
				wizard.current.WriteMsg( "<span class='boldannounce'>A starting location for you could not be found, please report this bug!</span>" );
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.wizards, typeof(Mind) )) {
				wiz = _a;
				
				wiz.current.loc = Rand13.PickFromTable( GlobalVars.wizardstart );
			}
			return true;
		}

		// Function from file: raginmages.dm
		public override void announce(  ) {
			Game13.WriteMsg( "<B>The current game mode is - Ragin' Mages!</B>" );
			Game13.WriteMsg( "<B>The <span class='warning'>Space Wizard Federation</span> is pissed, help defeat all the space wizards!</B>" );
			return;
		}

	}

}