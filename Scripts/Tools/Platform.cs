using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Platform Destroy()
    {
        Destroy(gameObject);
        return null;
    }
}
