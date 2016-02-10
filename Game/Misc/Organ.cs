// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Organ : Game_Data {

		public string name = "organ";
		public Mob_Living_Carbon_Human owner = null;
		public int status = 0;
		public bool vital = false;
		public ByTable autopsy_data = new ByTable();
		public ByTable trace_chemicals = new ByTable();
		public double germ_level = 0;

		// Function from file: organ.dm
		public void add_autopsy_data( string used_weapon = null, double damage = 0 ) {
			AutopsyData W = null;

			W = this.autopsy_data[used_weapon];

			if ( !( W != null ) ) {
				W = new AutopsyData();
				W.weapon = used_weapon;
				this.autopsy_data[used_weapon] = W;
			}
			W.hits += 1;
			W.damage += damage;
			W.time_inflicted = Game13.time;
			return;
		}

		// Function from file: organ.dm
		public void handle_antibiotics(  ) {
			int antibiotics = 0;

			antibiotics = ((Reagents)this.owner.reagents).get_reagent_amount( "spaceacillin" ) ?1:0;

			if ( !( this.germ_level != 0 ) || antibiotics < 5 ) {
				return;
			}

			if ( this.germ_level < 100 ) {
				this.germ_level = 0;
			} else if ( this.germ_level < 500 ) {
				this.germ_level -= 6;
			} else {
				this.germ_level -= 2;
			}
			return;
		}

		// Function from file: organ.dm
		public virtual Icon get_icon( string race_icon = null, bool? deform_icon = null ) {
			return new Icon( "icons/mob/human.dmi", "blank" );
		}

		// Function from file: organ.dm
		public virtual dynamic Copy(  ) {
			dynamic I = null;

			I = Lang13.Call( this.type );
			I.vital = this.vital;
			I.name = this.name;
			I.owner = this.owner;
			I.status = this.status;
			I.autopsy_data = this.autopsy_data;
			I.trace_chemicals = this.trace_chemicals;
			I.germ_level = this.germ_level;
			return I;
		}

		// Function from file: organ.dm
		public bool receive_chem( dynamic chemical = null ) {
			return false;
		}

		// Function from file: organ.dm
		public virtual bool process(  ) {
			return false;
		}

	}

}