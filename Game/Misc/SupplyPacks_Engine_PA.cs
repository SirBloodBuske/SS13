// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Engine_PA : SupplyPacks_Engine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Particle Accelerator crate";
			this.cost = 40;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Structure_ParticleAccelerator_FuelChamber), 
				typeof(Obj_Machinery_ParticleAccelerator_ControlBox), 
				typeof(Obj_Structure_ParticleAccelerator_ParticleEmitter_Center), 
				typeof(Obj_Structure_ParticleAccelerator_ParticleEmitter_Left), 
				typeof(Obj_Structure_ParticleAccelerator_ParticleEmitter_Right), 
				typeof(Obj_Structure_ParticleAccelerator_PowerBox), 
				typeof(Obj_Structure_ParticleAccelerator_EndCap)
			 });
			this.containertype = typeof(Obj_Structure_Closet_Crate_Secure_Engisec);
			this.containername = "Particle Accelerator crate";
		}

	}

}