namespace CDS.WinFormsMenus.Basic;

/// <summary>
/// Defines the custom API surface of <see cref="MenuTree"/>, providing a focused view
/// of its methods and properties without the noise of the underlying <see cref="UserControl"/> base class.
/// </summary>
public interface IMenuTreeApi
{
    /// <summary>
    /// Adds a new top-level group to the tree.
    /// </summary>
    /// <param name="name">The name of the group.</param>
    /// <returns>A <see cref="MenuGroup"/> representing the added group.</returns>
    MenuGroup AddGroup(string name);

    /// <summary>
    /// Adds a new top-level group to the tree.
    /// </summary>
    /// <param name="name">The name of the group.</param>
    /// <param name="tooltip">The tooltip text for the group.</param>
    /// <returns>A <see cref="MenuGroup"/> representing the added group.</returns>
    MenuGroup AddGroup(string name, string tooltip);

    /// <summary>
    /// Selects the given menu item in the tree and activates it as if the user had double-clicked it.
    /// </summary>
    /// <param name="menuItem">The menu item to select and activate.</param>
    void SelectMenuItem(MenuItem menuItem);

    /// <summary>
    /// Expands all groups in the tree.
    /// </summary>
    void ExpandAllGroups();
}
