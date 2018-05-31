using System;

namespace Sapienza.NewsFeed
{
	public interface IMediaService
    {
        byte[] ResizeImage(byte[] imageData, float width, float height);
    }
}
