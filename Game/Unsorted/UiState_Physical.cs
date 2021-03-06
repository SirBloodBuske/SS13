// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UiState_Physical : UiState {

		// Function from file: physical.dm
		public override int can_use_topic( Game_Data src_object = null, dynamic user = null ) {
			int _default = 0;

			_default = ((Mob)user).shared_ui_interaction( src_object );

			if ( _default > -1 ) {
				return Num13.MinInt( _default, ((Mob)user).physical_can_use_topic( src_object ) );
			}
			return _default;
		}

	}

}