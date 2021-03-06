// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease_RhumbaBeat : Disease {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "The Rhumba Beat";
			this.max_stages = 5;
			this.spread_text = "On contact";
			this.spread_flags = 32;
			this.cure_text = "Chick Chicky Boom!";
			this.cures = new ByTable(new object [] { "plasma" });
			this.agent = "Unknown";
			this.viable_mobtypes = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human) });
			this.severity = "BIOHAZARD THREAT!";
		}

		// Function from file: tgstation.dme
		public override void stage_act(  ) {
			base.stage_act();

			switch ((int?)( this.stage )) {
				case 1:
					
					if ( this.affected_mob.ckey == "rosham" ) {
						this.cure();
					}
					break;
				case 2:
					
					if ( this.affected_mob.ckey == "rosham" ) {
						this.cure();
					}

					if ( Rand13.PercentChance( 45 ) ) {
						((Mob_Living)this.affected_mob).adjustToxLoss( 5 );
						((Mob_Living)this.affected_mob).updatehealth();
					}

					if ( Rand13.PercentChance( 1 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>You feel strange...</span>" );
					}
					break;
				case 3:
					
					if ( this.affected_mob.ckey == "rosham" ) {
						this.cure();
					}

					if ( Rand13.PercentChance( 5 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>You feel the urge to dance...</span>" );
					} else if ( Rand13.PercentChance( 5 ) ) {
						((Mob)this.affected_mob).emote( "gasp" );
					} else if ( Rand13.PercentChance( 10 ) ) {
						this.affected_mob.WriteMsg( "<span class='danger'>You feel the need to chick chicky boom...</span>" );
					}
					break;
				case 4:
					
					if ( this.affected_mob.ckey == "rosham" ) {
						this.cure();
					}

					if ( Rand13.PercentChance( 10 ) ) {
						((Mob)this.affected_mob).emote( "gasp" );
						this.affected_mob.WriteMsg( "<span class='danger'>You feel a burning beat inside...</span>" );
					}

					if ( Rand13.PercentChance( 20 ) ) {
						((Mob_Living)this.affected_mob).adjustToxLoss( 5 );
						((Mob_Living)this.affected_mob).updatehealth();
					}
					break;
				case 5:
					
					if ( this.affected_mob.ckey == "rosham" ) {
						this.cure();
					}
					this.affected_mob.WriteMsg( "<span class='danger'>Your body is unable to contain the Rhumba Beat...</span>" );

					if ( Rand13.PercentChance( 50 ) ) {
						((Mob)this.affected_mob).gib();
					}
					break;
				default:
					return;
					break;
			}
			return;
		}

	}

}