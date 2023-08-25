namespace FTFlash;

partial class Form1
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
        btnConnect = new Button();
        btnReadIDs = new Button();
        lblConnection = new Label();
        lblID1 = new Label();
        lblID2 = new Label();
        lblID3 = new Label();
        btnWritePage = new Button();
        lblWrite = new Label();
        btnReadPage = new Button();
        nudWritePage = new NumericUpDown();
        nudReadPage = new NumericUpDown();
        richTextBox1 = new RichTextBox();
        btnErase = new Button();
        ((System.ComponentModel.ISupportInitialize)nudWritePage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudReadPage).BeginInit();
        SuspendLayout();
        // 
        // btnConnect
        // 
        btnConnect.Location = new Point(12, 12);
        btnConnect.Name = "btnConnect";
        btnConnect.Size = new Size(173, 40);
        btnConnect.TabIndex = 0;
        btnConnect.Text = "Connect to FTDI 232H";
        btnConnect.UseVisualStyleBackColor = true;
        btnConnect.Click += btnConnect_Click;
        // 
        // btnReadIDs
        // 
        btnReadIDs.Location = new Point(12, 58);
        btnReadIDs.Name = "btnReadIDs";
        btnReadIDs.Size = new Size(173, 41);
        btnReadIDs.TabIndex = 1;
        btnReadIDs.Text = "Read IDs";
        btnReadIDs.UseVisualStyleBackColor = true;
        btnReadIDs.Click += btnReadIDs_Click;
        // 
        // lblConnection
        // 
        lblConnection.AutoSize = true;
        lblConnection.Location = new Point(191, 25);
        lblConnection.Name = "lblConnection";
        lblConnection.Size = new Size(84, 15);
        lblConnection.TabIndex = 2;
        lblConnection.Text = "not connected";
        // 
        // lblID1
        // 
        lblID1.AutoSize = true;
        lblID1.Location = new Point(191, 54);
        lblID1.Name = "lblID1";
        lblID1.Size = new Size(41, 15);
        lblID1.TabIndex = 3;
        lblID1.Text = "empty";
        // 
        // lblID2
        // 
        lblID2.AutoSize = true;
        lblID2.Location = new Point(191, 69);
        lblID2.Name = "lblID2";
        lblID2.Size = new Size(41, 15);
        lblID2.TabIndex = 4;
        lblID2.Text = "empty";
        // 
        // lblID3
        // 
        lblID3.AutoSize = true;
        lblID3.Location = new Point(191, 84);
        lblID3.Name = "lblID3";
        lblID3.Size = new Size(41, 15);
        lblID3.TabIndex = 5;
        lblID3.Text = "empty";
        // 
        // btnWritePage
        // 
        btnWritePage.Location = new Point(12, 105);
        btnWritePage.Name = "btnWritePage";
        btnWritePage.Size = new Size(173, 41);
        btnWritePage.TabIndex = 6;
        btnWritePage.Text = "Write Page";
        btnWritePage.UseVisualStyleBackColor = true;
        btnWritePage.Click += btnWritePage_Click;
        // 
        // lblWrite
        // 
        lblWrite.AutoSize = true;
        lblWrite.Location = new Point(253, 118);
        lblWrite.Name = "lblWrite";
        lblWrite.Size = new Size(41, 15);
        lblWrite.TabIndex = 7;
        lblWrite.Text = "empty";
        // 
        // btnReadPage
        // 
        btnReadPage.Location = new Point(12, 152);
        btnReadPage.Name = "btnReadPage";
        btnReadPage.Size = new Size(173, 41);
        btnReadPage.TabIndex = 8;
        btnReadPage.Text = "Read Page";
        btnReadPage.UseVisualStyleBackColor = true;
        btnReadPage.Click += btnReadPage_Click;
        // 
        // nudWritePage
        // 
        nudWritePage.Location = new Point(191, 116);
        nudWritePage.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        nudWritePage.Name = "nudWritePage";
        nudWritePage.Size = new Size(56, 23);
        nudWritePage.TabIndex = 9;
        // 
        // nudReadPage
        // 
        nudReadPage.Location = new Point(191, 163);
        nudReadPage.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
        nudReadPage.Name = "nudReadPage";
        nudReadPage.Size = new Size(56, 23);
        nudReadPage.TabIndex = 10;
        // 
        // richTextBox1
        // 
        richTextBox1.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
        richTextBox1.Location = new Point(253, 162);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(519, 276);
        richTextBox1.TabIndex = 11;
        richTextBox1.Text = "empty";
        // 
        // btnErase
        // 
        btnErase.Location = new Point(12, 199);
        btnErase.Name = "btnErase";
        btnErase.Size = new Size(173, 41);
        btnErase.TabIndex = 12;
        btnErase.Text = "Erase Chip";
        btnErase.UseVisualStyleBackColor = true;
        btnErase.Click += btnErase_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btnErase);
        Controls.Add(richTextBox1);
        Controls.Add(nudReadPage);
        Controls.Add(nudWritePage);
        Controls.Add(btnReadPage);
        Controls.Add(lblWrite);
        Controls.Add(btnWritePage);
        Controls.Add(lblID3);
        Controls.Add(lblID2);
        Controls.Add(lblID1);
        Controls.Add(lblConnection);
        Controls.Add(btnReadIDs);
        Controls.Add(btnConnect);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FTFlash";
        ((System.ComponentModel.ISupportInitialize)nudWritePage).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudReadPage).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnConnect;
    private Button btnReadIDs;
    private Label lblConnection;
    private Label lblID1;
    private Label lblID2;
    private Label lblID3;
    private Button btnWritePage;
    private Label lblWrite;
    private Button btnReadPage;
    private NumericUpDown nudWritePage;
    private NumericUpDown nudReadPage;
    private RichTextBox richTextBox1;
    private Button btnErase;
}
