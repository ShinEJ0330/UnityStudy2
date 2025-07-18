using UnityEngine;

namespace fps
{
    public class PlayerMove : MonoBehaviour
    {
        public float moveSpeed = 7f;
        public float gravity = -20f;
        public float yVelocity = 0f;
        public float jumpPower = 10f;
        public bool isJumping = false;

        private CharacterController cc;

        void Start()
        {
            cc = GetComponent<CharacterController>();
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 dir = new Vector3(h, 0, v);
            dir = dir.normalized;

            dir = Camera.main.transform.TransformDirection(dir);

            //transform.position += dir * moveSpeed * Time.deltaTime;

            yVelocity += gravity * Time.deltaTime;
            dir.y = yVelocity;

            cc.Move(dir * moveSpeed * Time.deltaTime);

            if (cc.collisionFlags == CollisionFlags.Below)
            {
                if (isJumping)
                    isJumping = false;

                yVelocity = 0f;                
            }

            if (Input.GetButtonDown("Jump") && !isJumping)
            {
                yVelocity = jumpPower;
                isJumping = true;
            }
        }
    }
}