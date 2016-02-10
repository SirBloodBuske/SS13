// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Steal : Objective {

		public string target_category = "traitor";
		public dynamic steal_target = null;

		public Objective_Steal ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override dynamic check_completion(  ) {
			
			if ( this.blocked ) {
				return 0;
			}

			if ( !Lang13.Bool( this.steal_target ) ) {
				return 1;
			}
			return ((TheftObjective)this.steal_target).check_completion( this.owner );
		}

		// Function from file: objective.dm
		public dynamic select_target(  ) {
			dynamic possible_items_all = null;
			dynamic new_target = null;
			TheftObjective O = null;
			dynamic tmp_obj = null;
			dynamic custom_name = null;

			possible_items_all = GlobalVars.potential_theft_objectives[this.target_category] + "custom";
			new_target = Interface13.Input( "Select target:", "Objective target", null, null, possible_items_all, InputType.Null | InputType.Any );

			if ( !Lang13.Bool( new_target ) ) {
				return null;
			}

			if ( new_target == "custom" ) {
				O = new TheftObjective();
				O.typepath = Interface13.Input( "Select type:", "Type", null, null, Lang13.GetTypes( typeof(Obj_Item) ), InputType.Null | InputType.Any );

				if ( !Lang13.Bool( O.typepath ) ) {
					return null;
				}
				tmp_obj = Lang13.Call( O.typepath );
				custom_name = tmp_obj.name;
				GlobalFuncs.qdel( tmp_obj );
				O.name = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Enter target name:", "Objective target", custom_name, null, null, InputType.Str | InputType.Null ) ), 1, 26 );

				if ( !Lang13.Bool( O.name ) ) {
					return null;
				}
				this.steal_target = O;
				this.explanation_text = this.format_explanation();
			} else {
				this.steal_target = Lang13.Call( new_target );
				this.explanation_text = this.format_explanation();
			}
			return this.steal_target;
		}

		// Function from file: objective.dm
		public virtual string format_explanation(  ) {
			return "Steal " + this.steal_target.name + ".";
		}

		// Function from file: objective.dm
		public override dynamic find_target(  ) {
			ByTable possibleObjectives = null;
			int loopSanity = 0;
			dynamic pickedObjective = null;
			dynamic objective = null;

			possibleObjectives = GlobalVars.potential_theft_objectives[this.target_category];
			loopSanity = possibleObjectives.len;

			while (this.steal_target == null && loopSanity > 0) {
				loopSanity--;
				pickedObjective = Rand13.PickFromTable( possibleObjectives );
				objective = Lang13.Call( pickedObjective );
				Interface13.Stat( null, objective.protected_jobs.Contains( this.owner != null && Lang13.Bool( ((dynamic)this.owner).assigned_role ) ) );

				if ( false ) {
					continue;
				}
				this.steal_target = objective;
				this.explanation_text = this.format_explanation();
				return null;
			}
			this.explanation_text = "Free Objective.";
			return null;
		}

	}

}