// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent : Game_Data {

		public string name = "Reagent";
		public string id = "reagent";
		public string description = "";
		public Game_Data holder = null;
		public int reagent_state = 1;
		public dynamic data = null;
		public double? volume = 0;
		public double nutriment_factor = 0;
		public double sport = 1;
		public double? custom_metabolism = 0.2;
		public double? custom_plant_metabolism = 1;
		public double? overdose = 0;
		public bool overdose_dam = true;
		public string color = "#000000";
		public int alpha = 255;

		// Function from file: Chemistry-Reagents.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.holder is Reagents ) {
				((dynamic)this.holder).reagent_list -= this;
				this.holder = null;
			}
			return null;
		}

		// Function from file: vg.dm
		public virtual bool reagent_deleted(  ) {
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public virtual bool on_removal( dynamic data = null ) {
			return true;
		}

		// Function from file: Chemistry-Reagents.dm
		public virtual void on_update( dynamic A = null ) {
			return;
		}

		// Function from file: Chemistry-Reagents.dm
		public virtual void on_merge( dynamic data = null ) {
			return;
		}

		// Function from file: Chemistry-Reagents.dm
		public void on_new( dynamic data = null ) {
			return;
		}

		// Function from file: Chemistry-Reagents.dm
		public void on_move( dynamic M = null ) {
			return;
		}

		// Function from file: Chemistry-Reagents.dm
		public virtual void on_plant_life( Obj_Machinery_PortableAtmospherics_Hydroponics T = null ) {
			
			if ( !( this.holder != null ) ) {
				return;
			}

			if ( !( T != null ) ) {
				T = ((dynamic)this.holder).my_atom;
			}

			if ( !( T is Obj_Machinery_PortableAtmospherics_Hydroponics ) ) {
				return;
			}
			((dynamic)this.holder).remove_reagent( this.id, this.custom_plant_metabolism );
			return;
		}

		// Function from file: Chemistry-Reagents.dm
		public virtual bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( !( this.holder != null ) ) {
				return true;
			}

			if ( !( M != null ) ) {
				M = ((dynamic)this.holder).my_atom;
			}

			if ( !( M is Mob_Living ) ) {
				return true;
			}

			if ( Lang13.Bool( this.overdose ) && ( this.volume ??0) >= ( this.overdose ??0) ) {
				M.adjustToxLoss( this.overdose_dam );
			}
			((dynamic)this.holder).remove_reagent( this.id, this.custom_metabolism );

			if ( !( this.holder != null ) ) {
				return true;
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public virtual bool reaction_turf( dynamic T = null, double volume = 0 ) {
			
			if ( !( this.holder != null ) ) {
				return true;
			}

			if ( !( T is Tile_Simulated ) ) {
				return true;
			}
			Task13.Source = null;
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public virtual bool reaction_obj( dynamic O = null, double volume = 0 ) {
			
			if ( !( this.holder != null ) ) {
				return true;
			}

			if ( !( O is Obj ) ) {
				return true;
			}
			Task13.Source = null;
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public virtual bool reaction_animal( dynamic M = null, int? method = null, double volume = 0 ) {
			method = method ?? GlobalVars.TOUCH;

			Reagent self = null;

			
			if ( !( this.holder != null ) ) {
				return true;
			}

			if ( !( M is Mob_Living_SimpleAnimal ) ) {
				return true;
			}
			self = this;
			Task13.Source = null;
			((Mob_Living_SimpleAnimal)M).reagent_act( self.id, method, volume );
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public virtual bool reaction_mob( dynamic M = null, int? method = null, double volume = 0 ) {
			method = method ?? GlobalVars.TOUCH;

			Reagent self = null;
			dynamic chance = null;
			bool block = false;
			Obj_Item_Clothing C = null;

			
			if ( !( this.holder != null ) ) {
				return true;
			}

			if ( !( M is Mob_Living ) ) {
				return true;
			}
			self = this;
			Task13.Source = null;

			if ( self.holder != null && !( ((dynamic)self.holder).my_atom is Obj_Effect_Effect_Smoke_Chem ) ) {
				
				if ( method == GlobalVars.TOUCH ) {
					chance = 1;
					block = false;

					foreach (dynamic _a in Lang13.Enumerate( ((Mob)M).get_equipped_items(), typeof(Obj_Item_Clothing) )) {
						C = _a;
						

						if ( Convert.ToDouble( C.permeability_coefficient ) < Convert.ToDouble( chance ) ) {
							chance = C.permeability_coefficient;
						}

						if ( C is Obj_Item_Clothing_Suit_BioSuit ) {
							
							if ( Rand13.PercentChance( 75 ) ) {
								block = true;
							}
						}

						if ( C is Obj_Item_Clothing_Head_BioHood ) {
							
							if ( Rand13.PercentChance( 75 ) ) {
								block = true;
							}
						}
					}
					chance = chance * 100;

					if ( Rand13.PercentChance( Convert.ToInt32( chance ) ) && !block ) {
						
						if ( Lang13.Bool( M.reagents ) ) {
							((Reagents)M.reagents).add_reagent( self.id, ( self.volume ??0) / 2 );
						}
					}
				}
			}
			return false;
		}

	}

}