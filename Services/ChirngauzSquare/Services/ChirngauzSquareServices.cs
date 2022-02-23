using System;
using System.Collections.Generic;
using System.Text;
using Services.Infrustucture.Parametr;
using Services.ChirngauzSquare.Point;

namespace Services.ChirngauzSquare.Services
{
  public class ChirngauzSquareServices : IChirngauzSquareInfrastructure
  {
    public List<ChirgauzSquareModel> GetPoints(double a, double leftBorder, double rigthBorder, double step)
    {
      List<ChirgauzSquareModel> points = new List<ChirgauzSquareModel>();
      for(double x = leftBorder; x <= rigthBorder; x += step)
      {
        double y = GetY(x, a);
        points.Add(new ChirgauzSquareModel((double)x, y));
        points.Add(new ChirgauzSquareModel((double)x, -y));
      }
      return points;
    }
    private double GetY(double x, double a)
    {
      if (a > 0)
        if(x > a)
          throw new DivideByZeroException();
      if(a < 0)
        if (x < a)
          throw new DivideByZeroException();
      if (x + 0.1 > a && x - 0.1 < a)
        return 0;
      double y, numerator, denominator;
      denominator = 27 * a;
      double leftTemp = a - x;
      double rightTemp = (8 * a) + x;
      numerator = leftTemp * Math.Pow(rightTemp, 2);
      y = Math.Sqrt(numerator / denominator);
      return y;
    }
  }
}
