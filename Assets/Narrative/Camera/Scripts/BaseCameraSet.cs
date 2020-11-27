using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace SETHD.Narrative
{
    public interface ICameraSet
    {
        void InitializeSet();

        void DisposeSet();
    }
}
