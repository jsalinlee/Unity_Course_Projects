using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	private enum States {cell, lock_0, mirror, sheets_0, cell_mirror, lock_1, sheets_1, freedom};
	private States myState;
	public Text text;
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.cell) {
		state_cell();
		} else if (myState == States.sheets_0) {
			state_sheets_0();
		}
	}
	void state_cell() {
		text.text = "You wake up in a damp prison cell, head throbbing " +
					"as you piece together the events of last night. " +
					"What started as a cheery celebration at the tavern " +
					"quickly devolved into violence when someone made a " +
					"remark about your mother. Emotions ran high and " + 
					"chaos ensued as the tavern sang with clashes of " +
					"steel and iron. A bloody bout later, the police " +
					"arrived, guns drawn, and your LARPing career came " +
					"to a sudden halt. There are dirty sheets and a " +
					"broken mirror in the cell and the cell door is " +
					"fastened by a lock on the outside.\n\n" +
					"Press S to look at the Sheets, M to look at the " +
					"Mirror, and L to inspect the Lock";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		}
	}

	void state_sheets_0() {
		text.text = "You can't believe you sleep in these rags";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}
//AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
}
