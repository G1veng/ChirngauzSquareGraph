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
  public partial class Greeting : Form
  {
    public Greeting()
    {
      InitializeComponent();
      GreetingInner();
    }
    CheckBox dontShowAgain;
    public void GreetingInner()
    {
      this.Size = new Size(500, 350);
      this.MinimumSize = this.Size;
      this.MaximumSize = this.Size;
      this.TopMost = true;
      TextBox welcome = new TextBox();
      welcome.ReadOnly = true;
      welcome.Text = "Created by: Shishko Daniil Yrevich";
      welcome.Size = new Size(this.Width / 2, 20);
      welcome.Location = new Point(this.Width / 5, 0);
      this.Controls.Add(welcome);
      TextBox information = new TextBox();
      information.ReadOnly = true;
      information.Text = "Option: 9" + Environment.NewLine + "Aim: Create Win Forms application to " +
        "plotting a function graph and outputting a table of function values. User sets " +
        "rigth and left borders, step, coefficients (if presents). If unable to " +
        "plot a finction graph in seted gap user get warning " +
        "about this to change borders. If function graph in cause of" +
        "coefficients becomes a dot or can't be ploted user also sees warning.";
      information.Multiline = true;
      information.Size = new Size(this.Width / 2 + 150, this.Height / 2);
      information.Location = new Point(40, welcome.Height + 10);
      this.Controls.Add(information);
      dontShowAgain = new CheckBox();
      dontShowAgain.Enabled = true;
      dontShowAgain.Size = new Size(20, welcome.Height);
      dontShowAgain.Location = new Point(welcome.Location.X - dontShowAgain.Size.Width, information.Height + 20 + welcome.Height);
      dontShowAgain.Appearance = Appearance.Normal;
      this.Controls.Add(dontShowAgain);
      TextBox dontShowAgreement = new TextBox();
      dontShowAgreement.ReadOnly = true;
      dontShowAgreement.TextAlign = HorizontalAlignment.Left;
      dontShowAgreement.Text = "Check if you don't want see this again";
      dontShowAgreement.Size = new Size(welcome.Width + 20, 0);
      dontShowAgreement.Location = new Point(dontShowAgain.Location.X + 20, dontShowAgain.Location.Y);
      this.Controls.Add(dontShowAgreement);
      Button close = new Button();
      close.Text = "OK";
      close.Location = new Point(dontShowAgain.Location.X + dontShowAgreement.Size.Width + dontShowAgain.Size.Width + 20, dontShowAgain.Location.Y);
      close.Size = new Size(40, 30);
      this.Controls.Add(close);
      close.Click += close_Click;
    }
    public void close_Click(object sender, EventArgs e)
    {
      if (dontShowAgain.Checked)
      {
        StreamWriter file = new StreamWriter("Agreement.txt", false);
        file.WriteLine(1);
        file.Close();
      }
      if (!dontShowAgain.Checked)
      {
        StreamWriter file = new StreamWriter("Agreement.txt", false);
        file.WriteLine(0);
        file.Close();
      }
      this.Close();
    }
  }
}
