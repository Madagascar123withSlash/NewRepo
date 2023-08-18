// See https://aka.ms/new-console-template for more information


using System.Xml.Schema;
void NewBresenhamCircle()
{
    int radius = 100;
    int y = radius;
    int p = 1 - radius;
    var xmax = Convert.ToInt32((radius / Math.Sqrt(2)));
    int[] xlist = new int[xmax];
    int[] ylist = new int[xmax];
    for (int i = 0; i < xmax; i++)
    {
        if (i == 0)
        {
            xlist[0] = 0; ylist[0] = y;
        }
        else
        {
            if (p < 0)
            {
                p += 2 * i + 1;
                xlist[i] = i;
                ylist[i] = y;
            }
            else
            {
                y -= 1;
                p += 2 * (i - y) + 1;
                xlist[i] = i;
                ylist[i] = y;
            }
        }
    }
}

void BresenhamCircle()
{
    float r = 60;
    float y = r;
    var xmax = Convert.ToInt32((r / Math.Sqrt(2)));
    int[] xlist = new int[xmax];
    int[] ylist = new int[xmax];
    for (int i = 0; i < xmax; i++)
    {
        if (i == 0)
        {
            xlist[0] = 0; ylist[0] = Convert.ToInt32(y);
        }
        else
        {
            var p = Math.Pow(i, 2) + Math.Pow(y-0.5, 2) -Math.Pow(r,2);
            if (p < 0)
            {
                xlist[i] = i;
                ylist[i] = Convert.ToInt32(y);
            }
            else
            {
                xlist[i] = i;
                ylist[i] = Convert.ToInt32(y) - 1;
            }
        }
    }
}
void pythagoreanCircle()
{
    int r = 60;
    var xmax = Convert.ToInt32((r / Math.Sqrt(2)));
    int[] xlist = new int[xmax]; int[] ylist = new int[xmax];
    for(int i = 0; i < xmax;i++)
    {
        int y = Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) - Math.Pow(i, 2)));
        xlist[i] = i;
        ylist[i] = y;
        Console.WriteLine(ylist[i].ToString());
    }
}

void polarCircle()
{
    int r = 60;
    int[] xlist = new int[450]; int[] ylist = new int[450];
    for(int i = 0;i < 450;i++)
    {
        int x = Convert.ToInt32(r*Math.Cos(Math.PI/180*Convert.ToDouble(i)/10));
        int y = Convert.ToInt32(r * Math.Sin(Math.PI / 180*Convert.ToDouble(i) / 10));
        xlist[i] = x;
        ylist[i] = y;
        Console.WriteLine(xlist[i].ToString());
    }
}
polarCircle();
Console.WriteLine("0");