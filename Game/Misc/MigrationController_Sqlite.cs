// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MigrationController_Sqlite : MigrationController {

		public string dbfilename = "";
		public string empty_dbfilename = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.id = "sqlite";
		}

		// Function from file: sqlite_controller.dm
		public MigrationController_Sqlite ( string dbfile = null, string cleandbfile = null ) {
			this.dbfilename = dbfile;
			this.empty_dbfilename = cleandbfile;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: sqlite_controller.dm
		public override bool? hasTable( string tableName = null ) {
			return this.hasResult( "SELECT name FROM sqlite_master WHERE type='" + tableName + "'" );
		}

		// Function from file: sqlite_controller.dm
		public override bool? hasResult( string sql = null ) {
			Database_Query Q = null;

			Q = new Database_Query();
			Q.Add( sql );

			if ( !Lang13.Bool( Q.Execute( this.dbfilename ) ) ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "Error in migration controller (" + this.id + "): " + Q.ErrorMsg() ) );
				return GlobalVars.FALSE;
			}

			if ( Lang13.Bool( Q.NextRow() ) ) {
				return GlobalVars.TRUE;
			}
			return GlobalVars.FALSE;
		}

		// Function from file: sqlite_controller.dm
		public override ByTable query( string sql = null ) {
			Database_Query Q = null;
			ByTable O = null;

			Q = new Database_Query();
			Q.Add( sql );

			if ( !Lang13.Bool( Q.Execute( this.dbfilename ) ) ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "Error in migration controller (" + this.id + "): " + Q.ErrorMsg() ) );
				return null;
			}
			O = new ByTable();

			while (Lang13.Bool( Q.NextRow() )) {
				O.Add( new ByTable(new object [] { Q.GetRowData() }) );
			}
			return O;
		}

		// Function from file: sqlite_controller.dm
		public override dynamic execute( string sql = null ) {
			Database_Query Q = null;

			Q = new Database_Query();
			Q.Add( sql );

			if ( !Lang13.Bool( Q.Execute( this.dbfilename ) ) ) {
				Game13.log.WriteMsg( "## WARNING: " + ( "Error in migration controller (" + this.id + "): " + Q.ErrorMsg() ) );
				return GlobalVars.FALSE;
			}
			return GlobalVars.TRUE;
		}

		// Function from file: sqlite_controller.dm
		public override bool? createMigrationTable(  ) {
			string tableSQL = null;

			tableSQL = "\nCREATE TABLE IF NOT EXISTS " + this.TABLE_NAME + @" (
	pkgID TEXT NOT NULL,
	version INTEGER NOT NULL,
	PRIMARY KEY(pkgID)
);
	";
			this.execute( tableSQL );
			return null;
		}

		// Function from file: sqlite_controller.dm
		public override bool? setup(  ) {
			
			if ( !File13.Exists( "players2.sqlite" ) && File13.Exists( "players2_empty.sqlite" ) ) {
				File13.Copy( "players2_empty.sqlite", "players2.sqlite" );
			}
			return GlobalVars.TRUE;
		}

	}

}