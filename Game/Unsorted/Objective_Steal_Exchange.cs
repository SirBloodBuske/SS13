// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Steal_Exchange : Objective_Steal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dangerrating = 10;
		}

		public Objective_Steal_Exchange ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override void update_explanation_text(  ) {
			base.update_explanation_text();

			if ( Lang13.Bool( this.target ) && Lang13.Bool( this.target.current ) ) {
				this.explanation_text = "Acquire " + this.targetinfo.name + " held by " + this.target.name + ", the " + this.target.assigned_role + " and syndicate agent";
			} else {
				this.explanation_text = "Free Objective";
			}
			return;
		}

		// Function from file: objective.dm
		public virtual void set_faction( string faction = null, dynamic otheragent = null ) {
			this.target = otheragent;

			if ( faction == "red" ) {
				this.targetinfo = new ObjectiveItem_Unique_DocsBlue();
			} else if ( faction == "blue" ) {
				this.targetinfo = new ObjectiveItem_Unique_DocsRed();
			}
			this.explanation_text = "Acquire " + this.targetinfo.name + " held by " + this.target.current.real_name + ", the " + this.target.assigned_role + " and syndicate agent";
			this.steal_target = this.targetinfo.targetitem;
			return;
		}

	}

}