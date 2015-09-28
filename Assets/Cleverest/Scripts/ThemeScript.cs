using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThemeScript : MonoBehaviour
{
    public static bool edit;
    public GameObject themeName;
    public static string name;

    void Start() {
        edit = false;
    }

    public void SetTheme(string themename)
    {
        this.themeName.GetComponent<Text>().text = themename;
    }


    public void ClickEdit() {
        edit = !edit;
        name = themeName.GetComponent<Text>().text;
    }
}
