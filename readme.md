# CDS.WinFormsMenus

CDS.WinFormsMenus is a library for creating very simple and quick 
tree-view based menus on WinForms apps. It is great for simple demo and test applications, where
a conventional menu doesn't quite fit the pattern. 

It's available for .Net 8 and .Net Framework 4.8 applications.

It will only save you a few minutes of coding, but that leaves more 
time for the fun stuff!


## Usage

The menu consists of groups and items. Each group can contain other groups and items. Each item has an action 
associated with it.

After referencing the library, add a `CDS.WinFormsMenus.Basic.MenuTree` control to your form.

You can this create the menu like this:

```csharp
var formsGroup = menuTree.AddGroup("Forms", tooltip: "A group of items for showing colourful forms!");
formsGroup.AddDemo("Red form", "Opens a red form", this, () => new RedForm());
formsGroup.AddDemo("Blue form", "Opens a blue form", this, () => new BlueForm());

var actionsGroup = menuTree.AddGroup("Actions");
actionsGroup.AddDemo("Message box", "Shows a message box", this, ShowMessageBox);

menuTree.ExpandAllGroups();
```

The user can then either double-click an item to run the action, or select it and hit the enter key.

![Screenshot](https://raw.githubusercontent.com/nooogle/CDS.DemoAppMenus/master/CDS.WinFormsMenus/ScreenShot.png)




## License

This project is licensed under the MIT License.

## Attributions

[Hierarchy icon](https://www.flaticon.com/free-icons/hierarchy) created by Freepik - Flaticon.

