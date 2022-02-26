
namespace FunctionGraph
{
  partial class MainForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.Calculate = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.ConstA = new System.Windows.Forms.TextBox();
      this.LeftBorder = new System.Windows.Forms.TextBox();
      this.RightBorder = new System.Windows.Forms.TextBox();
      this.Step = new System.Windows.Forms.TextBox();
      this.WrongData = new System.Windows.Forms.ErrorProvider(this.components);
      this.Ecuation = new System.Windows.Forms.PictureBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.a = new System.Windows.Forms.Label();
      this.LBorder = new System.Windows.Forms.Label();
      this.RBorder = new System.Windows.Forms.Label();
      this.StepOfX = new System.Windows.Forms.Label();
      this.Table = new System.Windows.Forms.Button();
      this.SaveInitialData = new System.Windows.Forms.Button();
      this.GetInitial = new System.Windows.Forms.Button();
      this.SaveExcel = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.WrongData)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.Ecuation)).BeginInit();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // Calculate
      // 
      this.Calculate.Location = new System.Drawing.Point(568, 121);
      this.Calculate.Name = "Calculate";
      this.Calculate.Size = new System.Drawing.Size(126, 40);
      this.Calculate.TabIndex = 0;
      this.Calculate.Text = "Calculate";
      this.Calculate.UseVisualStyleBackColor = true;
      this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(12, 27);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(550, 411);
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // ConstA
      // 
      this.ConstA.Location = new System.Drawing.Point(569, 168);
      this.ConstA.Name = "ConstA";
      this.ConstA.PlaceholderText = "a";
      this.ConstA.Size = new System.Drawing.Size(50, 27);
      this.ConstA.TabIndex = 2;
      // 
      // LeftBorder
      // 
      this.LeftBorder.Location = new System.Drawing.Point(569, 201);
      this.LeftBorder.Name = "LeftBorder";
      this.LeftBorder.PlaceholderText = "Left";
      this.LeftBorder.Size = new System.Drawing.Size(51, 27);
      this.LeftBorder.TabIndex = 3;
      // 
      // RightBorder
      // 
      this.RightBorder.Location = new System.Drawing.Point(569, 235);
      this.RightBorder.Name = "RightBorder";
      this.RightBorder.PlaceholderText = "Right";
      this.RightBorder.Size = new System.Drawing.Size(50, 27);
      this.RightBorder.TabIndex = 4;
      // 
      // Step
      // 
      this.Step.Location = new System.Drawing.Point(569, 268);
      this.Step.Name = "Step";
      this.Step.PlaceholderText = "Step";
      this.Step.Size = new System.Drawing.Size(50, 27);
      this.Step.TabIndex = 5;
      // 
      // WrongData
      // 
      this.WrongData.ContainerControl = this;
      // 
      // Ecuation
      // 
      this.Ecuation.Image = ((System.Drawing.Image)(resources.GetObject("Ecuation.Image")));
      this.Ecuation.InitialImage = null;
      this.Ecuation.Location = new System.Drawing.Point(568, 27);
      this.Ecuation.Name = "Ecuation";
      this.Ecuation.Size = new System.Drawing.Size(207, 70);
      this.Ecuation.TabIndex = 6;
      this.Ecuation.TabStop = false;
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(800, 28);
      this.menuStrip1.TabIndex = 7;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
      this.aboutToolStripMenuItem.Text = "Information";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // a
      // 
      this.a.AutoSize = true;
      this.a.Location = new System.Drawing.Point(626, 171);
      this.a.Name = "a";
      this.a.Size = new System.Drawing.Size(102, 20);
      this.a.TabIndex = 8;
      this.a.Text = "\'a\' in equation";
      // 
      // LBorder
      // 
      this.LBorder.AutoSize = true;
      this.LBorder.Location = new System.Drawing.Point(626, 204);
      this.LBorder.Name = "LBorder";
      this.LBorder.Size = new System.Drawing.Size(164, 20);
      this.LBorder.TabIndex = 9;
      this.LBorder.Text = "Left border of equation";
      // 
      // RBorder
      // 
      this.RBorder.AutoSize = true;
      this.RBorder.Location = new System.Drawing.Point(626, 238);
      this.RBorder.Name = "RBorder";
      this.RBorder.Size = new System.Drawing.Size(174, 20);
      this.RBorder.TabIndex = 10;
      this.RBorder.Text = "Right border of equation";
      // 
      // StepOfX
      // 
      this.StepOfX.AutoSize = true;
      this.StepOfX.Location = new System.Drawing.Point(626, 269);
      this.StepOfX.Name = "StepOfX";
      this.StepOfX.Size = new System.Drawing.Size(153, 20);
      this.StepOfX.TabIndex = 11;
      this.StepOfX.Text = "Step of \'x\' in equation";
      // 
      // Table
      // 
      this.Table.Location = new System.Drawing.Point(568, 321);
      this.Table.Name = "Table";
      this.Table.Size = new System.Drawing.Size(94, 29);
      this.Table.TabIndex = 12;
      this.Table.Text = "Table";
      this.Table.UseVisualStyleBackColor = true;
      this.Table.Click += new System.EventHandler(this.Table_Click);
      // 
      // SaveInitialData
      // 
      this.SaveInitialData.Location = new System.Drawing.Point(568, 357);
      this.SaveInitialData.Name = "SaveInitialData";
      this.SaveInitialData.Size = new System.Drawing.Size(94, 29);
      this.SaveInitialData.TabIndex = 13;
      this.SaveInitialData.Text = "Save initial";
      this.SaveInitialData.UseVisualStyleBackColor = true;
      this.SaveInitialData.Click += new System.EventHandler(this.SaveInitialData_Click);
      // 
      // GetInitial
      // 
      this.GetInitial.Location = new System.Drawing.Point(568, 393);
      this.GetInitial.Name = "GetInitial";
      this.GetInitial.Size = new System.Drawing.Size(94, 29);
      this.GetInitial.TabIndex = 14;
      this.GetInitial.Text = "Get initial";
      this.GetInitial.UseVisualStyleBackColor = true;
      this.GetInitial.Click += new System.EventHandler(this.GetInitial_Click);
      // 
      // SaveExcel
      // 
      this.SaveExcel.Location = new System.Drawing.Point(669, 357);
      this.SaveExcel.Name = "SaveExcel";
      this.SaveExcel.Size = new System.Drawing.Size(94, 29);
      this.SaveExcel.TabIndex = 15;
      this.SaveExcel.Text = "Save Excel";
      this.SaveExcel.UseVisualStyleBackColor = true;
      this.SaveExcel.Click += new System.EventHandler(this.SaveExcel_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.SaveExcel);
      this.Controls.Add(this.GetInitial);
      this.Controls.Add(this.SaveInitialData);
      this.Controls.Add(this.Table);
      this.Controls.Add(this.StepOfX);
      this.Controls.Add(this.RBorder);
      this.Controls.Add(this.LBorder);
      this.Controls.Add(this.a);
      this.Controls.Add(this.Ecuation);
      this.Controls.Add(this.Step);
      this.Controls.Add(this.RightBorder);
      this.Controls.Add(this.LeftBorder);
      this.Controls.Add(this.ConstA);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.Calculate);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.MaximumSize = new System.Drawing.Size(818, 497);
      this.MinimumSize = new System.Drawing.Size(818, 497);
      this.Name = "MainForm";
      this.Text = "ChirgauzSquare";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.WrongData)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.Ecuation)).EndInit();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button Calculate;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.TextBox ConstA;
    private System.Windows.Forms.TextBox LeftBorder;
    private System.Windows.Forms.TextBox RightBorder;
    private System.Windows.Forms.TextBox Step;
    private System.Windows.Forms.ErrorProvider WrongData;
    private System.Windows.Forms.PictureBox Ecuation;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.Label StepOfX;
    private System.Windows.Forms.Label RBorder;
    private System.Windows.Forms.Label LBorder;
    private System.Windows.Forms.Label a;
    private System.Windows.Forms.Button Table;
    private System.Windows.Forms.Button SaveInitialData;
    private System.Windows.Forms.Button GetInitial;
    private System.Windows.Forms.Button SaveExcel;
  }
}

