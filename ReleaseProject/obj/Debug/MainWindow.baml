   M S B A M L   `   `   `  ����|  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting  5      I EReleaseProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ReleaseProjectReleaseProject 5   	      ReleaseProject.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   [ WXceed.Wpf.AvalonDock, Version=3.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4=
avalonDock,http://schemas.xceed.com/wpf/xaml/avalondock  5   
   �chartingToolkit{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit  5      (localclr-namespace:ReleaseProject  5   	   -   5        $��
mainWindow��5   >     � Title$  
MainWindow��6	   $��677.463��6   $��1025.298��6-   .��5      � -   5         �Name$ 
layoutRoot��5       � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� $��Файл��6   .@�5      m� $��
Новый��6   .@�5      m� -   5        $��База данных��5      64   m� 5      -   5        $��Файл��5      61   5      5      m� 5      $��Графики��6   .@�5      m� -   5        $��Гистограмма��5      60   m� 5      -   5        $��Диаграмма��5      6.   m� 5      -   5        $'��!Диаграмма-область��5      66   m� 5      -   5        $)��#Линейная диаграмма��5      67   5      5      �� 5   
   $��1��6   $��0��6   
������$��1q�6G   $
��Left=�6[   $	��164��6v   $��10,51.4,0,10q�6�   ._�5      �� .��5      �� -	   5         ��Name$ 
stackPanel��5       J� 	AllowDrop . 6C   5      5       �� 5!   
   
������$��1q�6*   $��380,51.4,10.2,10q�6>   $��1��6X   ._�5"      )  #Xceed.Wpf.AvalonDock.DockingManager  -
   5          Name$ dockManager��5"   (      AllowMixedOrientation . $��9.2,9.2,8,9.8q�6Z      Theme 5#      .  (Xceed.Wpf.AvalonDock.Themes.GenericTheme  5$         Layout. 5'      ,  &Xceed.Wpf.AvalonDock.Layout.LayoutRoot  -   5        	Test3��	   	RootPanel.	 5(      -  'Xceed.Wpf.AvalonDock.Layout.LayoutPanel  -   5        	Test2��
   Orientation$
 
Horizontal=�5(   <   5*      5+      5,      5-      �� 5.   
   
������$��1q�6*   $
��Left=�6>   $��193,51.4,0,10q�6Y   $��1��6p   $	��173��6}   ._�5/      �� -   5        $ stackPanel1��5/      58      59      5:      5;      