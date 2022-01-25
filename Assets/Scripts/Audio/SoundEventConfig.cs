using System.Collections.Generic;

namespace Alxtrkhv.AudioSystem
{
    public struct SoundEventConfig
    {
        public Dictionary<string, int> Switches { get; }

        public SoundEventConfig(Dictionary<string, int> switches)
        {
            Switches = switches;
        }
    }
}
