// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Angel : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Angelmycelium);
			this.filling_color = "#C0C0C0";
			this.icon_state = "angel";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Angel ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic _default = null;

			_default = base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Device_Analyzer_PlantAnalyzer ) {
				user.WriteMsg( "<span class='info'>- Amatoxins: <i>" + this.reagents.get_reagent_amount( "amatoxin" ) + "%</i></span>" );
				user.WriteMsg( "<span class='info'>- Mushroom Hallucinogen: <i>" + this.reagents.get_reagent_amount( "mushroomhallucinogen" ) + "%</i></span>" );
			}
			return _default;
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			base.add_juice( (object)(loc), potency );
			this.reagents.add_reagent( "nutriment", Num13.Round( ( this.potency ??0) / 50, 1 ) + 1 );
			this.reagents.add_reagent( "amatoxin", Num13.Round( ( this.potency ??0) / 3, 1 ) + 13 );
			this.reagents.add_reagent( "mushroomhallucinogen", Num13.Round( ( this.potency ??0) / 25, 1 ) + 1 );
			this.bitesize = Num13.Round( ( this.reagents.total_volume ??0) / 2, 1 ) + 1;
			return false;
		}

	}

}