using System.Collections.Generic;
using UnityEngine;

public class PersonData
{
    public int age;
    public string name;
    public float height;
    public float weight;
    
    public PersonData(int age, string name, float height, float weight)
    {
        this.age = age;
        this.name = name;
        this.height = height;
        this.weight = weight;
    }
}

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData>();

    void Start()
    {
        persons.Add("철수", new PersonData(10, "철수", 150f, 30f));
        persons.Add("영희", new PersonData(10, "영희", 150f, 30f));
        persons.Add("동수", new PersonData(10, "동수", 150f, 30f));

        Debug.Log(persons["철수"].age);
        Debug.Log(persons["철수"].name);
        Debug.Log(persons["철수"].height);
        Debug.Log(persons["철수"].weight);
    }
}