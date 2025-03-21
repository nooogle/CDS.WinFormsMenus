namespace WinFormsDemo;

/// <summary>
/// Demonstrates the Basic tree view menu.
/// </summary>
public partial class FormBasicTest : Form
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FormBasicTest"/> class.
    /// </summary>
    public FormBasicTest()
    {
        InitializeComponent();
        InitializeMenuTree();
    }

    /// <summary>
    /// Initializes the menu tree with groups and demo items.
    /// </summary>
    private void InitializeMenuTree()
    {
        var formsGroup = menuTree.AddGroup("Forms", tooltip: "A group of items for showing colourful forms!");
        formsGroup.AddDemo("Red form", "Opens a red form", this, () => new RedForm());
        formsGroup.AddDemo("Blue form", "Opens a blue form", this, () => new BlueForm());

        var actionsGroup = menuTree.AddGroup("Actions");
        actionsGroup.AddDemo("Message box", "Shows a message box", this, ShowMessageBox);

        menuTree.ExpandAllGroups();
    }

    /// <summary>
    /// Displays a simple message box as a demo action.
    /// </summary>
    private void ShowMessageBox() =>
        MessageBox.Show("This is a message box", "Message");
}
