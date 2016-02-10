// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Spell_Targeted_MindTransfer : Spell_Targeted {

		public ByTable protected_roles = new ByTable(new object [] { "Wizard", "Changeling", "Cultist" });
		public int msg_wait = 500;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mind Transfer";
			this.desc = "This spell allows the user to switch bodies with a target.";
			this.school = "transmutation";
			this.charge_max = 600;
			this.spell_flags = 0;
			this.invocation = "GIN'YU CAPAN";
			this.invocation_type = "whisper";
			this.mind_affecting = true;
			this.range = 1;
			this.cooldown_min = 200;
			this.compatible_mobs = new ByTable(new object [] { typeof(Mob_Living_Carbon_Human), typeof(Mob_Living_Carbon_Monkey) });
			this.amt_paralysis = 20;
			this.hud_state = "wiz_mindswap";
		}

		// Function from file: mind_transfer.dm
		public override bool cast( ByTable targets = null, Mob user = null ) {
			Mob_Living target = null;
			Mob_Living victim = null;
			Mob caster = null;
			dynamic V = null;
			dynamic V2 = null;
			Mob_Dead_Observer ghost = null;
			Spell S = null;
			dynamic V3 = null;
			Spell S2 = null;
			dynamic V4 = null;

			base.cast( targets, user );

			foreach (dynamic _g in Lang13.Enumerate( targets, typeof(Mob_Living) )) {
				target = _g;
				

				if ( target.stat == 2 ) {
					GlobalFuncs.to_chat( user, "You didn't study necromancy back at the Space Wizard Federation academy." );
					continue;
				}

				if ( !Lang13.Bool( target.key ) || !( target.mind != null ) ) {
					GlobalFuncs.to_chat( user, "They appear to be catatonic. Not even magic can affect their vacant mind." );
					continue;
				}
				Interface13.Stat( null, this.protected_roles.Contains( target.mind.special_role ) );

				if ( !Lang13.Bool( target.key ) || !( target.mind != null ) ) {
					GlobalFuncs.to_chat( user, "Their mind is resisting your spell." );
					continue;
				}
				victim = target;
				caster = user;

				if ( caster.mind.special_verbs.len != 0 ) {
					
					foreach (dynamic _a in Lang13.Enumerate( caster.mind.special_verbs )) {
						V = _a;
						
						caster.verbs.Remove( V );
					}
				}

				if ( victim.mind.special_verbs.len != 0 ) {
					
					foreach (dynamic _b in Lang13.Enumerate( victim.mind.special_verbs )) {
						V2 = _b;
						
						victim.verbs.Remove( V2 );
					}
				}
				ghost = victim.ghostize( false );
				ghost.spell_list = victim.spell_list;
				caster.mind.transfer_to( victim );
				victim.spell_list = new ByTable();

				foreach (dynamic _c in Lang13.Enumerate( caster.spell_list, typeof(Spell) )) {
					S = _c;
					
					victim.add_spell( S );
				}
				caster.spell_list = new ByTable();

				if ( victim.mind.special_verbs.len != 0 ) {
					
					foreach (dynamic _d in Lang13.Enumerate( caster.mind.special_verbs )) {
						V3 = _d;
						
						caster.verbs.Add( V3 );
					}
				}
				ghost.mind.transfer_to( caster );
				caster.key = ghost.key;

				foreach (dynamic _e in Lang13.Enumerate( ghost.spell_list, typeof(Spell) )) {
					S2 = _e;
					
					caster.add_spell( S2 );
				}
				ghost.spell_list = new ByTable();

				if ( caster.mind.special_verbs.len != 0 ) {
					
					foreach (dynamic _f in Lang13.Enumerate( caster.mind.special_verbs )) {
						V4 = _f;
						
						caster.verbs.Add( V4 );
					}
				}
				caster.Paralyse( this.amt_paralysis );
				Task13.Schedule( this.msg_wait, (Task13.Closure)(() => {
					GlobalFuncs.to_chat( caster, "<span class='danger'>You feel woozy and lightheaded. Your body doesn't seem like your own.</span>" );
					return;
				}));
			}
			return false;
		}

	}

}