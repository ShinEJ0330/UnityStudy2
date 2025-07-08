using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyStack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();
    public List<int> list1 = new List<int>();
    
    public int[] array = new int[3] { 1, 2, 3 };
    public int[] array2;

    void Start()
    {
        stack = new Stack<int>(array);
        
        array2 = stack.ToArray();
        list1 = stack.ToList();
    }
}