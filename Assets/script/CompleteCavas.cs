using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CompleteCavas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmPro;
    Interage interage;

    // Start is called before the first frame update

    private void Awake()
    {
        interage = FindObjectOfType<Interage>();
    }
    void Start()
    {
        tmPro.text = "Congratulations!\nYou scored" + interage.GetInterage() + "%";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
