using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace IronSphere.Extensions.AspNetCore
{
    public static class ImageExtension
    {
        /// <summary>
        /// Scales an image to a given size
        /// </summary>
        /// <param name="this"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Bitmap Scale(this Image @this, Size size)
        {
            return _scale(@this, size);
        }

        /// <summary>
        /// Scales an image to a percentage
        /// </summary>
        /// <param name="this"></param>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public static Bitmap Scale(this Image @this, int percentage)
        {
            Size size = new Size(@this.Width / 100 * percentage, @this.Height / 100 * percentage);
            return _scale(@this, size);
        }

        private static Bitmap _scale(Image image, Size size)
        {
            Rectangle destRect = new Rectangle(new Point(0, 0), size);
            Bitmap destImage = new Bitmap(size.Width, size.Height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (Graphics graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (ImageAttributes wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        public static byte[] Resize(this Image imgIn, Size size)
        {
            double y = imgIn.Height;
            double x = imgIn.Width;

            double factor = 1;
            if (size.Width > 0)
            {
                factor = size.Width / x;
            }
            else if (size.Height > 0)
            {
                factor = size.Height / y;
            }
            MemoryStream outStream = new MemoryStream();
            Bitmap imgOut = new Bitmap((int)(x * factor), (int)(y * factor));

            // Set DPI of image (xDpi, yDpi)
            imgOut.SetResolution(72, 72);

            Graphics g = Graphics.FromImage(imgOut);
            g.Clear(Color.White);
            g.DrawImage(imgIn, new Rectangle(0, 0, (int)(factor * x), (int)(factor * y)),
                new Rectangle(0, 0, (int)x, (int)y), GraphicsUnit.Pixel);

            // imgOut.Save(outStream, getImageFormat(path));
            imgOut.Save(outStream, ImageFormat.Jpeg);
            return outStream.ToArray();
        }
    }
}
