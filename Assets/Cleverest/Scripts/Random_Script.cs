using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Random_Script : MonoBehaviour
{

    public GameObject[] mas = new GameObject[36];
    public Sprite[] button_skins = new Sprite[5];

    void Color(int count, int color)
    {
        while (count < 10)
        {
            int a = UnityEngine.Random.Range(0, 35);
            if (Sprite.Equals(mas[a].GetComponent<Image>().sprite, null) && count < 10)
            {
                mas[a].GetComponent<Image>().sprite = button_skins[color];
                count++;

            }
            Debug.Log(a);
        }
    }

    void Randomize()
    {
        for (int i = 0; i < mas.Length; i++)
            mas[i].GetComponent<Image>().sprite = null;

        Color(0, 0);
        Color(0, 1);
        Color(0, 2);

        for (int i = 0; i < 36; i++)
        {
            if (Sprite.Equals(mas[i].GetComponent<Image>().sprite, null))
            {
                mas[i].GetComponent<Image>().sprite = button_skins[3];
            }
        }


        //mas [0].GetComponent<Image> ().sprite = button_skins [UnityEngine.Random.Range (0, 3) ];

    }

    void Start()
    {
        Randomize();

    }

    // Update is called once per frame
    void Update()
    {

    }
}