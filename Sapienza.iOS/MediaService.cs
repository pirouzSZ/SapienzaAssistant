using System;
using System.Drawing;
using Sapienza.iOS;
using Sapienza.NewsFeed;
using UIKit;
using Xamarin.Forms;


[assembly: Dependency(typeof(MediaService))]


namespace Sapienza.iOS
{
	public class MediaService : IMediaService
    {

        public UIKit.UIImage ImageFromByteArray(byte[] datas)
        {
            if (datas == null)
                return null;

            return new UIKit.UIImage(Foundation.NSData.FromArray(datas));
        }


        public byte[] ResizeImage(byte[] imageData, float width, float height)
        {
            Console.Out.WriteLine("image data : " + imageData.Length.ToString());

            UIImage originalImage = ImageFromByteArray(imageData);

            if (originalImage == null)
            {
                return null;
            }

            var originalHeight = originalImage.Size.Height;
            var originalWidth = originalImage.Size.Width;

            nfloat newHeight = 0;
            nfloat newWidth = 0;

            if (originalHeight > originalWidth)
            {
                newHeight = height;
                nfloat ratio = originalHeight / height;
                newWidth = originalWidth / ratio;
            }
            else
            {
                newWidth = width;
                nfloat ratio = originalWidth / width;
                newHeight = originalHeight / ratio;
            }

            width = (float)newWidth;
            height = (float)newHeight;

            UIGraphics.BeginImageContext(new SizeF(width, height));
            originalImage.Draw(new RectangleF(0, 0, width, height));
            var resizedImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            var bytesImagen = resizedImage.AsJPEG().ToArray();
            resizedImage.Dispose();
            return bytesImagen;
        }

    }
}
