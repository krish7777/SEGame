using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 7;
	public event System.Action OnPlayerDeath;

	float screenHalfWidthInWorldUnits;
	public AudioSource collissionSound;

	// Use this for initialization
	void Start () {

		float halfPlayerWidth = transform.localScale.x / 2f;
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
	
	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxisRaw ("Horizontal");
		float velocity = inputX * speed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);

		if (transform.position.x < -screenHalfWidthInWorldUnits) {
			transform.position = new Vector2 (screenHalfWidthInWorldUnits, transform.position.y);
		}

		if (transform.position.x > screenHalfWidthInWorldUnits) {
			transform.position = new Vector2 (-screenHalfWidthInWorldUnits, transform.position.y);
		}

		if (Input.touchCount > 0)
		{
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			if(touchPos.x>0)
            {
				velocity = speed;
			}
			else
            {
				velocity = -speed;
			}
			transform.Translate(Vector2.right * velocity * Time.deltaTime);

			if (transform.position.x < -screenHalfWidthInWorldUnits)
			{
				transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
			}

			if (transform.position.x > screenHalfWidthInWorldUnits)
			{
				transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D triggerCollider) {
		if (triggerCollider.tag == "Falling Block" ) {
			collissionSound.Play();
			if (OnPlayerDeath != null) {
				OnPlayerDeath ();
			}
			Destroy (gameObject);
		}
	}
}
