using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
 
public class ButtonManager : MonoBehaviour
{
    public Text Name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
 
    // Update is called once per frame
    void Update()
    {
       
    }
 
    public void OnClickButton(){
        Name.gameObject.SetActive(true);
    }
}