// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGeneratorModule : Game_Data {

		public MapGenerator mother = null;
		public dynamic spawnableAtoms = new ByTable();
		public ByTable spawnableTurfs = new ByTable();
		public int clusterMax = 5;
		public int clusterMin = 1;
		public int clusterCheckFlags = 16;
		public bool allowAtomsOnSpace = false;

		// Function from file: mapGeneratorModule.dm
		public bool checkPlaceAtom( dynamic T = null ) {
			bool _default = false;

			Ent_Static A = null;

			_default = true;

			if ( !Lang13.Bool( T ) ) {
				return false;
			}

			if ( T.density ) {
				_default = false;
			}

			foreach (dynamic _a in Lang13.Enumerate( T, typeof(Ent_Static) )) {
				A = _a;
				

				if ( A.density ) {
					_default = false;
					break;
				}
			}

			if ( !this.allowAtomsOnSpace && T is Tile_Space ) {
				_default = false;
			}
			return _default;
		}

		// Function from file: mapGeneratorModule.dm
		public bool place( dynamic T = null ) {
			bool _default = false;

			int? clustering = null;
			bool? skipLoopIteration = null;
			dynamic turfPath = null;
			dynamic F = null;
			dynamic F2 = null;
			dynamic atomPath = null;
			Ent_Dynamic M = null;
			Ent_Dynamic M2 = null;

			
			if ( !Lang13.Bool( T ) ) {
				return false;
			}
			clustering = 0;
			skipLoopIteration = GlobalVars.FALSE;

			foreach (dynamic _c in Lang13.Enumerate( this.spawnableTurfs )) {
				turfPath = _c;
				

				if ( this.clusterMax != 0 && this.clusterMin != 0 ) {
					
					if ( ( this.clusterCheckFlags & 8 ) != 0 ) {
						clustering = Rand13.Int( this.clusterMin, this.clusterMax );

						foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.trange( clustering, T ) )) {
							F = _a;
							

							if ( Lang13.Bool( turfPath.IsInstanceOfType( F ) ) ) {
								skipLoopIteration = GlobalVars.TRUE;
								break;
							}
						}

						if ( skipLoopIteration == true ) {
							skipLoopIteration = GlobalVars.FALSE;
							continue;
						}
					}

					if ( ( this.clusterCheckFlags & 2 ) != 0 ) {
						clustering = Rand13.Int( this.clusterMin, this.clusterMax );

						foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.trange( clustering, T ) )) {
							F2 = _b;
							

							if ( !Lang13.Bool( turfPath.IsInstanceOfType( F2 ) ) ) {
								skipLoopIteration = GlobalVars.TRUE;
								break;
							}
						}

						if ( skipLoopIteration == true ) {
							skipLoopIteration = GlobalVars.FALSE;
							continue;
						}
					}
				}

				if ( Rand13.PercentChance( Convert.ToInt32( this.spawnableTurfs[turfPath] ) ) ) {
					((Tile)T).ChangeTurf( turfPath );
				}
			}

			if ( this.checkPlaceAtom( T ) ) {
				
				foreach (dynamic _f in Lang13.Enumerate( this.spawnableAtoms )) {
					atomPath = _f;
					

					if ( this.clusterMax != 0 && this.clusterMin != 0 ) {
						
						if ( ( this.clusterCheckFlags & 16 ) != 0 ) {
							clustering = Rand13.Int( this.clusterMin, this.clusterMax );

							foreach (dynamic _d in Lang13.Enumerate( Map13.FetchInRange( T, clustering ), typeof(Ent_Dynamic) )) {
								M = _d;
								

								if ( Lang13.Bool( atomPath.IsInstanceOfType( M ) ) ) {
									skipLoopIteration = GlobalVars.TRUE;
									break;
								}
							}

							if ( skipLoopIteration == true ) {
								skipLoopIteration = GlobalVars.FALSE;
								continue;
							}
						}

						if ( ( this.clusterCheckFlags & 4 ) != 0 ) {
							clustering = Rand13.Int( this.clusterMin, this.clusterMax );

							foreach (dynamic _e in Lang13.Enumerate( Map13.FetchInRange( T, clustering ), typeof(Ent_Dynamic) )) {
								M2 = _e;
								

								if ( !Lang13.Bool( atomPath.IsInstanceOfType( M2 ) ) ) {
									skipLoopIteration = GlobalVars.TRUE;
									break;
								}
							}

							if ( skipLoopIteration == true ) {
								skipLoopIteration = GlobalVars.FALSE;
								continue;
							}
						}
					}

					if ( Rand13.PercentChance( Convert.ToInt32( this.spawnableAtoms[atomPath] ) ) ) {
						Lang13.Call( atomPath, T );
					}
				}
			}
			_default = true;
			return _default;
		}

		// Function from file: mapGeneratorModule.dm
		public virtual void generate(  ) {
			ByTable map = null;
			dynamic T = null;

			
			if ( !( this.mother != null ) ) {
				return;
			}
			map = this.mother.map;

			foreach (dynamic _a in Lang13.Enumerate( map )) {
				T = _a;
				
				this.place( T );
			}
			return;
		}

		// Function from file: mapGeneratorModule.dm
		public void sync( MapGenerator mum = null ) {
			this.mother = null;

			if ( mum != null ) {
				this.mother = mum;
			}
			return;
		}

	}

}