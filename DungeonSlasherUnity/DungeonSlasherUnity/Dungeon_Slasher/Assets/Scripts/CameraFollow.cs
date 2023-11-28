using System;
using UnityEngine;




    public class CameraFollow : MonoBehaviour
    {
	private AudioSource MenuMusic;
		public Transform target;// Target to follow
		public Vector3 offset; // Offset from the player
		public float lookAtHead= 2f;  // we set  the camera to look at the  head
		public float currentZoom = 10f; //how zoom we are inside the default state of game
		[SerializeField] private float currentYaw = 0f;
    private void Start()
    {
		
    }
    void LateUpdate()
		{

		// Set the  cameras position based on our  offset and zoom
		transform.position = target.position - offset * currentZoom;
			// Look at the player's head
			transform.LookAt(target.position + Vector3.up *lookAtHead);
			// Rotate around our player
			transform.RotateAround(target.position, Vector3.up, currentYaw);
		}
	}
