using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "Hello World***";
    public string[] str2 = new string[3] { "Hello", "Unity", "World" };

    void Start()
    {
        // Debug.Log(str1[0]); // H
        // Debug.Log(str1[2]); // l
        //
        // Debug.Log(str2[0]); // Hello
        // Debug.Log(str2[2]); // World
        //
        // Debug.Log(str1.Length); // 문자열의 길이 :
        // Debug.Log(str1.Trim()); // 앞뒤 공백 제거 :
        // Debug.Log(str1.Trim('*')); // 앞뒤 문자 '*' 제거 : 

        // Debug.Log(str1.Contains('H')); // 대문자 H가 있는지
        // Debug.Log(str1.Contains('h')); // 소문자 h가 있는지
        //
        // Debug.Log(str1.Contains("Hello")); // Hello가 있는지
        //
        // Debug.Log(str1.ToUpper());; // 대문자 변환
        // Debug.Log(str1.ToLower());; // 소문자 변환

        // str1 = str1.Replace("World", "Unity");
        // Debug.Log(str1);

        // string str = str1.Trim('*');
        // Debug.Log(str);

        string text = "Apple,Banana,Orange,Melon,Water Melon,Mango";
        string[] fruits = text.Split(','); // 특정 문자로 쪼개기

        foreach (var fruit in fruits)
            Debug.Log(fruit);
    }
}