// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Surgery_OrganManipulation_Soft : Surgery_OrganManipulation {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.possible_locs = new ByTable(new object [] { "groin", "eyes", "mouth" });
			this.steps = new ByTable(new object [] { typeof(SurgeryStep_Incise), typeof(SurgeryStep_RetractSkin), typeof(SurgeryStep_ClampBleeders), typeof(SurgeryStep_Incise), typeof(SurgeryStep_ManipulateOrgans) });
		}

	}

}