using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bombRb;
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layerMask;
    
    void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }
    
    // 원하는 타이밍에 폭탄 효과 실행
    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);

        BombForce();
    }

    private void BombForce()
    {
                                                                      // 감지 범위
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);

        foreach (var collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            // AddExplosionForce(폭발 파워, 폭발 위치, 폭발 범위, 폭발 높이)
            rb.AddExplosionForce(300f, transform.position, bombRange, 1f);
        }

        Destroy(gameObject);
    }
}