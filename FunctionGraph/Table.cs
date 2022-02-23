using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FunctionGraph
{
  public partial class Table : Form
  {
    PictureBox table;
    public Table()
    {
      InitializeComponent();
      CreateEntity();
    }
    private void CreateEntity()
    {
      this.Size = new Size(500, 300);
      this.MinimumSize = this.Size;
      this.MaximumSize = this.Size;
      this.TopMost = true;
      table = new PictureBox();
      table.Location = new Point(0, 0);
      table.Size = new Size(this.Width, (this.Height * 2) / 3);
      this.Controls.Add(table);
      Button back = new Button();
      back.Size = new Size(60, 20);
      back.Location = new Point((this.Width / 2) - back.Size.Width-20, table.Height + 20);
      this.Controls.Add(back);
      Button save = new Button();
      save.Size = new Size(back.Size.Width, back.Size.Height);
      save.Location = new Point((this.Width / 2) + back.Size.Width +20, back.Location.Y);
      this.Controls.Add(save);
    }

    private void LoadDataInTAble()
    {
      Graphics graphics = table.CreateGraphics();
      Pen pen = new Pen(Color.Black, 2);
      SolidBrush drawBrush = new SolidBrush(Color.Black);
      Font drawFont = new Font("Arial", 16);
      MainForm data = (MainForm)this.Owner;
      var points = data.GetCalculations();
      int iterator = 0;
      foreach(var point in points)
      {
        graphics.DrawLine(pen, 0, table.Height / 2, table.Width, table.Height / 2);
        graphics.DrawLine(pen, table.Width / 2, 0, table.Width / 2, table.Height);
        graphics.DrawString("x", drawFont, drawBrush, table.Width - (20), table.Height / 2 + (0));
        graphics.DrawString("y", drawFont, drawBrush, table.Width / 2 - 40 / 2, 0);
        iterator++;
      }
    }
  }
}
