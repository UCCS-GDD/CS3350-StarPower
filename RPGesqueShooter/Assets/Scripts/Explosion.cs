using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Explosion : MonoBehaviour
    {
        public void AnimDone()
        {
            Destroy(gameObject);
        }
    }
}
