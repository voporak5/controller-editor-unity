using UnityEngine;

namespace Controller
{
    public class CrouchCommand : ICCommand
    {
        private Command name = Command.Crouch;

        public void Execute()
        {
            Debug.LogFormat("Executed {0} Command", name.ToString());
        }

        public Command GetName()
        {
            return name;
        }
    }
}