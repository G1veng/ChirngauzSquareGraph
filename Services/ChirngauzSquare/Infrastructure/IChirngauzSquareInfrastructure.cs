using System;
using System.Collections.Generic;
using System.Text;
using Services.ChirngauzSquare.Point;

namespace Services.Infrustucture.Parametr
{
  public interface IChirngauzSquareInfrastructure
  {
    public List<ChirgauzSquareModel> GetPoints(double a, double leftBorder, double rigthBorder, double step); 
  }
}
