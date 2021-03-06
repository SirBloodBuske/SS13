// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Icepepper : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Icepepperseed);
			this.filling_color = "#0000CD";
			this.icon_state = "icepepper";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Icepepper ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic _default = null;

			_default = base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Device_Analyzer_PlantAnalyzer ) {
				user.WriteMsg( "<span class='info'>- Frost Oil: <i>" + this.reagents.get_reagent_amount( "frostoil" ) + "%</i></span>" );
			}
			return _default;
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			base.add_juice( (object)(loc), potency );
			this.reagents.add_reagent( "nutriment", Num13.Round( ( this.potency ??0) / 50, 1 ) + 1 );
			this.reagents.add_reagent( "vitamin", Num13.Round( ( this.potency ??0) / 50, 1 ) + 1 );
			this.reagents.add_reagent( "frostoil", Num13.Round( ( this.potency ??0) / 5, 1 ) + 3 );
			this.bitesize = Num13.Round( ( this.reagents.total_volume ??0) / 2, 1 ) + 1;
			return false;
		}

	}

}