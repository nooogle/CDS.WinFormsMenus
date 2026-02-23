using System.ComponentModel;

namespace CDS.WinFormsMenus.Basic;


/// <summary>
/// A tree view control for displaying a menu of demos.
/// </summary>
public partial class MenuTree : UserControl, IMenuTreeApi
{
    public MenuTree() => InitializeComponent();

    /// <summary>
    /// Gets the custom API surface of this control, providing focused access to its
    /// methods and properties without the noise of the underlying <see cref="UserControl"/> base class.
    /// </summary>
    public IMenuTreeApi API => this;

    /// <summary>
    /// Gets or sets which mouse interactions activate a menu item's action.
    /// Defaults to <see cref="MouseActivation.DoubleClick"/>.
    /// </summary>
    [DefaultValue(MouseActivation.DoubleClick)]
    public MouseActivation MouseActivation { get; set; } = MouseActivation.DoubleClick;

    /// <summary>
    /// Adds a new group to the tree view.
    /// </summary>
    /// <param name="name">The name of the group.</param>
    /// <returns>A <see cref="MenuGroup"/> representing the added group.</returns>
    public MenuGroup AddGroup(string name) => AddGroup(name: name, tooltip: string.Empty);

    /// <summary>
    /// Adds a new group to the tree view.
    /// </summary>
    /// <param name="name">The name of the group.</param>
    /// <returns>A <see cref="MenuGroup"/> representing the added group.</returns>
    public MenuGroup AddGroup(string name, string tooltip)
    {
        var groupTreeNode = treeView.Nodes.Add(name);
        groupTreeNode.ToolTipText = tooltip;
        return new MenuGroup(groupTreeNode);
    }

    /// <summary>
    /// Handles the NodeMouseDoubleClick event of the tree view.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
    private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (MouseActivation != MouseActivation.DoubleClick) return;

        try
        {
            var action = e.Node?.Tag as Action;
            action?.Invoke();
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            throw new InvalidOperationException("An error occurred while handling the node double-click event.", ex);
        }
    }

    /// <summary>
    /// Handles the NodeMouseClick event of the tree view.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
    private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (MouseActivation == MouseActivation.DoubleClick) return;

        try
        {
            var action = e.Node?.Tag as Action;
            action?.Invoke();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("An error occurred while handling the node click event.", ex);
        }
    }

    /// <summary>
    /// Handles the KeyPress event of the tree view.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
    private void treeView_KeyPress(object sender, KeyPressEventArgs e)
    {
        try
        {
            var isEnterKey = e.KeyChar == '\r';
            if (!isEnterKey) return;

            var action = treeView.SelectedNode?.Tag as Action;
            action?.Invoke();
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            throw new InvalidOperationException("An error occurred while handling the key press event.", ex);
        }
    }

    /// <summary>
    /// Selects the given menu item in the tree and activates it as if the user had double-clicked it.
    /// </summary>
    /// <param name="menuItem">The menu item to select and activate.</param>
    public void SelectMenuItem(MenuItem menuItem)
    {
        treeView.SelectedNode = menuItem.TreeNode;
        menuItem.Run();
    }

    /// <summary>
    /// Expands all groups in the tree view.
    /// </summary>
    public void ExpandAllGroups() => treeView.ExpandAll();
}
