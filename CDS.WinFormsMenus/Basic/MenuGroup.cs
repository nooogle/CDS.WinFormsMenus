namespace CDS.WinFormsMenus.Basic;

/// <summary>
/// Represents a group of demos in the DemosTreeView.
/// </summary>
public class MenuGroup
{
    private TreeNode treeNode;

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuGroup"/> class.
    /// </summary>
    /// <param name="treeNode">The tree node representing this group.</param>
    public MenuGroup(TreeNode treeNode) => this.treeNode = treeNode;

    /// <summary>
    /// Adds a new group to this group.
    /// </summary>
    /// <param name="name">The name of the new group.</param>
    /// <returns>A <see cref="MenuGroup"/> representing the added group.</returns>
    public MenuGroup AddGroup(string name) => AddGroup(name: name, tooltip: string.Empty);

    /// <summary>
    /// Adds a new group to this group.
    /// </summary>
    /// <param name="name">The name of the new group.</param>
    /// <returns>A <see cref="MenuGroup"/> representing the added group.</returns>
    public MenuGroup AddGroup(string name, string tooltip)
    {
        var groupTreeNode = treeNode.Nodes.Add(name);
        groupTreeNode.ToolTipText = tooltip;
        return new MenuGroup(groupTreeNode);
    }

    /// <summary>
    /// Adds a new demo to this group.
    /// </summary>
    /// <param name="name">The name of the demo.</param>
    /// <param name="tooltip">The tooltip text for the demo.</param>
    /// <param name="parent">The parent form for the demo.</param>
    /// <param name="createForm">A function to create the form for the demo.</param>
    public void AddDemo(string name, string tooltip, Form parent, Func<Form> createForm) =>
        _ = new MenuItem(name, tooltip, treeNode, () => RunModalForm(parent, createForm()));

    /// <summary>
    /// Adds a new demo to this group.
    /// </summary>
    /// <param name="name">The name of the demo.</param>
    /// <param name="tooltip">The tooltip text for the demo.</param>
    /// <param name="parent">The parent form for the demo.</param>
    /// <param name="action">An action to execute for the demo.</param>
    public void AddDemo(string name, string tooltip, Form parent, Action action) =>
        _ = new MenuItem(name, tooltip, treeNode, action);

    /// <summary>
    /// Runs the specified form as a modal dialog.
    /// </summary>
    /// <param name="parent">The parent form.</param>
    /// <param name="form">The form to run.</param>
    private void RunModalForm(Form parent, Form form)
    {
        try
        {
            form.ShowDialog(parent);
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            throw new InvalidOperationException("An error occurred while showing the modal form.", ex);
        }
        finally
        {
            form.Dispose();
        }
    }
}
