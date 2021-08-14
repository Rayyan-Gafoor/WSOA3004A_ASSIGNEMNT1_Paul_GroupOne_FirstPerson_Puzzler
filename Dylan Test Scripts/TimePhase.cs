using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePhase : MonoBehaviour
{
    public GameObject[] TimePhasedCubes;
    public GameObject[] CurrentWorldCubes;

    public KeyCode PhaseButton;

    public bool hasPhased;

    private void Start()
    {
        hasPhased = false;

        for (int i = 0; i < TimePhasedCubes.Length; i++)
        {
            TimePhasedCubes[i].SetActive(false);
            CurrentWorldCubes[i].SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(PhaseButton))
        {
            if (!hasPhased)
                hasPhased = true;
            else if (hasPhased)
                hasPhased = false;

            Phasing();
        }
    }

    private void Phasing()
    {
       if (hasPhased)
        {
            for (int i = 0; i < TimePhasedCubes.Length; i++)
            {
                TimePhasedCubes[i].SetActive(true);
                CurrentWorldCubes[i].SetActive(false);
            }

        } else if (!hasPhased)
        {
            for (int i = 0; i < TimePhasedCubes.Length; i++)
            {
                TimePhasedCubes[i].SetActive(false);
                CurrentWorldCubes[i].SetActive(true);
            }
        }
    }
}
