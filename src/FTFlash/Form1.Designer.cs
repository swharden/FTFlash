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
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(lblID3);
        Controls.Add(lblID2);
        Controls.Add(lblID1);
        Controls.Add(lblConnection);
        Controls.Add(btnReadIDs);
        Controls.Add(btnConnect);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FTFlash";
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
}
