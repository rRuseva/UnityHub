using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlls : MonoBehaviour {
	public static KeyCode attackKey = KeyCode.E;
	public static KeyCode jumpKey = KeyCode.W;
	public static KeyCode crouchKey = KeyCode.S;
	public static string HorizontalMovementAxis = "Horizontal";

	[SerializeField]
	private KeyCode attackKeyBinding = attackKey;
	[SerializeField]
	private KeyCode jumpKeyBinding = jumpKey;
	[SerializeField]
	private KeyCode crouchKeyBinding = crouchKey;

	// Called when the values are updated in the editor
	private void OnValidate() {
		attackKey = attackKeyBinding;
		jumpKey = jumpKeyBinding;
		crouchKey = crouchKeyBinding;
	}
}
