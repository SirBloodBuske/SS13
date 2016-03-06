// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_MindTransfer : Obj_Effect_ProcHolder_Spell_Targeted {

		public ByTable protected_roles = new ByTable(new object [] { "Wizard", "Changeling", "Cultist" });
		public int paralysis_amount_caster = 20;
		public int paralysis_amount_victim = 20;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.school = "transmutation";
			this.charge_max = 600;
			this.clothes_req = 0;
			this.invocation = "GIN'YU CAPAN";
			this.invocation_type = "whisper";
			this.range = 1;
			this.cooldown_min = 200;
			this.action_icon_state = "mindswap";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_MindTransfer ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mind_transfer.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			dynamic target = null;
			Mob victim = null;
			dynamic caster = null;
			dynamic V = null;
			dynamic V2 = null;
			Mob_Dead_Observer ghost = null;
			dynamic V3 = null;
			dynamic V4 = null;

			
			if ( !( targets.len != 0 ) ) {
				thearea.WriteMsg( "<span class='warning'>No mind found!</span>" );
				return false;
			}

			if ( targets.len > 1 ) {
				thearea.WriteMsg( "<span class='warning'>Too many minds! You're not a hive damnit!</span>" );
				return false;
			}
			target = targets[1];

			if ( !Map13.FetchInViewExcludeThis( null, this.range ).Contains( target ) && !Lang13.Bool( user ) ) {
				thearea.WriteMsg( "<span class='warning'>They are too far away!</span>" );
				return false;
			}

			if ( Convert.ToInt32( target.stat ) == 2 ) {
				thearea.WriteMsg( "<span class='warning'>You don't particularly want to be dead!</span>" );
				return false;
			}

			if ( !Lang13.Bool( target.key ) || !Lang13.Bool( target.mind ) ) {
				thearea.WriteMsg( "<span class='warning'>They appear to be catatonic! Not even magic can affect their vacant mind.</span>" );
				return false;
			}

			if ( Lang13.Bool( thearea.suiciding ) ) {
				thearea.WriteMsg( "<span class='warning'>You're killing yourself! You can't concentrate enough to do this!</span>" );
				return false;
			}

			if ( this.protected_roles.Contains( target.mind.special_role ) || String13.CompareIgnoreCase( "@", String13.SubStr( target.key, 1, 2 ) ) ) {
				thearea.WriteMsg( "<span class='warning'>Their mind is resisting your spell!</span>" );
				return false;
			}
			victim = target;
			caster = thearea;

			if ( caster.mind.special_verbs.len != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( caster.mind.special_verbs )) {
					V = _a;
					
					caster.verbs -= V;
				}
			}

			if ( victim.mind.special_verbs.len != 0 ) {
				
				foreach (dynamic _b in Lang13.Enumerate( victim.mind.special_verbs )) {
					V2 = _b;
					
					victim.verbs.Remove( V2 );
				}
			}
			ghost = victim.ghostize( false );
			((Mind)caster.mind).transfer_to( victim );

			if ( victim.mind.special_verbs.len != 0 ) {
				
				foreach (dynamic _c in Lang13.Enumerate( caster.mind.special_verbs )) {
					V3 = _c;
					
					caster.verbs += V3;
				}
			}
			ghost.mind.transfer_to( caster );

			if ( Lang13.Bool( ghost.key ) ) {
				caster.key = ghost.key;
			}
			GlobalFuncs.qdel( ghost );

			if ( caster.mind.special_verbs.len != 0 ) {
				
				foreach (dynamic _d in Lang13.Enumerate( caster.mind.special_verbs )) {
					V4 = _d;
					
					caster.verbs += V4;
				}
			}
			((Mob)caster).Paralyse( this.paralysis_amount_caster );
			victim.Paralyse( this.paralysis_amount_victim );
			caster.WriteMsg( new Sound( "sound/magic/MandSwap.ogg" ) );
			victim.WriteMsg( new Sound( "sound/magic/MandSwap.ogg" ) );
			return false;
		}

	}

}