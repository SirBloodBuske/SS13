// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Datacore : Game_Data {

		public ByTable medical = new ByTable();
		public int medicalPrintCount = 0;
		public ByTable general = new ByTable();
		public ByTable security = new ByTable();
		public int securityPrintCount = 0;
		public int securityCrimeCounter = 0;
		public ByTable locked = new ByTable();

		// Function from file: datacore.dm
		public Icon get_id_photo( dynamic H = null ) {
			Job J = null;
			Preferences P = null;

			J = GlobalVars.SSjob.GetJob( H.mind.assigned_role );
			P = H.client.prefs;
			return GlobalFuncs.get_flat_human_icon( null, J.outfit, P );
		}

		// Function from file: datacore.dm
		public void manifest_inject( dynamic H = null ) {
			dynamic assignment = null;
			string id = null;
			Icon image = null;
			Obj_Item_Weapon_Photo photo_front = null;
			Obj_Item_Weapon_Photo photo_side = null;
			Data_Record G = null;
			Data_Record M = null;
			Data_Record S = null;
			Data_Record L = null;

			
			if ( Lang13.Bool( H.mind ) && H.mind.assigned_role != H.mind.special_role ) {
				
				if ( Lang13.Bool( H.mind.assigned_role ) ) {
					assignment = H.mind.assigned_role;
				} else if ( Lang13.Bool( H.job ) ) {
					assignment = H.job;
				} else {
					assignment = "Unassigned";
				}
				id = GlobalFuncs.num2hex( GlobalVars.record_id_num++, 6 );
				image = this.get_id_photo( H );
				photo_front = new Obj_Item_Weapon_Photo();
				photo_side = new Obj_Item_Weapon_Photo();
				photo_front.photocreate( null, new Icon( image, null, GlobalVars.SOUTH ) );
				photo_side.photocreate( null, new Icon( image, null, GlobalVars.WEST ) );
				G = new Data_Record();
				G.fields["id"] = id;
				G.fields["name"] = H.real_name;
				G.fields["rank"] = assignment;
				G.fields["age"] = H.age;

				if ( GlobalVars.config.mutant_races ) {
					G.fields["species"] = H.dna.species.name;
				}
				G.fields["fingerprint"] = Num13.Md5( H.dna.uni_identity );
				G.fields["p_stat"] = "Active";
				G.fields["m_stat"] = "Stable";
				G.fields["sex"] = H.gender;
				G.fields["photo_front"] = photo_front;
				G.fields["photo_side"] = photo_side;
				this.general.Add( G );
				M = new Data_Record();
				M.fields["id"] = id;
				M.fields["name"] = H.real_name;
				M.fields["blood_type"] = H.dna.blood_type;
				M.fields["b_dna"] = H.dna.unique_enzymes;
				M.fields["mi_dis"] = "None";
				M.fields["mi_dis_d"] = "No minor disabilities have been declared.";
				M.fields["ma_dis"] = "None";
				M.fields["ma_dis_d"] = "No major disabilities have been diagnosed.";
				M.fields["alg"] = "None";
				M.fields["alg_d"] = "No allergies have been detected in this patient.";
				M.fields["cdi"] = "None";
				M.fields["cdi_d"] = "No diseases have been diagnosed at the moment.";
				M.fields["notes"] = "No notes.";
				this.medical.Add( M );
				S = new Data_Record();
				S.fields["id"] = id;
				S.fields["name"] = H.real_name;
				S.fields["criminal"] = "None";
				S.fields["mi_crim"] = new ByTable();
				S.fields["ma_crim"] = new ByTable();
				S.fields["notes"] = "No notes.";
				this.security.Add( S );
				L = new Data_Record();
				L.fields["id"] = Num13.Md5( "" + H.real_name + H.mind.assigned_role );
				L.fields["name"] = H.real_name;
				L.fields["rank"] = H.mind.assigned_role;
				L.fields["age"] = H.age;
				L.fields["sex"] = H.gender;
				L.fields["blood_type"] = H.dna.blood_type;
				L.fields["b_dna"] = H.dna.unique_enzymes;
				L.fields["enzymes"] = H.dna.struc_enzymes;
				L.fields["identity"] = H.dna.uni_identity;
				L.fields["species"] = H.dna.species.type;
				L.fields["features"] = H.dna.features;
				L.fields["image"] = image;
				this.locked.Add( L );
			}
			return;
		}

		// Function from file: datacore.dm
		public dynamic get_manifest( dynamic monochrome = null, bool? OOC = null ) {
			ByTable heads = null;
			ByTable sec = null;
			ByTable eng = null;
			ByTable med = null;
			ByTable sci = null;
			ByTable sup = null;
			ByTable civ = null;
			ByTable bot = null;
			ByTable misc = null;
			dynamic dat = null;
			bool even = false;
			Data_Record t = null;
			dynamic name = null;
			dynamic rank = null;
			bool department = false;
			dynamic name2 = null;
			dynamic name3 = null;
			dynamic name4 = null;
			dynamic name5 = null;
			dynamic name6 = null;
			dynamic name7 = null;
			dynamic name8 = null;
			dynamic name9 = null;
			dynamic name10 = null;

			heads = new ByTable();
			sec = new ByTable();
			eng = new ByTable();
			med = new ByTable();
			sci = new ByTable();
			sup = new ByTable();
			civ = new ByTable();
			bot = new ByTable();
			misc = new ByTable();
			dat = "\n	<head><style>\n		.manifest {border-collapse:collapse;}\n		.manifest td, th {border:1px solid " + ( Lang13.Bool( monochrome ) ? "black" : "#DEF; background-color:white; color:black" ) + "; padding:.25em}\n		.manifest th {height: 2em; " + ( Lang13.Bool( monochrome ) ? "border-top-width: 3px" : "background-color: #48C; color:white" ) + "}\n		.manifest tr.head th { " + ( Lang13.Bool( monochrome ) ? "border-top-width: 1px" : "background-color: #488;" ) + " }\n		.manifest td:first-child {text-align:right}\n		.manifest tr.alt td {" + ( Lang13.Bool( monochrome ) ? "border-top-width: 2px" : "background-color: #DEF" ) + @"}
	</style></head>
	<table class=""manifest"" width='350px'>
	<tr class='head'><th>Name</th><th>Rank</th></tr>
	";
			even = false;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.data_core.general, typeof(Data_Record) )) {
				t = _a;
				
				name = t.fields["name"];
				rank = t.fields["rank"];
				department = false;

				if ( GlobalVars.command_positions.Contains( rank ) ) {
					heads[name] = rank;
					department = true;
				}

				if ( GlobalVars.security_positions.Contains( rank ) ) {
					sec[name] = rank;
					department = true;
				}

				if ( GlobalVars.engineering_positions.Contains( rank ) ) {
					eng[name] = rank;
					department = true;
				}

				if ( GlobalVars.medical_positions.Contains( rank ) ) {
					med[name] = rank;
					department = true;
				}

				if ( GlobalVars.science_positions.Contains( rank ) ) {
					sci[name] = rank;
					department = true;
				}

				if ( GlobalVars.supply_positions.Contains( rank ) ) {
					sup[name] = rank;
					department = true;
				}

				if ( GlobalVars.civilian_positions.Contains( rank ) ) {
					civ[name] = rank;
					department = true;
				}

				if ( GlobalVars.nonhuman_positions.Contains( rank ) ) {
					bot[name] = rank;
					department = true;
				}

				if ( !department && !heads.Contains( name ) ) {
					misc[name] = rank;
				}
			}

			if ( heads.len > 0 ) {
				dat += "<tr><th colspan=3>Heads</th></tr>";

				foreach (dynamic _b in Lang13.Enumerate( heads )) {
					name2 = _b;
					
					dat += "<tr" + ( even ? " class='alt'" : "" ) + "><td>" + name2 + "</td><td>" + heads[name2] + "</td></tr>";
					even = !even;
				}
			}

			if ( sec.len > 0 ) {
				dat += "<tr><th colspan=3>Security</th></tr>";

				foreach (dynamic _c in Lang13.Enumerate( sec )) {
					name3 = _c;
					
					dat += "<tr" + ( even ? " class='alt'" : "" ) + "><td>" + name3 + "</td><td>" + sec[name3] + "</td></tr>";
					even = !even;
				}
			}

			if ( eng.len > 0 ) {
				dat += "<tr><th colspan=3>Engineering</th></tr>";

				foreach (dynamic _d in Lang13.Enumerate( eng )) {
					name4 = _d;
					
					dat += "<tr" + ( even ? " class='alt'" : "" ) + "><td>" + name4 + "</td><td>" + eng[name4] + "</td></tr>";
					even = !even;
				}
			}

			if ( med.len > 0 ) {
				dat += "<tr><th colspan=3>Medical</th></tr>";

				foreach (dynamic _e in Lang13.Enumerate( med )) {
					name5 = _e;
					
					dat += "<tr" + ( even ? " class='alt'" : "" ) + "><td>" + name5 + "</td><td>" + med[name5] + "</td></tr>";
					even = !even;
				}
			}

			if ( sci.len > 0 ) {
				dat += "<tr><th colspan=3>Science</th></tr>";

				foreach (dynamic _f in Lang13.Enumerate( sci )) {
					name6 = _f;
					
					dat += "<tr" + ( even ? " class='alt'" : "" ) + "><td>" + name6 + "</td><td>" + sci[name6] + "</td></tr>";
					even = !even;
				}
			}

			if ( sup.len > 0 ) {
				dat += "<tr><th colspan=3>Supply</th></tr>";

				foreach (dynamic _g in Lang13.Enumerate( sup )) {
					name7 = _g;
					
					dat += "<tr" + ( even ? " class='alt'" : "" ) + "><td>" + name7 + "</td><td>" + sup[name7] + "</td></tr>";
					even = !even;
				}
			}

			if ( civ.len > 0 ) {
				dat += "<tr><th colspan=3>Civilian</th></tr>";

				foreach (dynamic _h in Lang13.Enumerate( civ )) {
					name8 = _h;
					
					dat += "<tr" + ( even ? " class='alt'" : "" ) + "><td>" + name8 + "</td><td>" + civ[name8] + "</td></tr>";
					even = !even;
				}
			}

			if ( bot.len > 0 ) {
				dat += "<tr><th colspan=3>Silicon</th></tr>";

				foreach (dynamic _i in Lang13.Enumerate( bot )) {
					name9 = _i;
					
					dat += "<tr" + ( even ? " class='alt'" : "" ) + "><td>" + name9 + "</td><td>" + bot[name9] + "</td></tr>";
					even = !even;
				}
			}

			if ( misc.len > 0 ) {
				dat += "<tr><th colspan=3>Miscellaneous</th></tr>";

				foreach (dynamic _j in Lang13.Enumerate( misc )) {
					name10 = _j;
					
					dat += "<tr" + ( even ? " class='alt'" : "" ) + "><td>" + name10 + "</td><td>" + misc[name10] + "</td></tr>";
					even = !even;
				}
			}
			dat += "</table>";
			dat = GlobalFuncs.replacetext( dat, "\n", "" );
			dat = GlobalFuncs.replacetext( dat, "	", "" );
			return dat;
		}

		// Function from file: datacore.dm
		public void manifest_modify( dynamic name = null, dynamic assignment = null ) {
			Data_Record foundrecord = null;

			foundrecord = GlobalFuncs.find_record( "name", name, GlobalVars.data_core.general );

			if ( foundrecord != null ) {
				foundrecord.fields["rank"] = assignment;
			}
			return;
		}

		// Function from file: datacore.dm
		public void manifest( bool? nosleep = null ) {
			nosleep = nosleep ?? false;

			Mob_Living_Carbon_Human H = null;

			Task13.Schedule( 0, (Task13.Closure)(() => {
				
				if ( !( nosleep == true ) ) {
					Task13.Sleep( 40 );
				}

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Carbon_Human) )) {
					H = _a;
					
					this.manifest_inject( H );
				}
				return;
				return;
			}));
			return;
		}

		// Function from file: datacore.dm
		public void addMajorCrime( string id = null, Data_Crime crime = null ) {
			id = id ?? "";

			Data_Record R = null;
			dynamic crimes = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.security, typeof(Data_Record) )) {
				R = _a;
				

				if ( R.fields["id"] == id ) {
					crimes = R.fields["ma_crim"];
					crimes |= crime;
					return;
				}
			}
			return;
		}

		// Function from file: datacore.dm
		public void removeMajorCrime( dynamic id = null, string cDataId = null ) {
			Data_Record R = null;
			dynamic crimes = null;
			Data_Crime crime = null;

			
			foreach (dynamic _b in Lang13.Enumerate( this.security, typeof(Data_Record) )) {
				R = _b;
				

				if ( R.fields["id"] == id ) {
					crimes = R.fields["ma_crim"];

					foreach (dynamic _a in Lang13.Enumerate( crimes, typeof(Data_Crime) )) {
						crime = _a;
						

						if ( crime.dataId == String13.ParseNumber( cDataId ) ) {
							crimes -= crime;
							return;
						}
					}
				}
			}
			return;
		}

		// Function from file: datacore.dm
		public void removeMinorCrime( dynamic id = null, string cDataId = null ) {
			Data_Record R = null;
			dynamic crimes = null;
			Data_Crime crime = null;

			
			foreach (dynamic _b in Lang13.Enumerate( this.security, typeof(Data_Record) )) {
				R = _b;
				

				if ( R.fields["id"] == id ) {
					crimes = R.fields["mi_crim"];

					foreach (dynamic _a in Lang13.Enumerate( crimes, typeof(Data_Crime) )) {
						crime = _a;
						

						if ( crime.dataId == String13.ParseNumber( cDataId ) ) {
							crimes -= crime;
							return;
						}
					}
				}
			}
			return;
		}

		// Function from file: datacore.dm
		public void addMinorCrime( string id = null, Data_Crime crime = null ) {
			id = id ?? "";

			Data_Record R = null;
			dynamic crimes = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.security, typeof(Data_Record) )) {
				R = _a;
				

				if ( R.fields["id"] == id ) {
					crimes = R.fields["mi_crim"];
					crimes |= crime;
					return;
				}
			}
			return;
		}

		// Function from file: datacore.dm
		public Data_Crime createCrimeEntry( string cname = null, string cdetails = null, dynamic author = null, string time = null ) {
			cname = cname ?? "";
			cdetails = cdetails ?? "";
			author = author ?? "";
			time = time ?? "";

			Data_Crime c = null;

			c = new Data_Crime();
			c.crimeName = cname;
			c.crimeDetails = cdetails;
			c.author = author;
			c.time = time;
			c.dataId = ++this.securityCrimeCounter;
			return c;
		}

	}

}