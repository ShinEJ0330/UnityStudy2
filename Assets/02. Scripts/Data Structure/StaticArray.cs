using UnityEngine;

public class StaticArray : MonoBehaviour
{
    // 자료형 [ ] : 정적 배열
    public int[] array1; // 배열 선언
    public int[] array2 = { 10, 20, 30, 40, 50 }; // 배열 선언과 초기화
    public int[] array3 = new int[5]; // 배열 선언 및 공간 할당
    public int[] array4 = new int[5] { 10, 20, 30, 40, 50 }; // 배열 선언 및 공간 할당 + 초기화

    void Start()
    {
        int number1 = array1[3];
    }
}