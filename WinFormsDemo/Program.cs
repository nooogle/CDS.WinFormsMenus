namespace WinFormsDemo;

/// <summary>
/// Application entry point for the WinForms demo application.
/// </summary>
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

#if NET6_0_OR_GREATER
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
#else
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
#endif
  
        Application.Run(new FormBasicTest());
    }
}
