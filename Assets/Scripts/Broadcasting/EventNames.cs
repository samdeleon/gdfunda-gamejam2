using UnityEngine;
using System.Collections;

/*
 * Holder for event names
 * Created By: NeilDG
 */ 
public class EventNames {
	public const string ON_UPDATE_SCORE = "ON_UPDATE_SCORE";
	public const string ON_CORRECT_MATCH = "ON_CORRECT_MATCH";
	public const string ON_WRONG_MATCH = "ON_WRONG_MATCH";
	public const string ON_INCREASE_LEVEL = "ON_INCREASE_LEVEL";

	public const string ON_PICTURE_CLICKED = "ON_PICTURE_CLICKED";


	public class ARBluetoothEvents {
		public const string ON_START_BLUETOOTH_DEMO = "ON_START_BLUETOOTH_DEMO";
		public const string ON_RECEIVED_MESSAGE = "ON_RECEIVED_MESSAGE";
	}

	public class ARPhysicsEvents {
		public const string ON_FIRST_TARGET_SCAN = "ON_FIRST_TARGET_SCAN";
		public const string ON_FINAL_TARGET_SCAN = "ON_FINAL_TARGET_SCAN";
	}

	public class ExtendTrackEvents {
		public const string ON_TARGET_SCAN = "ON_TARGET_SCAN";
		public const string ON_TARGET_HIDE = "ON_TARGET_HIDE";
		public const string ON_SHOW_ALL = "ON_SHOW_ALL";
		public const string ON_HIDE_ALL = "ON_HIDE_ALL";
		public const string ON_DELETE_ALL = "ON_DELETE_ALL";
	}

	public class JabubuEvents
    {
		public const string ON_INTERACT = "ON_INTERACT";
		public const string ON_HOVER_TREAT = "ON_HOVER_TREAT";
		public const string NOT_HOVER_TREAT = "NOT_HOVER_TREAT";
		public const string TREAT_FOUND = "TREAT_FOUND";
		public const string TOGGLE_MAP = "TOGGLE_MAP";
		public const string TOGGLE_PAUSE = "TOGGLE_PAUSE";
		public const string TOGGLE_MENU = "TOGGLE_MENU";
		public const string ALL_TREAT_FOUND = "ALL_MAP_FOUND"; 
		public const string RESTART = "RESTART";
		public const string START_TIMER = "START_TIMER";

	}
}