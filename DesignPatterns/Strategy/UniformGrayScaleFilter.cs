using System.Drawing;

class UniformGrayScaleFilter : IFilter
{
    public Bitmap Process(Bitmap image)
    {
        var width = image.Width;
        var height = image.Height;

        for(int i = 0; i < height; i++)
            for(int j = 0; j < width; j++)
            {
                var pixel = image.GetPixel(j, i);
                int poundedMedian = (pixel.R + pixel.G + pixel.B) / 3;

                image.SetPixel(j, i, Color.FromArgb(poundedMedian, poundedMedian, poundedMedian));
            }

        return image;
    }
}