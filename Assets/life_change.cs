using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Text = TMPro.TextMeshProUGUI;
public class life_change : MonoBehaviour
{
    public int initiallife = 10;
    public int currlife;
    public Text _text;
    // Start is called before the first frame update
    void Start()
    {
        currlife = initiallife;
        _text = this.GetComponent<Text>();
        _text.text = "Life: " + currlife.ToString();

    }
    public void minusDisplay()
    {
        if (currlife != 0)
        {
            currlife -= 1;
             _text.text = "Life: " + currlife.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currlife == 0)
        {
            FindObjectOfType<game>().Loselevel();
        }
        
    }
}
