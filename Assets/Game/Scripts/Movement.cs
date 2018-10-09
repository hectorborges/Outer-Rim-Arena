using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    protected virtual void GetInput() { }
    protected virtual void Look() { }
    protected virtual void Move() { }
    protected virtual void Jump() { }
    public virtual void ResetTriggers() { }
}
