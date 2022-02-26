using Services.ChirngauzSquare.Point;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FunctionGraph
{
  public partial class Table : Form
  {
    List<ChirgauzSquareModel> points;
    PictureBox tableWithData;
    int counter;
    Pen pen = new Pen(Color.Black, 2);
    SolidBrush drawBrush = new SolidBrush(Color.Black);
    Font drawFont = new Font("Arial", 16);
    public Table(List<ChirgauzSquareModel> outPoints)
    {
      InitializeComponent();
      points = outPoints;
      CreateEntity();
    }
    private void CreateEntity()
    {
      this.Size = new Size(500, 300);
      this.MinimumSize = this.Size;
      this.MaximumSize = this.Size;
      this.TopMost = true;
      tableWithData = new PictureBox();
      tableWithData.Location = new Point(0, 0);
      tableWithData.Size = new Size(this.Width, this.Height * 2 / 3);
      tableWithData.BackColor = Color.White;
      this.Controls.Add(tableWithData);
      Paint += new PaintEventHandler(LoadDataInTAble);
      MouseWheel += new MouseEventHandler(TableWithData_MouseWheel);
      Button back = new Button();
      back.Size = new Size(80, 30);
      back.Location = new Point(40, tableWithData.Height + 10);
      back.Text = "Return";
      this.Controls.Add(back);
      back.Click += Back_Click;
      Button save = new Button();
      save.Size = new Size(back.Size.Width, back.Size.Height);
      save.Location = new Point((this.Width / 2) + back.Size.Width + 20, back.Location.Y);
      save.Text = "Save";
      this.Controls.Add(save);
      save.Click += Save_Click;
      counter = 4;
    }
    private void LoadDataInTAble(object sender, PaintEventArgs e)
    {
      Graphics graphics = tableWithData.CreateGraphics();
      graphics.Clear(Color.White);
      graphics.DrawLine(pen, 120, 0, 120, tableWithData.Height);
      graphics.DrawLine(pen, (tableWithData.Width / 2) - 10, 0, (tableWithData.Width / 2) - 10, tableWithData.Height);
      for (int i = 0; i < 5 && counter < points.Count; i++)
      {
        graphics.DrawLine(pen, 0, (tableWithData.Height / 5) * i, tableWithData.Width, (tableWithData.Height / 5) * i);
        graphics.DrawString((i + 1).ToString(), drawFont, drawBrush, tableWithData.Height / 20, (tableWithData.Height / 20) + (i * 40));
        graphics.DrawString(points[i].x.ToString(), drawFont, drawBrush, (tableWithData.Width / 2) - (tableWithData.Width / 4),
          (tableWithData.Height / 20) + (i * 40));
        graphics.DrawString(points[i].y.ToString(), drawFont, drawBrush, (tableWithData.Width) - (tableWithData.Width / 2),
          (tableWithData.Height / 20) + (i * 40));
      }
    }
    private void TableWithData_MouseWheel(object sender, MouseEventArgs e)
    {
      if (e.Delta > 0 && counter - 6 >= 0)
      {
        counter--;
        PaintData(counter - 5);
      }
      if (e.Delta < 0 && counter + 1 < points.Count)
      {
        counter++;
        PaintData(counter - 5);
      }
    }
    private void PaintData(int innerCounter)
    {
      Graphics graphics = tableWithData.CreateGraphics();
      graphics.Clear(Color.White);
      graphics.DrawLine(pen, 120, 0, 120, tableWithData.Height);
      graphics.DrawLine(pen, (tableWithData.Width / 2) - 10, 0, (tableWithData.Width / 2) - 10, tableWithData.Height);
      for (int i = 0; i < 5; i++)
      {
        graphics.DrawLine(pen, 0, (tableWithData.Height / 5) * i, tableWithData.Width, (tableWithData.Height / 5) * i);
        graphics.DrawString((innerCounter + 1).ToString(), drawFont, drawBrush, tableWithData.Height / 20, (tableWithData.Height / 20) + (i * 40));
        graphics.DrawString(points[innerCounter].x.ToString(), drawFont, drawBrush, (tableWithData.Width / 2) - (tableWithData.Width / 4),
          (tableWithData.Height / 20) + (i * 40));
        graphics.DrawString(points[innerCounter].y.ToString(), drawFont, drawBrush, (tableWithData.Width) - (tableWithData.Width / 2),
          (tableWithData.Height / 20) + (i * 40));
        innerCounter++;
      }
    }
    private void Back_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    private void Save_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.InitialDirectory = "c:\\";
      saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      if (saveFileDialog.ShowDialog() == DialogResult.OK)
      {
        var filePath = saveFileDialog.FileName;
        StreamWriter file = new StreamWriter(filePath, false);
        foreach (var point in points)
        {
          file.WriteLine(point.x.ToString() + " " + point.y.ToString());
        }
        file.Close();
      }
    }
  }
}
