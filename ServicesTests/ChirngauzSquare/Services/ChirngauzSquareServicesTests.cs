using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.ChirngauzSquare.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ChirngauzSquare.Services.Tests
{
  [TestClass()]
  public class ChirngauzSquareServicesTests
  {
    [TestMethod()]
    public void GetPointsTest()
    {
      double[] correctY = new double[10];
      correctY[0] = 3.8103173776627215;
      correctY[1] = -3.8103173776627215;
      correctY[2] = 3.5355339059327378;
      correctY[3] = -3.5355339059327378;
      correctY[4] = 3.079201435678004;
      correctY[5] = -3.079201435678004;
      correctY[6] = 2.3134069792952237;
      correctY[7] = -2.3134069792952237;
      correctY[8] = 0;
      correctY[9] = -0;
      int iterator = 0;
      double a = 2, leftBorder = -2, rightBorder = 2, step = 1;
      var classToTest = new ChirngauzSquareServices();
      var points = classToTest.GetPoints(a, leftBorder, rightBorder, step);
      foreach(var point in points)
      {
        Assert.AreEqual(point.y, correctY[iterator]);
        iterator++;
      }
    }
  }
}