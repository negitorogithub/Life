using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
public class Status2Text : MonoBehaviour
{
    public TextMeshProUGUI TMPro;
    public StatusVM status;

    private void Update()
    {
        TMPro.text = status.hp.ToString();
    }
}

