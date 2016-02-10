// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Seed_Test : Seed {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "test";
			this.seed_name = "testing";
			this.seed_noun = "data";
			this.display_name = "runtimes";
			this.packet_icon = "seed-replicapod";
			this.products = new ByTable(new object [] { typeof(Mob_Living_SimpleAnimal_Cat_Runtime) });
			this.plant_icon = "replicapod";
			this.nutrient_consumption = 0;
			this.water_consumption = 0;
			this.pest_tolerance = 11;
			this.weed_tolerance = 11;
			this.lifespan = 1000;
			this.maturation = 1;
			this.production = 1;
			this.yield = 1;
		}

	}

}