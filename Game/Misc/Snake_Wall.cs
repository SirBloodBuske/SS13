// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Snake_Wall : Snake {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dir = 2;
		}

		// Function from file: snake.dm
		public Snake_Wall ( int? xx = null, int? yy = null ) {
			this.x = xx;
			this.y = yy;
			return;
		}

	}

}