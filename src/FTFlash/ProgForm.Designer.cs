namespace FTFlash;

partial class ProgForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnRead = new Button();
        btnWrite = new Button();
        numericUpDown1 = new NumericUpDown();
        label1 = new Label();
        lblBytes = new Label();
        progressBar1 = new ProgressBar();
        lblProgress = new Label();
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
        SuspendLayout();
        // 
        // btnRead
        // 
        btnRead.Location = new Point(21, 67);
        btnRead.Name = "btnRead";
        btnRead.Size = new Size(137, 42);
        btnRead.TabIndex = 0;
        btnRead.Text = "Read All Memory";
        btnRead.UseVisualStyleBackColor = true;
        btnRead.Click += btnRead_Click;
        // 
        // btnWrite
        // 
        btnWrite.Location = new Point(164, 67);
        btnWrite.Name = "btnWrite";
        btnWrite.Size = new Size(137, 42);
        btnWrite.TabIndex = 1;
        btnWrite.Text = "Write All Memory";
        btnWrite.UseVisualStyleBackColor = true;
        btnWrite.Click += btnWrite_Click;
        // 
        // numericUpDown1
        // 
        numericUpDown1.Location = new Point(88, 30);
        numericUpDown1.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        numericUpDown1.Name = "numericUpDown1";
        numericUpDown1.Size = new Size(55, 23);
        numericUpDown1.TabIndex = 2;
        numericUpDown1.Value = new decimal(new int[] { 32, 0, 0, 0 });
        numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(23, 32);
        label1.Name = "label1";
        label1.Size = new Size(59, 15);
        label1.TabIndex = 3;
        label1.Text = "Size (Mb):";
        // 
        // lblBytes
        // 
        lblBytes.AutoSize = true;
        lblBytes.Location = new Point(149, 32);
        lblBytes.Name = "lblBytes";
        lblBytes.Size = new Size(56, 15);
        lblBytes.TabIndex = 4;
        lblBytes.Text = "123 bytes";
        // 
        // progressBar1
        // 
        progressBar1.Location = new Point(21, 140);
        progressBar1.Maximum = 1000;
        progressBar1.Name = "progressBar1";
        progressBar1.Size = new Size(280, 23);
        progressBar1.TabIndex = 5;
        // 
        // lblProgress
        // 
        lblProgress.AutoSize = true;
        lblProgress.Location = new Point(21, 122);
        lblProgress.Name = "lblProgress";
        lblProgress.Size = new Size(52, 15);
        lblProgress.TabIndex = 6;
        lblProgress.Text = "Progress";
        // 
        // ProgForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(341, 190);
        Controls.Add(lblProgress);
        Controls.Add(progressBar1);
        Controls.Add(lblBytes);
        Controls.Add(label1);
        Controls.Add(numericUpDown1);
        Controls.Add(btnWrite);
        Controls.Add(btnRead);
        Name = "ProgForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ProgForm";
        ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnRead;
    private Button btnWrite;
    private NumericUpDown numericUpDown1;
    private Label label1;
    private Label lblBytes;
    private ProgressBar progressBar1;
    private Label lblProgress;
}