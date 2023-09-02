namespace FTFlash;

public partial class MenuForm : Form
{
    public MenuForm()
    {
        InitializeComponent();
        Text = ProgramVersion.FullNameAndVersion;
        button3.Select();
    }

    private void button1_Click(object sender, EventArgs e) => new TestForm().ShowDialog();

    private void button2_Click(object sender, EventArgs e) => new ProgForm().ShowDialog();

    private void button3_Click(object sender, EventArgs e) => new WiringForm().ShowDialog();
}
