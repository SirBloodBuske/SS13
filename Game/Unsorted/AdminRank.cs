// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AdminRank : Game_Data {

		public dynamic name = "NoRank";
		public dynamic rights = 0;
		public ByTable adds = null;
		public ByTable subs = null;

		// Function from file: admin_ranks.dm
		public AdminRank ( dynamic init_name = null, dynamic init_rights = null, ByTable init_adds = null, ByTable init_subs = null ) {
			this.name = init_name;

			dynamic _a = this.name; // Was a switch-case, sorry for the mess.
			if ( _a=="Removed" || _a==null || _a=="" ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					GlobalFuncs.qdel( this );
					return;
				}));
				throw new Exception( "invalid admin-rank name" );
				return;
			}

			if ( Lang13.Bool( init_rights ) ) {
				this.rights = init_rights;
			}

			if ( !( init_adds != null ) ) {
				init_adds = new ByTable();
			}

			if ( !( init_subs != null ) ) {
				init_subs = new ByTable();
			}
			this.adds = init_adds;
			this.subs = init_subs;
			return;
		}

		// Function from file: admin_ranks.dm
		public void process_keyword( dynamic word = null, dynamic previous_rights = null ) {
			previous_rights = previous_rights ?? 0;

			dynamic flag = null;
			Type path = null;

			flag = GlobalFuncs.admin_keyword_to_flag( word, previous_rights );

			if ( Lang13.Bool( flag ) ) {
				
				switch ((int)( String13.GetCharCode( word, 1 ) )) {
					case 43:
						this.rights |= flag;
						break;
					case 45:
						this.rights &= ~flag;
						break;
				}
			} else {
				path = GlobalFuncs.admin_keyword_to_path( word );

				if ( path != null ) {
					
					switch ((int)( String13.GetCharCode( word, 1 ) )) {
						case 43:
							
							if ( !this.subs.Remove( path ) ) {
								this.adds.Add( path );
							}
							break;
						case 45:
							
							if ( !this.adds.Remove( path ) ) {
								this.subs.Add( path );
							}
							break;
					}
				}
			}
			return;
		}

	}

}