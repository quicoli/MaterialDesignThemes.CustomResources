WPF (.net core and full .net) has a memory leak regarding using a font source with FontFamily.
This is discussed in issue #746 from Material Design in Xaml Toolkit

https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit/issues/746

This solution is based on Dominic Jonas idea (https://stackoverflow.com/questions/50964801/wpf-use-font-installed-with-addfontmemresourceex-for-process-only)
and adapted to be used/integrated by Material Design in Xaml Tookit.

To the verify the issue open the full .net Demo and change the MainPage, Page1 and Page2 to use default font family sintax:

FontFamily="{DynamicResource MaterialDesignFont}"

Follow steps:
1. Run it; 
2. Take a snapshot from Visual Studio Diagnostics Tool.
3. Look form Unmanaged Resources. You find 101.
4. Open Page 1;
5. Take a snapshot from Visual Studio Diagnostics Tool.
6. Look form Unmanaged Resources. You find 106.
7. Open Page 2;
8. Take a snapshot from Visual Studio Diagnostics Tool.
9. Look form Unmanaged Resources. You find 110.
7. Open Page 1 again;
8. Take a snapshot from Visual Studio Diagnostics Tool.
9. Look form Unmanaged Resources. You find 113.

Apply the fix in the MainPage, Page1 and Page2:

FontFamily="{customResources:FontResource FontName=Roboto}"

Follow steps:
1. Run it; 
2. Take a snapshot from Visual Studio Diagnostics Tool.
3. Look form Unmanaged Resources. You find 63.
4. Open Page 1;
5. Take a snapshot from Visual Studio Diagnostics Tool.
6. Look form Unmanaged Resources. You find 64.
7. Open Page 2;
8. Take a snapshot from Visual Studio Diagnostics Tool.
9. Look form Unmanaged Resources. You find 65.
7. Open Page 1 again;
8. Take a snapshot from Visual Studio Diagnostics Tool.
9. Look form Unmanaged Resources. You find 65.

As we can see now the number of Unmanaged Resources created by the use of resource Fonts
doesn't increase anymore.