using UnityEngine;
using System.Collections;
using Utils;

public class cdman_control : MonoBehaviour {

	Directions direction=Directions.NONE;
	float speed=0.04f;
	Animator animator;
	public static int Score=0;
	public AudioSource audioPoint;
	public GameObject dieAnimation;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.CompareTag("world")){
			direction = Directions.NONE;
			animator.Play("cdman_stand");
		}
		if (col.gameObject.CompareTag ("point")) {
			audioPoint.Play();
			Destroy(col.gameObject);
			Score+=100;
		}
		if (col.gameObject.CompareTag ("point_super")) {
			audioPoint.Play();
			Destroy(col.gameObject);
			Score+=500;
		}
		if (col.gameObject.CompareTag ("enemy")) {
			respounter.On=false;
			Instantiate(dieAnimation, transform.position,Quaternion.Euler(0,0,0));
			Destroy(gameObject);
			//удаляем всех врагов
			foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("enemy"))
			{
				Destroy(enemy);
			}
		}
	}

	void Awake()
	{
		// Setting up references.

	}

	void FixedUpdate () {
		switch (direction) {
		case Directions.DOWN:
			transform.rotation = Quaternion.Euler(0, 0, -90);
			//rigidbody2D.velocity=-Vector2.up * speed;
			transform.position+=-Vector3.up * speed;
			animator.Play("cdman_move");
			break;
		case Directions.UP:
			transform.rotation=Quaternion.Euler(0, 0, 90);
			//rigidbody2D.velocity=Vector2.up * speed;
			transform.position+=Vector3.up * speed;
			animator.Play("cdman_move");
			break;
		case Directions.LEFT:
			transform.rotation=Quaternion.Euler(0, 180, 0);
			//rigidbody2D.velocity=-Vector2.right * speed;
			transform.position+=-Vector3.right * speed;
			animator.Play("cdman_move");
			break;
		case Directions.RIGHT:
			transform.rotation=Quaternion.Euler(0, 0, 0);
			//rigidbody2D.velocity=Vector2.right * speed;
			transform.position+=Vector3.right * speed;
			animator.Play("cdman_move");
			break;
		};
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			direction=Directions.UP;
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			direction=Directions.DOWN;
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			direction=Directions.LEFT;
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			direction=Directions.RIGHT;
		}
	}
}
