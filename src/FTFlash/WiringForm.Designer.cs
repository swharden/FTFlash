namespace FTFlash;

partial class WiringForm
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
        richTextBox1 = new RichTextBox();
        button1 = new Button();
        label1 = new Label();
        label2 = new Label();
        label3 = new Label();
        button2 = new Button();
        SuspendLayout();
        // 
        // richTextBox1
        // 
        richTextBox1.BackColor = SystemColors.Control;
        richTextBox1.BorderStyle = BorderStyle.None;
        richTextBox1.Enabled = false;
        richTextBox1.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
        richTextBox1.Location = new Point(51, 48);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(182, 132);
        richTextBox1.TabIndex = 0;
        richTextBox1.Text = "FT232H  FLASH\n  D0-----CLK\n  D1-----MOSI\n  D2-----MISO\n  D3-----CS";
        // 
        // button1
        // 
        button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        button1.Location = new Point(12, 252);
        button1.Name = "button1";
        button1.Size = new Size(175, 40);
        button1.TabIndex = 1;
        button1.Text = "Launch Tutorial Website";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 16);
        label1.Name = "label1";
        label1.Size = new Size(263, 15);
        label1.TabIndex = 2;
        label1.Text = "Connect your FT232H to a SPI flash chip like this:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 193);
        label2.Name = "label2";
        label2.Size = new Size(194, 15);
        label2.TabIndex = 3;
        label2.Text = "Both chips must share a ground rail";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(12, 219);
        label3.Name = "label3";
        label3.Size = new Size(281, 15);
        label3.TabIndex = 4;
        label3.Text = "Be mindful that some flash chips require 3.3V power";
        // 
        // button2
        // 
        button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        button2.Location = new Point(193, 252);
        button2.Name = "button2";
        button2.Size = new Size(126, 40);
        button2.TabIndex = 5;
        button2.Text = "Close";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // WiringForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(331, 307);
        Controls.Add(button2);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(button1);
        Controls.Add(richTextBox1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Name = "WiringForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FTFlash Wiring Diagram";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private RichTextBox richTextBox1;
    private Button button1;
    private Label label1;
    private Label label2;
    private Label label3;
    private Button button2;
}