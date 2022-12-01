//Handler listens for any input any attempts
//to run the assigned command on the controller

using System;
using UnityEngine;

namespace Controller
{
    public class InputHandler : MonoBehaviour
    {
        public static Controller controller { get; private set; }
        public static Action<KeyCode> KeyPressEvent;
        KeyCode[] keycodes;

        void Awake()
        {
            //Controller could live anywhere.
            //I put it in this class for the 
            //sake of convenience.
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

        void Update()
        {
            foreach (KeyCode keycode in keycodes)
            {
                if (Input.GetKeyDown(keycode))
                {
                    controller.Execute((int)keycode);
                    KeyPressEvent?.Invoke(keycode);
                }                
            }            
        }
    }
}
