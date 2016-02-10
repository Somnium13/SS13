// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Migration_Mysql : Migration {

		public DBConnection db = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dbms = "mysql";
		}

		// Function from file: mysql_migration.dm
		public Migration_Mysql ( dynamic mc = null ) : base( (object)(mc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( mc is MigrationController_Mysql ) {
				this.db = mc.db;
			}
			return;
		}

		// Function from file: mysql_migration.dm
		public override dynamic hasColumn( string tableName = null, string columnName = null ) {
			return this.hasResult( "SHOW COLUMNS FROM " + tableName + " LIKE '" + columnName + "'" );
		}

		// Function from file: mysql_migration.dm
		public override dynamic hasTable( string tableName = null ) {
			return this.hasResult( "SHOW TABLES LIKE '" + tableName + "'" );
		}

		// Function from file: mysql_migration.dm
		public override bool? execute( string sql = null ) {
			DBQuery query = null;

			query = this.db.NewQuery( sql );

			if ( !query.Execute() ) {
				Game13.log.WriteMsg( "Error in " + this.package + "#" + this.id + ": " + query.ErrorMsg() );
				return GlobalVars.FALSE;
			}
			return GlobalVars.TRUE;
		}

		// Function from file: mysql_migration.dm
		public override dynamic hasResult( string sql = null ) {
			DBQuery query = null;

			query = this.db.NewQuery( sql );

			if ( !query.Execute() ) {
				Game13.log.WriteMsg( "Error in " + this.package + "#" + this.id + ": " + query.ErrorMsg() );
				return GlobalVars.FALSE;
			}

			if ( query.NextRow() ) {
				return GlobalVars.TRUE;
			}
			return GlobalVars.FALSE;
		}

		// Function from file: mysql_migration.dm
		public override dynamic query( string sql = null ) {
			DBQuery query = null;
			ByTable rows = null;

			query = this.db.NewQuery( sql );

			if ( !query.Execute() ) {
				Game13.log.WriteMsg( "Error in " + this.package + "#" + this.id + ": " + query.ErrorMsg() );
				return GlobalVars.FALSE;
			}
			rows = new ByTable();

			while (query.NextRow()) {
				rows.Add( new ByTable(new object [] { query.item }) );
			}
			return rows;
		}

	}

}