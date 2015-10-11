using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Random_Script : MonoBehaviour
{

    public GameObject[] mas = new GameObject[36];
	public int[] mas2 = new int[36];
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

		for (int i = 0; i < 36; i++) {
			/*switch (mas [i].GetComponent<Image> ().sprite) {
			case button_skins[0]:
				mas2 [i] = 0;
				break;
			case button_skins[1]:
				mas2 [i] = 1;
				break;
			case button_skins[2]:
				mas2 [i] = 2;
				break;
			case button_skins[3]:
				mas2 [i] = 3;
				break;
			}*/


			if (mas [i].GetComponent<Image> ().sprite == button_skins[0])
				mas2 [i] = 0;
			if (mas [i].GetComponent<Image> ().sprite == button_skins[1])
				mas2 [i] = 1;
			if (mas [i].GetComponent<Image> ().sprite == button_skins[2])
				mas2 [i] = 2;
			if (mas [i].GetComponent<Image> ().sprite == button_skins[3])
				mas2 [i] = 3;
		}

		for (int i = 0; i < 36; i++)
		{
			mas[i].GetComponent<Image>().sprite = button_skins[4];
		}

    }

	void PushTable()
	{

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