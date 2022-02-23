using System;
using System.Drawing;
using System.Windows.Forms;
using Services.Infrustucture.Parametr;
using System.Windows.Input;
using System.IO;
using Services.ChirngauzSquare.Point;
using System.Collections.Generic;

namespace FunctionGraph
{
  public partial class MainForm : Form
  {
    static int multiply = 1;
    string error = "Wrong data";
    string errorOfConst = "Graph is dot";

    private readonly IChirngauzSquareInfrastructure _concentrationService;
    public delegate void FormChanged(object sender, EventArgs e);
    public MainForm(IChirngauzSquareInfrastructure concentrationService)
    {
      _concentrationService = concentrationService ?? throw new ArgumentNullException(nameof(concentrationService));
      InitializeComponent();
      MouseWheel += new MouseEventHandler(pictureBox1_MouseWheel);
      CreateFormGreeting();
    }
    private void Calculate_Click(object sender, EventArgs e)
    {
      #region Check data
      WrongData.Clear();
      string constA = "", leftBorder = "", rightBorder = "", step = "";
      if (ConstA.Text == "")
      {
        WrongData.SetError(ConstA, error);
      }
      if (ConstA.Text != "")
      {
        if (double.Parse(ConstA.Text) == 0)
        {
          WrongData.SetError(ConstA, errorOfConst);
        }
        else
        {
          constA = ConstA.Text;
        }
      }
      if (LeftBorder.Text == "")
        WrongData.SetError(LeftBorder, error);
      else
      {
        leftBorder = LeftBorder.Text;
      }
      if (RightBorder.Text == "")
        WrongData.SetError(RightBorder, error);
      else
      {
        rightBorder = RightBorder.Text;
      }
      if (Step.Text == "")
        WrongData.SetError(Step, error);
      else
      {
        step = Step.Text;
      }
      if (ConstA.Text != "" && ConstA.Text != "0") {
        if (double.Parse(constA) > 0)
          if (double.Parse(rightBorder) > double.Parse(constA))
            WrongData.SetError(RightBorder, error);
        if (double.Parse(constA) < 0)
          if (double.Parse(leftBorder) < double.Parse(constA))
            WrongData.SetError(LeftBorder, error);
      }
      #endregion
      Graphics graphics = pictureBox1.CreateGraphics();
      graphics.Clear(Color.White);
      GetAxes();
      if (constA != "" & leftBorder != "" & rightBorder != "" & step != "" && WrongData.GetError(LeftBorder) == "" && WrongData.GetError(RightBorder) == ""
        && WrongData.GetError(ConstA) == "")
      {
        var points = GetCalculations();
        PointF[] somePointsUp = new PointF[points.Count / 2];
        PointF[] somePointsDown = new PointF[points.Count / 2];
        int centerX = pictureBox1.Width / 2;
        int centerY = pictureBox1.Height / 2;
        int iterator = 0;
        for (int i = 0; i < points.Count; i += 2)
        {
          somePointsUp[iterator] = new PointF((float)(points[i].x * multiply + centerX), ((float)points[i].y * multiply + centerY));
          somePointsDown[iterator] = new PointF((float)(points[i + 1].x * multiply + centerX), (float)(points[i + 1].y * multiply + centerY));
          iterator++;
        }
        Pen pen = new Pen(Color.Black, 2);
        graphics.DrawCurve(pen, somePointsUp);
        graphics.DrawCurve(pen, somePointsDown);
      }
    }

    public List<ChirgauzSquareModel> GetCalculations()
    {
      return _concentrationService.GetPoints(double.Parse(ConstA.Text), double.Parse(LeftBorder.Text), double.Parse(RightBorder.Text), double.Parse(Step.Text));
    }

    private void GetAxes()
    {
      Graphics graphics = pictureBox1.CreateGraphics();
      Pen pen = new Pen(Color.Black, 2);
      graphics.DrawLine(pen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
      graphics.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
      Font drawFont = new Font("Arial", 16);
      SolidBrush drawBrush = new SolidBrush(Color.Black);
      Brush brush = Brushes.Black;
      graphics.DrawString("x", drawFont, drawBrush,  pictureBox1.Width - (20), pictureBox1.Height / 2 + (0));
      graphics.DrawString("y", drawFont, drawBrush, pictureBox1.Width / 2  - 40 / 2, 0);
    }
    private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
    {
      if(e.Delta > 0 && multiply < 30)
      {
        multiply++;
        Calculate_Click(sender, e);
      }
      if(e.Delta < 0 && multiply > 1)
      {
        multiply--;
        Calculate_Click(sender, e);
      }
    }
    private static void CreateFormGreeting()
    {
      StreamReader file = new StreamReader("Agreement.txt");
      int Agreement = 0;
      if (file != null)
      {
        string yesOrNo = file.ReadLine();
        Agreement = int.Parse(yesOrNo);
      }
      file.Close();
      if (Agreement != 1)
      {
        Greeting greeting = new Greeting();
        greeting.Show();
      }
    }

    private void Table_Click(object sender, EventArgs e)
    {
      Table table = new Table();
      table.ShowDialog(this);
    }
  }
}
