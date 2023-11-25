using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiationManager : MonoBehaviour
{
    public Image radiationBar;
    public float radiationAmount = 5f;
    public float temp = 25f;
    // Start is called before the first frame update
    void Start()
    {
        radiationBar.fillAmount = 0;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            AbsorbRadiation(25);
            if (radiationBar.fillAmount == 1)
            {
                ResetRadiaiton();
            }
        }

    }
    public void AbsorbRadiation(float radiation)
    {
        radiationAmount += radiation;

        radiationBar.fillAmount = radiationAmount / temp;
    }
    public void ResetRadiaiton()
    {
        radiationAmount = 0;
        radiationBar.fillAmount = 0;
        temp += 25;
    }
}
