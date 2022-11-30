using UnityEngine;
namespace Controller
{
    public class DummyCommand : ICCommand
    {
        private Command name = Command.None;

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