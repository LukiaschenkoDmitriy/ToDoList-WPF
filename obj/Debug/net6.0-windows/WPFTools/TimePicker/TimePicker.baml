   M S B A M L   `   `   `  ????C  ?ToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPFToolsWPFTools  5          WPFTools.TimePicker   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:WPFTools     5      -   5          >?Name$  UserControl??5   )   $
??Auto??6   $
??Auto??6   .??5
      ? -   5         ?Name$ 
LayoutRoot??5
      $??10 0 0 0q?6   $
??Auto??61   $
??Auto??6>    ? ColumnDefinitions 5   
   ?? 5      $
??0.2* ?6   ?? 5      $??0.05* ?6   ?? 5      $
??0.2* ?6   .+?5   
   ?? $??3??6    ?? RadiusX$ 15??6(    ?? RadiusY$ 15??65   ??5      ?? 5       ?? Color$ White??6"    ?? Opacity$	 0.7Q?60   5      ? 5   
   -   5        $ hours??5      $
|?True??6   .+?5      ?? -   5         ??Name$ hh??5       ?? TextWrapping$
 Wrap=?6"   $??16(?5      	 ?? TextAlignment$	 Center=?5      $??Center=?6-   $??0q?6I   ??5   6   ?? 
 ?? Path$
 Hours? ?? ElementName$ UserControl?? ?? Mode$ Default=?.??5   ]   ??5      ?? 5      $ 0Q?6&   64   .??5   &   5      5      ? 5"   
   $??1??6   .+?5#      ?? -   5        $
 sep1??5#   6   $??16(?6    ?? 
IsReadOnly$
 True??6$   $
 Wrap=?6D   $??Center=?6X   $??:??6s   $	 Center=?6|   $??0q?6?   .??6?   ??5$      ?? 5%      $ 0Q?6&   .??5&   &   5'      5(      ? 5+   
   -   5        $ minutes??5+       $??2??6   $
|?True??61   .+?5,      ?? -   5        $ mm??5,   $   $??16(?6   $
 Wrap=?61   $	 Center=?5.      $??Center=?6.   $??0q?6I   ??5,   E   ?? $
 Minutes?$ UserControl??$ Default=?.??5.   ^   ??5/      ?? 50      $ 0Q?6&   64   .??51   &   52      53      54      56      