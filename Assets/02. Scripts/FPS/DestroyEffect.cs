using UnityEngine;

namespace fps
{
    public class DestroyEffect : MonoBehaviour
    {
        public float destrotTime = 2f;
        private float currentTime = 0f;

        void Update()
        {
            if (currentTime > destrotTime)
            {
                Destroy(gameObject);
            }

            currentTime += Time.deltaTime;
        }
    }
}
