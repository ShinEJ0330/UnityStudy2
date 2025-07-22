using UnityEngine;

namespace fps
{
    public class Billboard : MonoBehaviour
    {
        public Transform target;

        void Update()
        {
            transform.forward = Camera.main.transform.forward;
        }
    }
}
