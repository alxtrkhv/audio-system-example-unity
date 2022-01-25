using UnityEngine;

namespace Alxtrkhv.AudioSystem
{
    public static class SoundContainerParser
    {
        public static AudioClip ParseContainerForAudioClip(ISoundContainer container, SoundEventConfig config)
        {
            while (true) {
                var containerMember = container.ContainerType switch
                {
                    SoundContainerType.Single => container[0],
                    SoundContainerType.Random => ParseRandomContainer(container),
                    SoundContainerType.Switch => ParseSwitchContainer(container, config),
                    _ => default
                };

                if (containerMember.SoundContainer != null) {
                    container = containerMember.SoundContainer;
                    continue;
                }

                return containerMember.AudioClip;
            }
        }

        private static SoundContainerMember ParseSwitchContainer(ISoundContainer container, SoundEventConfig config)
        {
            var index = 0;

            config.Switches?.TryGetValue(container.Id, out index);

            return container[index];
        }

        private static SoundContainerMember ParseRandomContainer(ISoundContainer container)
        {
            var index = Random.Range(0, container.Count);

            return container[index];
        }
    }
}
