using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Selectobj : MonoBehaviour {
    
    private Text label;    
    private GameObject bgLabel;
    
    // Use this for initialization
    void Start () {
        label = GameObject.Find("LabelName").GetComponent<Text>();
        label.text = "";        
        bgLabel = GameObject.Find("bgLabel");
        bgLabel.SetActive(false);
        label.text = "";



    }
	
	// Update is called once per frame
	void Update () {       
        if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    enabled = true;
                    //label.text = hit.transform.name.ToString();
                    if (hit.collider.gameObject.tag == "Tire")
                    {                        
                        bgLabel.SetActive(true);
                    label.text = "fitur pengereman\n ABS (Anti-lock Braking System)\n" +
                        "EBD (Electronic Brake-Force Distribution) ";                       
                    }
                    else if (hit.collider.gameObject.name == "hood")
                {
                    bgLabel.SetActive(true);
                    label.text = "Mesin 6498 cc dengan Tenaga 700 hp 750 CV pada 8400 rpm dan torsi 690 Nm pada 5500 rpm\n" +
                        "100 kpj dari nol dalam 2,9 detik";
                }
                else if (hit.collider.gameObject.name == "Youtube")
                {
                    Application.OpenURL("http://www.youtube.com/watch?v=BKihFM2x7Ig");
                    enabled = false;
                    StartCoroutine(UpdateOn());
                }
                else if (hit.collider.gameObject.name == "Instagram")
                {
                    Application.OpenURL("http://www.instagram.com/dikihenas/");
                    enabled = false;
                    StartCoroutine(UpdateOn());
                }
            }
                else
                {
                Debug.Log("Tekan");
                    bgLabel.SetActive(false);
                    label.text = "";
                }

            }
                    
	}  
    IEnumerator UpdateOn()
    {
        yield return new WaitForSeconds(0.5f);
        enabled = true;
    }
}
