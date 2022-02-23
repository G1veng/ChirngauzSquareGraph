using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ChirngauzSquare.Point
{
  public class ChirgauzSquareModel
  {
    public double x { get; set;  }
    public double y { get; set;  }

    public ChirgauzSquareModel( double innerX, double innerY)
    {
      x = innerX;
      y = innerY;
    }
  }
}
