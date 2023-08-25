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
        lblIDs = new Label();
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
        // lblIDs
        // 
        lblIDs.AutoSize = true;
        lblIDs.Location = new Point(191, 71);
        lblIDs.Name = "lblIDs";
        lblIDs.Size = new Size(41, 15);
        lblIDs.TabIndex = 3;
        lblIDs.Text = "empty";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(lblIDs);
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
    private Label lblIDs;
}
