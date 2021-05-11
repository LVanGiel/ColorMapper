using System;
using System.Collections.Generic;
using System.Drawing;
using System.ComponentModel;
using System.Linq;

namespace ColorMapper
{
    class ColorMapper
    {
        static MyOrganizerColor[] myOrgColors = {   new MyOrganizerColor(1,"dark","#2F353B"),
                                                    new MyOrganizerColor(2,"blue","#3598DC"),
                                                    new MyOrganizerColor(3,"blue-madison","#578EBE"),
                                                    new MyOrganizerColor(4,"turquoise","#32C5D2"),
                                                    new MyOrganizerColor(5,"green-meadow","#1BBC9B"),
                                                    new MyOrganizerColor(6,"default","#E1E5EC"),
                                                    new MyOrganizerColor(7,"grey-salsa","#ACB5C3"),
                                                    new MyOrganizerColor(8,"grey-gallery","#555555"),
                                                    new MyOrganizerColor(9,"grey-mint","#525E64"),
                                                    new MyOrganizerColor(11,"red-pink","#E08283"),
                                                    new MyOrganizerColor(13,"red-thunderbird","#D91E18"),
                                                    new MyOrganizerColor(15,"yellow-casablanca","#F2784B"),
                                                    new MyOrganizerColor(17,"yellow-gold","#E87E04"),
                                                    new MyOrganizerColor(18,"yellow","#C49F47"),
                                                    new MyOrganizerColor(19,"yellow-lemon","#F7CA18"),
                                                    new MyOrganizerColor(20,"purple-medium","#BF55EC"),
                                                    new MyOrganizerColor(21,"purple-intense","#8775A7"),
                                                    new MyOrganizerColor(22,"purple-sharp","#796799"),
                                                    new MyOrganizerColor(23,"yellow-soft","#C8D046"),
                                                    new MyOrganizerColor(23,"white","#FFFFFF")};
        static void Main(string[] args)
        {
            string color;
            color= Console.ReadLine();
            Console.WriteLine(myOrgColors[ChangeColor(color)].Name);
        }

        //METHODS
        private static int ChangeColor(string givenColor)
        {
            var converter = new ColorConverter();
            List<Color> myOrgColorList = new List<Color>();
            Color color = (Color)converter.ConvertFromString(givenColor);

            //change array of strings to list of colors for myorgcolors
            foreach (var orgColor in myOrgColors)
            {
                myOrgColorList.Add(orgColor.RgbColor);
            }

            var closestColor =  ClosestColor(myOrgColorList, color);
            return closestColor;
        }

        // closed match in RGB space
        static int ClosestColor(List<Color> colors, Color target)
        {
            var colorDiffs = colors.Select(n => ColorDiff(n, target)).Min(n => n);
            return colors.FindIndex(n => ColorDiff(n, target) == colorDiffs);
        }

        //calculate color difference between 2 colors
        static int ColorDiff(Color c1, Color c2)
        {
            return (int)Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R)
                                   + (c1.G - c2.G) * (c1.G - c2.G)
                                   + (c1.B - c2.B) * (c1.B - c2.B));
        }
    }
    class MyOrganizerColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexColor { get; set; }
        public Color RgbColor { get; set; }

        public MyOrganizerColor(int id, string name, string hexColor)
        {
            Id = id;
            Name = name;
            HexColor = hexColor;
            RgbColor = GetRGB(hexColor);
        }
        Color GetRGB(string hexColor)
        {
            var converter = new ColorConverter();
            Color color = (Color)converter.ConvertFromString(hexColor);
            return color;
        }
    }
}
