using System;
using System.Drawing;
using System.Windows.Forms;
using Services.Infrustucture.Parametr;
using System.Windows.Input;
using System.IO;
using Services.ChirngauzSquare.Point;
using System.Collections.Generic;
using OfficeOpenXml;

namespace FunctionGraph
{
  public partial class MainForm : Form
  {
    static int multiply = 1;
    string error = "Wrong data";
    string errorOfConst = "Graph is dot";
    string borderError = "Wrong border edges";
    private readonly IChirngauzSquareInfrastructure _concentrationService;
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
      if (ConstA.Text == "" || !double.TryParse(ConstA.Text, out double uselessResult))
      {
        WrongData.SetError(ConstA, error);
      }
      if (ConstA.Text != "" && double.TryParse(ConstA.Text, out uselessResult))
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
      if (LeftBorder.Text == "" || !double.TryParse(LeftBorder.Text, out uselessResult))
        WrongData.SetError(LeftBorder, error);
      else
      {
        leftBorder = LeftBorder.Text;
      }
      if (RightBorder.Text == "" || !double.TryParse(RightBorder.Text, out uselessResult))
        WrongData.SetError(RightBorder, error);
      else
      {
        rightBorder = RightBorder.Text;
      }
      if (Step.Text == "" || !double.TryParse(Step.Text, out uselessResult))
        WrongData.SetError(Step, error);
      else
      {
        step = Step.Text;
      }
      if (ConstA.Text != "" && ConstA.Text != "0" && WrongData.GetError(LeftBorder) == "" && WrongData.GetError(RightBorder) == "")
      {
        if (double.Parse(constA) > 0)
          if (double.Parse(rightBorder) > double.Parse(constA))
            WrongData.SetError(RightBorder, error);
        if (double.Parse(constA) < 0)
          if (double.Parse(leftBorder) < double.Parse(constA))
            WrongData.SetError(LeftBorder, error);
      }
      if (RightBorder.Text != "" && double.TryParse(RightBorder.Text, out uselessResult))
      {
        if (LeftBorder.Text != "" && double.TryParse(LeftBorder.Text, out uselessResult))
        {
          if (double.Parse(LeftBorder.Text) > double.Parse(RightBorder.Text))
          {
            WrongData.SetError(LeftBorder, borderError);
            WrongData.SetError(RightBorder, borderError);
          }
        }
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
      if (ConstA.Text != "" & double.TryParse(ConstA.Text, out double constA) &
        LeftBorder.Text != "" & double.TryParse(LeftBorder.Text, out double leftBorder) &
        RightBorder.Text != "" & double.TryParse(RightBorder.Text, out double rightBorder) &
        Step.Text != "" & double.TryParse(Step.Text, out double step) & (int)constA != 0)
        return _concentrationService.GetPoints(double.Parse(ConstA.Text), double.Parse(LeftBorder.Text), double.Parse(RightBorder.Text), double.Parse(Step.Text));
      return null;
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
      var result = GetCalculations();
      if (result != null) {
        Table table = new Table(result);
        table.Show();
      }
    }
    private void SaveInitialData_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = "c:\\";
      saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      if (ConstA.Text != "" & double.TryParse(ConstA.Text, out double constA) &
   LeftBorder.Text != "" & double.TryParse(LeftBorder.Text, out double leftBorder) &
   RightBorder.Text != "" & double.TryParse(RightBorder.Text, out double rightBorder) &
   Step.Text != "" & double.TryParse(Step.Text, out double step) & (int)constA != 0)
      {
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
        var filePath = saveFileDialog.FileName;
        StreamWriter file = new StreamWriter(filePath, false);

          if((int)constA == 0)
          {
            WrongData.SetError(ConstA, errorOfConst);
          }
          else
          {
            file.WriteLine(constA);
            file.WriteLine(leftBorder);
            file.WriteLine(rightBorder);
            file.WriteLine(step);
          }
          file.Close();
        }
      }
    }
    private void GetInitial_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog openFileDialog = new OpenFileDialog())
      {
        openFileDialog.InitialDirectory = "d:\\4 семестр\\РПС\\FunctionGraph";
        openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog.FilterIndex = 2;
        openFileDialog.RestoreDirectory = true;
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
          var filePath = openFileDialog.FileName;
          var fileStream = openFileDialog.OpenFile();
          using (StreamReader reader = new StreamReader(fileStream))
          {
            ConstA.Text = reader.ReadLine();
            LeftBorder.Text = reader.ReadLine();
            RightBorder.Text = reader.ReadLine();
            Step.Text = reader.ReadLine();
          }
        }
      }
    }
    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CreateFormGreeting();
    }

    private void SaveExcel_Click(object sender, EventArgs e)
    {
      WriteRoExcelTable();
    }
    private void WriteRoExcelTable()
    {
      if (ConstA.Text != "" & double.TryParse(ConstA.Text, out double constA) &
   LeftBorder.Text != "" & double.TryParse(LeftBorder.Text, out double leftBorder) &
   RightBorder.Text != "" & double.TryParse(RightBorder.Text, out double rightBorder) &
   Step.Text != "" & double.TryParse(Step.Text, out double step) & (int)constA != 0)
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.InitialDirectory = "d:\\4 семестр\\РПС\\FunctionGraph";
        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.xlsx)|*.xlsx";
        saveFileDialog.FilterIndex = 2;
        saveFileDialog.RestoreDirectory = true;
        var filePath = "";
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
          filePath = saveFileDialog.FileName;
        }
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("GraphPoint");
        sheet.Cells[1,1].Value = "a - "; sheet.Cells[1, 2].Value = constA;
        sheet.Cells[2, 1].Value = "Left border - "; sheet.Cells[2, 2].Value = leftBorder;
        sheet.Column(1).Width = 14;
        sheet.Column(2).Width = 14;
        sheet.Cells[3, 1].Value = "Right border - "; sheet.Cells[3, 2].Value = rightBorder;
        sheet.Cells[4, 1].Value = "Step - "; sheet.Cells[4, 2].Value = step;
        sheet.Cells[5, 1, 5, 2].LoadFromArrays(new object[][] { new[] { "X", "Y" } });
        sheet.Cells[5, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        sheet.Cells[5, 2].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
        var points = GetCalculations();
        for (int i = 0; i < points.Count; i++)
        {
          sheet.Cells[i + 6, 1].Value = points[i].x;
          sheet.Cells[i + 6, 2].Value = points[i].y;
        }
        File.WriteAllBytes(filePath, package.GetAsByteArray());
      }
    }
  }
}
