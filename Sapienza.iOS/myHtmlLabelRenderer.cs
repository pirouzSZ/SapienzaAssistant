using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using UIKit;
using Sapienza;
using Sapienza.iOS;
using Foundation;
using System.Xml.Linq;
using Sapienza.NewsFeed;

[assembly: ExportRenderer(typeof(myHtmlLabel), typeof(myHtmlLabelRenderer))]
namespace Sapienza.iOS
{
	public class myHtmlLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // will convert HTML text into attributed string. 
                // does not work with complex HTML code.

                var attr = new NSAttributedStringDocumentAttributes();
                var nsError = new NSError();
                attr.DocumentType = NSDocumentType.HTML;

                var myHtmlData = NSData.FromString(Element.Text, NSStringEncoding.Unicode);
                this.Control.AttributedText = new NSAttributedString(myHtmlData, attr, ref nsError);

            }

        }
    }
}
