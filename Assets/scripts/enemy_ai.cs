using UnityEngine;
using System.Collections;
using Utils;

public class enemy_ai : MonoBehaviour {

	Directions direction;
	private float speed=3;
	Vector3 OldPisition;

	// Use this for initialization
	void Start () {
		direction = Utilits.GetRandomEnum<Directions>(1);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		UpdateDirection ();
	}

	void UpdateDirection(){
		direction = Utilits.GetRandomEnum<Directions>(1);
	}

	void FixedUpdate () {
		switch (direction) {
		case Directions.DOWN:
			transform.rotation = Quaternion.Euler(0, 0, -90);
			//rigidbody2D.velocity=-Vector2.up * speed;
			transform.position+=-Vector3.up * speed*Time.deltaTime;
			break;
		case Directions.UP:
			transform.rotation=Quaternion.Euler(0, 0, 90);
			//rigidbody2D.velocity=Vector2.up * speed;
			transform.position+=Vector3.up * speed*Time.deltaTime;
			break;
		case Directions.LEFT:
			transform.rotation=Quaternion.Euler(0, 180, 0);
			//rigidbody2D.velocity=-Vector2.right * speed;
			transform.position+=-Vector3.right * speed*Time.deltaTime;
			break;
		case Directions.RIGHT:
			transform.rotation=Quaternion.Euler(0, 0, 0);
			//rigidbody2D.velocity=Vector2.right * speed;
			transform.position+=Vector3.right * speed*Time.deltaTime;
			break;
		};
	}

}
