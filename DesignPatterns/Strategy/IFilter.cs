using System.Drawing;

interface IFilter
{
    Bitmap Process(Bitmap image);
}