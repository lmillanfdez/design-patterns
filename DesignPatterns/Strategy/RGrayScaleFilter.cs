using System;
using System.Drawing;

class RGrayScaleFilter : IFilter
{
    public Bitmap Process(Bitmap image)
    {
        var width = image.Width;
        var height = image.Height;

        for(int i = 0; i < height; i++)
            for(int j = 0; j < width; j++)
            {
                var pixel = image.GetPixel(j, i);
                int poundedMedian = Convert.ToInt32(pixel.R * 0.2 + pixel.G * 0.4 + pixel.B * 0.4);

                image.SetPixel(j, i, Color.FromArgb(poundedMedian, poundedMedian, poundedMedian));
            }

        return image;
    }
}