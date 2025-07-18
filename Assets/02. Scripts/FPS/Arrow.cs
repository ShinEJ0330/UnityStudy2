using UnityEngine;

namespace fps
{

    public class Arrow : MonoBehaviour
    {
        public float moveSpeed = 100f;
        public bool isMove = true;

        void Update()
        {
            if (isMove)
                transform.position += transform.up * moveSpeed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            var closetPos = other.ClosestPoint(transform.position);

            transform.position = closetPos;
            transform.SetParent(other.transform);
            isMove = false;
            
            /*
            if (other.name == "Player")
            {
                transform.SetParent(other.transform);
                isMove = false;
            }
            */
        }
    }
}
