using UnityEngine;

namespace fps
{
    public class BombAction : MonoBehaviour
    {
        public GameObject bombEffect;
        private void OnCollisionEnter(Collision collision)
        {
            GameObject eff = Instantiate(bombEffect);
            eff.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
