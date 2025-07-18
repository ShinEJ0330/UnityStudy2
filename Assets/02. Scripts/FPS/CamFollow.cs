using UnityEngine;

namespace fps
{
    public class CamFollow : MonoBehaviour
    {
        public Transform target;

        void Update()
        {
            transform.position = target.position;
        }
    }
}