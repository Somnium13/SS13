using System;
using Som13;

namespace Game13 {
	static class GlobalVars {
		public const JsonReader _jsonr = new JsonReader();
		public const JsonWriter _jsonw = new JsonWriter();
		public static DmmSuite_Preloader _preloader = null;
		public static Ent_Screen_ClickCatcher _void = null;
		public const int AALARM_WIRE_IDSCAN = 1;
		public static dynamic abandon_allowed = 1;
		public const int access_ai_upload = 16;
		public const int access_all_personal_lockers = 21;
		public const int access_armory = 3;
		public const int access_atmospherics = 24;
		public const int access_bar = 25;
		public const int access_brig = 2;
		public const int access_captain = 20;
		public const int access_cargo = 31;
		public const int access_ce = 56;
		public const int access_cent_captain = 109;
		public const int access_cent_general = 101;
		public const int access_cent_living = 105;
		public const int access_cent_medical = 104;
		public const int access_cent_specops = 103;
		public const int access_cent_storage = 106;
		public const int access_cent_teleporter = 107;
		public const int access_cent_thunder = 102;
		public const int access_change_ids = 15;
		public const int access_chapel_office = 22;
		public const int access_chemistry = 33;
		public const int access_cmo = 40;
		public const int access_construction = 32;
		public const int access_court = 42;
		public const int access_crematorium = 27;
		public const int access_engine = 10;
		public const int access_engine_equip = 11;
		public const int access_eva = 18;
		public const int access_external_airlocks = 13;
		public const int access_forensics_lockers = 4;
		public const int access_gateway = 62;
		public const int access_genetics = 9;
		public const int access_heads = 19;
		public const int access_heads_vault = 53;
		public const int access_hop = 57;
		public const int access_hos = 58;
		public const int access_hydroponics = 35;
		public const int access_janitor = 26;
		public const int access_keycard_auth = 60;
		public const int access_kitchen = 28;
		public const int access_lawyer = 38;
		public const int access_library = 37;
		public const int access_mailsorting = 50;
		public const int access_maint_tunnels = 12;
		public const int access_medical = 5;
		public const int access_mineral_storeroom = 64;
		public const int access_mining = 48;
		public const int access_mining_station = 54;
		public const int access_minisat = 65;
		public const int access_morgue = 6;
		public const int access_qm = 41;
		public const int access_RC_announce = 59;
		public const int access_rd = 30;
		public const int access_research = 47;
		public const int access_robotics = 29;
		public const int access_sec_doors = 63;
		public const int access_security = 1;
		public const int access_surgery = 45;
		public const int access_syndicate = 150;
		public const int access_syndicate_leader = 151;
		public const int access_tcomsat = 61;
		public const int access_tech_storage = 23;
		public const int access_teleporter = 17;
		public const int access_theatre = 46;
		public const int access_tox = 7;
		public const int access_tox_storage = 8;
		public const int access_virology = 39;
		public const int access_weapons = 66;
		public const int access_xenobiology = 55;
		public const ByTable accessable_z_levels = new ByTable(new object [] { 1, 3, 4, 5, 6, 7 });
		public static ByTable active_turfs_startlist = new ByTable();
		public const ByTable adjectives = GlobalFuncs.file2list( "config/names/adjectives.txt" );
		public static ByTable admin_datums = new ByTable();
		public const ByTable admin_log = new ByTable();
		public static string admin_notice = "";
		public static ByTable admin_ranks = new ByTable();
		public static dynamic admin_sound = null;
		public const ByTable admin_verbs_admin = new ByTable(new object [] { typeof(Client).GetMethod( "player_panel_new" ), typeof(Client).GetMethod( "invisimin" ), typeof(Admins).GetMethod( "show_player_panel" ), typeof(Client).GetMethod( "game_panel" ), typeof(Client).GetMethod( "check_ai_laws" ), typeof(Admins).GetMethod( "toggleooc" ), typeof(Admins).GetMethod( "toggleoocdead" ), typeof(Admins).GetMethod( "toggleenter" ), typeof(Admins).GetMethod( "toggleguests" ), typeof(Admins).GetMethod( "announce" ), typeof(Admins).GetMethod( "set_admin_notice" ), typeof(Client).GetMethod( "admin_ghost" ), typeof(Client).GetMethod( "toggle_view_range" ), typeof(Admins).GetMethod( "view_txt_log" ), typeof(Admins).GetMethod( "view_atk_log" ), typeof(Client).GetMethod( "cmd_admin_subtle_message" ), typeof(Client).GetMethod( "cmd_admin_delete" ), typeof(Client).GetMethod( "cmd_admin_check_contents" ), typeof(Client).GetMethod( "check_antagonists" ), typeof(Admins).GetMethod( "access_news_network" ), typeof(Client).GetMethod( "giveruntimelog" ), typeof(Client).GetMethod( "getruntimelog" ), typeof(Client).GetMethod( "getserverlog" ), typeof(Client).GetMethod( "jumptocoord" ), typeof(Client).GetMethod( "Getmob" ), typeof(Client).GetMethod( "Getkey" ), typeof(Client).GetMethod( "jumptoarea" ), typeof(Client).GetMethod( "jumptokey" ), typeof(Client).GetMethod( "jumptomob" ), typeof(Client).GetMethod( "jumptoturf" ), typeof(Client).GetMethod( "admin_call_shuttle" ), typeof(Client).GetMethod( "admin_cancel_shuttle" ), typeof(Client).GetMethod( "cmd_admin_direct_narrate" ), typeof(Client).GetMethod( "cmd_admin_world_narrate" ), typeof(Client).GetMethod( "cmd_admin_local_narrate" ), typeof(Client).GetMethod( "cmd_admin_create_centcom_report" ), typeof(Client).GetMethod( "toggle_antag_hud" ) });
		public const ByTable admin_verbs_ban = new ByTable(new object [] { typeof(Client).GetMethod( "unban_panel" ), typeof(Client).GetMethod( "jobbans" ), typeof(Client).GetMethod( "unjobban_panel" ), typeof(Client).GetMethod( "DB_ban_panel" ), typeof(Client).GetMethod( "stickybanpanel" ) });
		public const ByTable admin_verbs_debug = new ByTable(new object [] { typeof(Client).GetMethod( "restart_controller" ), typeof(Client).GetMethod( "cmd_admin_list_open_jobs" ), typeof(Client).GetMethod( "Debug2" ), typeof(Client).GetMethod( "cmd_debug_make_powernets" ), typeof(Client).GetMethod( "debug_controller" ), typeof(Client).GetMethod( "cmd_debug_mob_lists" ), typeof(Client).GetMethod( "cmd_admin_delete" ), typeof(Client).GetMethod( "cmd_debug_del_all" ), typeof(Client).GetMethod( "restart_controller" ), typeof(Client).GetMethod( "enable_debug_verbs" ), typeof(Client).GetMethod( "callproc" ), typeof(Client).GetMethod( "callproc_datum" ), typeof(Client).GetMethod( "SDQL2_query" ), typeof(Client).GetMethod( "test_movable_UI" ), typeof(Client).GetMethod( "test_snap_UI" ), typeof(Client).GetMethod( "debugNatureMapGenerator" ), typeof(Client).GetMethod( "check_bomb_impacts" ), typeof(GlobalFuncs).GetMethod( "machine_upgrade" ), typeof(Client).GetMethod( "populate_world" ), typeof(Client).GetMethod( "cmd_display_del_log" ), typeof(Client).GetMethod( "reset_latejoin_spawns" ), typeof(Client).GetMethod( "create_outfits" ), typeof(Client).GetMethod( "debug_huds" ) });
		public const ByTable admin_verbs_default = new ByTable(new object [] { typeof(Client).GetMethod( "toggleadminhelpsound" ), typeof(Client).GetMethod( "toggleannouncelogin" ), typeof(Client).GetMethod( "deadmin_self" ), typeof(Client).GetMethod( "cmd_admin_say" ), typeof(Client).GetMethod( "hide_verbs" ), typeof(Client).GetMethod( "hide_most_verbs" ), typeof(Client).GetMethod( "debug_variables" ), typeof(Client).GetMethod( "admin_memo" ), typeof(Client).GetMethod( "deadchat" ), typeof(Client).GetMethod( "dsay" ), typeof(Client).GetMethod( "toggleprayers" ), typeof(Client).GetMethod( "toggleprayersounds" ), typeof(Client).GetMethod( "toggle_hear_radio" ), typeof(Client).GetMethod( "investigate_show" ), typeof(Client).GetMethod( "secrets" ), typeof(Client).GetMethod( "reload_admins" ), typeof(Client).GetMethod( "reestablish_db_connection" ), typeof(Client).GetMethod( "cmd_admin_pm_context" ), typeof(Client).GetMethod( "cmd_admin_pm_panel" ), typeof(Client).GetMethod( "stop_sounds" ) });
		public const ByTable admin_verbs_fun = new ByTable(new object [] { typeof(Client).GetMethod( "cmd_admin_dress" ), typeof(Client).GetMethod( "cmd_admin_gib_self" ), typeof(Client).GetMethod( "drop_bomb" ), typeof(Client).GetMethod( "cinematic" ), typeof(Client).GetMethod( "one_click_antag" ), typeof(Client).GetMethod( "send_space_ninja" ), typeof(Client).GetMethod( "cmd_admin_add_freeform_ai_law" ), typeof(Client).GetMethod( "cmd_admin_add_random_ai_law" ), typeof(Client).GetMethod( "object_say" ), typeof(Client).GetMethod( "toggle_random_events" ), typeof(Client).GetMethod( "set_ooc" ), typeof(Client).GetMethod( "reset_ooc" ), typeof(Client).GetMethod( "forceEvent" ), typeof(Client).GetMethod( "bluespace_artillery" ), typeof(Client).GetMethod( "admin_change_sec_level" ), typeof(Client).GetMethod( "toggle_nuke" ) });
		public const ByTable admin_verbs_hideable = new ByTable(new object [] { typeof(Client).GetMethod( "set_ooc" ), typeof(Client).GetMethod( "reset_ooc" ), typeof(Client).GetMethod( "deadmin_self" ), typeof(Client).GetMethod( "deadchat" ), typeof(Client).GetMethod( "toggleprayers" ), typeof(Client).GetMethod( "toggle_hear_radio" ), typeof(Admins).GetMethod( "show_traitor_panel" ), typeof(Admins).GetMethod( "toggleenter" ), typeof(Admins).GetMethod( "toggleguests" ), typeof(Admins).GetMethod( "announce" ), typeof(Admins).GetMethod( "set_admin_notice" ), typeof(Client).GetMethod( "admin_ghost" ), typeof(Client).GetMethod( "toggle_view_range" ), typeof(Admins).GetMethod( "view_txt_log" ), typeof(Admins).GetMethod( "view_atk_log" ), typeof(Client).GetMethod( "cmd_admin_subtle_message" ), typeof(Client).GetMethod( "cmd_admin_check_contents" ), typeof(Admins).GetMethod( "access_news_network" ), typeof(Client).GetMethod( "admin_call_shuttle" ), typeof(Client).GetMethod( "admin_cancel_shuttle" ), typeof(Client).GetMethod( "cmd_admin_direct_narrate" ), typeof(Client).GetMethod( "cmd_admin_world_narrate" ), typeof(Client).GetMethod( "cmd_admin_local_narrate" ), typeof(Client).GetMethod( "play_local_sound" ), typeof(Client).GetMethod( "play_sound" ), typeof(Client).GetMethod( "set_round_end_sound" ), typeof(Client).GetMethod( "cmd_admin_dress" ), typeof(Client).GetMethod( "cmd_admin_gib_self" ), typeof(Client).GetMethod( "drop_bomb" ), typeof(Client).GetMethod( "cinematic" ), typeof(Client).GetMethod( "send_space_ninja" ), typeof(Client).GetMethod( "cmd_admin_add_freeform_ai_law" ), typeof(Client).GetMethod( "cmd_admin_add_random_ai_law" ), typeof(Client).GetMethod( "cmd_admin_create_centcom_report" ), typeof(Client).GetMethod( "object_say" ), typeof(Client).GetMethod( "toggle_random_events" ), typeof(Client).GetMethod( "cmd_admin_add_random_ai_law" ), typeof(Admins).GetMethod( "startnow" ), typeof(Admins).GetMethod( "restart" ), typeof(Admins).GetMethod( "delay" ), typeof(Admins).GetMethod( "toggleaban" ), typeof(Client).GetMethod( "toggle_log_hrefs" ), typeof(Client).GetMethod( "everyone_random" ), typeof(Admins).GetMethod( "toggleAI" ), typeof(Client).GetMethod( "restart_controller" ), typeof(Client).GetMethod( "cmd_admin_list_open_jobs" ), typeof(Client).GetMethod( "callproc" ), typeof(Client).GetMethod( "callproc_datum" ), typeof(Client).GetMethod( "Debug2" ), typeof(Client).GetMethod( "reload_admins" ), typeof(Client).GetMethod( "cmd_debug_make_powernets" ), typeof(Client).GetMethod( "debug_controller" ), typeof(Client).GetMethod( "startSinglo" ), typeof(Client).GetMethod( "cmd_debug_mob_lists" ), typeof(Client).GetMethod( "cmd_debug_del_all" ), typeof(Client).GetMethod( "enable_debug_verbs" ), typeof(GlobalFuncs).GetMethod( "possess" ), typeof(GlobalFuncs).GetMethod( "release" ), typeof(Client).GetMethod( "reload_admins" ), typeof(Client).GetMethod( "panicbunker" ), typeof(Client).GetMethod( "admin_change_sec_level" ), typeof(Client).GetMethod( "toggle_nuke" ), typeof(Client).GetMethod( "cmd_display_del_log" ), typeof(Client).GetMethod( "toggle_antag_hud" ), typeof(Client).GetMethod( "debug_huds" ) });
		public const ByTable admin_verbs_permissions = new ByTable(new object [] { typeof(Client).GetMethod( "edit_admin_permissions" ), typeof(Client).GetMethod( "create_poll" ) });
		public const ByTable admin_verbs_possess = new ByTable(new object [] { typeof(GlobalFuncs).GetMethod( "possess" ), typeof(GlobalFuncs).GetMethod( "release" ) });
		public const ByTable admin_verbs_rejuv = new ByTable(new object [] { typeof(Client).GetMethod( "respawn_character" ) });
		public const ByTable admin_verbs_server = new ByTable(new object [] { typeof(Admins).GetMethod( "startnow" ), typeof(Admins).GetMethod( "restart" ), typeof(Admins).GetMethod( "end_round" ), typeof(Admins).GetMethod( "delay" ), typeof(Admins).GetMethod( "toggleaban" ), typeof(Client).GetMethod( "toggle_log_hrefs" ), typeof(Client).GetMethod( "everyone_random" ), typeof(Admins).GetMethod( "toggleAI" ), typeof(Client).GetMethod( "cmd_admin_delete" ), typeof(Client).GetMethod( "cmd_debug_del_all" ), typeof(Client).GetMethod( "toggle_random_events" ), typeof(Client).GetMethod( "panicbunker" ) });
		public const ByTable admin_verbs_sounds = new ByTable(new object [] { typeof(Client).GetMethod( "play_local_sound" ), typeof(Client).GetMethod( "play_sound" ), typeof(Client).GetMethod( "set_round_end_sound" ) });
		public const ByTable admin_verbs_spawn = new ByTable(new object [] { typeof(Admins).GetMethod( "spawn_atom" ), typeof(Client).GetMethod( "respawn_character" ) });
		public const ByTable adminlog = new ByTable();
		public static ByTable admins = new ByTable();
		public const ByTable advance_cures = new ByTable(new object [] { "sodiumchloride", "sugar", "orangejuice", "spaceacillin", "salglu_solution", "ethanol", "leporazine", "synaptizine", "lipolicide", "silver", "gold" });
		public const int agents_possible = 5;
		public static ByTable ai_list = new ByTable();
		public const ByTable ai_names = GlobalFuncs.file2list( "config/names/ai.txt" );
		public const int AIPRIV_FREQ = 1447;
		public const ByTable airlock_overlays = new ByTable();
		public const int AIRLOCK_WIRE_BACKUP_POWER1 = 16;
		public const int AIRLOCK_WIRE_BACKUP_POWER2 = 32;
		public const int AIRLOCK_WIRE_DOOR_BOLTS = 8;
		public const int AIRLOCK_WIRE_ELECTRIFY = 256;
		public const int AIRLOCK_WIRE_IDSCAN = 1;
		public const int AIRLOCK_WIRE_LIGHT = 2048;
		public const int AIRLOCK_WIRE_MAIN_POWER1 = 2;
		public const int AIRLOCK_WIRE_MAIN_POWER2 = 4;
		public const int AIRLOCK_WIRE_OPEN_DOOR = 64;
		public const int AIRLOCK_WIRE_SAFETY = 512;
		public const int AIRLOCK_WIRE_SPEED = 1024;
		public static ByTable airlocks = new ByTable();
		public const int ALIEN_AFK_BRACKET = 450;
		public const ByTable all_radios = new ByTable();
		public const ByTable all_supply_groups = new ByTable(new object [] { GlobalVars.supply_emergency, GlobalVars.supply_security, GlobalVars.supply_engineer, GlobalVars.supply_medical, GlobalVars.supply_science, GlobalVars.supply_organic, GlobalVars.supply_materials, GlobalVars.supply_misc });
		public static ByTable allCasters = new ByTable();
		public static ByTable allConsoles = new ByTable();
		public const ByTable alldirs = new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST, GlobalVars.NORTHEAST, GlobalVars.NORTHWEST, GlobalVars.SOUTHEAST, GlobalVars.SOUTHWEST });
		public const ByTable allowed_items = new ByTable().set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Blumpkin), "blumpkinjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Pumpkin), "pumpkinjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries_Poison), "poisonberryjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Watermelonslice), "watermelonjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Watermelon), "watermelonjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Lime), "limejuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Orange), "orangejuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Lemon), "lemonjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Potato), "potato" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana), "banana" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Grapes_Green), "grapejuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Grapes), "grapejuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries), "berryjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carrot), "carrotjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato), "tomatojuice" );
		public const ByTable alphabet = new ByTable(new object [] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });
		public const ByTable animated_spines_list = new ByTable();
		public const ByTable animated_tails_list_human = new ByTable();
		public const ByTable animated_tails_list_lizard = new ByTable();
		public static ByTable announcement_systems = new ByTable();
		public static double announcing_vox = 0;
		public const int APC_WIRE_AI_CONTROL = 8;
		public const int APC_WIRE_MAIN_POWER1 = 2;
		public const int APC_WIRE_MAIN_POWER2 = 4;
		public static ByTable apcs_list = new ByTable();
		public const ByTable appearance_keylist = new ByTable( 0 );
		public const ByTable archive_diseases = new ByTable();
		public const int AREA_SPACE = 2;
		public const int AREA_SPECIAL = 3;
		public const int AREA_STATION = 1;
		public const ByTable assistant_occupations = new ByTable(new object [] { "Assistant", "Atmospheric Technician", "Cargo Technician", "Chaplain", "Lawyer", "Librarian" });
		public const ByTable awaydestinations = new ByTable();
		public const ByTable backbaglist = new ByTable(new object [] { "Backpack", "Satchel" });
		public static ByTable bad_mutations = new ByTable();
		public const dynamic bad_se_blocks = null;
		public const dynamic Banlist = null;
		public const dynamic Banlistjob = null;
		public const ByTable be_special_flags = new ByTable().set( "Shadowling", 8192 ).set( "Revenant", 32768 ).set( "Abductor", 16384 ).set( "Gang", 4096 ).set( "Monkey", 2048 ).set( "Ninja", 1024 ).set( "Blob", 512 ).set( "Cultist", 256 ).set( "pAI", 128 ).set( "Alien Lifeform", 64 ).set( "Revolutionary", 32 ).set( "Malf AI", 16 ).set( "Wizard", 8 ).set( "Changeling", 4 ).set( "Operative", 2 ).set( "Traitor", 1 );
		public const ByTable bibleitemstates = new ByTable(new object [] { "bible", "koran", "scrapbook", "bible", "bible", "bible", "syringe_kit", "syringe_kit", "syringe_kit", "syringe_kit", "syringe_kit", "kingyellow", "ithaqua", "scientology", "melted", "necronomicon" });
		public const ByTable biblenames = new ByTable(new object [] { "Bible", "Quran", "Scrapbook", "Burning Bible", "Clown Bible", "Banana Bible", "Creeper Bible", "White Bible", "Holy Light", "The God Delusion", "Tome", "The King in Yellow", "Ithaqua", "Scientology", "Melted Bible", "Necronomicon" });
		public const ByTable biblestates = new ByTable(new object [] { "bible", "koran", "scrapbook", "burning", "honk1", "honk2", "creeper", "white", "holylight", "atheist", "tome", "kingyellow", "ithaqua", "scientology", "melted", "necronomicon" });
		public const ByTable binary = new ByTable(new object [] { "0", "1" });
		public static Ent_Machinery_BlackboxRecorder blackbox = null;
		public const int BLEND_ADD = 2;
		public const int BLEND_DEFAULT = 0;
		public const int BLEND_MULTIPLY = 4;
		public const int BLEND_OVERLAY = 1;
		public static ByTable blob_cores = new ByTable();
		public static ByTable blob_nodes = new ByTable();
		public static ByTable blobs = new ByTable();
		public static ByTable blobstart = new ByTable();
		public const ByTable blood_splatter_icons = new ByTable();
		public const int BLOOD_VOLUME_SAFE = 501;
		public const ByTable bloody_footprints_cache = new ByTable();
		public const ByTable body_markings_list = new ByTable();
		public static int bomb_set = 0;
		public static ByTable bombers = new ByTable();
		public const int BORDER_2NDTILE = 3;
		public const int BORDER_BETWEEN = 2;
		public const int BORDER_NONE = 1;
		public const int BORDER_SPACE = 4;
		public static ByTable BUMP_TELEPORTERS = new ByTable();
		public const ByTable cable_coil_recipes = new ByTable(new object [] { new StackRecipe( "cable restraints", typeof(Ent_Item_Weapon_Restraints_Handcuffs_Cable), 15 ) });
		public static ByTable cable_list = new ByTable();
		public static ByTable cachedbooks = null;
		public const int CALL_SHUTTLE_REASON_LENGTH = 12;
		public const Cameranet cameranet = new Cameranet();
		public const ByTable cardboard_recipes = new ByTable(new object [] { new StackRecipe( "box", typeof(Ent_Item_Weapon_Storage_Box) ), new StackRecipe( "light tubes", typeof(Ent_Item_Weapon_Storage_Box_Lights_Tubes) ), new StackRecipe( "light bulbs", typeof(Ent_Item_Weapon_Storage_Box_Lights_Bulbs) ), new StackRecipe( "mouse traps", typeof(Ent_Item_Weapon_Storage_Box_Mousetraps) ), new StackRecipe( "cardborg suit", typeof(Ent_Item_Clothing_Suit_Cardborg), 3 ), new StackRecipe( "cardborg helmet", typeof(Ent_Item_Clothing_Head_Cardborg) ), new StackRecipe( "pizza box", typeof(Ent_Item_Pizzabox) ), new StackRecipe( "folder", typeof(Ent_Item_Weapon_Folder) ), new StackRecipe( "large box", typeof(Ent_Structure_Closet_Cardboard), 4 ) });
		public const ByTable cardinal = new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST });
		public const double CELLRATE = 0.0020000000949949026;
		public const int CENTCOM_FREQ = 1337;
		public const int changeling_amount = 4;
		public const string changelog_hash = "";
		public const double CHARGELEVEL = 0.0010000000474974513;
		public const ByTable chatchannels = new ByTable().set( GlobalVars.default_ntrc_chatroom.name, GlobalVars.default_ntrc_chatroom );
		public static ByTable chemical_mob_spawn_meancritters = new ByTable();
		public static ByTable chemical_mob_spawn_nicecritters = new ByTable();
		public static ByTable chemical_reactions_list = null;
		public static ByTable chemical_reagents_list = null;
		public static int chicken_count = 0;
		public const int CHUNK_SIZE = 16;
		public const int CIVILIAN = 4;
		public const ByTable civilian_positions = new ByTable(new object [] { "Bartender", "Botanist", "Cook", "Janitor", "Librarian", "Lawyer", "Chaplain", "Clown", "Mime", "Assistant" });
		public const int CLAMPED_OFF = 1;
		public const ByTable clientmessages = new ByTable();
		public static ByTable clients = new ByTable();
		public const int CLOSE_DURATION = 6;
		public const int CLOSED = 2;
		public const ByTable clown_names = GlobalFuncs.file2list( "config/names/clown.txt" );
		public const ByTable clown_recipes = new ByTable(new object [] { new StackRecipe( "bananium tile", typeof(Ent_Item_Stack_Tile_Mineral_Bananium), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Bananium_Clown) ).set( 1, "Clown Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static dynamic CMinutes = null;
		public static string cmp_field = "name";
		public const ByTable combatlog = new ByTable();
		public const int COMM_FREQ = 1353;
		public static string command_name = null;
		public const ByTable command_positions = new ByTable(new object [] { "Captain", "Head of Personnel", "Head of Security", "Chief Engineer", "Research Director", "Chief Medical Officer" });
		public const ByTable commando_names = GlobalFuncs.file2list( "config/names/death_commando.txt" );
		public const ByTable common_tools = new ByTable(new object [] { typeof(Ent_Item_Stack_CableCoil), typeof(Ent_Item_Weapon_Wrench), typeof(Ent_Item_Weapon_Weldingtool), typeof(Ent_Item_Weapon_Screwdriver), typeof(Ent_Item_Weapon_Wirecutters), typeof(Ent_Item_Device_Multitool), typeof(Ent_Item_Weapon_Crowbar) });
		public static int comms_allowed = 0;
		public static dynamic comms_key = "default_pwd";
		public const dynamic config = null;
		public const ByTable contrabandposters = new ByTable(new object [] { 
			new ByTable().set( "desc", " A salvaged shred of a much larger flag, colors bled together and faded from age." ).set( "name", "- Free Tonto" ), 
			new ByTable().set( "desc", " A relic of a failed rebellion." ).set( "name", "- Atmosia Declaration of Independence" ), 
			new ByTable().set( "desc", " A poster condemning the station's security forces." ).set( "name", "- Fun Police" ), 
			new ByTable().set( "desc", " A heretical poster depicting the titular star of an equally heretical book." ).set( "name", "- Lusty Xenomorph" ), 
			new ByTable().set( "desc", " See the galaxy! Shatter corrupt megacorporations! Join today!" ).set( "name", "- Syndicate Recruitment" ), 
			new ByTable().set( "desc", " Honk." ).set( "name", "- Clown" ), 
			new ByTable().set( "desc", " A poster advertising a rival corporate brand of cigarettes." ).set( "name", "- Smoke" ), 
			new ByTable().set( "desc", " A rebellious poster symbolizing assistant solidarity." ).set( "name", "- Grey Tide" ), 
			new ByTable().set( "desc", " This poster references the uproar that followed Nanotrasen's financial cuts toward insulated-glove purchases." ).set( "name", "- Missing Gloves" ), 
			new ByTable().set( "desc", " This poster details the internal workings of the common Nanotrasen airlock. Sadly, it appears out of date." ).set( "name", "- Hacking Guide" ), 
			new ByTable().set( "desc", " This seditious poster references Nanotrasen's genocide of a space station full of badgers." ).set( "name", "- RIP Badger" ), 
			new ByTable().set( "desc", " This poster is lookin' pretty trippy man." ).set( "name", "- Ambrosia Vulgaris" ), 
			new ByTable().set( "desc", " This poster is an unauthorized advertisement for Donut Corp." ).set( "name", "- Donut Corp." ), 
			new ByTable().set( "desc", " This poster promotes rank gluttony." ).set( "name", "- EAT." ), 
			new ByTable().set( "desc", " This poster looks like an advertisement for tools, but is in fact a subliminal jab at the tools at CentComm." ).set( "name", "- Tools" ), 
			new ByTable().set( "desc", " A poster that positions the seat of power outside Nanotrasen." ).set( "name", "- Power" ), 
			new ByTable().set( "desc", " Ignorant of Nature's Harmonic 6 Side Space Cube Creation, the Spacemen are Dumb, Educated Singularity Stupid and Evil." ).set( "name", "- Space Cube" ), 
			new ByTable().set( "desc", " All hail the Communist party!" ).set( "name", "- Communist State" ), 
			new ByTable().set( "desc", " This poster depicts Lamarr. Probably made by a traitorous Research Director." ).set( "name", "- Lamarr" ), 
			new ByTable().set( "desc", " Being fancy can be for any borg, just need a suit." ).set( "name", "- Borg Fancy" ), 
			new ByTable().set( "desc", " Borg Fancy, Now only taking the most fancy." ).set( "name", "- Borg Fancy v2" ), 
			new ByTable().set( "desc", " A poster mocking CentComm's denial of the existence of the derelict station near Space Station 13." ).set( "name", "- Kosmicheskaya Stantsiya 13 Does Not Exist" ), 
			new ByTable().set( "desc", " A poster urging the viewer to rebel against Nanotrasen." ).set( "name", "- Rebels Unite" ), 
			new ByTable().set( "desc", " A poster advertising the Scarborough Arms C-20r." ).set( "name", "- C-20r" ), 
			new ByTable().set( "desc", " Who cares about lung cancer when you're high as a kite?" ).set( "name", "- Have a Puff" ), 
			new ByTable().set( "desc", " Because seven shots are all you need." ).set( "name", "- Revolver" ), 
			new ByTable().set( "desc", " A promotional poster for some rapper." ).set( "name", "- D-Day Promo" ), 
			new ByTable().set( "desc", " A poster advertising syndicate pistols as being 'classy as fuck'. It is covered in faded gang tags." ).set( "name", "- Syndicate Pistol" ), 
			new ByTable().set( "desc", " All the colors of the bloody murder rainbow." ).set( "name", "- Energy Swords" ), 
			new ByTable().set( "desc", " Looking at this poster makes you want to kill." ).set( "name", "- Red Rum" ), 
			new ByTable().set( "desc", " The latest portable computer from Comrade Computing, with a whole 64kB of ram!" ).set( "name", "- CC 64K Ad" ), 
			new ByTable().set( "desc", " Fight things for no reason, like a man!" ).set( "name", "- Punch Shit" ), 
			new ByTable().set( "desc", " The Griffin commands you to be the worst you can be. Will you?" ).set( "name", "- The Griffin" ), 
			new ByTable().set( "desc", " This lewd poster depicts a lizard preparing to mate." ).set( "name", "- Lizard" ), 
			new ByTable().set( "desc", " This poster commemorates the bravery of the rogue drone banned by CentComm." ).set( "name", "- Free Drone" ), 
			new ByTable().set( "desc", " Get a load, or give, of these all natural Xenos!" ).set( "name", "- Busty Backdoor Xeno Babes 6" )
		 });
		public const ByTable corgi_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( 3, 3 ).set( 2, typeof(Ent_Item_Clothing_Suit_Hooded_IanCostume) ).set( 1, "corgi costume" ).applyCtor( typeof(StackRecipe) ) });
		public static dynamic create_mob_html = null;
		public const ByTable create_object_forms = new ByTable(new object [] { typeof(Entity), typeof(Ent_Structure), typeof(Ent_Machinery), typeof(Ent_Effect), typeof(Ent_Item), typeof(Ent_Item_Clothing), typeof(Ent_Item_Stack), typeof(Ent_Item_Device), typeof(Ent_Item_Weapon), typeof(Ent_Item_Weapon_ReagentContainers), typeof(Ent_Item_Weapon_Gun) });
		public static dynamic create_object_html = null;
		public static dynamic create_turf_html = null;
		public const ByTable crematoriums = new ByTable();
		public const Crewmonitor crewmonitor = new Crewmonitor();
		public const ByTable crit_allowed_modes = new ByTable(new object [] { "whisper", "changeling", "alientalk" });
		public const ByTable custom_outfits = new ByTable();
		public const dynamic data_core = null;
		public const int days_early = 1;
		public static DBConnection dbcon = new DBConnection();
		public static ByTable dead_mob_list = new ByTable();
		public static ByTable deadmins = new ByTable();
		public const ByTable deathsquadspawn = new ByTable();
		public const int Debug = 0;
		public static int Debug2 = 0;
		public const Chatroom default_ntrc_chatroom = new Chatroom();
		public const ByTable defaults = new ByTable(new object [] { "No", "Yes" });
		public static ByTable deliverybeacons = new ByTable();
		public static ByTable deliverybeacontags = new ByTable();
		public const ByTable department_radio_keys = new ByTable().set( ".ï", "changeling" ).set( "#ï", "changeling" ).set( ":ï", "changeling" ).set( ".é", "Supply" ).set( "#é", "Supply" ).set( ":é", "Supply" ).set( ".å", "Syndicate" ).set( "#å", "Syndicate" ).set( ":å", "Syndicate" ).set( ".ô", "alientalk" ).set( "#ô", "alientalk" ).set( ":ô", "alientalk" ).set( ".è", "binary" ).set( "#è", "binary" ).set( ":è", "binary" ).set( ".ö", "whisper" ).set( "#ö", "whisper" ).set( ":ö", "whisper" ).set( ".û", "Security" ).set( "#û", "Security" ).set( ":û", "Security" ).set( ".ó", "Engineering" ).set( "#ó", "Engineering" ).set( ":ó", "Engineering" ).set( ".ü", "Medical" ).set( "#ü", "Medical" ).set( ":ü", "Medical" ).set( ".ò", "Science" ).set( "#ò", "Science" ).set( ":ò", "Science" ).set( ".ñ", "Command" ).set( "#ñ", "Command" ).set( ":ñ", "Command" ).set( ".ð", "department" ).set( "#ð", "department" ).set( ":ð", "department" ).set( ".ø", "intercom" ).set( "#ø", "intercom" ).set( ":ø", "intercom" ).set( ".ä", "left hand" ).set( "#ä", "left hand" ).set( ":ä", "left hand" ).set( ".ê", "right hand" ).set( "#ê", "right hand" ).set( ":ê", "right hand" ).set( ".Y", "Centcom" ).set( "#Y", "Centcom" ).set( ":Y", "Centcom" ).set( ".G", "changeling" ).set( "#G", "changeling" ).set( ":G", "changeling" ).set( ".O", "AI Private" ).set( "#O", "AI Private" ).set( ":O", "AI Private" ).set( ".V", "Service" ).set( "#V", "Service" ).set( ":V", "Service" ).set( ".U", "Supply" ).set( "#U", "Supply" ).set( ":U", "Supply" ).set( ".T", "Syndicate" ).set( "#T", "Syndicate" ).set( ":T", "Syndicate" ).set( ".A", "alientalk" ).set( "#A", "alientalk" ).set( ":A", "alientalk" ).set( ".B", "binary" ).set( "#B", "binary" ).set( ":B", "binary" ).set( ".W", "whisper" ).set( "#W", "whisper" ).set( ":W", "whisper" ).set( ".S", "Security" ).set( "#S", "Security" ).set( ":S", "Security" ).set( ".E", "Engineering" ).set( "#E", "Engineering" ).set( ":E", "Engineering" ).set( ".M", "Medical" ).set( "#M", "Medical" ).set( ":M", "Medical" ).set( ".N", "Science" ).set( "#N", "Science" ).set( ":N", "Science" ).set( ".C", "Command" ).set( "#C", "Command" ).set( ":C", "Command" ).set( ".H", "department" ).set( "#H", "department" ).set( ":H", "department" ).set( ".I", "intercom" ).set( "#I", "intercom" ).set( ":I", "intercom" ).set( ".L", "left hand" ).set( "#L", "left hand" ).set( ":L", "left hand" ).set( ".R", "right hand" ).set( "#R", "right hand" ).set( ":R", "right hand" ).set( ".y", "Centcom" ).set( "#y", "Centcom" ).set( ":y", "Centcom" ).set( ".g", "changeling" ).set( "#g", "changeling" ).set( ":g", "changeling" ).set( ".o", "AI Private" ).set( "#o", "AI Private" ).set( ":o", "AI Private" ).set( ".v", "Service" ).set( "#v", "Service" ).set( ":v", "Service" ).set( ".u", "Supply" ).set( "#u", "Supply" ).set( ":u", "Supply" ).set( ".t", "Syndicate" ).set( "#t", "Syndicate" ).set( ":t", "Syndicate" ).set( ".a", "alientalk" ).set( "#a", "alientalk" ).set( ":a", "alientalk" ).set( ".b", "binary" ).set( "#b", "binary" ).set( ":b", "binary" ).set( ".w", "whisper" ).set( "#w", "whisper" ).set( ":w", "whisper" ).set( ".s", "Security" ).set( "#s", "Security" ).set( ":s", "Security" ).set( ".e", "Engineering" ).set( "#e", "Engineering" ).set( ":e", "Engineering" ).set( ".m", "Medical" ).set( "#m", "Medical" ).set( ":m", "Medical" ).set( ".n", "Science" ).set( "#n", "Science" ).set( ":n", "Science" ).set( ".c", "Command" ).set( "#c", "Command" ).set( ":c", "Command" ).set( ".h", "department" ).set( "#h", "department" ).set( ":h", "department" ).set( ".i", "intercom" ).set( "#i", "intercom" ).set( ":i", "intercom" ).set( ".l", "left hand" ).set( "#l", "left hand" ).set( ":l", "left hand" ).set( ".r", "right hand" ).set( "#r", "right hand" ).set( ":r", "right hand" );
		public static ByTable department_security_spawns = new ByTable();
		public const ByTable diagonals = new ByTable(new object [] { GlobalVars.NORTHEAST, GlobalVars.NORTHWEST, GlobalVars.SOUTHEAST, GlobalVars.SOUTHWEST });
		public const ByTable diamond_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Transparent_Diamond) ).set( 1, "diamond door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "diamond tile", typeof(Ent_Item_Stack_Tile_Mineral_Diamond), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Diamond_Captain) ).set( 1, "Captain Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Diamond_Ai1) ).set( 1, "AI Hologram Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Diamond_Ai2) ).set( 1, "AI Core Statue" ).applyCtor( typeof(StackRecipe) ) });
		public const dynamic diary = null;
		public const dynamic diaryofmeanpeople = null;
		public const ByTable dictionary_symptoms = new ByTable();
		public const ByTable direction_table = new ByTable();
		public static ByTable directory = new ByTable();
		public const int DISCONNECTED = 0;
		public const dynamic diseases = Misc13.types( typeof(Disease) ) - typeof(Disease);
		public const ByTable disposalpipeID2State = new ByTable(new object [] { "pipe-s", "pipe-c", "pipe-j1", "pipe-j2", "pipe-y", "pipe-t", "disposal", "outlet", "intake", "pipe-j1s", "pipe-j2s" });
		public static dynamic dooc_allowed = 1;
		public static ByTable doppler_arrays = new ByTable();
		public const int DOWN = 32;
		public const int duration = 13;
		public const ByTable ears_list = new ByTable();
		public const int EAST = 4;
		public const int EFFECTS_LAYER = 5000;
		public static int emergency_access = 0;
		public static ByTable emergencyresponseteamspawn = new ByTable();
		public static dynamic emojis = null;
		public const int ENG_FREQ = 1357;
		public const ByTable engineering_positions = new ByTable(new object [] { "Chief Engineer", "Station Engineer", "Atmospheric Technician" });
		public const int ENGSEC = 1;
		public static dynamic enter_allowed = 1;
		public const int EYE_PERSPECTIVE = 1;
		public const ByTable facial_hair_styles_female_list = new ByTable();
		public const ByTable facial_hair_styles_list = new ByTable();
		public const ByTable facial_hair_styles_male_list = new ByTable();
		public static int failed_db_connections = 0;
		public static Controller_Failsafe Failsafe = null;
		public const int FALSE = 0;
		public const string FEMALE = "female";
		public const ByTable female_clothing_icons = new ByTable();
		public static double fileaccess_timer = 0;
		public const dynamic fire_overlay = typeof(Image).BTNew( new ByTable().set( "icon_state", "fire" ).set( "icon", new ByRsc(292) ) );
		public const ByTable first_names_female = GlobalFuncs.file2list( "config/names/first_female.txt" );
		public const ByTable first_names_male = GlobalFuncs.file2list( "config/names/first_male.txt" );
		public const int FLOAT_LAYER = -1;
		public static int floorIsLava = 0;
		public const int FLY_LAYER = 5;
		public const ByTable forbidden_varedit_object_types = new ByTable(new object [] { typeof(Admins), typeof(Ent_Machinery_BlackboxRecorder), typeof(FeedbackVariable), typeof(AdminRank) });
		public const int FREQ_LISTENING = 1;
		public const ByTable freqtospan = new ByTable().set( "1337", "centcomradio" ).set( "1213", "syndradio" ).set( "1447", "aiprivradio" ).set( "1353", "comradio" ).set( "1359", "secradio" ).set( "1349", "servradio" ).set( "1347", "suppradio" ).set( "1357", "engradio" ).set( "1355", "medradio" ).set( "1351", "sciradio" );
		public const ByTable frills_list = new ByTable();
		public static ByTable g_fancy_list_of_types = null;
		public static ByTable gang_colors_pool = new ByTable(new object [] { "red", "orange", "yellow", "green", "blue", "purple" });
		public static ByTable gang_name_pool = new ByTable(new object [] { "Clandestine", "Prima", "Zero-G", "Max", "Blasto", "Waffle", "North", "Omni", "Newton", "Cyber", "Donk", "Gene", "Gib", "Tunnel", "Diablo", "Psyke", "Osiron", "Sirius", "Sleeping Carp" });
		public static dynamic gaussian_next = null;
		public static ByTable ghost_darkness_images = new ByTable();
		public const ByTable ghost_forms = new ByTable(new object [] { "ghost", "ghostking", "ghostian2", "skeleghost", "ghost_red", "ghost_black", "ghost_blue", "ghost_yellow", "ghost_green", "ghost_pink", "ghost_cyan", "ghost_dblue", "ghost_dred", "ghost_dgreen", "ghost_dcyan", "ghost_grey", "ghost_dyellow", "ghost_dpink", "ghost_purpleswirl", "ghost_funkypurp", "ghost_pinksherbert", "ghost_blazeit", "ghost_mellow", "ghost_rainbow", "ghost_camo", "ghost_fire" });
		public static int gid = 1;
		public static int gl_uid = 1;
		public const GlobalHud global_hud = new GlobalHud();
		public const dynamic global_map = null;
		public const ByTable global_mutations = new ByTable();
		public static int global_uid = 0;
		public const ByTable globalBlankCanvases = new ByTable( 4 );
		public const ByTable GlobalPool = new ByTable();
		public const ByTable gold_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Gold) ).set( 1, "golden door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "gold tile", typeof(Ent_Item_Stack_Tile_Mineral_Gold), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Hos) ).set( 1, "HoS Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Hop) ).set( 1, "HoP Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Ce) ).set( 1, "CE Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Rd) ).set( 1, "RD Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Cmo) ).set( 1, "CMO Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable good_mutations = new ByTable();
		public const ByTable GPS_list = new ByTable();
		public const ByTable gravity_generators = new ByTable();
		public static dynamic guests_allowed = 1;
		public const ByTable hair_styles_female_list = new ByTable();
		public const ByTable hair_styles_list = new ByTable();
		public const ByTable hair_styles_male_list = new ByTable();
		public const ByTable hex_characters = new ByTable(new object [] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" });
		public const ByTable hit_appends = new ByTable(new object [] { "-OOF", "-ACK", "-UGH", "-HRNK", "-HURGH", "-GLORF" });
		public static ByTable hivemind_bank = new ByTable();
		public static ByTable holdingfacility = new ByTable();
		public const int HOLOPAD_MODE = 4;
		public const ByTable horns_list = new ByTable();
		public static dynamic host = null;
		public const dynamic href_logfile = null;
		public const ByTable hrefs = new ByTable().set( "Spawn Air Canister", "hsbspawn&path=" + typeof(Ent_Machinery_PortableAtmospherics_Canister_Air) ).set( "Spawn O2 Canister", "hsbspawn&path=" + typeof(Ent_Machinery_PortableAtmospherics_Canister_Oxygen) ).set( 31, "Canisters" ).set( "Spawn Medbot", "hsbspawn&path=" + typeof(Ent_Machinery_Bot_Medbot) ).set( "Spawn Floorbot", "hsbspawn&path=" + typeof(Ent_Machinery_Bot_Floorbot) ).set( "Spawn Cleanbot", "hsbspawn&path=" + typeof(Ent_Machinery_Bot_Cleanbot) ).set( 27, "Bots" ).set( "Spawn Water Tank", "hsbspawn&path=" + typeof(Ent_Structure_ReagentDispensers_Watertank) ).set( "Spawn Welding Fuel Tank", "hsbspawn&path=" + typeof(Ent_Structure_ReagentDispensers_Fueltank) ).set( "Spawn Air Scrubber", "hsbscrubber" ).set( 23, "Miscellaneous" ).set( "Spawn Airlock", "hsbairlock" ).set( "Spawn RCD Ammo", "hsb_safespawn&path=" + typeof(Ent_Item_Weapon_RcdAmmo) ).set( "Spawn Rapid Construction Device", "hsbrcd" ).set( "Spawn Inf. Capacity Power Cell", "hsbspawn&path=" + typeof(Ent_Item_Weapon_StockParts_Cell_Infinite) ).set( "Spawn Hyper Capacity Power Cell", "hsbspawn&path=" + typeof(Ent_Item_Weapon_StockParts_Cell_Hyper) ).set( "Spawn Full Cable Coil", "hsbspawn&path=" + typeof(Ent_Item_Stack_CableCoil) ).set( "Spawn 50 Glass", "hsbglass" ).set( "Spawn 50 Reinforced Glass", "hsbrglass" ).set( "Spawn 50 Plasteel", "hsbplasteel" ).set( "Spawn 50 Metal", "hsbmetal" ).set( "Spawn 50 Wood", "hsbwood" ).set( 11, "Building Supplies" ).set( "Spawn All-Access ID", "hsbaaid" ).set( "Spawn Medical Kit", "hsbspawn&path=" + typeof(Ent_Item_Weapon_Storage_Firstaid_Regular) ).set( "Spawn Light Replacer", "hsbspawn&path=" + typeof(Ent_Item_Device_Lightreplacer) ).set( "Spawn Toolbox", "hsbspawn&path=" + typeof(Ent_Item_Weapon_Storage_Toolbox_Mechanical) ).set( "Spawn Flashlight", "hsbspawn&path=" + typeof(Ent_Item_Device_Flashlight) ).set( 5, "Standard Tools" ).set( "Spawn Emergency Air Tank", "hsbspawn&path=" + typeof(Ent_Item_Weapon_Tank_Internals_EmergencyOxygen_Double) ).set( "Spawn Gas Mask", "hsbspawn&path=" + typeof(Ent_Item_Clothing_Mask_Gas) ).set( "Suit Up (Space Travel Gear)", "hsbsuit" ).set( 1, "Space Gear" );
		public static int hsboxspawn = 1;
		public const ByTable html_interfaces = new ByTable();
		public const ByTable huds = new ByTable().set( 10, new AtomHud_Antag() ).set( 9, new AtomHud_Antag() ).set( 8, new AtomHud_Antag() ).set( 7, new AtomHud_Antag() ).set( 6, new AtomHud_Antag() ).set( 5, new AtomHud_Data_Diagnostic() ).set( 4, new AtomHud_Data_Human_Medical_Advanced() ).set( 3, new AtomHud_Data_Human_Medical_Basic() ).set( 2, new AtomHud_Data_Human_Security_Advanced() ).set( 1, new AtomHud_Data_Human_Security_Basic() );
		public const ByTable IClog = new ByTable();
		public const int ICON_SIZE = 4;
		public const ByTable icons_to_ignore_at_floor_init = new ByTable(new object [] { "damaged1", "damaged2", "damaged3", "damaged4", "damaged5", "panelscorched", "floorscorched1", "floorscorched2", "platingdmg1", "platingdmg2", "platingdmg3", "plating", "light_on", "light_on_flicker1", "light_on_flicker2", "light_on_clicker3", "light_on_clicker4", "light_on_clicker5", "light_broken", "light_on_broken", "light_off", "wall_thermite", "grass", "sand", "asteroid", "asteroid_dug", "asteroid0", "asteroid1", "asteroid2", "asteroid3", "asteroid4", "asteroid5", "asteroid6", "asteroid7", "asteroid8", "asteroid9", "asteroid10", "asteroid11", "asteroid12", "oldburning", "light-on-r", "light-on-y", "light-on-g", "light-on-b", "wood", "wood-broken", "carpetcorner", "carpetside", "carpet", "ironsand1", "ironsand2", "ironsand3", "ironsand4", "ironsand5", "ironsand6", "ironsand7", "ironsand8", "ironsand9", "ironsand10", "ironsand11", "ironsand12", "ironsand13", "ironsand14", "ironsand15" });
		public const ByTable iconsetids = new ByTable();
		public const int INGEST = 2;
		public static int intercom_range_display_status = 0;
		public const ByTable jobban_keylist = new ByTable( 0 );
		public const dynamic join_motd = null;
		public static ByTable joined_player_list = new ByTable();
		public const string js_byjax = "\n\nfunction replaceContent() {\n	var args = Array.prototype.slice.call(arguments);\n	var id = args[0];\n	var content = args[1];\n	var callback  = null;\n	if(args[2]){\n		callback = args[2];\n		if(args[3]){\n			args = args.slice(3);\n		}\n	}\n	var parent = document.getElementById(id);\n	if(typeof(parent)!=='undefined' && parent!=null){\n		parent.innerHTML = content?content:'';\n	}\n	if(callback && window[callback]){\n		window[callback].apply(null,args);\n	}\n}\n";
		public const string js_dropdowns = "\nfunction dropdowns() {\n    var divs = document.getElementsByTagName('div');\n    var headers = new Array();\n    var links = new Array();\n    for(var i=0;i<divs.length;i++){\n        if(divs[i].className=='header') {\n            divs[i].className='header closed';\n            divs[i].innerHTML = divs[i].innerHTML+' +';\n            headers.push(divs[i]);\n        }\n        if(divs[i].className=='links') {\n            divs[i].className='links hidden';\n            links.push(divs[i]);\n        }\n    }\n    for(var i=0;i<headers.length;i++){\n        if(typeof(links[i])!== 'undefined' && links[i]!=null) {\n            headers[i].onclick = (function(elem) {\n                return function() {\n                    if(elem.className.search('visible')>=0) {\n                        elem.className = elem.className.replace('visible','hidden');\n                        this.className = this.className.replace('open','closed');\n                        this.innerHTML = this.innerHTML.replace('-','+');\n                    }\n                    else {\n                        elem.className = elem.className.replace('hidden','visible');\n                        this.className = this.className.replace('closed','open');\n                        this.innerHTML = this.innerHTML.replace('+','-');\n                    }\n                return false;\n                }\n            })(links[i]);\n        }\n    }\n}\n";
		public const ByTable json_escape = new ByTable(new object [] { "\\", "\"", "'", "\n" });
		public static ByTable landmarks_list = new ByTable();
		public const ByTable last_names = GlobalFuncs.file2list( "config/names/last.txt" );
		public const ByTable lastsignalers = new ByTable();
		public static ByTable latejoin = new ByTable();
		public const ByTable lawchanges = new ByTable();
		public const ByTable legitposters = new ByTable(new object [] { 
			new ByTable().set( "desc", " A poster glorifying the station's security force." ).set( "name", "- Here For Your Safety" ), 
			new ByTable().set( "desc", " A poster depicting the Nanotrasen logo." ).set( "name", "- Nanotrasen Logo" ), 
			new ByTable().set( "desc", " A poster warning of the dangers of poor hygiene." ).set( "name", "- Cleanliness" ), 
			new ByTable().set( "desc", " A poster encouraging you to help fellow crewmembers." ).set( "name", "- Help Others" ), 
			new ByTable().set( "desc", " A poster glorifying the engineering team." ).set( "name", "- Build" ), 
			new ByTable().set( "desc", " A poster blessing this area." ).set( "name", "- Bless This Spess" ), 
			new ByTable().set( "desc", " A poster depicting an atom." ).set( "name", "- Science" ), 
			new ByTable().set( "desc", " Arf arf. Yap." ).set( "name", "- Ian" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to obey authority." ).set( "name", "- Obey" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to walk instead of running." ).set( "name", "- Walk" ), 
			new ByTable().set( "desc", " A poster instructing cyborgs to state their laws." ).set( "name", "- State Laws" ), 
			new ByTable().set( "desc", " Ian is love, Ian is life." ).set( "name", "- Love Ian" ), 
			new ByTable().set( "desc", " A poster advertising the television show Space Cops." ).set( "name", "- Space Cops." ), 
			new ByTable().set( "desc", " This thing is all in Japanese." ).set( "name", "- Ue No." ), 
			new ByTable().set( "desc", " LEGS: Leadership, Experience, Genius, Subordination." ).set( "name", "- Get Your LEGS" ), 
			new ByTable().set( "desc", " A poster instructing the viewer not to ask about things they aren't meant to know." ).set( "name", "- Do Not Question" ), 
			new ByTable().set( "desc", " A poster encouraging you to work for your future." ).set( "name", "- Work For A Future" ), 
			new ByTable().set( "desc", " A poster reprint of some cheap pop art." ).set( "name", "- Soft Cap Pop Art" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to wear internals in the rare environments where there is no oxygen or the air has been rendered toxic." ).set( "name", "- Safety: Internals" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to wear eye protection when dealing with chemicals, smoke, or bright lights." ).set( "name", "- Safety: Eye Protection" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to report suspicious activity to the security force." ).set( "name", "- Safety: Report" ), 
			new ByTable().set( "desc", " A poster encouraging the swift reporting of crime or seditious behavior to station security." ).set( "name", "- Report Crimes" ), 
			new ByTable().set( "desc", " A poster displaying an Ion Rifle." ).set( "name", "- Ion Rifle" ), 
			new ByTable().set( "desc", " Foam Force, it's Foam or be Foamed!" ).set( "name", "- Foam Force Ad" ), 
			new ByTable().set( "desc", " Cohiba Robusto, the classy cigar." ).set( "name", "- Cohiba Robusto Ad" ), 
			new ByTable().set( "desc", " A reprint of a poster from 2505, commemorating the 50th Aniversery of Nanoposters Manufacturing, a subsidary of Nanotrasen." ).set( "name", "- 50th Anniversary Vintage Reprint" ), 
			new ByTable().set( "desc", " Simple, yet awe-inspiring." ).set( "name", "- Fruit Bowl" ), 
			new ByTable().set( "desc", " A poster advertising the latest PDA from Nanotrasen suppliers." ).set( "name", "- PDA Ad" ), 
			new ByTable().set( "desc", " Enlist in the Nanotrasen Deathsquadron reserves today!" ).set( "name", "- Enlist" ), 
			new ByTable().set( "desc", " A poster advertising Nanomichi brand audio cassettes." ).set( "name", "- Nanomichi Ad" ), 
			new ByTable().set( "desc", " A poster boasting about the superiority of 12 gauge shotgun shells." ).set( "name", "- 12 Gauge" ), 
			new ByTable().set( "desc", " I told you to shake it, no stirring." ).set( "name", "- High-Class Martini" ), 
			new ByTable().set( "desc", " The Owl would do his best to protect the station. Will you?" ).set( "name", "- The Owl" ), 
			new ByTable().set( "desc", " This poster reminds the crew that Eroticism, Rape and Pornography are banned on Nanotrasen stations." ).set( "name", "- No ERP" ), 
			new ByTable().set( "desc", " This informational poster teaches the viewer what carbon dioxide is." ).set( "name", "- Carbon Dioxide" )
		 });
		public const dynamic list_symptoms = Misc13.types( typeof(Symptom) ) - typeof(Symptom);
		public static ByTable living_mob_list = new ByTable();
		public const ByTable lizard_names_female = GlobalFuncs.file2list( "config/names/lizard_female.txt" );
		public const ByTable lizard_names_male = GlobalFuncs.file2list( "config/names/lizard_male.txt" );
		public static ByTable machines = new ByTable();
		public const string MALE = "male";
		public const ByTable map_transition_config = new ByTable().set( "Empty Area 2", 2 ).set( "Empty Area 1", 2 ).set( "Mining Asteroid", 2 ).set( "Derelicted Station", 2 ).set( "Abandoned Satellite", 2 ).set( "CentComm", 1 ).set( "Main Station", 2 );
		public const DmmSuite maploader = new DmmSuite();
		public static Controller_GameController master_controller = new Controller_GameController();
		public static dynamic master_mode = "traitor";
		public const int MAX_ACTIVE_TIME = 400;
		public const int MAX_CHICKENS = 50;
		public static int MAX_EX_DEVESTATION_RANGE = 3;
		public static int MAX_EX_FLAME_RANGE = 14;
		public static int MAX_EX_FLASH_RANGE = 14;
		public static int MAX_EX_HEAVY_RANGE = 7;
		public static int MAX_EX_LIGHT_RANGE = 14;
		public const int max_health = 100;
		public const int MAX_ICON_DIMENSION = 1024;
		public const int MAX_IMPREGNATION_TIME = 150;
		public const int max_secret_rooms = 6;
		public const int max_signs = 4;
		public static ByTable mechas_list = new ByTable();
		public const int MED_FREQ = 1355;
		public const ByTable medical_positions = new ByTable(new object [] { "Chief Medical Officer", "Medical Doctor", "Geneticist", "Virologist", "Chemist" });
		public const int MEDSCI = 2;
		public static int message_delay = 0;
		public static ByTable message_servers = new ByTable();
		public const ByTable metal_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 2, typeof(Ent_Structure_Bed_Stool) ).set( 1, "stool" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 2, typeof(Ent_Structure_Bed_Chair) ).set( 1, "chair" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Bed_Chair_Office_Dark) ).set( 1, "swivel chair" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Bed_Chair_Comfy_Beige) ).set( 1, "comfy chair" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Bed) ).set( 1, "bed" ).applyCtor( typeof(StackRecipe) ), null, new StackRecipe( "rack parts", typeof(Ent_Item_Weapon_RackParts) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Closet) ).set( 1, "closet" ).applyCtor( typeof(StackRecipe) ), null, new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 10 ).set( 2, typeof(Ent_Machinery_PortableAtmospherics_Canister) ).set( 1, "canister" ).applyCtor( typeof(StackRecipe) ), null, new StackRecipe( "floor tile", typeof(Ent_Item_Stack_Tile_Plasteel), 1, 4, 20 ), new StackRecipe( "metal rod", typeof(Ent_Item_Stack_Rods), 1, 2, 60 ), null, new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 25 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Computerframe) ).set( 1, "computer frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Girder) ).set( 1, "wall girders" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_DoorAssembly) ).set( 1, "airlock assembly" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 3 ).set( 2, typeof(Ent_Structure_FirelockFrame) ).set( 1, "firelock frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 25 ).set( 3, 5 ).set( 2, typeof(Ent_Machinery_ConstructableFrame_MachineFrame) ).set( 1, "machine frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 25 ).set( 3, 5 ).set( 2, typeof(Ent_Machinery_PortaTurretConstruct) ).set( 1, "turret frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 25 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_KitchenspikeFrame) ).set( 1, "meatspike frame" ).applyCtor( typeof(StackRecipe) ), null, new StackRecipe( "grenade casing", typeof(Ent_Item_Weapon_Grenade_ChemGrenade) ), new StackRecipe( "light fixture frame", typeof(Ent_Item_Wallframe_LightFixture), 2 ), new StackRecipe( "small light fixture frame", typeof(Ent_Item_Wallframe_LightFixture_Small), 1 ), null, new StackRecipe( "apc frame", typeof(Ent_Item_Wallframe_Apc), 2 ), new StackRecipe( "air alarm frame", typeof(Ent_Item_Wallframe_Alarm), 2 ), new StackRecipe( "fire alarm frame", typeof(Ent_Item_Wallframe_Firealarm), 2 ), new StackRecipe( "button frame", typeof(Ent_Item_Wallframe_Button), 1 ), null, new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 20 ).set( 2, typeof(Ent_Structure_MineralDoor_Iron) ).set( 1, "iron door" ).applyCtor( typeof(StackRecipe) ) });
		public const int meteordelay = 2000;
		public const ByTable meteors_catastrophic = new ByTable().set( typeof(Ent_Effect_Meteor_Tunguska), 1 ).set( typeof(Ent_Effect_Meteor_Irradiated), 10 ).set( typeof(Ent_Effect_Meteor_Flaming), 10 ).set( typeof(Ent_Effect_Meteor_Big), 75 ).set( typeof(Ent_Effect_Meteor_Medium), 5 );
		public const ByTable meteors_normal = new ByTable().set( typeof(Ent_Effect_Meteor_Irradiated), 3 ).set( typeof(Ent_Effect_Meteor_Flaming), 1 ).set( typeof(Ent_Effect_Meteor_Big), 3 ).set( typeof(Ent_Effect_Meteor_Medium), 8 ).set( typeof(Ent_Effect_Meteor_Dust), 3 );
		public const ByTable meteors_threatening = new ByTable().set( typeof(Ent_Effect_Meteor_Irradiated), 3 ).set( typeof(Ent_Effect_Meteor_Flaming), 3 ).set( typeof(Ent_Effect_Meteor_Big), 8 ).set( typeof(Ent_Effect_Meteor_Medium), 4 );
		public const ByTable meteorsB = new ByTable().set( typeof(Ent_Effect_Meteor_Meaty_Xeno), 1 ).set( typeof(Ent_Effect_Meteor_Meaty), 5 );
		public const ByTable meteorsC = new ByTable(new object [] { typeof(Ent_Effect_Meteor_Dust) });
		public const ByTable meteorsSPOOKY = new ByTable(new object [] { typeof(Ent_Effect_Meteor_Pumpkin) });
		public const ByTable mime_names = GlobalFuncs.file2list( "config/names/mime.txt" );
		public const int MIN_ACTIVE_TIME = 200;
		public const int MIN_IMPREGNATION_TIME = 100;
		public const int MOB_LAYER = 4;
		public static ByTable mob_list = new ByTable();
		public const int MOB_PERSPECTIVE = 0;
		public const Moduletypes mods = new Moduletypes();
		public static ByTable modules = new ByTable().set( "/obj/machinery/power/apc", "card_reader,power_control,id_auth,cell_power,cell_charge" );
		public const ByTable monkey_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( 3, 1 ).set( 2, typeof(Ent_Item_Clothing_Mask_Gas_Monkeymask) ).set( 1, "monkey mask" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( 3, 2 ).set( 2, typeof(Ent_Item_Clothing_Suit_Monkeysuit) ).set( 1, "monkey suit" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable monkeystart = new ByTable();
		public const int mulebot_count = 0;
		public static ByTable multiverse = new ByTable();
		public const ByTable mutations_list = new ByTable();
		public static ByTable navbeacons = new ByTable();
		public static ByTable newplayer_start = new ByTable();
		public const Newscaster_FeedNetwork news_network = new Newscaster_FeedNetwork();
		public static int next_mob_id = 0;
		public static int nextid = 1;
		public static dynamic nextmap = null;
		public const ByTable ninja_names = GlobalFuncs.file2list( "config/names/ninjaname.txt" );
		public const ByTable ninja_titles = GlobalFuncs.file2list( "config/names/ninjatitle.txt" );
		public const int NO_SLIP_WHEN_WALKING = 1;
		public const ByTable non_fakeattack_weapons = new ByTable(new object [] { typeof(Ent_Item_Weapon_Gun_Projectile), typeof(Ent_Item_AmmoBox_A357), typeof(Ent_Item_Weapon_Gun_Energy_KineticAccelerator_Crossbow), typeof(Ent_Item_Weapon_Melee_Energy_Sword_Saber), typeof(Ent_Item_Weapon_Storage_Box_Syndicate), typeof(Ent_Item_Weapon_Storage_Box_Emps), typeof(Ent_Item_Weapon_Cartridge_Syndicate), typeof(Ent_Item_Clothing_Under_Chameleon), typeof(Ent_Item_Clothing_Shoes_Sneakers_Syndigaloshes), typeof(Ent_Item_Weapon_Card_Id_Syndicate), typeof(Ent_Item_Clothing_Mask_Gas_Voice), typeof(Ent_Item_Clothing_Glasses_Thermal), typeof(Ent_Item_Device_Chameleon), typeof(Ent_Item_Weapon_Card_Emag), typeof(Ent_Item_Weapon_Storage_Toolbox_Syndicate), typeof(Ent_Item_Weapon_AiModule), typeof(Ent_Item_Device_Radio_Headset_Syndicate), typeof(Ent_Item_Weapon_C4), typeof(Ent_Item_Device_Powersink), typeof(Ent_Item_Weapon_Storage_Box_SyndieKit), typeof(Ent_Item_Toy_Syndicateballoon), typeof(Ent_Item_Weapon_Gun_Energy_Laser_Captain), typeof(Ent_Item_Weapon_HandTele), typeof(Ent_Item_Weapon_Rcd), typeof(Ent_Item_Weapon_Tank_Jetpack), typeof(Ent_Item_Clothing_Under_Rank_Captain), typeof(Ent_Item_Device_Aicard), typeof(Ent_Item_Clothing_Shoes_Magboots), typeof(Ent_Item_Areaeditor_Blueprints), typeof(Ent_Item_Weapon_Disk_Nuclear), typeof(Ent_Item_Clothing_Suit_Space_Nasavoid), typeof(Ent_Item_Weapon_Tank) });
		public const dynamic non_revealed_runes = Misc13.types( typeof(Ent_Effect_Rune) ) - typeof(Ent_Effect_Rune_Malformed) - typeof(Ent_Effect_Rune);
		public const ByTable nonhuman_positions = new ByTable(new object [] { "AI", "Cyborg", "pAI" });
		public static string normal_ooc_colour = "#002eb8";
		public const int NORTH = 1;
		public const int NORTHEAST = 5;
		public const int NORTHWEST = 9;
		public static ByTable not_good_mutations = new ByTable();
		public static ByTable nuke_list = new ByTable();
		public const int num_power_levels = 6;
		public const int OBJ_LAYER = 3;
		public static dynamic ooc_allowed = 1;
		public const ByTable OOClog = new ByTable();
		public const int OPEN_DURATION = 6;
		public const int OPERATING = 2;
		public const int PARTICLE_STRENGTH_WIRE = 2;
		public const int PARTICLE_TOGGLE_WIRE = 1;
		public const int PATCH = 4;
		public static ByTable PDAs = new ByTable();
		public const ByTable pipe_types = new ByTable(new object [] { typeof(Ent_Machinery_Atmospherics_Pipe_Simple), typeof(Ent_Machinery_Atmospherics_Pipe_Manifold), typeof(Ent_Machinery_Atmospherics_Pipe_Manifold4w), typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Simple), typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold), typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold4w), typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Junction), typeof(Ent_Machinery_Atmospherics_Components_Unary_PortablesConnector), typeof(Ent_Machinery_Atmospherics_Components_Unary_VentPump), typeof(Ent_Machinery_Atmospherics_Components_Unary_VentScrubber), typeof(Ent_Machinery_Atmospherics_Components_Unary_HeatExchanger), typeof(Ent_Machinery_Atmospherics_Components_Binary_Pump), typeof(Ent_Machinery_Atmospherics_Components_Binary_PassiveGate), typeof(Ent_Machinery_Atmospherics_Components_Binary_VolumePump), typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve), typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve_Digital), typeof(Ent_Machinery_Atmospherics_Components_Trinary_Filter), typeof(Ent_Machinery_Atmospherics_Components_Trinary_Mixer) });
		public const ByTable pipeID2State = new ByTable().set( "" + typeof(Ent_Machinery_Atmospherics_Components_Trinary_Mixer), "mixer" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Trinary_Filter), "filter" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve_Digital), "dvalve" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve), "mvalve" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_VolumePump), "volumepump" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_PassiveGate), "passivegate" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_Pump), "pump" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Unary_HeatExchanger), "heunary" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Unary_VentScrubber), "scrubber" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Unary_VentPump), "uvent" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Unary_PortablesConnector), "connector" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Junction), "junction" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold4w), "he_manifold4w" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold), "he_manifold" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Simple), "he" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_Manifold4w), "manifold4w" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_Manifold), "manifold" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_Simple), "simple" );
		public const ByTable pipeimages = new ByTable();
		public static int pipenetwarnings = 10;
		public const int PIZZA_WIRE_DISARM = 1;
		public const ByTable plasma_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Transparent_Plasma) ).set( 1, "plasma door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "plasma tile", typeof(Ent_Item_Stack_Tile_Mineral_Plasma), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Plasma_Scientist) ).set( 1, "Scientist Statue" ).applyCtor( typeof(StackRecipe) ) });
		public const dynamic plasmaman_on_fire = typeof(Image).BTNew( new ByTable().set( "icon_state", "plasmaman" ).set( "icon", new ByRsc(234) ) );
		public const ByTable plasteel_recipes = new ByTable(new object [] { new ByTable().set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_AIcore) ).set( 1, "AI core" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable player_list = new ByTable();
		public const string PLURAL = "plural";
		public static ByTable pointers = new ByTable();
		public static ByTable portals = new ByTable();
		public static int posibrain_notif_cooldown = 0;
		public static ByTable possible_changeling_IDs = new ByTable(new object [] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega" });
		public const ByTable possible_items = new ByTable();
		public const ByTable possible_items_special = new ByTable();
		public static ByTable possible_uplinker_IDs = new ByTable(new object [] { "Alfa", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Zero", "Niner" });
		public const ByTable possibleShadowlingNames = new ByTable(new object [] { "U'ruan", "Y`shej", "Nex", "Hel-uae", "Noaey'gief", "Mii`mahza", "Amerziox", "Gyrg-mylin", "Kanet'pruunance", "Vigistaezian" });
		public static ByTable possiblethemes = new ByTable(new object [] { "organharvest", "cult", "wizden", "cavein", "xenoden", "hitech", "speakeasy", "plantlab" });
		public const int POWER_DOWN = 2;
		public const int POWER_IDLE = 0;
		public const int POWER_UP = 1;
		public static ByTable powernets = new ByTable();
		public const ByTable preferences_datums = new ByTable();
		public static ByTable prisonsecuritywarp = new ByTable();
		public static ByTable prisonwarp = new ByTable();
		public const ByTable prisonwarped = new ByTable();
		public static Subsystem_Procqueue procqueue = null;
		public const dynamic protected_config = null;
		public const ByTable protected_objects = new ByTable(new object [] { typeof(Ent_Structure_Table), typeof(Ent_Structure_Cable), typeof(Ent_Structure_Window) });
		public static ByTable rad_collectors = new ByTable();
		public const string RADIO_AIRLOCK = "6";
		public const string RADIO_ATMOSIA = "4";
		public const string RADIO_CHAT = "3";
		public static Subsystem_Radio radio_controller = null;
		public const string RADIO_FROM_AIRALARM = "2";
		public const string RADIO_MAGNETS = "9";
		public const string RADIO_TO_AIRALARM = "1";
		public const ByTable radiochannels = new ByTable().set( "AI Private", 1447 ).set( "Service", 1349 ).set( "Supply", 1347 ).set( "Syndicate", 1213 ).set( "Centcom", 1337 ).set( "Security", 1359 ).set( "Engineering", 1357 ).set( "Medical", 1355 ).set( "Command", 1353 ).set( "Science", 1351 ).set( "Common", 1459 );
		public const ByTable radiochannelsreverse = new ByTable().set( "1447", "AI Private" ).set( "1349", "Service" ).set( "1347", "Supply" ).set( "1213", "Syndicate" ).set( "1337", "Centcom" ).set( "1359", "Security" ).set( "1357", "Engineering" ).set( "1355", "Medical" ).set( "1353", "Command" ).set( "1351", "Science" ).set( "1459", "Common" );
		public static ByTable rcd_list = new ByTable();
		public const ByTable recentmessages = new ByTable();
		public const int record_id_num = 1001;
		public static ByTable req_console_assistance = new ByTable();
		public static ByTable req_console_information = new ByTable();
		public static ByTable req_console_supplies = new ByTable();
		public const Getrev revdata = new Getrev();
		public static ByTable rockTurfEdgeCache = null;
		public const ByTable rod_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Grille) ).set( 1, "grille" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_TableFrame) ).set( 1, "table frame" ).applyCtor( typeof(StackRecipe) ) });
		public const int ROOM_ERR_SPACE = -1;
		public const int ROOM_ERR_TOOLARGE = -2;
		public static double round_start_time = 0;
		public const ByTable roundstart_species = new ByTable( 0 );
		public const ByTable RPD_recipes = new ByTable()
			.set( "Disposal Pipes", new ByTable().set( "Sort Junction", new PipeInfo_Disposal( 9, 2 ) ).set( "Chute", new PipeInfo_Disposal( 8, 4 ) ).set( "Outlet", new PipeInfo_Disposal( 7, 4 ) ).set( "Bin", new PipeInfo_Disposal( 6, 5 ) ).set( "Trunk", new PipeInfo_Disposal( 5, 2 ) ).set( "Y-Junction", new PipeInfo_Disposal( 4, 2 ) ).set( "Junction", new PipeInfo_Disposal( 2, 2 ) ).set( "Bent Pipe", new PipeInfo_Disposal( 1, 2 ) ).set( "Pipe", new PipeInfo_Disposal( 0, 0 ) ) )
			.set( "Heat Exchange", new ByTable().set( "Heat Exchanger", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Unary_HeatExchanger), 1, 4 ) ).set( "Junction", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Junction), 1, 4 ) ).set( "4-Way Manifold", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold4w), 1, 5 ) ).set( "Manifold", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold), 1, 2 ) ).set( "Pipe", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Simple), 1, 1 ) ) )
			.set( "Devices", new ByTable().set( "Gas Mixer", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Trinary_Mixer), 1, 3 ) ).set( "Gas Filter", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Trinary_Filter), 1, 3 ) ).set( "Meter", new PipeInfo_Meter() ).set( "Scrubber", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Unary_VentScrubber), 1, 4 ) ).set( "Volume Pump", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_VolumePump), 1, 4 ) ).set( "Passive Gate", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_PassiveGate), 1, 4 ) ).set( "Gas Pump", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_Pump), 1, 4 ) ).set( "Unary Vent", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Unary_VentPump), 1, 4 ) ).set( "Connector", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Unary_PortablesConnector), 1, 4 ) ) )
			.set( "Regular Pipes", new ByTable().set( "4-Way Manifold", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_Manifold4w), 1, 5 ) ).set( "Digital Valve", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve_Digital), 1, 0 ) ).set( "Manual Valve", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve), 1, 0 ) ).set( "Manifold", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_Manifold), 1, 2 ) ).set( "Pipe", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_Simple), 1, 1 ) ) )
			
		;
		public const ByTable runed_metal_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 40 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_Cult_Pylon) ).set( 1, "pylon" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 40 ).set( 3, 6 ).set( 2, typeof(Ent_Structure_Cult_Forge) ).set( 1, "forge" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 40 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_Cult_Tome) ).set( 1, "archives" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 40 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_Cult_Talisman) ).set( 1, "altar" ).applyCtor( typeof(StackRecipe) ) });
		public const ByTable sacrificed = new ByTable();
		public const int SAFETY_COOLDOWN = 100;
		public const ByTable same_wires = new ByTable();
		public const ByTable sandstone_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 3 ).set( 2, typeof(Ent_Machinery_Hydroponics_Soil) ).set( 1, "pile of dirt" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Sandstone) ).set( 1, "sandstone door" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Sandstone_Assistant) ).set( 1, "Assistant Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static dynamic say_disabled = 0;
		public const string sc_safecode1 = "" + Rand.Int( 0, 9 );
		public const string sc_safecode2 = "" + Rand.Int( 0, 9 );
		public const string sc_safecode3 = "" + Rand.Int( 0, 9 );
		public const string sc_safecode4 = "" + Rand.Int( 0, 9 );
		public const string sc_safecode5 = "" + Rand.Int( 0, 9 );
		public const ByTable scarySounds = new ByTable(new object [] { new ByRsc(108), new ByRsc(261), new ByRsc(419), new ByRsc(43), new ByRsc(44), new ByRsc(45), new ByRsc(46), new ByRsc(254), new ByRsc(253), new ByRsc(16), new ByRsc(17), new ByRsc(18), new ByRsc(244), new ByRsc(110), new ByRsc(258), new ByRsc(38), new ByRsc(39) });
		public const int SCI_FREQ = 1351;
		public const ByTable science_positions = new ByTable(new object [] { "Research Director", "Scientist", "Roboticist" });
		public static ByTable sec_departments = new ByTable(new object [] { "engineering", "supply", "medical", "science" });
		public const int SEC_FREQ = 1359;
		public static ByTable secequipment = new ByTable();
		public static dynamic secret_force_mode = "secret";
		public static int security_level = 0;
		public const ByTable security_positions = new ByTable(new object [] { "Head of Security", "Warden", "Detective", "Security Officer" });
		public const int SEE_MOBS = 4;
		public const int SEE_OBJS = 8;
		public const int SEE_SELF = 32;
		public const int SEE_TURFS = 16;
		public const int SERV_FREQ = 1349;
		public static ByTable shuttle_caller_list = new ByTable();
		public const ByTable silver_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Silver) ).set( 1, "silver door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "silver tile", typeof(Ent_Item_Stack_Tile_Mineral_Silver), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Md) ).set( 1, "Med Officer Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Janitor) ).set( 1, "Janitor Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Sec) ).set( 1, "Sec Officer Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Secborg) ).set( 1, "Sec Borg Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Medborg) ).set( 1, "Med Borg Statue" ).applyCtor( typeof(StackRecipe) ) });
		public const ByTable skin_tones = new ByTable(new object [] { "albino", "caucasian1", "caucasian2", "caucasian3", "latino", "mediterranean", "asian1", "asian2", "arab", "indian", "african1", "african2" });
		public const ByTable slot_equipment_priority = new ByTable(new object [] { 1, 7, 14, 13, 2, 11, 12, 10, 8, 9, 6, 17, 15, 16 });
		public const ByTable slot2slot = new ByTable().set( "s_store", 17 ).set( "wear_id", 7 ).set( "ears", 8 ).set( "glasses", 9 ).set( "gloves", 10 ).set( "belt", 6 ).set( "shoes", 12 ).set( "w_uniform", 14 ).set( "wear_suit", 13 ).set( "back", 1 ).set( "wear_mask", 2 ).set( "head", 11 );
		public const ByTable slot2type = new ByTable().set( "s_store", typeof(Ent_Item_Changeling) ).set( "wear_id", typeof(Ent_Item_Changeling) ).set( "ears", typeof(Ent_Item_Changeling) ).set( "glasses", typeof(Ent_Item_Clothing_Glasses_Changeling) ).set( "gloves", typeof(Ent_Item_Clothing_Gloves_Changeling) ).set( "belt", typeof(Ent_Item_Changeling) ).set( "shoes", typeof(Ent_Item_Clothing_Shoes_Changeling) ).set( "w_uniform", typeof(Ent_Item_Clothing_Under_Changeling) ).set( "wear_suit", typeof(Ent_Item_Clothing_Suit_Changeling) ).set( "back", typeof(Ent_Item_Changeling) ).set( "wear_mask", typeof(Ent_Item_Clothing_Mask_Changeling) ).set( "head", typeof(Ent_Item_Clothing_Head_Changeling) );
		public const ByTable slots = new ByTable(new object [] { "head", "wear_mask", "back", "wear_suit", "w_uniform", "shoes", "belt", "gloves", "glasses", "ears", "wear_id", "s_store" });
		public static ByTable smesImageCache = null;
		public const ByTable snouts_list = new ByTable();
		public const ByTable socks_f = new ByTable();
		public const ByTable socks_list = new ByTable();
		public const ByTable socks_m = new ByTable();
		public const ByTable sortedAreas = new ByTable();
		public const SortInstance sortInstance = new SortInstance();
		public const int SOUND_PAUSED = 2;
		public const int SOUND_STREAM = 4;
		public const int SOUTH = 2;
		public const int SOUTHEAST = 6;
		public const int SOUTHWEST = 10;
		public const ByTable spawn_forbidden = new ByTable(new object [] { typeof(Ent_Item_Weapon_Grab), typeof(Ent_Item_TkGrab), typeof(Ent_Item_Weapon_Implant), typeof(Ent_Item_Assembly), typeof(Ent_Item_Device_Onetankbomb), typeof(Ent_Item_Radio), typeof(Ent_Item_Device_Pda_Ai), typeof(Ent_Item_Device_Uplink_Hidden), typeof(Ent_Item_SmallDelivery), typeof(Ent_Item_Missile), typeof(Ent_Item_Projectile), typeof(Ent_Item_Borg_Sight), typeof(Ent_Item_Borg_Stun), typeof(Ent_Item_Weapon_RobotModule) });
		public const int SPAWN_HEAT = 1;
		public const int SPAWN_OXYGEN = 8;
		public const ByTable special_roles = new ByTable().set( "abductor", typeof(GameMode_Abduction) ).set( "shadowling", typeof(GameMode_Shadowling) ).set( "gangster", typeof(GameMode_Gang) ).set( "monkey", typeof(GameMode_Monkey) ).set( 11, "ninja" ).set( "blob", typeof(GameMode_Blob) ).set( "cultist", typeof(GameMode_Cult) ).set( 8, "pAI/posibrain" ).set( 7, "alien" ).set( "revolutionary", typeof(GameMode_Revolution) ).set( "malf AI", typeof(GameMode_Malfunction) ).set( "wizard", typeof(GameMode_Wizard) ).set( "changeling", typeof(GameMode_Changeling) ).set( "operative", typeof(GameMode_Nuclear) ).set( "traitor", typeof(GameMode_Traitor) );
		public const ByTable species_list = new ByTable( 0 );
		public const dynamic spells = Misc13.types( typeof(Ent_Effect_ProcHolder_Spell) );
		public const ByTable spines_list = new ByTable();
		public static string sqladdress = "localhost";
		public static string sqlfdbkdb = "test";
		public static string sqlfdbklogin = "root";
		public static string sqlfdbkpass = "";
		public static string sqlfdbktableprefix = "erro_";
		public static string sqlport = "3306";
		public const ByTable sqrtTable = new ByTable(new object [] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 10 });
		public static Subsystem_Air SSair = null;
		public static Subsystem_Bots SSbot = null;
		public static Subsystem_Npcpool SSbp = null;
		public static Subsystem_Diseases SSdisease = null;
		public static Subsystem_Events SSevent = null;
		public static Subsystem_GarbageCollector SSgarbage = null;
		public static Subsystem_Job SSjob = null;
		public static Subsystem_Lighting SSlighting = null;
		public static Subsystem_Machines SSmachine = null;
		public static Subsystem_Mobs SSmob = null;
		public static Subsystem_Nano SSnano = null;
		public static Subsystem_Objects SSobj = null;
		public static Subsystem_Pai SSpai = null;
		public static Subsystem_Shuttle SSshuttle = null;
		public static Subsystem_Sun SSsun = null;
		public static Subsystem_Timer SStimer = null;
		public static Subsystem_Vote SSvote = null;
		public static ByTable start_landmarks_list = new ByTable();
		public static StationState start_state = null;
		public const int STATE_ALERT_LEVEL = 8;
		public const int STATE_CALLSHUTTLE = 2;
		public const int STATE_CANCELSHUTTLE = 3;
		public const int STATE_CONFIRM_LEVEL = 9;
		public const int STATE_DEFAULT = 1;
		public const int STATE_DELMESSAGE = 6;
		public const int STATE_MESSAGELIST = 4;
		public const int STATE_STATUSDISPLAY = 7;
		public const int STATE_TOGGLE_EMERGENCY = 10;
		public const int STATE_VIEWMESSAGE = 5;
		public static string station_name = null;
		public static int status_overlays = 0;
		public static ByTable status_overlays_charging = null;
		public static ByTable status_overlays_environ = null;
		public static ByTable status_overlays_equipment = null;
		public static ByTable status_overlays_lighting = null;
		public static ByTable status_overlays_lock = null;
		public const ByTable stealthminID = new ByTable();
		public static ByTable sting_paths = null;
		public static ByTable string_cache = null;
		public const int SUPP_FREQ = 1347;
		public const int supply_emergency = 1;
		public const int supply_engineer = 3;
		public const int supply_materials = 7;
		public const int supply_medical = 4;
		public const int supply_misc = 8;
		public const int supply_organic = 6;
		public const ByTable supply_positions = new ByTable(new object [] { "Head of Personnel", "Quartermaster", "Cargo Technician", "Shaft Miner" });
		public const int supply_science = 5;
		public const int supply_security = 2;
		public const ByTable surgeries_list = new ByTable();
		public static ByTable swapmaps_byname = null;
		public static dynamic swapmaps_compiled_maxx = null;
		public static dynamic swapmaps_compiled_maxy = null;
		public static dynamic swapmaps_compiled_maxz = null;
		public const dynamic swapmaps_iconcache = null;
		public static int swapmaps_initialized = 0;
		public static ByTable swapmaps_loaded = null;
		public const int swapmaps_mode = 0;
		public const int SYMPTOM_ACTIVATION_PROB = 3;
		public const int SYND_FREQ = 1213;
		public static string syndicate_code_phrase = null;
		public static string syndicate_code_response = null;
		public static string syndicate_name = null;
		public const string TAB = "&nbsp;&nbsp;&nbsp;&nbsp;";
		public const ByTable table_recipes = new ByTable();
		public const ByTable TAGGERLOCATIONS = new ByTable(new object [] { "Disposals", "Cargo Bay", "QM Office", "Engineering", "CE Office", "Atmospherics", "Security", "HoS Office", "Medbay", "CMO Office", "Chemistry", "Research", "RD Office", "Robotics", "HoP Office", "Library", "Chapel", "Theatre", "Bar", "Kitchen", "Hydroponics", "Janitor Closet", "Genetics" });
		public const ByTable tails_list_human = new ByTable();
		public const ByTable tails_list_lizard = new ByTable();
		public static ByTable tdome1 = new ByTable();
		public static ByTable tdome2 = new ByTable();
		public static ByTable tdomeadmin = new ByTable();
		public static ByTable tdomeobserve = new ByTable();
		public static ByTable telecomms_list = new ByTable();
		public const ByTable teleport_other_runes = new ByTable();
		public const ByTable teleport_runes = new ByTable();
		public const ByTable teleportlocs = new ByTable();
		public static Ent_Machinery_Gateway_Centerstation the_gateway = null;
		public const ByTable the_station_areas = new ByTable(new object [] { new ByArea(2804), new ByArea(2826), new ByArea(2837), new ByArea(2839), new ByArea(2858), new ByArea(2876), new ByArea(2862), new ByArea(2865), new ByArea(2866), new ByArea(2724), new ByArea(2885), new ByArea(2890), new ByArea(2891), new ByArea(2910), new ByArea(2929), new ByArea(2937), new ByArea(2938), new ByArea(2939), new ByArea(2949), new ByArea(2961), new ByArea(2996), new ByArea(2711), new ByArea(2725), new ByArea(2726), new ByArea(2727) });
		public static Subsystem_Ticker ticker = null;
		public static double time_last_changed_position = 0;
		public const int timezoneOffset = 0;
		public static dynamic tinted_weldhelh = 1;
		public const int tk_maxrange = 15;
		public const int TOUCH = 1;
		public static ByTable tracked_implants = new ByTable();
		public const int TRUE = 1;
		public const ByTable tube_dir_list = new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST, GlobalVars.NORTHEAST, GlobalVars.NORTHWEST, GlobalVars.SOUTHEAST, GlobalVars.SOUTHWEST });
		public const int TURF_LAYER = 2;
		public const ByTable TYPES_SHORTCUTS = new ByTable().set( typeof(Ent_Item_Organ_Internal), "ORGAN_INT" ).set( typeof(Ent_Item_MechaParts_MechaEquipment), "MECHA_EQUIP" ).set( typeof(Ent_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_MissileRack), "MECHA_MISSILE_RACK" ).set( typeof(Ent_Machinery_PortableAtmospherics), "PORT_ATMOS" ).set( typeof(Ent_Machinery_Atmospherics), "ATMOS" ).set( typeof(Ent_Item_Weapon_ReagentContainers), "REAGENT_CONTAINERS" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food), "FOOD" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Drinks), "DRINK" ).set( typeof(Ent_Item_Weapon_Book_Manual), "MANUAL" ).set( typeof(Ent_Item_Clothing_Head_Helmet_Space), "SPESSHELMET" ).set( typeof(Ent_Item_Device_Radio_Headset), "HEADSET" ).set( typeof(Ent_Effect_Decal_Cleanable), "CLEANABLE" );
		public const ByTable undershirt_f = new ByTable();
		public const ByTable undershirt_list = new ByTable();
		public const ByTable undershirt_m = new ByTable();
		public const ByTable underwear_f = new ByTable();
		public const ByTable underwear_list = new ByTable();
		public const ByTable underwear_m = new ByTable();
		public const ByTable uplink_items = new ByTable();
		public const ByTable uranium_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Uranium) ).set( 1, "uranium door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "uranium tile", typeof(Ent_Item_Stack_Tile_Mineral_Uranium), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Uranium_Nuke) ).set( 1, "Nuke Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Uranium_Eng) ).set( 1, "Engineer Statue" ).applyCtor( typeof(StackRecipe) ) });
		public const int VAPOR = 3;
		public const ByTable ventcrawl_machinery = new ByTable(new object [] { typeof(Ent_Machinery_Atmospherics_Components_Unary_VentPump), typeof(Ent_Machinery_Atmospherics_Components_Unary_VentScrubber) });
		public const ByTable verbs = GlobalFuncs.file2list( "config/names/verbs.txt" );
		public const int VOX_CHANNEL = 200;
		public const ByTable vox_sounds = new ByTable().set( "zulu", new ByRsc(1480) ).set( "zone", new ByRsc(1479) ).set( "zero", new ByRsc(1478) ).set( "z", new ByRsc(1477) ).set( "yourself", new ByRsc(1476) ).set( "your", new ByRsc(1475) ).set( "you", new ByRsc(1474) ).set( "yes", new ByRsc(1473) ).set( "yellow", new ByRsc(1472) ).set( "year", new ByRsc(1471) ).set( "yards", new ByRsc(1470) ).set( "yankee", new ByRsc(1469) ).set( "y", new ByRsc(1468) ).set( "xenomorphs", new ByRsc(1467) ).set( "xenomorph", new ByRsc(1466) ).set( "xenobiology", new ByRsc(1465) ).set( "xeno", new ByRsc(1464) ).set( "x", new ByRsc(1463) ).set( "woody", new ByRsc(1462) ).set( "wood", new ByRsc(1461) ).set( "without", new ByRsc(1460) ).set( "with", new ByRsc(1459) ).set( "will", new ByRsc(1458) ).set( "wilco", new ByRsc(1457) ).set( "white", new ByRsc(1456) ).set( "whiskey", new ByRsc(1455) ).set( "west", new ByRsc(1454) ).set( "welcome", new ByRsc(1453) ).set( "weapon", new ByRsc(1452) ).set( "we", new ByRsc(1451) ).set( "water", new ByRsc(1450) ).set( "waste", new ByRsc(1449) ).set( "warning", new ByRsc(1448) ).set( "warn", new ByRsc(1447) ).set( "warm", new ByRsc(1446) ).set( "wanted", new ByRsc(1445) ).set( "want", new ByRsc(1444) ).set( "wanker", new ByRsc(1443) ).set( "wall", new ByRsc(1442) ).set( "walk", new ByRsc(1441) ).set( "w", new ByRsc(1440) ).set( "voxtest", new ByRsc(1439) ).set( "vox_login", new ByRsc(1438) ).set( "vox", new ByRsc(1437) ).set( "voltage", new ByRsc(1436) ).set( "virology", new ByRsc(1435) ).set( "violation", new ByRsc(1434) ).set( "violated", new ByRsc(1433) ).set( "victor", new ByRsc(1432) ).set( "ventilation", new ByRsc(1431) ).set( "vent", new ByRsc(1430) ).set( "vapor", new ByRsc(1429) ).set( "valid", new ByRsc(1428) ).set( "vacate", new ByRsc(1427) ).set( "v", new ByRsc(1426) ).set( "user", new ByRsc(1425) ).set( "used", new ByRsc(1424) ).set( "use", new ByRsc(1423) ).set( "usa", new ByRsc(1422) ).set( "us", new ByRsc(1421) ).set( "uranium", new ByRsc(1420) ).set( "upper", new ByRsc(1419) ).set( "upload", new ByRsc(1418) ).set( "updating", new ByRsc(1417) ).set( "updated", new ByRsc(1416) ).set( "update", new ByRsc(1415) ).set( "up", new ByRsc(1414) ).set( "until", new ByRsc(1413) ).set( "unlocked", new ByRsc(1412) ).set( "uniform", new ByRsc(1411) ).set( "under", new ByRsc(1410) ).set( "unauthorized", new ByRsc(1409) ).set( "u", new ByRsc(1408) ).set( "two", new ByRsc(1407) ).set( "twenty", new ByRsc(1406) ).set( "twelve", new ByRsc(1405) ).set( "turret", new ByRsc(1404) ).set( "turn", new ByRsc(1403) ).set( "tunnel", new ByRsc(1402) ).set( "truck", new ByRsc(1401) ).set( "transportation", new ByRsc(1400) ).set( "traitor", new ByRsc(1399) ).set( "train", new ByRsc(1398) ).set( "track", new ByRsc(1397) ).set( "toxins", new ByRsc(1396) ).set( "towards", new ByRsc(1395) ).set( "touch", new ByRsc(1394) ).set( "topside", new ByRsc(1393) ).set( "top", new ByRsc(1392) ).set( "to", new ByRsc(1391) ).set( "time", new ByRsc(1390) ).set( "tide", new ByRsc(1389) ).set( "through", new ByRsc(1388) ).set( "three", new ByRsc(1387) ).set( "threat", new ByRsc(1386) ).set( "thousand", new ByRsc(1385) ).set( "those", new ByRsc(1384) ).set( "this", new ByRsc(1383) ).set( "thirty", new ByRsc(1382) ).set( "thirteen", new ByRsc(1381) ).set( "third", new ByRsc(1380) ).set( "there", new ByRsc(1379) ).set( "then", new ByRsc(1378) ).set( "the", new ByRsc(1377) ).set( "that", new ByRsc(1376) ).set( "test", new ByRsc(1375) ).set( "termination", new ByRsc(1374) ).set( "terminated", new ByRsc(1373) ).set( "terminal", new ByRsc(1372) ).set( "ten", new ByRsc(1371) ).set( "temporal", new ByRsc(1370) ).set( "temperature", new ByRsc(1369) ).set( "team", new ByRsc(1368) ).set( "target", new ByRsc(1367) ).set( "tank", new ByRsc(1366) ).set( "tango", new ByRsc(1365) ).set( "talk", new ByRsc(1364) ).set( "take", new ByRsc(1363) ).set( "tactical", new ByRsc(1362) ).set( "t", new ByRsc(1361) ).set( "systems", new ByRsc(1360) ).set( "system", new ByRsc(1359) ).set( "syndicate", new ByRsc(1358) ).set( "switch", new ByRsc(1357) ).set( "surrounded", new ByRsc(1356) ).set( "surround", new ByRsc(1355) ).set( "surrender", new ByRsc(1354) ).set( "surface", new ByRsc(1353) ).set( "supply", new ByRsc(1352) ).set( "supercooled", new ByRsc(1351) ).set( "superconducting", new ByRsc(1350) ).set( "suit", new ByRsc(1349) ).set( "suffer", new ByRsc(1348) ).set( "sudden", new ByRsc(1347) ).set( "subsurface", new ByRsc(1346) ).set( "sub", new ByRsc(1345) ).set( "stuck", new ByRsc(1344) ).set( "storage", new ByRsc(1343) ).set( "sterilization", new ByRsc(1342) ).set( "sterile", new ByRsc(1341) ).set( "status", new ByRsc(1340) ).set( "station", new ByRsc(1339) ).set( "starboard", new ByRsc(1338) ).set( "stairway", new ByRsc(1337) ).set( "ss13", new ByRsc(1336) ).set( "square", new ByRsc(1335) ).set( "squad", new ByRsc(1334) ).set( "south", new ByRsc(1333) ).set( "sorry", new ByRsc(1332) ).set( "son", new ByRsc(1331) ).set( "something", new ByRsc(1330) ).set( "someone", new ByRsc(1329) ).set( "some", new ByRsc(1328) ).set( "soldier", new ByRsc(1327) ).set( "solars", new ByRsc(1326) ).set( "solar", new ByRsc(1325) ).set( "slow", new ByRsc(1324) ).set( "slime", new ByRsc(1323) ).set( "sixty", new ByRsc(1322) ).set( "sixteen", new ByRsc(1321) ).set( "six", new ByRsc(1320) ).set( "singularity", new ByRsc(1319) ).set( "silo", new ByRsc(1318) ).set( "sight", new ByRsc(1317) ).set( "sierra", new ByRsc(1316) ).set( "side", new ByRsc(1315) ).set( "shuttle", new ByRsc(1314) ).set( "shut", new ByRsc(1313) ).set( "shower", new ByRsc(1312) ).set( "shoot", new ByRsc(1311) ).set( "shock", new ByRsc(1310) ).set( "shitting", new ByRsc(1309) ).set( "shits", new ByRsc(1308) ).set( "shitlord", new ByRsc(1307) ).set( "shit", new ByRsc(1306) ).set( "shirt", new ByRsc(1305) ).set( "shipment", new ByRsc(1304) ).set( "shield", new ByRsc(1303) ).set( "sewer", new ByRsc(1302) ).set( "sewage", new ByRsc(1301) ).set( "severe", new ByRsc(1300) ).set( "seventy", new ByRsc(1299) ).set( "seventeen", new ByRsc(1298) ).set( "seven", new ByRsc(1297) ).set( "service", new ByRsc(1296) ).set( "sensors", new ByRsc(1295) ).set( "selected", new ByRsc(1294) ).set( "select", new ByRsc(1293) ).set( "security", new ByRsc(1292) ).set( "secured", new ByRsc(1291) ).set( "secure", new ByRsc(1290) ).set( "sector", new ByRsc(1289) ).set( "seconds", new ByRsc(1288) ).set( "secondary", new ByRsc(1287) ).set( "second", new ByRsc(1286) ).set( "search", new ByRsc(1285) ).set( "screen", new ByRsc(1284) ).set( "scream", new ByRsc(1283) ).set( "science", new ByRsc(1282) ).set( "save", new ByRsc(1281) ).set( "satellite", new ByRsc(1280) ).set( "sargeant", new ByRsc(1279) ).set( "sarah", new ByRsc(1278) ).set( "safety", new ByRsc(1277) ).set( "safe", new ByRsc(1276) ).set( "s", new ByRsc(1275) ).set( "run", new ByRsc(1274) ).set( "round", new ByRsc(1273) ).set( "room", new ByRsc(1272) ).set( "romeo", new ByRsc(1271) ).set( "roger", new ByRsc(1270) ).set( "rocket", new ByRsc(1269) ).set( "right", new ByRsc(1268) ).set( "rest", new ByRsc(1267) ).set( "resistance", new ByRsc(1266) ).set( "resevoir", new ByRsc(1265) ).set( "research", new ByRsc(1264) ).set( "required", new ByRsc(1263) ).set( "reports", new ByRsc(1262) ).set( "report", new ByRsc(1261) ).set( "repair", new ByRsc(1260) ).set( "renegade", new ByRsc(1259) ).set( "removal", new ByRsc(1258) ).set( "remaining", new ByRsc(1257) ).set( "released", new ByRsc(1256) ).set( "relay", new ByRsc(1255) ).set( "red", new ByRsc(1254) ).set( "reactor", new ByRsc(1253) ).set( "reached", new ByRsc(1252) ).set( "reach", new ByRsc(1251) ).set( "rapid", new ByRsc(1250) ).set( "raiders", new ByRsc(1249) ).set( "raider", new ByRsc(1248) ).set( "rads", new ByRsc(1247) ).set( "radioactive", new ByRsc(1246) ).set( "radiation", new ByRsc(1245) ).set( "r", new ByRsc(1244) ).set( "quit", new ByRsc(1243) ).set( "quick", new ByRsc(1242) ).set( "questioning", new ByRsc(1241) ).set( "question", new ByRsc(1240) ).set( "queen", new ByRsc(1239) ).set( "quebec", new ByRsc(1238) ).set( "quantum", new ByRsc(1237) ).set( "q", new ByRsc(1236) ).set( "push", new ByRsc(1235) ).set( "protective", new ByRsc(1234) ).set( "prosecute", new ByRsc(1233) ).set( "propulsion", new ByRsc(1232) ).set( "proper", new ByRsc(1231) ).set( "progress", new ByRsc(1230) ).set( "processing", new ByRsc(1229) ).set( "proceed", new ByRsc(1228) ).set( "primary", new ByRsc(1227) ).set( "press", new ByRsc(1226) ).set( "presence", new ByRsc(1225) ).set( "power", new ByRsc(1224) ).set( "portal", new ByRsc(1223) ).set( "port", new ByRsc(1222) ).set( "point", new ByRsc(1221) ).set( "please", new ByRsc(1220) ).set( "platform", new ByRsc(1219) ).set( "plasma", new ByRsc(1218) ).set( "plant", new ByRsc(1217) ).set( "pipe", new ByRsc(1216) ).set( "personnel", new ByRsc(1215) ).set( "permitted", new ByRsc(1214) ).set( "perimeter", new ByRsc(1213) ).set( "percent", new ByRsc(1212) ).set( "panel", new ByRsc(1211) ).set( "pal", new ByRsc(1210) ).set( "pain", new ByRsc(1209) ).set( "pacify", new ByRsc(1208) ).set( "p", new ByRsc(1207) ).set( "override", new ByRsc(1206) ).set( "overload", new ByRsc(1205) ).set( "over", new ByRsc(1204) ).set( "outside", new ByRsc(1203) ).set( "out", new ByRsc(1202) ).set( "oscar", new ByRsc(1201) ).set( "organic", new ByRsc(1200) ).set( "order", new ByRsc(1199) ).set( "option", new ByRsc(1198) ).set( "operative", new ByRsc(1197) ).set( "operations", new ByRsc(1196) ).set( "operating", new ByRsc(1195) ).set( "open", new ByRsc(1194) ).set( "one", new ByRsc(1193) ).set( "on", new ByRsc(1192) ).set( "ok", new ByRsc(1191) ).set( "officer", new ByRsc(1190) ).set( "of", new ByRsc(1189) ).set( "obtain", new ByRsc(1188) ).set( "observation", new ByRsc(1187) ).set( "objective", new ByRsc(1186) ).set( "o", new ByRsc(1185) ).set( "number", new ByRsc(1184) ).set( "now", new ByRsc(1183) ).set( "november", new ByRsc(1182) ).set( "not", new ByRsc(1181) ).set( "north", new ByRsc(1180) ).set( "nominal", new ByRsc(1179) ).set( "no", new ByRsc(1178) ).set( "ninety", new ByRsc(1177) ).set( "nineteen", new ByRsc(1176) ).set( "nine", new ByRsc(1175) ).set( "nice", new ByRsc(1174) ).set( "nearest", new ByRsc(1173) ).set( "nanotrasen", new ByRsc(1172) ).set( "n", new ByRsc(1171) ).set( "my", new ByRsc(1170) ).set( "must", new ByRsc(1169) ).set( "move", new ByRsc(1168) ).set( "motorpool", new ByRsc(1167) ).set( "motor", new ByRsc(1166) ).set( "money", new ByRsc(1165) ).set( "mode", new ByRsc(1164) ).set( "mister", new ByRsc(1163) ).set( "minutes", new ByRsc(1162) ).set( "minimum", new ByRsc(1161) ).set( "minefield", new ByRsc(1160) ).set( "million", new ByRsc(1159) ).set( "milli", new ByRsc(1158) ).set( "military", new ByRsc(1157) ).set( "miles", new ByRsc(1156) ).set( "mike", new ByRsc(1155) ).set( "middle", new ByRsc(1154) ).set( "micro", new ByRsc(1153) ).set( "meter", new ByRsc(1152) ).set( "message", new ByRsc(1151) ).set( "mesa", new ByRsc(1150) ).set( "mercy", new ByRsc(1149) ).set( "men", new ByRsc(1148) ).set( "medical", new ByRsc(1147) ).set( "medbay", new ByRsc(1146) ).set( "me", new ByRsc(1145) ).set( "may", new ByRsc(1144) ).set( "maximum", new ByRsc(1143) ).set( "materials", new ByRsc(1142) ).set( "mass", new ByRsc(1141) ).set( "man", new ByRsc(1140) ).set( "malfunction", new ByRsc(1139) ).set( "maintenance", new ByRsc(1138) ).set( "main", new ByRsc(1137) ).set( "magnetic", new ByRsc(1136) ).set( "m", new ByRsc(1135) ).set( "lowest", new ByRsc(1134) ).set( "lower", new ByRsc(1133) ).set( "loose", new ByRsc(1132) ).set( "lockout", new ByRsc(1131) ).set( "locker", new ByRsc(1130) ).set( "locked", new ByRsc(1129) ).set( "lock", new ByRsc(1128) ).set( "location", new ByRsc(1127) ).set( "located", new ByRsc(1126) ).set( "locate", new ByRsc(1125) ).set( "loading", new ByRsc(1124) ).set( "liquid", new ByRsc(1123) ).set( "lima", new ByRsc(1122) ).set( "light", new ByRsc(1121) ).set( "life", new ByRsc(1120) ).set( "lieutenant", new ByRsc(1119) ).set( "lie", new ByRsc(1118) ).set( "lever", new ByRsc(1117) ).set( "level", new ByRsc(1116) ).set( "legal", new ByRsc(1115) ).set( "left", new ByRsc(1114) ).set( "leave", new ByRsc(1113) ).set( "leak", new ByRsc(1112) ).set( "laws", new ByRsc(1111) ).set( "law", new ByRsc(1110) ).set( "launch", new ByRsc(1109) ).set( "last", new ByRsc(1108) ).set( "laser", new ByRsc(1107) ).set( "lambda", new ByRsc(1106) ).set( "lab", new ByRsc(1105) ).set( "l", new ByRsc(1104) ).set( "kit", new ByRsc(1103) ).set( "kilo", new ByRsc(1102) ).set( "kill", new ByRsc(1101) ).set( "key", new ByRsc(1100) ).set( "k", new ByRsc(1099) ).set( "juliet", new ByRsc(1098) ).set( "johnson", new ByRsc(1097) ).set( "j", new ByRsc(1096) ).set( "it", new ByRsc(1095) ).set( "is", new ByRsc(1094) ).set( "invasion", new ByRsc(1093) ).set( "invalid", new ByRsc(1092) ).set( "intruder", new ByRsc(1091) ).set( "interchange", new ByRsc(1090) ).set( "inspector", new ByRsc(1089) ).set( "inspection", new ByRsc(1088) ).set( "inside", new ByRsc(1087) ).set( "inoperative", new ByRsc(1086) ).set( "ing", new ByRsc(1085) ).set( "india", new ByRsc(1084) ).set( "inches", new ByRsc(1083) ).set( "in", new ByRsc(1082) ).set( "immediately", new ByRsc(1081) ).set( "immediate", new ByRsc(1080) ).set( "illegal", new ByRsc(1079) ).set( "idiot", new ByRsc(1078) ).set( "i", new ByRsc(1077) ).set( "hydroponics", new ByRsc(1076) ).set( "hydro", new ByRsc(1075) ).set( "hunger", new ByRsc(1074) ).set( "hundred", new ByRsc(1073) ).set( "human", new ByRsc(1072) ).set( "hours", new ByRsc(1071) ).set( "hour", new ByRsc(1070) ).set( "hotel", new ByRsc(1069) ).set( "hot", new ByRsc(1068) ).set( "hostile", new ByRsc(1067) ).set( "hole", new ByRsc(1066) ).set( "hit", new ByRsc(1065) ).set( "highest", new ByRsc(1064) ).set( "high", new ByRsc(1063) ).set( "hide", new ByRsc(1062) ).set( "here", new ByRsc(1061) ).set( "help", new ByRsc(1060) ).set( "hello", new ByRsc(1059) ).set( "helium", new ByRsc(1058) ).set( "helicopter", new ByRsc(1057) ).set( "heat", new ByRsc(1056) ).set( "health", new ByRsc(1055) ).set( "head", new ByRsc(1054) ).set( "hazard", new ByRsc(1053) ).set( "have", new ByRsc(1052) ).set( "has", new ByRsc(1051) ).set( "harm", new ByRsc(1050) ).set( "hangar", new ByRsc(1049) ).set( "handling", new ByRsc(1048) ).set( "hackers", new ByRsc(1047) ).set( "hacker", new ByRsc(1046) ).set( "h", new ByRsc(1045) ).set( "guthrie", new ByRsc(1044) ).set( "gun", new ByRsc(1043) ).set( "gulf", new ByRsc(1042) ).set( "guard", new ByRsc(1041) ).set( "grenade", new ByRsc(1040) ).set( "green", new ByRsc(1039) ).set( "great", new ByRsc(1038) ).set( "gray", new ByRsc(1037) ).set( "granted", new ByRsc(1036) ).set( "government", new ByRsc(1035) ).set( "got", new ByRsc(1034) ).set( "gordon", new ByRsc(1033) ).set( "goodbye", new ByRsc(1032) ).set( "good", new ByRsc(1031) ).set( "going", new ByRsc(1030) ).set( "go", new ByRsc(1029) ).set( "glory", new ByRsc(1028) ).set( "get", new ByRsc(1027) ).set( "gas", new ByRsc(1026) ).set( "g", new ByRsc(1025) ).set( "fuel", new ByRsc(1024) ).set( "fucks", new ByRsc(1023) ).set( "fucking", new ByRsc(1022) ).set( "fuck", new ByRsc(1021) ).set( "front", new ByRsc(1020) ).set( "from", new ByRsc(1019) ).set( "freezer", new ByRsc(1018) ).set( "freeman", new ByRsc(1017) ).set( "foxtrot", new ByRsc(1016) ).set( "fourty", new ByRsc(1015) ).set( "fourth", new ByRsc(1014) ).set( "fourteen", new ByRsc(1013) ).set( "four", new ByRsc(1012) ).set( "found", new ByRsc(1011) ).set( "forms", new ByRsc(1010) ).set( "fore", new ByRsc(1009) ).set( "force", new ByRsc(1008) ).set( "forbidden", new ByRsc(1007) ).set( "for", new ByRsc(1006) ).set( "fool", new ByRsc(1005) ).set( "floor", new ByRsc(1004) ).set( "flooding", new ByRsc(1003) ).set( "five", new ByRsc(1002) ).set( "first", new ByRsc(1001) ).set( "fire", new ByRsc(1000) ).set( "fine", new ByRsc(999) ).set( "final", new ByRsc(998) ).set( "fifty", new ByRsc(997) ).set( "fifth", new ByRsc(996) ).set( "fifteen", new ByRsc(995) ).set( "field", new ByRsc(994) ).set( "feet", new ByRsc(993) ).set( "fast", new ByRsc(992) ).set( "farthest", new ByRsc(991) ).set( "failure", new ByRsc(990) ).set( "failed", new ByRsc(989) ).set( "fahrenheit", new ByRsc(988) ).set( "facility", new ByRsc(987) ).set( "f", new ByRsc(986) ).set( "extreme", new ByRsc(985) ).set( "extinguisher", new ByRsc(984) ).set( "extinguish", new ByRsc(983) ).set( "exterminate", new ByRsc(982) ).set( "exposure", new ByRsc(981) ).set( "explosion", new ByRsc(980) ).set( "explode", new ByRsc(979) ).set( "experimental", new ByRsc(978) ).set( "experiment", new ByRsc(977) ).set( "expect", new ByRsc(976) ).set( "exit", new ByRsc(975) ).set( "exchange", new ByRsc(974) ).set( "evacuate", new ByRsc(973) ).set( "escape", new ByRsc(972) ).set( "error", new ByRsc(971) ).set( "environment", new ByRsc(970) ).set( "entry", new ByRsc(969) ).set( "enter", new ByRsc(968) ).set( "engine", new ByRsc(967) ).set( "engaged", new ByRsc(966) ).set( "engage", new ByRsc(965) ).set( "energy", new ByRsc(964) ).set( "emergency", new ByRsc(963) ).set( "eliminate", new ByRsc(962) ).set( "eleven", new ByRsc(961) ).set( "elevator", new ByRsc(960) ).set( "electromagnetic", new ByRsc(959) ).set( "electric", new ByRsc(958) ).set( "eighty", new ByRsc(957) ).set( "eighteen", new ByRsc(956) ).set( "eight", new ByRsc(955) ).set( "egress", new ByRsc(954) ).set( "effect", new ByRsc(953) ).set( "ed", new ByRsc(952) ).set( "echo", new ByRsc(951) ).set( "east", new ByRsc(950) ).set( "e", new ByRsc(949) ).set( "duct", new ByRsc(948) ).set( "dual", new ByRsc(947) ).set( "down", new ByRsc(946) ).set( "door", new ByRsc(945) ).set( "doctor", new ByRsc(944) ).set( "do", new ByRsc(943) ).set( "distortion", new ByRsc(942) ).set( "distance", new ByRsc(941) ).set( "disposal", new ByRsc(940) ).set( "dish", new ByRsc(939) ).set( "disengaged", new ByRsc(938) ).set( "dirt", new ByRsc(937) ).set( "dimensional", new ByRsc(936) ).set( "die", new ByRsc(935) ).set( "did", new ByRsc(934) ).set( "device", new ByRsc(933) ).set( "detonation", new ByRsc(932) ).set( "detected", new ByRsc(931) ).set( "detain", new ByRsc(930) ).set( "destroyed", new ByRsc(929) ).set( "destroy", new ByRsc(928) ).set( "deployed", new ByRsc(927) ).set( "deploy", new ByRsc(926) ).set( "denied", new ByRsc(925) ).set( "delta", new ByRsc(924) ).set( "degrees", new ByRsc(923) ).set( "defense", new ByRsc(922) ).set( "deeoo", new ByRsc(921) ).set( "decontamination", new ByRsc(920) ).set( "decompression", new ByRsc(919) ).set( "deactivated", new ByRsc(918) ).set( "day", new ByRsc(917) ).set( "danger", new ByRsc(916) ).set( "damaged", new ByRsc(915) ).set( "damage", new ByRsc(914) ).set( "d", new ByRsc(913) ).set( "cyborgs", new ByRsc(912) ).set( "cyborg", new ByRsc(911) ).set( "cunt", new ByRsc(910) ).set( "cryogenic", new ByRsc(909) ).set( "cross", new ByRsc(908) ).set( "crew", new ByRsc(907) ).set( "cowards", new ByRsc(906) ).set( "coward", new ByRsc(905) ).set( "corridor", new ByRsc(904) ).set( "correct", new ByRsc(903) ).set( "core", new ByRsc(902) ).set( "coomer", new ByRsc(901) ).set( "coolant", new ByRsc(900) ).set( "control", new ByRsc(899) ).set( "contraband", new ByRsc(898) ).set( "contamination", new ByRsc(897) ).set( "containment", new ByRsc(896) ).set( "connor", new ByRsc(895) ).set( "condition", new ByRsc(894) ).set( "computer", new ByRsc(893) ).set( "complex", new ByRsc(892) ).set( "communication", new ByRsc(891) ).set( "command", new ByRsc(890) ).set( "come", new ByRsc(889) ).set( "collider", new ByRsc(888) ).set( "coded", new ByRsc(887) ).set( "code", new ByRsc(886) ).set( "clown", new ByRsc(885) ).set( "close", new ByRsc(884) ).set( "clearance", new ByRsc(883) ).set( "clear", new ByRsc(882) ).set( "cleanup", new ByRsc(881) ).set( "chemical", new ByRsc(880) ).set( "checkpoint", new ByRsc(879) ).set( "check", new ByRsc(878) ).set( "charlie", new ByRsc(877) ).set( "changed", new ByRsc(876) ).set( "chamber", new ByRsc(875) ).set( "central", new ByRsc(874) ).set( "centi", new ByRsc(873) ).set( "center", new ByRsc(872) ).set( "centcom", new ByRsc(871) ).set( "celsius", new ByRsc(870) ).set( "ceiling", new ByRsc(869) ).set( "cargo", new ByRsc(868) ).set( "capture", new ByRsc(867) ).set( "captain", new ByRsc(866) ).set( "cap", new ByRsc(865) ).set( "canal", new ByRsc(864) ).set( "called", new ByRsc(863) ).set( "call", new ByRsc(862) ).set( "cable", new ByRsc(861) ).set( "c", new ByRsc(860) ).set( "bypass", new ByRsc(859) ).set( "button", new ByRsc(858) ).set( "but", new ByRsc(857) ).set( "bust", new ByRsc(856) ).set( "bridge", new ByRsc(855) ).set( "break", new ByRsc(854) ).set( "breached", new ByRsc(853) ).set( "breach", new ByRsc(852) ).set( "bravo", new ByRsc(851) ).set( "bottom", new ByRsc(850) ).set( "blue", new ByRsc(849) ).set( "blocked", new ByRsc(848) ).set( "blast", new ByRsc(847) ).set( "black", new ByRsc(846) ).set( "bitches", new ByRsc(845) ).set( "bitch", new ByRsc(844) ).set( "birdwell", new ByRsc(843) ).set( "biological", new ByRsc(842) ).set( "biohazard", new ByRsc(841) ).set( "beyond", new ByRsc(840) ).set( "before", new ByRsc(839) ).set( "been", new ByRsc(838) ).set( "be", new ByRsc(837) ).set( "bay", new ByRsc(836) ).set( "base", new ByRsc(835) ).set( "barracks", new ByRsc(834) ).set( "bailey", new ByRsc(833) ).set( "bag", new ByRsc(832) ).set( "bad", new ByRsc(831) ).set( "backman", new ByRsc(830) ).set( "back", new ByRsc(829) ).set( "b", new ByRsc(828) ).set( "away", new ByRsc(827) ).set( "automatic", new ByRsc(826) ).set( "authorized", new ByRsc(825) ).set( "authorize", new ByRsc(824) ).set( "attention", new ByRsc(823) ).set( "atomic", new ByRsc(822) ).set( "at", new ByRsc(821) ).set( "assholes", new ByRsc(820) ).set( "asshole", new ByRsc(819) ).set( "ass", new ByRsc(818) ).set( "asimov", new ByRsc(817) ).set( "arrest", new ByRsc(816) ).set( "array", new ByRsc(815) ).set( "armory", new ByRsc(814) ).set( "armor", new ByRsc(813) ).set( "armed", new ByRsc(812) ).set( "arm", new ByRsc(811) ).set( "area", new ByRsc(810) ).set( "are", new ByRsc(809) ).set( "approach", new ByRsc(808) ).set( "apprehend", new ByRsc(807) ).set( "any", new ByRsc(806) ).set( "antenna", new ByRsc(805) ).set( "anomalous", new ByRsc(804) ).set( "announcement", new ByRsc(803) ).set( "and", new ByRsc(802) ).set( "an", new ByRsc(801) ).set( "ammunition", new ByRsc(800) ).set( "amigo", new ByRsc(799) ).set( "am", new ByRsc(798) ).set( "alpha", new ByRsc(797) ).set( "all", new ByRsc(796) ).set( "aligned", new ByRsc(795) ).set( "alien", new ByRsc(794) ).set( "alert", new ByRsc(793) ).set( "alarm", new ByRsc(792) ).set( "ai", new ByRsc(791) ).set( "agent", new ByRsc(790) ).set( "after", new ByRsc(789) ).set( "aft", new ByRsc(788) ).set( "advanced", new ByRsc(787) ).set( "administration", new ByRsc(786) ).set( "adios", new ByRsc(785) ).set( "activity", new ByRsc(784) ).set( "activated", new ByRsc(783) ).set( "activate", new ByRsc(782) ).set( "across", new ByRsc(781) ).set( "acquisition", new ByRsc(780) ).set( "acquired", new ByRsc(779) ).set( "acknowledged", new ByRsc(778) ).set( "acknowledge", new ByRsc(777) ).set( "access", new ByRsc(776) ).set( "accepted", new ByRsc(775) ).set( "accelerator", new ByRsc(774) ).set( "accelerating", new ByRsc(773) ).set( "abortions", new ByRsc(772) ).set( "a", new ByRsc(771) ).set( ".", new ByRsc(770) ).set( ",", new ByRsc(769) );
		public const ByTable VVckey_edit = new ByTable(new object [] { "key", "ckey" });
		public const ByTable VVicon_edit_lock = new ByTable(new object [] { "icon", "icon_state", "overlays", "underlays", "resize" });
		public const ByTable VVlocked = new ByTable(new object [] { "vars", "client", "virus", "viruses", "cuffed", "last_eaten", "unlock_content", "step_x", "step_y", "force_ending" });
		public const int waittime_h = 1800;
		public const int waittime_l = 600;
		public const ByTable WALLITEMS = new ByTable(new object [] { typeof(Ent_Machinery_Power_Apc), typeof(Ent_Machinery_Alarm), typeof(Ent_Item_Device_Radio_Intercom), typeof(Ent_Structure_ExtinguisherCabinet), typeof(Ent_Structure_ReagentDispensers_Peppertank), typeof(Ent_Machinery_StatusDisplay), typeof(Ent_Machinery_RequestsConsole), typeof(Ent_Machinery_LightSwitch), typeof(Ent_Structure_Sign), typeof(Ent_Machinery_Newscaster), typeof(Ent_Machinery_Firealarm), typeof(Ent_Structure_Noticeboard), typeof(Ent_Machinery_Button), typeof(Ent_Machinery_Computer_Security_Telescreen), typeof(Ent_Machinery_EmbeddedController_Radio_SimpleVentController), typeof(Ent_Item_Weapon_Storage_Secure_Safe), typeof(Ent_Machinery_DoorTimer), typeof(Ent_Machinery_Flasher), typeof(Ent_Machinery_KeycardAuth), typeof(Ent_Structure_Mirror), typeof(Ent_Structure_Fireaxecabinet), typeof(Ent_Machinery_Computer_Security_Telescreen_Entertainment) });
		public const ByTable WALLITEMS_EXTERNAL = new ByTable(new object [] { typeof(Ent_Machinery_Camera), typeof(Ent_Machinery_CameraAssembly), typeof(Ent_Machinery_LightConstruct), typeof(Ent_Machinery_Light) });
		public const ByTable WALLITEMS_INVERSE = new ByTable(new object [] { typeof(Ent_Machinery_LightConstruct), typeof(Ent_Machinery_Light) });
		public static ByTable weedImageCache = null;
		public const int WEST = 8;
		public const int WIRE_ACTIVATE = 16;
		public const int WIRE_BOOM = 1;
		public const int WIRE_DELAY = 4;
		public const int WIRE_PROCEED = 8;
		public const int WIRE_RECEIVE = 2;
		public const int WIRE_TRANSMIT = 4;
		public const int WIRE_UNBOLT = 2;
		public const ByTable wireColours = new ByTable(new object [] { "red", "blue", "green", "black", "orange", "brown", "gold", "gray", "cyan", "navy", "purple", "pink" });
		public const ByTable wizard_first = GlobalFuncs.file2list( "config/names/wizardfirst.txt" );
		public const ByTable wizard_second = GlobalFuncs.file2list( "config/names/wizardsecond.txt" );
		public static ByTable wizardstart = new ByTable();
		public const ByTable wood_recipes = new ByTable(new object [] { new StackRecipe( "wooden sandals", typeof(Ent_Item_Clothing_Shoes_Sandal), 1 ), new StackRecipe( "wood floor tile", typeof(Ent_Item_Stack_Tile_Wood), 1, 4, 20 ), new ByTable().set( "time", 10 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_TableFrame_Wood) ).set( 1, "wood table frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "time", 40 ).set( 3, 10 ).set( 2, typeof(Ent_Item_Weaponcrafting_Stock) ).set( 1, "rifle stock" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 3 ).set( 2, typeof(Ent_Structure_Bed_Chair_Wood_Normal) ).set( 1, "wooden chair" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Barricade_Wooden) ).set( 1, "wooden barricade" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 20 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Wood) ).set( 1, "wooden door" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Closet_Coffin) ).set( 1, "coffin" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_Bookcase) ).set( 1, "book case" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 10 ).set( 2, typeof(Ent_Machinery_Smartfridge_DryingRack) ).set( 1, "drying rack" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_Bed_Dogbed) ).set( 1, "dog bed" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_DisplaycaseChassis) ).set( 1, "display case chassis" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable world_uplinks = new ByTable();
		public const ByTable xeno_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( 3, 1 ).set( 2, typeof(Ent_Item_Clothing_Head_Xenos) ).set( 1, "alien helmet" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( 3, 2 ).set( 2, typeof(Ent_Item_Clothing_Suit_Xenos) ).set( 1, "alien suit" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable xeno_spawn = new ByTable();
		public const dynamic year = Misc13.formatTime( Game.realtime, "YYYY" );
		public const dynamic year_integer = Misc13.parseNumber( GlobalVars.year );
		public const ByTable z_levels_list = new ByTable();
		public const ByTable zero_character_only = new ByTable(new object [] { "0" });
	}
}