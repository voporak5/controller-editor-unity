using System.Collections.Generic;

namespace Controller
{
    public class Controller
    {
        private Dictionary<int,ICCommand> dictSettings;

        public Controller()
        {
            dictSettings = new Dictionary<int, ICCommand>();
        }

        public void SetCommand(int val,ICCommand command, int prev = -1)
        {
            if(prev >= 0) dictSettings.Remove(prev);
            dictSettings[val] = command;
        }

        public void Execute(int val)
        {
            if (dictSettings.ContainsKey(val)) dictSettings[val].Execute();
        }

        public Command GetCommandForKey(int val)
        {
            if (dictSettings.ContainsKey(val))
            {
                return dictSettings[val].GetName();
            }

            return Command.None;
        }

        public KeyValuePair<int,ICCommand>[] GetSettings()
        {
            List<KeyValuePair<int, ICCommand>> listSettings = new List<KeyValuePair<int, ICCommand>>();
            
            foreach (KeyValuePair<int, ICCommand> entry in dictSettings)
            {
                listSettings.Add(entry);
            }

            //Give editor a way of accessing values without
            //touching data
            return listSettings.ToArray();
        }
    }
}