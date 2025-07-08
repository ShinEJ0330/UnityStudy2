using System;
using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>();
    
    void Start()
    {
       for (int i = 1; i <= 10; i++) // 1 ~ 10까지 값을 list1에 추가
           list1.Add(i); // 뒤에 i를 추가
       
       // list1.Insert(5, 100); // 인덱스 5번에 100을 삽입
       // list1.Remove(5); // 값 5를 제거
       // list1.RemoveAt(5); // 인덱스 5번에 있는 값을 제거
       // list1.RemoveRange(1, 3); // 인덱스 1번에서 3개까지 제거
       // list1.Clear(); // 데이터 모두 제거
       // list1.RemoveAll(x => x > 5); // 현재 List 안에서 x > 5 값은 모두 제거
       // list1.Sort(); // 오름차순 정렬
       // string str = String.Empty; // ""
       // foreach (var x in list1)
       // {
       //     str += x.ToString() + " / ";
       // }
       //
       // Debug.Log(str);

       if (list1.Contains(10)) // List에서 10이라는 값이 있으면 true
           Debug.Log("값 10이 존재 O");
       else
           Debug.Log("값 10이 존재 X");
    }
}