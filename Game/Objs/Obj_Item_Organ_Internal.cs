// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal : Obj_Item_Organ {

		public string zone = "chest";
		public string slot = null;
		public bool vital = false;
		public string organ_action_name = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "biotech=2";
			this.force = 1;
			this.w_class = 2;
		}

		public Obj_Item_Organ_Internal ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: organ_internal.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			dynamic H = null;
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Organ S = null;

			
			if ( M == user && user is Mob_Living_Carbon_Human ) {
				H = user;

				if ( this.status == 1 ) {
					S = this.prepare_eat();

					if ( S != null ) {
						H.drop_item();
						((Mob)H).put_in_active_hand( S );
						S.attack( H, H );
						GlobalFuncs.qdel( this );
					}
				}
			} else {
				base.attack( (object)(M), (object)(user), def_zone );
			}
			return false;
		}

		// Function from file: organ_internal.dm
		public override dynamic Destroy(  ) {
			
			if ( Lang13.Bool( this.owner ) ) {
				this.Remove( this.owner, true );
			}
			return base.Destroy();
		}

		// Function from file: organ_internal.dm
		public virtual Obj_Item_Weapon_ReagentContainers_Food_Snacks_Organ prepare_eat(  ) {
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Organ S = null;

			S = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Organ();
			S.name = this.name;
			S.desc = this.desc;
			S.icon = this.icon;
			S.icon_state = this.icon_state;
			S.origin_tech = this.origin_tech;
			S.w_class = this.w_class;
			return S;
		}

		// Function from file: organ_internal.dm
		public virtual void on_life(  ) {
			return;
		}

		// Function from file: organ_internal.dm
		public virtual void on_find( dynamic finder = null ) {
			return;
		}

		// Function from file: organ_internal.dm
		public virtual void Remove( dynamic M = null, bool? special = null ) {
			special = special ?? false;

			this.owner = null;

			if ( Lang13.Bool( M ) ) {
				M.internal_organs.Remove( this );

				if ( this.vital && !( special == true ) ) {
					((Mob)M).death();
				}
			}

			if ( Lang13.Bool( this.organ_action_name ) ) {
				this.action_button_name = null;
			}
			return;
		}

		// Function from file: organ_internal.dm
		public virtual void Insert( dynamic M = null, int? special = null ) {
			special = special ?? 0;

			Obj_Item_Organ_Internal replaced = null;

			
			if ( !( M is Mob_Living_Carbon ) || this.owner == M ) {
				return;
			}
			replaced = ((Mob)M).getorganslot( this.slot );

			if ( replaced != null ) {
				replaced.Remove( M, true );
			}
			this.owner = M;
			M.internal_organs.Or( this );
			this.loc = null;

			if ( Lang13.Bool( this.organ_action_name ) ) {
				this.action_button_name = this.organ_action_name;
			}
			return;
		}

	}

}