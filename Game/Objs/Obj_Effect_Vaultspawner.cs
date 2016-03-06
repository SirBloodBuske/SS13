// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Vaultspawner : Obj_Effect {

		public int maxX = 6;
		public int maxY = 6;
		public int minX = 2;
		public int minY = 2;

		// Function from file: vaultspawner.dm
		public Obj_Effect_Vaultspawner ( dynamic location = null, int? lX = null, int? uX = null, int? lY = null, int? uY = null, dynamic type = null ) : base( (object)(location) ) {
			lX = lX ?? this.minX;
			uX = uX ?? this.maxX;
			lY = lY ?? this.minY;
			uY = uY ?? this.maxY;

			int? lowBoundX = null;
			int? lowBoundY = null;
			int? hiBoundX = null;
			int? hiBoundY = null;
			int z = 0;
			int? i = null;
			int? j = null;
			Tile T = null;

			
			if ( !Lang13.Bool( type ) ) {
				type = Rand13.Pick(new object [] { "sandstone", "rock", "alien" });
			}
			lowBoundX = Lang13.IntNullable( location.x );
			lowBoundY = Lang13.IntNullable( location.y );
			hiBoundX = Lang13.IntNullable( location.x + Rand13.Int( lX ??0, uX ??0 ) );
			hiBoundY = Lang13.IntNullable( location.y + Rand13.Int( lY ??0, uY ??0 ) );
			z = Convert.ToInt32( location.z );
			i = null;
			i = lowBoundX;

			while (( i ??0) <= ( hiBoundX ??0)) {
				j = null;
				j = lowBoundY;

				while (( j ??0) <= ( hiBoundY ??0)) {
					T = Map13.GetTile( i ??0, j ??0, z );

					if ( i == lowBoundX || i == hiBoundX || j == lowBoundY || j == hiBoundY ) {
						T.ChangeTurf( typeof(Tile_Simulated_Wall_Vault) );
					} else {
						T.ChangeTurf( typeof(Tile_Simulated_Floor_Vault) );
					}
					T.icon_state = "" + type + "vault";
					j++;
				}
				i++;
			}
			GlobalFuncs.qdel( this );
			return;
		}

	}

}