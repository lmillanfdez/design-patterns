using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

class ImageProcessor
{
    public enum Filters { UNIFORM_GRAY_SCALE, RED_CHANNEL_GRAY_SCALE };

    public ImageProcessor()
    {
        SelectedAlgorithm = Filters.UNIFORM_GRAY_SCALE;
    }

    public string ImagePath { get; set; }
    public Filters SelectedAlgorithm { get; set; }

    public Bitmap Process()
    {
        Bitmap bitmap;        

        var filters = new Dictionary<Filters, IFilter>
        {
            { Filters.UNIFORM_GRAY_SCALE, new UniformGrayScaleFilter() },
            { Filters.RED_CHANNEL_GRAY_SCALE, new RGrayScaleFilter() }
        };
        
        try
        {
            using(var fs = new FileStream(ImagePath, FileMode.Open, FileAccess.Read))
                bitmap = new Bitmap(fs);
        }
        catch(Exception exc)
        {
            throw new Exception("It wasn't possible to load the image. Check out the inner exception", exc);
        }

        IFilter filter = filters.GetValueOrDefault(SelectedAlgorithm, new UniformGrayScaleFilter());

        return filter.Process(bitmap);
    }
}