using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
 
public class ButtonManager : MonoBehaviour
{
    public Text questionText;
    public string answer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
 
    // Update is called once per frame
    void Update()
    {
       
    }
 
    public void OnClickButton(){
        questionText.text = answer;
    }

    
}