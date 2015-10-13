using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Explosion : MonoBehaviour
    {
        // Animation is over
        public void AnimDone()
        {
            // destroys the gameObject
            Destroy(gameObject);
        }
    }
}
