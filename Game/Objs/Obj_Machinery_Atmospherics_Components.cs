// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Components : Obj_Machinery_Atmospherics {

		public bool? welded = false;
		public bool showpipe = false;
		public ByTable parents = new ByTable();
		public ByTable airs = new ByTable();

		// Function from file: components_base.dm
		public Obj_Machinery_Atmospherics_Components ( dynamic loc = null, int? process = null ) : base( (object)(loc), process ) {
			double I = 0;
			GasMixture A = null;

			this.parents.len = this.device_type;
			this.airs.len = this.device_type;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, this.device_type )) {
				I = _a;
				
				A = new GasMixture();
				A.volume = 200;
				this.airs[I] = A;
			}
			return;
		}

		// Function from file: components_base.dm
		public override int ui_status( dynamic user = null, UiState state = null ) {
			
			if ( this.allowed( user ) ) {
				return base.ui_status( (object)(user), state );
			}
			user.WriteMsg( "<span class='danger'>Access denied.</span>" );
			return -1;
		}

		// Function from file: components_base.dm
		public override ByTable returnPipenets(  ) {
			ByTable _default = null;

			double I = 0;

			_default = new ByTable();

			foreach (dynamic _a in Lang13.IterateRange( 1, this.device_type )) {
				I = _a;
				
				_default.Add( this.returnPipenet( this.nodes[I] ) );
			}
			return _default;
		}

		// Function from file: components_base.dm
		public override void unsafe_pressure_release( dynamic user = null, double? pressures = null ) {
			dynamic T = null;
			GasMixture environment = null;
			dynamic lost = null;
			int times_lost = 0;
			double I = 0;
			dynamic air = null;
			dynamic shared_loss = null;
			dynamic to_release = null;
			double I2 = 0;
			dynamic air2 = null;

			base.unsafe_pressure_release( (object)(user), pressures );
			T = GlobalFuncs.get_turf( this );

			if ( Lang13.Bool( T ) ) {
				environment = ((Ent_Static)T).return_air();
				lost = null;
				times_lost = 0;

				foreach (dynamic _a in Lang13.IterateRange( 1, this.device_type )) {
					I = _a;
					
					air = this.airs[I];
					lost += ( pressures ??0) * ( environment.volume ??0) / Convert.ToDouble( air.temperature * 8.31 );
					times_lost++;
				}
				shared_loss = lost / times_lost;
				to_release = null;

				foreach (dynamic _b in Lang13.IterateRange( 1, this.device_type )) {
					I2 = _b;
					
					air2 = this.airs[I2];

					if ( !Lang13.Bool( to_release ) ) {
						to_release = air2.remove( shared_loss );
						continue;
					}
					to_release.merge( air2.remove( shared_loss ) );
				}
				((Ent_Static)T).assume_air( to_release );
				this.air_update_turf( true );
			}
			return;
		}

		// Function from file: components_base.dm
		public override void replacePipenet( Pipeline Old = null, Pipeline New = null ) {
			int I = 0;

			I = this.parents.Find( Old );
			this.parents[I] = New;
			return;
		}

		// Function from file: components_base.dm
		public override Pipeline returnPipenet( Obj_Machinery_Atmospherics A = null ) {
			A = A ?? this.nodes[1];

			dynamic I = null;

			I = this.nodes.Find( A );
			return this.parents[I];
		}

		// Function from file: components_base.dm
		public override void setPipenet( Pipeline reference = null, Obj_Machinery_Atmospherics A = null ) {
			dynamic I = null;

			I = this.nodes.Find( A );

			this.parents[I] = reference;
		}

		// Function from file: components_base.dm
		public override ByTable pipeline_expansion( Pipeline reference = null ) {
			int I = 0;

			
			if ( reference != null ) {
				I = this.parents.Find( reference );
				return new ByTable(new object [] { this.nodes[I] });
			} else {
				return base.pipeline_expansion( reference );
			}
		}

		// Function from file: components_base.dm
		public override dynamic returnPipenetAir( Pipeline reference = null ) {
			int I = 0;

			I = this.parents.Find( reference );
			return this.airs[I];
		}

		// Function from file: components_base.dm
		public override void build_network(  ) {
			double I = 0;
			Pipeline P = null;

			
			foreach (dynamic _a in Lang13.IterateRange( 1, this.device_type )) {
				I = _a;
				

				if ( !Lang13.Bool( this.parents[I] ) ) {
					this.parents[I] = new Pipeline();
					P = this.parents[I];
					P.build_pipeline( this );
				}
			}
			return;
		}

		// Function from file: components_base.dm
		public override void construction( dynamic pipe_type = null, dynamic obj_color = null ) {
			base.construction( (object)(pipe_type), (object)(obj_color) );
			this.update_parents();
			return;
		}

		// Function from file: components_base.dm
		public override void nullifyNode( double I = 0 ) {
			base.nullifyNode( I );

			if ( Lang13.Bool( this.nodes[I] ) ) {
				this.nullifyPipenet( this.parents[I] );
				GlobalFuncs.qdel( this.airs[I] );
				this.airs[I] = null;
			}
			return;
		}

		// Function from file: components_base.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			Ent_Static T = null;
			int? connected = null;
			double I = 0;

			this.update_icon_nopipes();
			this.underlays.Cut();
			T = this.loc;

			if ( this.level == 2 || !Lang13.Bool( ((dynamic)T).intact ) ) {
				this.showpipe = true;
			} else {
				this.showpipe = false;
			}

			if ( !this.showpipe ) {
				return false;
			}
			connected = 0;

			foreach (dynamic _a in Lang13.IterateRange( 1, this.device_type )) {
				I = _a;
				

				if ( Lang13.Bool( this.nodes[I] ) ) {
					connected |= Convert.ToInt32( this.icon_addintact( this.nodes[I] ) );
				}
			}
			this.icon_addbroken( connected );
			return false;
		}

		// Function from file: components_base.dm
		public void update_parents(  ) {
			double I = 0;
			dynamic parent = null;

			
			foreach (dynamic _a in Lang13.IterateRange( 1, this.device_type )) {
				I = _a;
				
				parent = this.parents[I];

				if ( !Lang13.Bool( parent ) ) {
					throw new Exception( "Component is missing a pipenet! Rebuilding..." );
					this.build_network();
				}
				parent.update = 1;
			}
			return;
		}

		// Function from file: components_base.dm
		public dynamic safe_input( dynamic title = null, dynamic text = null, dynamic default_set = null ) {
			dynamic new_value = null;

			new_value = Interface13.Input( Task13.User, text, title, default_set, null, InputType.Num );

			if ( Task13.User.canUseTopic( this ) ) {
				return new_value;
			}
			return default_set;
		}

		// Function from file: components_base.dm
		public void nullifyPipenet( Pipeline reference = null ) {
			int I = 0;

			I = this.parents.Find( reference );
			reference.other_airs.Remove( this.airs[I] );
			reference.other_atmosmch.Remove( this );
			this.parents[I] = null;
			return;
		}

		// Function from file: components_base.dm
		public virtual void update_icon_nopipes( bool? animation = null ) {
			return;
		}

		// Function from file: components_base.dm
		public void icon_addbroken( int? connected = null ) {
			connected = connected ?? 0;

			int unconnected = 0;
			dynamic direction = null;

			unconnected = ~( connected ??0) & Convert.ToInt32( this.initialize_directions );

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.cardinal )) {
				direction = _a;
				

				if ( ( unconnected & Convert.ToInt32( direction ) ) != 0 ) {
					this.underlays.Add( this.getpipeimage( "icons/obj/atmospherics/components/binary_devices.dmi", "pipe_exposed", direction ) );
				}
			}
			return;
		}

		// Function from file: components_base.dm
		public dynamic icon_addintact( Obj_Machinery_Atmospherics node = null ) {
			Image img = null;

			img = this.getpipeimage( "icons/obj/atmospherics/components/binary_devices.dmi", "pipe_intact", Map13.GetDistance( this, node ), node.pipe_color );
			this.underlays.Add( img );
			return ((dynamic)img).dir;
		}

		// Function from file: datum_pipeline.dm
		public override void addMember( Obj_Machinery_Atmospherics A = null ) {
			Pipeline P = null;

			P = this.returnPipenet( A );
			P.addMember( A, this );
			return;
		}

	}

}