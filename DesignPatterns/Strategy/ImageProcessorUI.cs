using System;
using System.Drawing.Imaging;
using System.Collections.Generic;

class ImageProcessorUI
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

        result.Save(@".\assests\resultingImage.jpg", ImageFormat.Jpeg);
    }
}