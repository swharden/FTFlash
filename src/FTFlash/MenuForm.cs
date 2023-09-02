namespace FTFlash;

public partial class MenuForm : Form
{
    public MenuForm()
    {
        InitializeComponent();
        Text = ProgramVersion.FullNameAndVersion;
        this.Select();
    }

    private void button1_Click(object sender, EventArgs e) => HideAndShowDialog(new TestForm());

    private void button2_Click(object sender, EventArgs e) => HideAndShowDialog(new ProgForm());

    private void button3_Click(object sender, EventArgs e) => HideAndShowDialog(new WiringForm());

    private void HideAndShowDialog(Form frm)
    {
        Hide();
        frm.ShowDialog();
        Show();
    }
}
