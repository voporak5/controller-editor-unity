//Handler listens for any input any attempts
//to run the assigned command on the controller

using System;
using UnityEngine;

namespace Controller
{
    public class InputHandler : MonoBehaviour
    {
        public static Controller controller { get; private set; }
        KeyCode[] keycodes;

        void Awake()
        {
            controller = new Controller();
        }

        void Start()
        {
            Array keycodeInts = Enum.GetValues(typeof(KeyCode));
            keycodes = new KeyCode[keycodeInts.Length];
            int index = 0;

            foreach (int i in keycodeInts)
            {
                keycodes[index++] = (KeyCode)i;
            }
        }

        // Update is called once per frame
        void Update()
        {
            foreach (KeyCode keycode in keycodes)
            {
                if (Input.GetKeyDown(keycode))
                {
                    Debug.Log(keycode.ToString());
                    controller.Execute((int)keycode);
                }                
            }            
        }
    }
}
