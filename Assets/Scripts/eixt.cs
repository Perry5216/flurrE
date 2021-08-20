using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eixt : MonoBehaviour
{
    public void quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Aplication.quit();
#endif
    } 
}