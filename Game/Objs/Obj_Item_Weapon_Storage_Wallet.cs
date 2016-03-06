// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Wallet : Obj_Item_Weapon_Storage {

		public Obj_Item_Weapon_Card_Id front_id = null;
		public ByTable combined_access = new ByTable();

		protected override void __FieldInit() {
			base.__FieldInit();

			this.storage_slots = 4;
			this.w_class = 2;
			this.burn_state = 0;
			this.can_hold = new ByTable(new object [] { 
				typeof(Obj_Item_Stack_Spacecash), 
				typeof(Obj_Item_Weapon_Card), 
				typeof(Obj_Item_Clothing_Mask_Cigarette), 
				typeof(Obj_Item_Device_Flashlight_Pen), 
				typeof(Obj_Item_Seeds), 
				typeof(Obj_Item_Stack_Medical), 
				typeof(Obj_Item_Toy_Crayon), 
				typeof(Obj_Item_Weapon_Coin), 
				typeof(Obj_Item_Weapon_Dice), 
				typeof(Obj_Item_Weapon_Disk), 
				typeof(Obj_Item_Weapon_Implanter), 
				typeof(Obj_Item_Weapon_Lighter), 
				typeof(Obj_Item_Weapon_Lipstick), 
				typeof(Obj_Item_Weapon_Match), 
				typeof(Obj_Item_Weapon_Paper), 
				typeof(Obj_Item_Weapon_Pen), 
				typeof(Obj_Item_Weapon_Photo), 
				typeof(Obj_Item_Weapon_ReagentContainers_Dropper), 
				typeof(Obj_Item_Weapon_ReagentContainers_Syringe), 
				typeof(Obj_Item_Weapon_Screwdriver), 
				typeof(Obj_Item_Weapon_Stamp)
			 });
			this.slot_flags = 256;
			this.icon_state = "wallet";
		}

		public Obj_Item_Weapon_Storage_Wallet ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wallets.dm
		public override dynamic GetAccess(  ) {
			
			if ( this.combined_access.len != 0 ) {
				return this.combined_access;
			} else {
				return base.GetAccess();
			}
		}

		// Function from file: wallets.dm
		public override dynamic GetID(  ) {
			return this.front_id;
		}

		// Function from file: wallets.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.front_id != null ) {
				
				switch ((string)( this.front_id.icon_state )) {
					case "id":
						this.icon_state = "walletid";
						return false;
						break;
					case "silver":
						this.icon_state = "walletid_silver";
						return false;
						break;
					case "gold":
						this.icon_state = "walletid_gold";
						return false;
						break;
					case "centcom":
						this.icon_state = "walletid_centcom";
						return false;
						break;
				}
			}
			this.icon_state = "wallet";
			return false;
		}

		// Function from file: wallets.dm
		public override bool handle_item_insertion( dynamic W = null, bool? prevent_warning = null, dynamic user = null ) {
			prevent_warning = prevent_warning ?? false;

			bool _default = false;

			_default = base.handle_item_insertion( (object)(W), prevent_warning, (object)(user) );

			if ( _default ) {
				
				if ( W is Obj_Item_Weapon_Card_Id ) {
					this.refreshID();
				}
			}
			return _default;
		}

		// Function from file: wallets.dm
		public void refreshID(  ) {
			Obj_Item_Weapon_Card_Id I = null;

			this.combined_access.Cut();

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item_Weapon_Card_Id) )) {
				I = _a;
				

				if ( !( this.front_id != null ) ) {
					this.front_id = I;
					this.update_icon();
				}
				this.combined_access.Or( I.access );
			}
			return;
		}

		// Function from file: wallets.dm
		public override bool remove_from_storage( dynamic W = null, dynamic new_location = null, bool? burn = null ) {
			bool _default = false;

			_default = base.remove_from_storage( (object)(W), (object)(new_location), burn );

			if ( _default ) {
				
				if ( W is Obj_Item_Weapon_Card_Id ) {
					
					if ( W == this.front_id ) {
						this.front_id = null;
					}
					this.refreshID();
					this.update_icon();
				}
			}
			return _default;
		}

	}

}