using Base.Core;
using Base.Defs;
using Base.Levels;
using PhoenixPoint.Common.Game;
using PhoenixPoint.Modding;
using PhoenixPoint.Geoscape.Entities.Interception.Equipments;
using System.Linq;
using UnityEngine;



namespace FireFAirW
{
	/// <summary>
	/// This is the main mod class. Only one can exist per assembly.
	/// If no ModMain is detected in assembly, then no other classes/callbacks will be called.
	/// </summary>
	public class FireFAirWMain : ModMain
	{
		/// Config is accessible at any time, if any is declared.
		public new FireFAirWConfig Config => (FireFAirWConfig)base.Config;

		/// This property indicates if mod can be Safely Disabled from the game.
		/// Safely sisabled mods can be reenabled again. Unsafely disabled mods will need game restart ot take effect.
		/// Unsafely disabled mods usually cannot revert thier changes in OnModDisabled
		public override bool CanSafelyDisable => true;

		/// <summary>
		/// Callback for when mod is enabled. Called even on game starup.
		/// </summary>
		public override void OnModEnabled() {

			/// All mod dependencies are accessible and always loaded.
			int c = Dependencies.Count();
			/// Mods have their own logger. Message through this logger will appear in game console and Unity log file.
			Logger.LogInfo($"Say anything crab people-related.");
			/// Metadata is whatever is written in meta.json
			string v = MetaData.Version.ToString();
			/// Game creates Harmony object for each mod. Accessible if needed.
			HarmonyLib.Harmony harmony = (HarmonyLib.Harmony)HarmonyInstance;
			/// Mod instance is mod's runtime representation in game.
			string id = Instance.ID;
			/// Game creates Game Object for each mod. 
			GameObject go = ModGO;
			/// PhoenixGame is accessible at any time.
			PhoenixGame game = GetGame();

			/// Apply any general game modifications.
			DefRepository Repo = GameUtl.GameComponent<DefRepository>();
			/*GeoVehicleWeaponDamageDef shredDamage = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Shred_GeoVehicleWeaponDamageDef"));
			GeoVehicleWeaponDamageDef regularDamage = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Regular_GeoVehicleWeaponDamageDef"));
			Nomad.DamagePayloads[0] = new GeoWeaponDamagePayload { Damage = shredDamage, Amount = 20 };
			Nomad.DamagePayloads.Add(new GeoWeaponDamagePayload { Damage = regularDamage, Amount = 60 });*/
			//GeoVehicleWeaponDamageDef Damage = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Regular_GeoVehicleWeaponDamageDef"));
			//GeoVehicleWeaponDamageDef Shred = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Shred_GeoVehicleWeaponDamageDef"));

			GeoVehicleWeaponDamageDef standardDamageNomad = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Regular_GeoVehicleWeaponDamageDef"));
			GeoVehicleWeaponDamageDef standardDamageOrochi = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Regular_GeoVehicleWeaponDamageDef"));
			GeoVehicleWeaponDamageDef standardDamageTyr = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Regular_GeoVehicleWeaponDamageDef"));
			GeoVehicleWeaponDamageDef standardDamagePhoenixBolt = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Regular_GeoVehicleWeaponDamageDef"));
			GeoVehicleWeaponDamageDef standardDamageFenrir = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Regular_GeoVehicleWeaponDamageDef"));
			GeoVehicleWeaponDamageDef standardDamageBrokkr = Repo.GetAllDefs<GeoVehicleWeaponDamageDef>().FirstOrDefault(gvw => gvw.name.Equals("Regular_GeoVehicleWeaponDamageDef"));

			GeoVehicleWeaponDef Nomad = Repo.GetAllDefs<GeoVehicleWeaponDef>().FirstOrDefault(a => a.name.Equals("PX_BasicMissileNomadAAM_VehicleWeaponDef"));
			Nomad.Accuracy = 80;
			Nomad.ProjectileSpeed = 150;
			Nomad.NumberOfProjectiles = 1;
			Nomad.DamagePayloads[0] = new GeoWeaponDamagePayload { Damage = standardDamageNomad, Amount = 420 };
			Nomad.AmmoCount = 210;
			
			GeoVehicleWeaponDef Orochi = Repo.GetAllDefs<GeoVehicleWeaponDef>().FirstOrDefault(a => a.name.Equals("PX_HeavyCannonOrochiHC1_VehicleWeaponDef"));

			Orochi.DamagePayloads[0] = new GeoWeaponDamagePayload { Damage = standardDamageOrochi, Amount = 540 };
			//Orochi.DamagePayloads.DamageKeywords[0].Value = 540;
			Orochi.AmmoCount = 210;

			GeoVehicleWeaponDef Tyr = Repo.GetAllDefs<GeoVehicleWeaponDef>().FirstOrDefault(a => a.name.Equals("PX_HypersonicMissileHandOfTyr_VehicleWeaponDef"));

			Tyr.DamagePayloads[0] = new GeoWeaponDamagePayload { Damage = standardDamageTyr, Amount = 900 };
			Tyr.AmmoCount = 84;

			GeoVehicleWeaponDef PhoenixBolt = Repo.GetAllDefs<GeoVehicleWeaponDef>().FirstOrDefault(a => a.name.Equals("PX_ElectrolaserThunderboltHC9_VehicleWeaponDef"));

			PhoenixBolt.DamagePayloads[0] = new GeoWeaponDamagePayload { Damage = standardDamagePhoenixBolt, Amount = 450 };
			PhoenixBolt.AmmoCount = 210;
			//PhoenixBolt.DamagePayloads.DamageKeywords[0].Value = 450;

			GeoVehicleWeaponDef Fenrir = Repo.GetAllDefs<GeoVehicleWeaponDef>().FirstOrDefault(a => a.name.Equals("PX_VirophageGunFenrirRC7_VehicleWeaponDef"));

			Fenrir.DamagePayloads[0] = new GeoWeaponDamagePayload { Damage = standardDamageFenrir, Amount = 180 };
			Fenrir.AmmoCount = 686;
			//Fenrir.DamagePayloads.DamageKeywords[0].Value = 180;


			GeoVehicleWeaponDef Brokkr = Repo.GetAllDefs<GeoVehicleWeaponDef>().FirstOrDefault(a => a.name.Equals("PX_AutocannonBrokkrAC3_VehicleWeaponDef"));

			Brokkr.DamagePayloads[0] = new GeoWeaponDamagePayload { Damage = standardDamageBrokkr, Amount = 300 };
			Brokkr.AmmoCount = 630;
			//Brokkr.DamagePayloads.DamageKeywords[0].Value = 300; 

			GeoVehicleModuleDef PhoenixAB = Repo.GetAllDefs<GeoVehicleModuleDef>().FirstOrDefault(a => a.name.Equals("PX_Afterburner_GeoVehicleModuleDef"));
			PhoenixAB.HitPoints = 450;
			PhoenixAB.AmmoCount = 35;

			GeoVehicleModuleDef Formula1Air = Repo.GetAllDefs<GeoVehicleModuleDef>().FirstOrDefault(a => a.name.Equals("NJ_CruiseControl_GeoVehicleModuleDef"));

			Formula1Air.GeoVehicleModuleBonusValue = 700;

		}

		/// <summary>
		/// Callback for when mod is disabled. This will be called even if mod cannot be safely disabled.
		/// Guaranteed to have OnModEnabled before.
		/// </summary>
		public override void OnModDisabled() {
			/// Undo any game modifications if possible. Else "CanSafelyDisable" must be set to false.
			/// ModGO will be destroyed after OnModDisabled.
		}

		/// <summary>
		/// Callback for when any property from mod's config is changed.
		/// </summary>
		public override void OnConfigChanged() {
			/// Config is accessible at any time.
		}


		/// <summary>
		/// In Phoenix Point there can be only one active level at a time. 
		/// Levels go through different states (loading, unloaded, start, etc.).
		/// General puprose level state change callback.
		/// </summary>
		/// <param name="level">Level being changed.</param>
		/// <param name="prevState">Old state of the level.</param>
		/// <param name="state">New state of the level.</param>
		public override void OnLevelStateChanged(Level level, Level.State prevState, Level.State state) {
			/// Alternative way to access current level at any time.
			Level l = GetLevel();
		}

		/// <summary>
		/// Useful callback for when level is loaded, ready, and starts.
		/// Usually game setup is executed.
		/// </summary>
		/// <param name="level">Level that starts.</param>
		public override void OnLevelStart(Level level) {
		}

		/// <summary>
		/// Useful callback for when level is ending, before unloading.
		/// Usually game cleanup is executed.
		/// </summary>
		/// <param name="level">Level that ends.</param>
		public override void OnLevelEnd(Level level) {
		}
	}
}
