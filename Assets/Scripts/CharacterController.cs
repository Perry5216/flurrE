using UnityEngine;

public class CharacterController : MonoBehaviour
{
	static Animator anim;
	public class GroundState
	{
		private readonly GameObject player;
		public float width;
		public float height;
		public float length;

		//GroundState constructor.  Sets offsets for raycasting.
		public GroundState(GameObject playerRef,float l)
		{
			player = playerRef;
			width = player.GetComponent<Collider2D>().bounds.extents.x + 0.1f;
			height = player.GetComponent<Collider2D>().bounds.extents.y + 0.2f;
            length = 0.05f;
		}

		//Returns whether or not player is touching wall.
		public bool isWall()
		{
			bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width,player.transform.position.y),-Vector2.right,length);
			bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width,player.transform.position.y),Vector2.right,length);
			if( left || right )

			return true;
			return false;
		}

		//Returns whether or not player is touching ground.
		public bool isGround()
		{
			bool bottom1 = Physics2D.Raycast(new Vector2(player.transform.position.x,player.transform.position.y - height),-Vector2.up,length);
            Debug.DrawLine(new Vector2(player.transform.position.x, player.transform.position.y - height), -Vector2.up);

            bool bottom2 = Physics2D.Raycast(new Vector2(player.transform.position.x + (width - 0.2f),player.transform.position.y - height),-Vector2.up,length);
            Debug.DrawLine(new Vector2(player.transform.position.x + (width - 0.2f), player.transform.position.y - height), -Vector2.up);

            bool bottom3 = Physics2D.Raycast(new Vector2(player.transform.position.x - (width - 0.2f),player.transform.position.y - height),-Vector2.up,length);
            Debug.DrawLine(new Vector2(player.transform.position.x - (width - 0.2f), player.transform.position.y - height), -Vector2.up);
            if ( bottom1 || bottom2 || bottom3 )

			return true;
			return false;
		}

		//Returns whether or not player is touching wall or ground.
		public bool isTouching()
		{
			if( isGround() || isWall() )

			return true;
			return false;
		}

		//Returns direction of wall.
		public int wallDirection()
		{
			bool left = Physics2D.Raycast(new Vector2(player.transform.position.x - width,player.transform.position.y),-Vector2.right,length);
			bool right = Physics2D.Raycast(new Vector2(player.transform.position.x + width,player.transform.position.y),Vector2.right,length);

			if( left )
				return -2;

			if( right )
				return 2;
			    return 0;
		}
	}

	public float speed = 14f;
	public float accel = 6f;
	public float airAccel = 3f;
	public float jump = 14f;
    public float length;
	private GroundState groundState;
	void Start()
	{
		//Create an object to check if player is grounded or touching wall
		groundState = new GroundState(transform.gameObject, length);
		anim = GetComponent<Animator>();
	}

	private Vector2 input;
	private void Update()
	{
		float translation = Mathf.Abs(Input.GetAxis("Horizontal")); //the Abs or absolute function is part of Unity's Mathf (floating point maths) library, so we call it via a call to that library.

		if ( Input.GetAxis("Horizontal") < 0.01 ) input.x = -1;
		if( Input.GetAxis("Horizontal") > 0.01 ) input.x = 1;
		if (Input.GetAxis("Horizontal") == 0) input.x = 0;
		if( Input.GetButtonDown("Jump") )
		{
			input.y = 1;
			anim.SetTrigger("isJumping");
		}

		if (translation != 0)
		{
			anim.SetBool("isRunning", true);
			anim.SetBool("isIdle", false);
		}
		else
		{
			anim.SetBool("isRunning", false);
			anim.SetBool("isIdle", true);
		}

		//Reverse player if going different direction
		transform.localEulerAngles = new Vector3(transform.localEulerAngles.x,input.x == 0 ? transform.localEulerAngles.y : (input.x - 1) * 90,  transform.localEulerAngles.z);
	}


	private void FixedUpdate()
	{
		GetComponent<Rigidbody2D>().AddForce(new Vector2((input.x * speed - GetComponent<Rigidbody2D>().velocity.x) * (groundState.isGround() ? accel : airAccel), 0));//Move player.
		GetComponent<Rigidbody2D>().velocity =new Vector2(input.x == 0 && groundState.isGround() ? 0 : GetComponent<Rigidbody2D>().velocity.x,input.y == 1 && groundState.isTouching()? jump: GetComponent<Rigidbody2D>().velocity.y);//Stop player if input.x is 0 (and grounded) and jump if input.y is 1
		if( groundState.isWall() && !groundState.isGround() && input.y == 1 )GetComponent<Rigidbody2D>().velocity =new Vector2(-groundState.wallDirection() * speed * 0.75f, GetComponent<Rigidbody2D>().velocity.y);//Add force negative to wall direction (with speed reduction)
		input.y = 0;
	}
	
}
