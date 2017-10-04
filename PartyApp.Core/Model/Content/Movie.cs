using PartyApp.Core.Enum;
using System.Collections.Generic;
using System.Linq;

namespace PartyApp.Core.Model.Content
{
    public class Movie : MediaContainer
    {
        public int CMIId { get; set; }
        public int Id { get; set; }
        public FeatureValues FeatureId { get; set; }
        public virtual IList<AudioGuestbookMessage> AudioGuestBookMessages { get; set; } = new List<AudioGuestbookMessage>();
        public bool UseAudioDefault { get; set; }

        public void AddAudioGuestBookMessage(AudioGuestbookMessage audioGuestBookMessage)
        {
            AudioGuestBookMessages.Add(audioGuestBookMessage);
            ((List<AudioGuestbookMessage>)AudioGuestBookMessages).Sort();

            UseAudioDefault = false;
        }

        public void AddImage(Image image)
        {
            //Check if the core.imagecontent imagecontentId has already been added to the list
            if (Images.Any(i => i.ImageId == image.ImageId)) return;

            Images.Add(image);
            ((List<Image>)Images).Sort();

            UseImageDefault = false;
        }
    }
}
