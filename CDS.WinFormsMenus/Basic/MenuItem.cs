namespace CDS.WinFormsMenus.Basic;

/// <summary>
/// Represents a demo item in the DemosTreeView.
/// </summary>
public class MenuItem
{
    private TreeNode treeNode;

    /// <summary>
    /// Initializes a new instance of the <see cref="MenuItem"/> class.
    /// </summary>
    /// <param name="name">The name of the demo.</param>
    /// <param name="tooltip">The tooltip text for the demo.</param>
    /// <param name="parentTreeNode">The parent tree node to which this demo belongs.</param>
    /// <param name="action">The action to execute when the demo is run.</param>
    public MenuItem(string name, string tooltip, TreeNode parentTreeNode, Action action)
    {
        treeNode = parentTreeNode.Nodes.Add(name);
        treeNode.ToolTipText = tooltip;
        treeNode.Tag = action;
    }

    /// <summary>
    /// Runs the demo by invoking the associated action.
    /// </summary>
    public void Run()
    {
        try
        {
            var action = treeNode.Tag as Action;
            action?.Invoke();
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            throw new InvalidOperationException("An error occurred while running the demo action.", ex);
        }
    }
}
