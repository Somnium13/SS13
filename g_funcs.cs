using System;

namespace Som13 {
	static class GlobalFuncs {
	function _command_name(  ) {
		local name
[object Object],[object Object],[object Object],[object Object]
	}

	function _station_name(  ) {
[object Object],[object Object],[object Object],[object Object]
	}

	function _syndicate_name(  ) {
		local name
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function above_neck( zone =null ) {
		local zones
[object Object],[object Object]
	}

	function active_ais( check_mind =null ) {
		local A, _default
[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function active_free_borgs(  ) {
		local R, _default
[object Object],[object Object],[object Object]
		return _default
	}

	function add_logs( user =null, target =null, what_done =null, _object =null, addition =null ) {
		local newhealthtxt, L
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function add_lspace( t =null, u =null ) {
[object Object],[object Object]
	}

	function add_note( target_ckey =null, notetext =null, timestamp =null, adminckey =null, logged =null, server =null ) {
		local new_ckey, query_find_ckey, err, target_sql_ckey, admin_sql_ckey, query_noteadd
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function add_radio( radio =null, freq =null ) {
[object Object],[object Object],[object Object],[object Object]
	}

	function add_tspace( t =null, u =null ) {
[object Object],[object Object]
	}

	function add_zero( t =null, u =null ) {
[object Object],[object Object]
	}

	function AddBan( ckey =null, computerid =null, reason =null, bannedby =null, temp =null, minutes =null, address =null ) {
		local bantimestamp
[object Object],[object Object],[object Object],[object Object]
	}

	function addtimer( thingToCall =null, procToCall =null, wait =null, argList =null ) {
		local _event
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function admin_forcemove( mover =null, newloc =null ) {
[object Object],[object Object],[object Object],[object Object]
	}

	function admin_keyword_to_flag( word =null, previous_rights =null ) {
		local flag
[object Object],[object Object],[object Object],[object Object]
	}

	function admin_keyword_to_path( word =null ) {
[object Object]
	}

	function AdminCreateVirus( user =null ) {
		local i, D, symptoms, symptom, S, new_name, AD, H, name_symptoms
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function adminscrub( t =null, limit =null ) {
[object Object],[object Object]
	}

	function Advance_Mix( D_list =null ) {
		local diseases, A, i, D1, D2, to_return
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function alien_type_present( alienpath =null ) {
		local A
[object Object],[object Object],[object Object]
	}

	function alone_in_area( the_area =null, must_be_alone =null, check_type =null ) {
		local our_area, C
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function angle2dir( degree =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function angle2text( degree =null ) {
[object Object]
	}

	function anim( location =null, target =null, a_icon =null, a_icon_state =null, flick_anim =null, sleeptime =null, direction =null ) {
		local animation
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function anyprob( value =null ) {
[object Object]
	}

	function appearance_fullban( M =null, reason =null ) {
[object Object],[object Object],[object Object]
	}

	function appearance_isbanned( M =null ) {
		local s, startpos, text
[object Object],[object Object]
	}

	function appearance_remove( X =null ) {
		local i
[object Object],[object Object],[object Object],[object Object]
	}

	function appearance_savebanfile(  ) {
		local S
[object Object],[object Object]
	}

	function appearance_unban( M =null ) {
[object Object],[object Object]
	}

	function arctan( x =null ) {
		local y
[object Object],[object Object]
	}

	function assign_progress_bar( user =null, progbar =null ) {
[object Object]
	}

	function AStar( start =null, end =null, atom =null, dist =null, maxnodes =null, maxnodedepth =null, mintargetdist =null, adjacent =null, id =null, exclude =null, simulated_only =null ) {
		local open, closed, path, cur, closeenough, L, T, newg, PN, i
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function attach_spans( input =null, spans =null ) {
[object Object]
	}

	function attempt_initiate_surgery( I =null, M =null, user =null ) {
		local H, affecting, selected_zone, current_surgery, S, all_surgeries, available_surgeries, path, P, procedure
[object Object],[object Object]
	}

	function AutoUpdateAI( subject =null ) {
		local is_in_use, A, M
[object Object],[object Object],[object Object]
	}

	function AverageColour( I =null ) {
		local colours, x_pixel, y_pixel, this_colour, final_average, colour
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function ban_unban_log_save( formatted_log =null ) {
[object Object]
	}

	function blendMode2iconMode( blend_mode =null ) {
[object Object]
	}

	function BlendRGB( rgb1 =null, rgb2 =null, amount =null ) {
		local RGB1, RGB2, usealpha, r, g, b, alpha
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function blood_incompatible( donor =null, receiver =null, donor_species =null, receiver_species =null ) {
		local donor_antigen, receiver_antigen, donor_rh, receiver_rh
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function blood_splatter( target =null, source =null, large =null ) {
		local B, decal_type, T, M, donor, drips, drop
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function Broadcast_Message( AM =null, vmask =null, radio =null, message =null, name =null, job =null, realname =null, data =null, compression =null, level =null, freq =null, spans =null, verb_say =null, verb_ask =null, verb_exclaim =null, verb_yell =null ) {
		local radios, virt, R, freqtext, receive, M, rendered, hearer, blackbox_msg
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function Broadcast_SimpleMessage( source =null, frequency =null, text =null, data =null, M =null, compression =null, level =null ) {
		local H, connection, display_freq, receive, R, position, syndicateconnection, heard_normal, heard_garbled, heard_gibberish, part_a, freq_text, part_b_extra, radio, part_b, part_c, part_blackbox_b, blackbox_msg, rendered, quotedmsg
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function build_click( user =null, buildmode =null, _params =null, _object =null ) {
		local holder, H, pa, T, WIN, A, G
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function calculate_adjacencies( A =null ) {
		local adjacencies, AM, direction
[object Object],[object Object],[object Object],[object Object]
	}

	function CallMaterialName( ID =null ) {
		local temp_reagent, return_name, R
[object Object],[object Object],[object Object]
	}

	function CallTechName( ID =null ) {
		local check_tech, return_name, T
[object Object],[object Object],[object Object],[object Object]
	}

	function camera_sort( L =null ) {
		local a, b, i, j
[object Object],[object Object],[object Object],[object Object]
	}

	function can_embed( W =null ) {
		local embed_items
[object Object],[object Object],[object Object],[object Object]
	}

	function can_see( source =null, target =null, length =null ) {
		local current, target_turf, steps, A
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function cancel_progress_bar( user =null, progbar =null ) {
[object Object]
	}

	function CanHug( M =null ) {
		local C, H
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function capitalize( t =null ) {
[object Object]
	}

	function cardinalrange( center =null ) {
		local things, direction, T
[object Object],[object Object],[object Object],[object Object]
	}

	function Ceiling( x =null ) {
[object Object]
	}

	function Centcomm_announce( text =null, Sender =null ) {
		local msg
[object Object],[object Object],[object Object]
	}

	function center_image( I =null, x_dimension =null, y_dimension =null ) {
		local x_offset, y_offset
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function changeling_transform( user =null, chosen_prof =null ) {
		local chosen_dna, slot, C, equip, thetype
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function changemap( VM =null ) {
		local file, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function cheap_hypotenuse( Ax =null, Ay =null, Bx =null, By =null ) {
[object Object]
	}

	function check_if_greater_rights_than( other =null ) {
[object Object],[object Object]
	}

	function check_rights( rights_required =null, show_msg =null ) {
[object Object],[object Object],[object Object]
	}

	function check_rights_for( subject =null, rights_required =null ) {
[object Object],[object Object]
	}

	function check_tank_exists( parent_tank =null, M =null, O =null ) {
[object Object]
	}

	function check_zone( zone =null ) {
[object Object],[object Object],[object Object]
	}

	function chemscan( user =null, M =null ) {
		local H, R
[object Object]
	}

	function circlerange( center =null, radius =null ) {
		local centerturf, turfs, rsq, T, dx, dy
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function circlerangeturfs( center =null, radius =null ) {
		local centerturf, turfs, rsq, T, dx, dy
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function Clamp( val =null, min =null, max =null ) {
[object Object]
	}

	function clearlist( list =null ) {
[object Object],[object Object]
	}

	function closeToolTip( user =null ) {
[object Object]
	}

	function cmd_admin_mute( whom =null, mute_type =null, automute =null ) {
		local muteunmute, mute_string, C, P
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function cmp_abilities_cost( a =null, b =null ) {
[object Object]
	}

	function cmp_ckey_asc( a =null, b =null ) {
[object Object]
	}

	function cmp_ckey_dsc( a =null, b =null ) {
[object Object]
	}

	function cmp_name_asc( a =null, b =null ) {
[object Object]
	}

	function cmp_name_dsc( a =null, b =null ) {
[object Object]
	}

	function cmp_numeric_asc( a =null, b =null ) {
[object Object]
	}

	function cmp_records_asc( a =null, b =null ) {
[object Object]
	}

	function cmp_records_dsc( a =null, b =null ) {
[object Object]
	}

	function cmp_rped_sort( A =null, B =null ) {
[object Object]
	}

	function cmp_subsystem_priority( a =null, b =null ) {
[object Object]
	}

	function cmp_text_asc( a =null, b =null ) {
[object Object]
	}

	function color2hex( color =null ) {
[object Object],[object Object]
	}

	function construct_block( value =null, values =null, blocksize =null ) {
		local width
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function convert_notes_sql( ckey =null ) {
		local notesfile, notetext, server, regex, results, timestamp, adminckey, query_convert_time, err
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function count_by_type( L =null, type =null ) {
		local i, T
[object Object],[object Object],[object Object],[object Object]
	}

	function create_ninja_mind( key =null ) {
		local Mind
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function create_space_ninja( spawn_loc =null ) {
		local new_ninja, A
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function create_xeno( ckey =null ) {
		local candidates, M, alien_caste, spawn_here, new_xeno
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function createRandomZlevel(  ) {
		local potentialRandomZlevels, Lines, t, pos, name, map, file, L
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function cultist_commune( user =null, clear =null, say =null, message =null ) {
		local M
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function dd_hasprefix_case( text =null, prefix =null ) {
		local start, end
[object Object],[object Object],[object Object]
	}

	function dd_hassuffix( text =null, suffix =null ) {
		local start
[object Object],[object Object],[object Object]
	}

	function dd_limittext( message =null, length =null ) {
		local size
[object Object],[object Object],[object Object]
	}

	function dd_range( low =null, high =null, num =null ) {
[object Object]
	}

	function deconstruct_block( value =null, values =null, blocksize =null ) {
		local width
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function deltimer( id =null ) {
		local _event
[object Object],[object Object],[object Object]
	}

	function derpspeech( message =null, stuttering =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function dir2angle( D =null ) {
[object Object]
	}

	function dir2text( direction =null ) {
[object Object],[object Object]
	}

	function dir2text_short( direction =null ) {
[object Object],[object Object]
	}

	function DirBlockedWithAccess( T =null, dir =null, ID =null ) {
		local D
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function display_roundstart_logout_report(  ) {
		local msg, L, found, C, D, M
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function do_after( user =null, delay =null, numticks =null, needhand =null, target =null, progress =null ) {
		local Tloc, delayfraction, Uloc, holding, holdingnull, progbar, continue_looping, i
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function do_mob( user =null, target =null, time =null, numticks =null, uninterruptible =null, progress =null ) {
		local user_loc, target_loc, holding, timefraction, progbar, continue_looping, i
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function do_teleport( ... ) { // Arg Names: 0: ateleatom, 1: adestination, 2: aprecision, 3: afteleport, 4: aeffectin, 5: aeffectout, 6: asoundin, 7: asoundout
		local D
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function DrawPixel( I =null, colour =null, drawX =null, drawY =null ) {
		local Iwidth, Iheight
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function DuplicateObject( original =null, perfectcopy =null, sameloc =null ) {
		local O, V
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function edit_note( note_id =null ) {
		local target_ckey, sql_ckey, query_find_note_edit, err, old_note, adminckey, new_note, edit_text, query_update_note
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function electrocute_mob( M =null, power_source =null, source =null, siemens_coeff =null ) {
		local H, G, source_area, Cable, PN, cell, apc, PN_damage, cell_damage, shock_damage, drained_hp, drained_energy, drained_power
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function Ellipsis( original_msg =null, chance =null, keep_words =null ) {
		local words, new_words, new_msg, w
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function emoji_parse( text =null ) {
		local parsed, pos, search, emoji
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function empulse( epicenter =null, heavy_range =null, light_range =null, log =null ) {
		local T, distance
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function english_list( input =null, nothing_text =null, and_text =null, comma_text =null, final_comma_text =null ) {
		local total, output, index
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function establish_db_connection(  ) {
[object Object],[object Object]
	}

	function explosion( epicenter =null, devastation_range =null, heavy_impact_range =null, light_impact_range =null, flash_range =null, adminlog =null, ignorecap =null, flame_range =null, silent =null ) {
		local orig_dev_range, orig_heavy_range, orig_light_range, start, max_range, cached_exp_block, far_dist, frequency, M, M_turf, dist, far_volume, postponeCycles, E, x0, y0, z0, affected_turfs, T, D, W, B, Trajectory, flame_dist, throw_dist, throw_dir, I, throw_range, throw_at, took, i, Array
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function feedback_add_details( variable =null, details =null ) {
		local FV
[object Object],[object Object],[object Object],[object Object]
	}

	function feedback_inc( variable =null, value =null ) {
		local FV
[object Object],[object Object],[object Object],[object Object]
	}

	function feedback_set( variable =null, value =null ) {
		local FV
[object Object],[object Object],[object Object],[object Object]
	}

	function feedback_set_details( variable =null, details =null ) {
		local FV
[object Object],[object Object],[object Object],[object Object]
	}

	function file2list( filename =null, seperator =null ) {
[object Object],[object Object]
	}

	function filter_fancy_list( L =null, filter =null ) {
		local matches, key, value
[object Object],[object Object],[object Object],[object Object]
	}

	function find_record( field =null, value =null, L =null ) {
		local R
[object Object],[object Object]
	}

	function find_type_in_direction( source =null, direction =null, range =null ) {
		local x_offset, y_offset, target_turf, A, a_type
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function findchar( haystack =null, needles =null, start =null, end =null ) {
		local temp, len, i
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function findname( msg =null ) {
		local M
[object Object],[object Object],[object Object],[object Object]
	}

	function flick_overlay( I =null, show_to =null, duration =null ) {
		local C
[object Object],[object Object],[object Object]
	}

	function forbidden_atoms_check( A =null ) {
		local blacklist, thing
[object Object],[object Object],[object Object]
	}

	function format_frequency( f =null ) {
[object Object],[object Object]
	}

	function format_table_name( table =null ) {
[object Object]
	}

	function format_text( text =null ) {
[object Object]
	}

	function gameTimestamp( format =null ) {
[object Object],[object Object]
	}

	function gaussian( mean =null, stddev =null ) {
		local R1, R2, working
[object Object],[object Object]
	}

	function Gcd( a =null, b =null ) {
[object Object]
	}

	function generate_code_phrase(  ) {
		local code_phrase, words, safety, nouns, drinks, locations, names, t, maxwords
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function generate_female_clothing( index =null, t_color =null, icon =null, type =null ) {
		local female_clothing_icon, female_s
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function generate_ion_law( ionMessage =null ) {
		local ionthreats, ionobjects, ioncrew1, ioncrew2, ionadjectives, ionadjectiveshalf, ionverb, ionnumberbase, ionnumbermodhalf, ionarea, ionthinksof, ionmust, ionrequire, ionthings, ionallergy, ionallergysev, ionspecies, ionabstract, ionfood, message
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get( loc =null, type =null ) {
[object Object],[object Object]
	}

	function get_access_desc( A =null ) {
[object Object]
	}

	function get_airlock_overlay( icon_state =null, icon_file =null ) {
		local iconkey
[object Object],[object Object],[object Object],[object Object]
	}

	function get_all_accesses(  ) {
[object Object]
	}

	function get_all_centcom_access(  ) {
[object Object]
	}

	function get_all_centcom_jobs(  ) {
[object Object]
	}

	function get_all_job_icons(  ) {
[object Object]
	}

	function get_all_jobs(  ) {
[object Object]
	}

	function get_all_syndicate_access(  ) {
[object Object]
	}

	function Get_Angle( start =null, end =null ) {
		local dy, dx, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function get_area( O =null ) {
		local location, i
[object Object],[object Object],[object Object],[object Object]
	}

	function get_area_all_atoms( areatype =null ) {
		local areatemp, atoms, N, A
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_area_master( O =null ) {
		local A
[object Object],[object Object],[object Object]
	}

	function get_area_name( N =null ) {
		local A
[object Object],[object Object],[object Object]
	}

	function get_area_turfs( areatype =null ) {
		local areatemp, turfs, N, T
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_both_hands( M =null ) {
		local hands
[object Object],[object Object]
	}

	function get_candidates( be_special_flag =null, afk_bracket =null, jobbanType =null ) {
		local candidates, G
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_centcom_access( job =null ) {
[object Object]
	}

	function get_centcom_access_desc( A =null ) {
[object Object]
	}

	function get_department_heads( job_title =null ) {
		local J
[object Object],[object Object],[object Object]
	}

	function get_dist_euclidian( Loc1 =null, Loc2 =null ) {
		local dx, dy, dist
[object Object],[object Object],[object Object],[object Object]
	}

	function get_domination_time( G =null ) {
[object Object]
	}

	function get_edge_target_turf( A =null, direction =null ) {
		local target
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_ert_access( _class =null ) {
[object Object]
	}

	function get_fancy_list_of_types(  ) {
		local temp, type, typename, tn
[object Object],[object Object]
	}

	function get_hear( range =null, source =null ) {
		local lum, heard
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_hearers_in_view( R =null, source =null ) {
		local T, hear, range, A
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_location_accessible( M =null, location =null ) {
		local covered_locations, face_covered, eyesmouth_covered, C, I, H
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_location_modifier( M =null ) {
		local T
[object Object],[object Object]
	}

	function get_mob_by_ckey( key =null ) {
		local mobs, M
[object Object],[object Object],[object Object],[object Object]
	}

	function get_mob_by_key( key =null ) {
		local M
[object Object],[object Object],[object Object]
	}

	function get_mobs_in_radio_ranges( radios =null ) {
		local R, _default
[object Object],[object Object],[object Object]
		return _default
	}

	function get_offset_target_turf( A =null, dx =null, dy =null ) {
		local x, y
[object Object],[object Object],[object Object]
	}

	function get_radio_name( freq =null ) {
		local returntext
[object Object],[object Object],[object Object]
	}

	function get_radio_span( freq =null ) {
		local returntext
[object Object],[object Object],[object Object]
	}

	function get_rand_frequency(  ) {
[object Object]
	}

	function get_ranged_target_turf( A =null, direction =null, range =null ) {
		local x, y
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_region_accesses( code =null ) {
[object Object]
	}

	function get_region_accesses_name( code =null ) {
[object Object]
	}

	function get_security_level(  ) {
[object Object]
	}

	function get_sfx( soundin =null ) {
[object Object],[object Object]
	}

	function get_stickyban_from_ckey( ckey =null ) {
		local key, _default
[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function get_supply_group_name( cat =null ) {
[object Object]
	}

	function get_teleport_loc( location =null, target =null, distance =null, density =null, errorx =null, errory =null, eoffsetx =null, eoffsety =null ) {
		local dirx, diry, xoffset, yoffset, b1xerror, b1yerror, b2xerror, b2yerror, destination, destination_list, center, T
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_timestamp(  ) {
[object Object]
	}

	function get_turf( A =null ) {
[object Object],[object Object],[object Object]
	}

	function get_turf_pixel( AM =null ) {
		local rough_x, rough_y, final_x, final_y, i_width, i_height, AMicon, n_width, n_height
[object Object]
	}

	function get_uplink_items( gamemode_override =null ) {
		local last, item, I, filtered_uplink_items, category
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function get_viewable_pdas(  ) {
		local P, _default
[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function getb( col =null ) {
[object Object]
	}

	function getBlankIcon( A =null, safety =null ) {
		local flat_icon, blank_icon
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function getblock( input =null, blocknumber =null, blocksize =null ) {
[object Object],[object Object]
	}

	function GetColors( hex =null ) {
		local hi1, lo1, hi2, lo2, hi3, lo3, hi4, lo4
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function GetExp( minutes =null ) {
		local exp, timeleftstring
[object Object],[object Object],[object Object]
	}

	function GetExpjob( minutes =null ) {
		local exp, timeleftstring
[object Object],[object Object],[object Object]
	}

	function getFlatIcon( A =null, defdir =null, deficon =null, defstate =null, defblend =null ) {
		local flat, noIcon, curicon, curstate, curdir, curblend, layers, copy, process, pSet, curIndex, current, currentLayer, compare, cmpIndex, add, flatX1, flatX2, flatY1, flatY2, addX1, addX2, addY1, addY2, I
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function GetFromPool( get_type =null, second_arg =null ) {
		local pooled, AM
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function getg( col =null ) {
[object Object]
	}

	function getHologramIcon( A =null, safety =null ) {
		local flat_icon, alpha_mask
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function getIconMask( A =null ) {
		local alpha_mask, I, image_overlay
[object Object],[object Object],[object Object],[object Object]
	}

	function getleftblocks( input =null, blocknumber =null, blocksize =null ) {
[object Object]
	}

	function getLetterImage( A =null, letter =null, uppercase =null ) {
		local atom_icon, text_image
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function getline( M =null, N =null ) {
		local px, py, line, dx, dy, dxabs, dyabs, sdx, sdy, x, y, j
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function getmobs(  ) {
		local mobs, names, creatures, namecounts, M, name
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function getr( col =null ) {
[object Object]
	}

	function getrightblocks( input =null, blocknumber =null, blocksize =null ) {
[object Object]
	}

	function getStaticIcon( A =null, safety =null ) {
		local flat_icon, static_icon
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function Gibberish( t =null, p =null ) {
		local returntext, i, letter, j
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function gibs( location =null, viruses =null, MobDNA =null ) {
[object Object]
	}

	function give_codewords( traitor_mob =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function gotwallitem( loc =null, dir =null, check_external =null ) {
		local locdir, O
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function has_gravity( AT =null, T =null ) {
		local A
[object Object],[object Object],[object Object],[object Object]
	}

	function hasvar( A =null, varname =null ) {
[object Object]
	}

	function healthscan( user =null, M =null, mode =null ) {
		local oxy_loss, tox_loss, fire_loss, brute_loss, mob_status, H, damaged, org, D, blood_volume, blood_percent, blood_type, implant_detect, CI
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function HeapPathWeightCompare( a =null, b =null ) {
[object Object]
	}

	function heat2colour_b( temp =null ) {
[object Object],[object Object]
		return _default
	}

	function heat2colour_g( temp =null ) {
[object Object],[object Object]
		return _default
	}

	function heat2colour_r( temp =null ) {
[object Object],[object Object]
		return _default
	}

	function hex2num( hex =null ) {
		local negative, len, i, num, _default
[object Object],[object Object],[object Object]
		return _default
	}

	function hgibs( location =null, viruses =null, MobDNA =null ) {
[object Object]
	}

	function hsv( hue =null, sat =null, val =null, alpha =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function init_paths( prototype =null, L =null ) {
		local path
[object Object]
	}

	function init_sprite_accessory_subtypes( prototype =null, L =null, male =null, female =null ) {
		local path, D
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function init_subtypes( prototype =null, L =null ) {
		local path
[object Object],[object Object],[object Object],[object Object]
	}

	function InitializeSwapMaps(  ) {
		local V
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function inLineOfSight( X1 =null, Y1 =null, X2 =null, Y2 =null, Z =null, PX1 =null, PY1 =null, PX2 =null, PY2 =null ) {
		local T, s, m, b, signX, signY
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function intent_numeric( argument =null ) {
[object Object]
	}

	function investigate_subject2file( subject =null ) {
[object Object]
	}

	function ionnum(  ) {
[object Object]
	}

	function is_blind( A =null ) {
		local B
[object Object],[object Object]
	}

	function is_convertable_to_cult( mind =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function is_gangster( M =null ) {
[object Object]
	}

	function is_in_gang( M =null, gang_type =null ) {
		local G
[object Object],[object Object],[object Object],[object Object]
	}

	function is_pointed( W =null ) {
[object Object],[object Object],[object Object],[object Object]
	}

	function is_sacrifice_target( mind =null ) {
		local cult_mode
[object Object],[object Object]
	}

	function is_shadow( M =null ) {
[object Object]
	}

	function is_shadow_or_thrall( M =null ) {
[object Object]
	}

	function is_special_character( M =null ) {
		local R, A
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function is_thrall( M =null ) {
[object Object]
	}

	function is_type_in_list( A =null, L =null ) {
		local type
[object Object],[object Object],[object Object]
	}

	function iscultist( M =null ) {
[object Object]
	}

	function isemptylist( L =null ) {
[object Object],[object Object]
	}

	function IsEven( x =null ) {
[object Object]
	}

	function IsGuestKey( key =null ) {
		local i, ch, len
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function IsInRange( val =null, min =null, max =null ) {
[object Object]
	}

	function isInSight( A =null, B =null ) {
		local Aturf, Bturf
[object Object],[object Object],[object Object],[object Object]
	}

	function isLeap( y =null ) {
[object Object]
	}

	function isloyal( A =null ) {
		local L
[object Object],[object Object],[object Object]
	}

	function IsMultiple( x =null, y =null ) {
[object Object]
	}

	function IsOdd( x =null ) {
[object Object]
	}

	function isorgan( A =null ) {
[object Object]
	}

	function istool( O =null ) {
[object Object],[object Object]
	}

	function IsValidSrc( A =null ) {
		local B
[object Object],[object Object],[object Object]
	}

	function iswizard( M =null ) {
[object Object]
	}

	function item_heal_robotic( H =null, user =null, brute =null, burn =null ) {
		local affecting, dam
[object Object],[object Object],[object Object]
	}

	function jobban_fullban( M =null, rank =null, reason =null ) {
[object Object],[object Object],[object Object]
	}

	function jobban_isbanned( M =null, rank =null ) {
		local s, startpos, text
[object Object],[object Object]
	}

	function jobban_remove( X =null ) {
		local i
[object Object],[object Object],[object Object],[object Object]
	}

	function jobban_savebanfile(  ) {
		local S
[object Object],[object Object]
	}

	function jobban_unban( M =null, rank =null ) {
[object Object],[object Object]
	}

	function key_name( whom =null, include_link =null, include_name =null ) {
		local M, C, key, ckey, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function key_name_admin( whom =null, include_name =null ) {
[object Object],[object Object]
	}

	function keywords_lookup( msg =null ) {
		local adminhelp_ignored_words, msglist, surnames, forenames, ckeys, M, indexing, _string, L, surname_found, i, word, ai_found, mobs_found, original_word, found
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function kick_clients_in_lobby( message =null, kick_only_afk =null ) {
		local kicked_client_names, C
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function list2json( L =null ) {
[object Object]
	}

	function list2stickyban( ban =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function list2text( ls =null, sep =null ) {
		local l, i, _default
[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function listclearnulls( L =null ) {
		local i, thing
[object Object]
	}

	function listgetindex( L =null, index =null ) {
[object Object],[object Object]
	}

	function living_player_count(  ) {
		local living_player_count, mob
[object Object],[object Object],[object Object],[object Object]
	}

	function lizard_name( gender =null ) {
[object Object]
	}

	function load_admin_ranks(  ) {
		local previous_rights, line, next, R, prev, query, rank_name, flags
[object Object],[object Object]
	}

	function load_admins(  ) {
		local C, rank_names, R, Lines, line, List, ckey, rank, D, query
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function load_library_db_to_cache(  ) {
		local query, newbook
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function log_access( text =null ) {
[object Object]
	}

	function log_admin( text =null ) {
[object Object],[object Object]
	}

	function log_attack( text =null ) {
[object Object]
	}

	function log_chat( text =null ) {
[object Object]
	}

	function log_comment( text =null ) {
[object Object]
	}

	function log_emote( text =null ) {
[object Object]
	}

	function log_game( text =null ) {
[object Object]
	}

	function log_law( text =null ) {
[object Object]
	}

	function log_ooc( text =null ) {
[object Object]
	}

	function log_pda( text =null ) {
[object Object]
	}

	function log_prayer( text =null ) {
[object Object]
	}

	function log_say( text =null ) {
[object Object]
	}

	function log_vote( text =null ) {
[object Object]
	}

	function log_whisper( text =null ) {
[object Object]
	}

	function machine_upgrade( M =null ) {
		local new_rating, P
[object Object],[object Object],[object Object]
	}

	function make_maint_all_access(  ) {
		local A, D
[object Object],[object Object],[object Object],[object Object]
	}

	function make_mining_asteroid_secret(  ) {
		local valid, T, sanity, room, turfs, x_size, y_size, areapoints, theme, walltypes, floortypes, treasureitems, fluffitems, floor, surroundings, emptyturfs, A, surprise, garbage
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function make_ne_corner( adjacencies =null ) {
		local sdir
[object Object],[object Object],[object Object]
	}

	function make_nw_corner( adjacencies =null ) {
		local sdir
[object Object],[object Object],[object Object]
	}

	function make_progress_bar( current_number =null, goal_number =null, target =null ) {
		local progbar
[object Object]
	}

	function make_se_corner( adjacencies =null ) {
		local sdir
[object Object],[object Object],[object Object]
	}

	function make_sw_corner( adjacencies =null ) {
		local sdir
[object Object],[object Object],[object Object]
	}

	function makeBody( G_found =null ) {
		local new_character
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function makeNewConstruct( ctype =null, target =null, stoner =null, cultoverride =null ) {
		local newstruct
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function maprotate(  ) {
		local players, mapvotes, c, vote, map, VM, pickedmap, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function merge_powernets( net1 =null, net2 =null ) {
		local temp, Cable, Node
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function merge_text( into =null, from =null, null_char =null ) {
		local null_ascii, previous, start, end, i, ascii, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function message_admins( msg =null ) {
[object Object],[object Object]
	}

	function message_spans_start( spans =null ) {
		local output, S
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function mineral_scan_pulse( mobs =null, T =null, range =null ) {
		local minerals, M, user, C, F, I
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function minor_announce( message =null, title =null, alert =null ) {
		local M
[object Object],[object Object],[object Object],[object Object]
	}

	function mix_color_from_reagents( reagent_list =null ) {
		local color, vol_counter, vol_temp, R
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function moveElement( L =null, fromIndex =null, toIndex =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function moveRange( L =null, fromIndex =null, toIndex =null, len =null ) {
		local distance, i
[object Object],[object Object],[object Object]
	}

	function near_camera( M =null ) {
		local R
[object Object],[object Object],[object Object]
	}

	function new_station_name(  ) {
		local random, name, new_station_name, holiday_name, holiday
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function next_list_item( item =null, L =null ) {
		local i
[object Object],[object Object],[object Object]
	}

	function ninjaspeak( n =null ) {
		local te, t, p, n_letter, n_mod
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function notice( msg =null ) {
[object Object]
	}

	function Nuke_request( text =null, Sender =null ) {
		local msg
[object Object],[object Object],[object Object],[object Object]
	}

	function nukelastname( M =null ) {
		local randomname, newname
[object Object],[object Object],[object Object],[object Object]
	}

	function NukeNameAssign( lastname =null, syndicates =null ) {
		local synd_mind, H
[object Object],[object Object],[object Object]
	}

	function num2hex( num =null, len =null ) {
		local i, remainder, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function num2seclevel( num =null ) {
[object Object]
	}

	function onclose( user =null, windowid =null, _ref =null ) {
		local param
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function parse_zone( zone =null ) {
[object Object]
	}

	function parsepencode( t =null, user =null, signfont =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function pick_n_take( L =null ) {
		local picked, _default
[object Object]
		return _default
	}

	function pickweight( L =null ) {
		local total, item
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function PlaceInPool( diver =null, destroy =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function play_vox_word( word =null, z_level =null, only_listener =null ) {
		local sound_file, voice, M, T
[object Object],[object Object],[object Object]
	}

	function playsound( source =null, soundin =null, vol =null, vary =null, extrarange =null, falloff =null, surround =null ) {
		local frequency, turf_source, P, M, T
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function pollCandidates( Question =null, jobbanType =null, gametypeCheck =null, be_special_flag =null, poll_time =null ) {
		local candidates, time_passed, G
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function PoolOrNew( get_type =null, second_arg =null ) {
[object Object],[object Object],[object Object]
		return _default
	}

	function pop( L =null ) {
[object Object]
		return _default
	}

	function possess( O =null ) {
		local T
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function power_failure(  ) {
		local S, skipped_areas, A, skip, area_type, AT, C
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function power_list( T =null, source =null, d =null, unmarked =null, cable_only =null ) {
		local AM, P, C, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function power_restore(  ) {
		local C, S, A
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function power_restore_quick(  ) {
		local S
[object Object],[object Object],[object Object]
	}

	function pretty_string_from_reagent_list( reagent_list =null ) {
		local result, R
[object Object],[object Object],[object Object],[object Object]
	}

	function previous_list_item( item =null, L =null ) {
		local i
[object Object],[object Object],[object Object]
	}

	function print_command_report( text =null, title =null ) {
		local C, P
[object Object],[object Object],[object Object],[object Object]
	}

	function priority_announce( text =null, title =null, sound =null, type =null ) {
		local announcement, M
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function projectile_trajectory( src_x =null, src_y =null, rotation =null, angle =null, power =null ) {
		local power_x, power_y, time, distance, dest_x, dest_y
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function propagate_network( O =null, PN =null ) {
		local worklist, found_machines, index, P, C, M, PM
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function qdel( A =null ) {
		local hint
[object Object],[object Object]
	}

	function qdeleted( A =null ) {
[object Object],[object Object],[object Object]
	}

	function radiation_pulse( epicenter =null, heavy_range =null, light_range =null, severity =null, log =null ) {
		local light_severity, T, distance
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function ran_zone( zone =null, probability =null ) {
		local t
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function randmut( M =null, candidates =null, difficulty =null ) {
		local num, _default
[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function randmutb( M =null ) {
		local HM, _default
[object Object],[object Object],[object Object]
		return _default
	}

	function randmutg( M =null ) {
		local HM, _default
[object Object],[object Object],[object Object]
		return _default
	}

	function randmuti( M =null ) {
		local num, newdna
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function random_blood_type(  ) {
[object Object]
	}

	function random_eye_color(  ) {
[object Object]
	}

	function random_facial_hair_style( gender =null ) {
[object Object]
	}

	function random_features(  ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function random_hair_style( gender =null ) {
[object Object]
	}

	function random_short_color(  ) {
[object Object]
	}

	function random_skin_tone(  ) {
[object Object]
	}

	function random_socks( gender =null ) {
[object Object],[object Object]
	}

	function random_step( AM =null, steps =null, chance =null ) {
		local initial_chance
[object Object],[object Object]
	}

	function random_string( length =null, characters =null ) {
		local i, _default
[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function random_undershirt( gender =null ) {
[object Object],[object Object]
	}

	function random_underwear( gender =null ) {
[object Object],[object Object]
	}

	function random_unique_lizard_name( gender =null, attempts_to_find_unique_name =null ) {
		local i, _default
[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function random_unique_name( gender =null, attempts_to_find_unique_name =null ) {
		local i, _default
[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function randomColor( mode =null ) {
[object Object],[object Object]
	}

	function randomize_human( H =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function ReadHSV( hsv =null ) {
		local i, start, ch, which, hue, sat, val, alpha, usealpha, digits, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function ReadRGB( rgb =null ) {
		local i, start, ch, which, r, g, b, alpha, usealpha, digits, single, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function recursive_hear_check( O =null ) {
		local processing_list, processed_list, found_atoms, A, B
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function recursive_mob_check( O =null, client_check =null, sight_check =null, include_radio =null ) {
		local processing_list, processed_list, found_mobs, A, passed, A_tmp, B
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function regex_find( str =null, exp =null ) {
[object Object]
	}

	function regex_note_sql_extract( str =null, exp =null ) {
[object Object]
	}

	function reject_bad_name( t_in =null, allow_numbers =null, max_length =null ) {
		local number_of_alphanumeric, last_char_group, t_out, i, ascii_char, bad_name
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function reject_bad_text( text =null, max_length =null ) {
		local non_whitespace, i
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function release( O =null ) {
		local H
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function remove_note( note_id =null ) {
		local ckey, notetext, adminckey, query_find_note_del, err, query_del_note
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function remove_radio( radio =null, freq =null ) {
[object Object],[object Object],[object Object]
	}

	function remove_radio_all( radio =null ) {
		local freq
[object Object],[object Object]
	}

	function RemoveBan( foldername =null ) {
		local key, id, A
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function RemoveBanjob( foldername =null ) {
		local key, id, rank, A
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function removeNullsFromList( L =null ) {
[object Object],[object Object]
	}

	function repeat_string( times =null, _string =null ) {
		local i, _default
[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function replacetext( str =null, exp =null, fmt =null ) {
[object Object]
	}

	function replacetextEx( str =null, exp =null, fmt =null ) {
[object Object]
	}

	function return_file_text( filename =null ) {
		local text
[object Object],[object Object],[object Object],[object Object]
	}

	function reverseRange( L =null, start =null, end =null ) {
[object Object],[object Object],[object Object],[object Object]
	}

	function revoke_maint_all_access(  ) {
		local A, D
[object Object],[object Object],[object Object],[object Object]
	}

	function rgb2hsl( red =null, green =null, blue =null ) {
		local max, min, range, hue, saturation, lightness, dred, dgreen, dblue
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function RGBtoHSV( rgb =null ) {
		local RGB, r, g, b, hi, lo, val, sat, hue, dir, mid
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function rightandwrong( summon_type =null, user =null, survivor_probability =null ) {
		local gunslist, magiclist, magicspeciallist, H, guns, survive, obj_count, OBJ, randomizeguns, randomizemagic, randomizemagicspecial, gat
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function rights2text( rights =null, seperator =null, adds =null, subs =null ) {
		local verbpath, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function robogibs( location =null, viruses =null ) {
[object Object]
	}

	function RoundDiagBar( value =null ) {
[object Object],[object Object]
	}

	function RoundHealth( health =null ) {
[object Object],[object Object]
	}

	function safepick( L =null ) {
[object Object]
	}

	function sanitize( t =null, repl_chars =null ) {
[object Object],[object Object]
	}

	function sanitize_frequency( f =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function sanitize_gender( gender =null, neuter =null, plural =null, __default =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function sanitize_hexcolor( color =null, desired_format =null, include_crunch =null, __default =null ) {
		local crunch, start, len, step_size, i, ascii, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function sanitize_inlist( value =null, List =null, __default =null ) {
[object Object],[object Object],[object Object]
	}

	function sanitize_integer( number =null, min =null, max =null, __default =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function sanitize_ooccolor( color =null ) {
		local HSL, RGB
[object Object],[object Object],[object Object],[object Object]
	}

	function sanitize_simple( t =null, repl_chars =null ) {
		local _char, index
[object Object],[object Object],[object Object],[object Object]
	}

	function sanitize_text( text =null, __default =null ) {
[object Object],[object Object],[object Object]
	}

	function sanitizeSQL( t =null ) {
		local sqltext
[object Object],[object Object]
	}

	function scramble_dna( M =null, ui =null, se =null, probability =null ) {
		local i
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function screen_loc2turf( scr_loc =null, origin =null ) {
		local tX, tY, tZ
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function SDQL_expression( _object =null, expression =null, start =null ) {
		local result, val, i, op, ret
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function SDQL_from_objs( tree =null ) {
		local _out, type, _char
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function SDQL_get_all( type =null, location =null ) {
		local _out, d
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function SDQL_parse( query_list =null ) {
		local parser, querys, query_tree, pos, querys_pos, do_parse, val, parsed_tree
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function SDQL_testout( query_tree =null, indent =null ) {
		local spaces, s, item
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function SDQL_value( _object =null, expression =null, start =null ) {
		local i, val, ret
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function SDQL_var( _object =null, expression =null, start =null ) {
[object Object],[object Object]
	}

	function SDQL2_tokenize( query_text =null ) {
		local whitespace, single, multi, word, query_list, len, i, _char, char2
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function seclevel2num( seclevel =null ) {
[object Object]
	}

	function seedify( O =null, t_max =null, extractor =null ) {
		local t_amount, F, t_prod
[object Object],[object Object],[object Object]
	}

	function select_active_ai( user =null ) {
		local ais, _default
[object Object],[object Object],[object Object]
		return _default
	}

	function select_active_ai_with_fewest_borgs(  ) {
		local selected, active, A
[object Object],[object Object],[object Object],[object Object]
	}

	function select_active_free_borg( user =null ) {
		local borgs, _default
[object Object],[object Object],[object Object]
		return _default
	}

	function send_byjax( receiver =null, control_id =null, target_element =null, new_content =null, callback =null, callback_args =null ) {
		local argums
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function send2irc( msg =null, msg2 =null ) {
[object Object],[object Object]
	}

	function send2irc_adminless_only( source =null, msg =null, requiredflags =null ) {
		local admin_number_total, admin_number_afk, admin_number_ignored, admin_number_decrease, X, invalid, admin_number_present
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function set_security_level( level =null ) {
		local FA, pod
[object Object],[object Object]
	}

	function setblock( istring =null, blocknumber =null, replacement =null, blocksize =null ) {
[object Object],[object Object],[object Object]
	}

	function setup_database_connection(  ) {
		local user, pass, db, address, port, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function setup_map_transitions(  ) {
		local SLS, D, conf_set_len, k, A, point_grid, grid, P, i, j, pnt, possible_points, used_points, S
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function SetViruses( R =null, data =null ) {
		local preserve, A
[object Object]
	}

	function shake_camera( M =null, duration =null, strength =null ) {
		local oldeye, x
[object Object],[object Object]
	}

	function show_note( target_ckey =null, index =null, linkless =null ) {
		local output, navbar, ruler, letter, target_sql_ckey, query_get_notes, err, id, timestamp, notetext, adminckey, last_editor, server, index_ckey, search, query_list_notes
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function shuffle( L =null ) {
		local i
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function sign( x =null ) {
[object Object]
	}

	function SimplifyDegrees( degrees =null ) {
[object Object],[object Object],[object Object]
	}

	function slur( n =null ) {
		local phrase, leng, counter, newphrase, newletter
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function smooth_icon( A =null ) {
		local adjacencies
[object Object],[object Object]
	}

	function smooth_icon_neighbors( A =null ) {
		local T
[object Object],[object Object]
	}

	function sortInsert( L =null, cmp =null, associative =null, fromIndex =null, toIndex =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function sortKey( L =null, order =null ) {
[object Object],[object Object]
	}

	function sortList( L =null, cmp =null ) {
[object Object],[object Object]
	}

	function sortmobs(  ) {
		local moblist, sortmob, M
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function sortNames( L =null, order =null ) {
[object Object],[object Object]
	}

	function sortRecord( L =null, field =null, order =null ) {
[object Object],[object Object],[object Object],[object Object]
	}

	function sortTim( L =null, cmp =null, associative =null, fromIndex =null, toIndex =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function spaceDebrisFinishLoc( startSide =null, Z =null ) {
		local endy, endx, T
[object Object],[object Object],[object Object]
	}

	function spaceDebrisStartLoc( startSide =null, Z =null ) {
		local starty, startx, T
[object Object],[object Object],[object Object]
	}

	function spawn_meteor( meteortypes =null ) {
		local pickedstart, pickedgoal, max_i, startSide, Me, M
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function spawn_meteors( number =null, meteortypes =null ) {
		local i
[object Object],[object Object],[object Object],[object Object]
	}

	function spawn_room( start_loc =null, x_size =null, y_size =null, walltypes =null, floor =null, name =null ) {
		local room_turfs, x, y, T, cur_loc, A, wall
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function sql_poll_admins(  ) {
		local admincount, sqltime, query, err
[object Object],[object Object],[object Object],[object Object]
	}

	function sql_poll_players(  ) {
		local playercount, M, sqltime, query, err
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function sql_report_cyborg_death( H =null ) {
		local T, placeofdeath, podname, sqlname, sqlkey, sqlpod, sqlspecial, sqljob, laname, lakey, sqltime, coord, query, err
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function sql_report_death( H =null ) {
		local T, placeofdeath, podname, sqlname, sqlkey, sqlpod, sqlspecial, sqljob, laname, lakey, sqltime, coord, query, err
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function SQLtime(  ) {
[object Object]
	}

	function stars( n =null, pr =null ) {
		local te, t, p
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function stickyban2list( ban =null ) {
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function string2listofvars( t_string =null, var_source =null ) {
		local var_found, list_value, intermediate_stage, value, A, _default
[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function strings( filename =null, key =null ) {
		local fileList, stringsList, s
[object Object],[object Object],[object Object]
	}

	function strip_html_simple( t =null, limit =null ) {
		local strip_chars, _char, index
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function stripped_input( user =null, message =null, title =null, __default =null, max_length =null ) {
		local name
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function stripped_multiline_input( user =null, message =null, title =null, __default =null, max_length =null ) {
		local name
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function stutter( n =null ) {
		local te, t, p, n_letter
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function summonevents(  ) {
[object Object]
	}

	function Syndicate_announce( text =null, Sender =null ) {
		local msg
[object Object],[object Object],[object Object]
	}

	function testing( msg =null ) {

	}

	function text2dir_extended( direction =null ) {
[object Object],[object Object]
	}

	function text2list( text =null, delimiter =null ) {
		local delim_len, last_found, found, _default
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function time_stamp( format =null ) {
[object Object],[object Object]
	}

	function tkMaxRangeCheck( user =null, target =null, focus =null ) {
		local d
[object Object],[object Object],[object Object],[object Object]
	}

	function toggle_ooc( toggle =null ) {
[object Object],[object Object],[object Object]
	}

	function togglebuildmode( M =null ) {
		local H, A, B, C, D
[object Object]
	}

	function trange( Dist =null, Center =null ) {
		local x1y1, x2y2
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function transform_dir( direction =null ) {
[object Object]
	}

	function TransformUsingVariable( input =null, inputmaximum =null, scaling_modifier =null ) {
		local inputToDegrees, size_factor
[object Object],[object Object],[object Object],[object Object]
	}

	function trim( text =null, max_length =null ) {
[object Object],[object Object]
	}

	function trim_left( text =null ) {
		local i
[object Object],[object Object],[object Object]
	}

	function trim_right( text =null ) {
		local i
[object Object],[object Object],[object Object],[object Object]
	}

	function try_move_adjacent( AM =null ) {
		local T, direction
[object Object],[object Object],[object Object]
	}

	function ui_style2icon( ui_style =null ) {
[object Object]
	}

	function ultra_range( dist =null, center =null, orange =null ) {
		local t_center, L, T, y, x, c_dist
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function unix2date( timestamp =null, seperator =null ) {
		local year, dayInSeconds, daysInYear, daysInLYear, days, tmpDays, monthsInDays, month, day, mDays, monthIndex, m
[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function updateallghostimages(  ) {
		local O
[object Object],[object Object]
	}

	function UpdateTime(  ) {
[object Object],[object Object]
	}

	function view_or_range( distance =null, center =null, type =null ) {
[object Object],[object Object],[object Object],[object Object]
		return _default
	}

	function vol_by_throwforce_and_or_w_class( I =null ) {
[object Object],[object Object]
	}

	function wabbajack( M =null ) {
		local Robot, W, new_mob, randomize, robot, D, Slime, beast, animal, A, H, all_species, speciestype, S
[object Object]
	}

	function warning( msg =null ) {
[object Object]
	}

	function wear_female_version( t_color =null, icon =null, layer =null, type =null ) {
		local index, female_clothing_icon, standing
[object Object],[object Object],[object Object],[object Object],[object Object]
	}

	function worldtime2text(  ) {
[object Object]
	}

	function Wrap( val =null, min =null, max =null ) {
		local d, t
[object Object],[object Object],[object Object]
	}

	function xgibs( location =null, viruses =null ) {
[object Object]
	}

	}
}