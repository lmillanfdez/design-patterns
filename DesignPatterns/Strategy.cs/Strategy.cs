using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace design_patterns.DesignPatterns.Strategy
{
    interface IFilter
    {
        String Process(Bitmap image);
    }

    public class ImageProcessorUI
    {
        public static void Run()
        {
            Console.WriteLine("Please, paste in the image's path and press enter.\n\nImage's path: ");
            var imagePath = Console.ReadLine();

            Console.WriteLine("\nPlease, type in the filter to use and press enter\n");

            var optionsList = new List<string>();
            foreach(ImageProcessor.Filters f in Enum.GetValues(typeof(ImageProcessor.Filters)))
                optionsList.Add($"{Convert.ToInt32(f)} - {f.ToString().Replace('_', ' ')}\n");

            Console.WriteLine(String.Join('\n', optionsList));

            Console.WriteLine("\nSelected option: ");
            var filterId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n\nCan we procced(Y/N)?:");
            var approval = Console.ReadLine().ToUpper().Trim() == "Y";

            if(!approval)
            {
                Console.WriteLine("Bye!!");
                return;
            }

            var ip = new ImageProcessor();

            ip.ImagePath = imagePath;
            ip.SelectedAlgorithm = (ImageProcessor.Filters)filterId;

            var result = ip.Process();

            Console.WriteLine(result);
        }
    }

    class ImageProcessor
    {
        public enum Filters { GRAY_SCALE, GAUSSIAN };

        public ImageProcessor()
        {
            SelectedAlgorithm = Filters.GRAY_SCALE;
        }

        public string ImagePath { get; set; }
        public Filters SelectedAlgorithm { get; set; }

        public String Process()
        {
            Bitmap bitmap;
            IFilter filter;

            /* using a Dictionary for storing the algorithms could be an improve */
            
            try
            {
                /* bitmap = new Bitmap(ImagePath); */
                bitmap = null;
            }
            catch(Exception exc)
            {
                throw new Exception("It wasn't possible to load the image. Check out the inner exception", exc);
            }

            switch(SelectedAlgorithm)
            {
                case Filters.GRAY_SCALE:
                {
                    filter = new GrayScaleFilter();
                    break;
                }
                default:
                {
                    filter = new GaussianFilter();
                    break;
                }
            }

            return filter.Process(bitmap);
        }
    }

    class GrayScaleFilter : IFilter
    {
        public String Process(Bitmap image)
        {
            return "Gray Scale Filter";
        }
    }

    class GaussianFilter : IFilter
    {
        public String Process(Bitmap image)
        {
            return "Gaussian Filter";
        }
    }
}