   M S B A M L   `   `   `  ����B  >RSS_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RSS_WPFRSS_WPF  5   	       RSS_WPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:RSS_WPF     5   	     � Title$	  RSS��5   	   $	��350��6   $	��525��6"   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��auto �6   $��50��6,   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   � -   5         �Name$ progressBar��5      $��0��6+   $��2��6;   $��0��6O    J� Opacity$	 0.4Q�6\   �� 5   
   $��0��6   $��1��6%   .+�5      �� -   5        $	����5         
MenuButton#��[  6<   �� 5      -   5        $	����5      #��[  6@   5      � 5   
   $��1��6   $��1��6   .+�5      �� -   5         ��Name$ scroll��5      .��5      �  5      �� 5      $��3* �6+   �� 5      $
��auto �6+   �� 5      $��* �6+   .+�5      �� -   5         ��Name$
 list��5   3   $��0��6#   $��Stretch=�6A   ��5       �� 5!      .R�5"   "   �� .+�5#   &   �� ��6,   �� *NameChannel+&   System.Windows.Controls.DataGrid  5$   &   -   5           ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5$   y   ��6/   �� *Posts+   Columns 5%   *   4  .System.Windows.Controls.DataGridTemplateColumn  5&   .   	   CellTemplate	 5'   2   �� 5(   6   .R�5)   :   �� $
��Wrap=�6D   �� 5*   >   -   5        
���   ���5*   H   �� *Link+
 �� TextDecorations
 6e   Z� .�6�   .�5+   B   �� �6F   �� *Name+5,   ?   5-   ;   5.   7   50   /   0  *System.Windows.Controls.DataGridTextColumn  51   .   ,  &System.Windows.Controls.DataGridColumn   Width$	 110 6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *Date+58   '   59   #   5:      5<      �� 5=      $��1��6#   $��2��63    �� ShowsPreview . $��4��6X   $��Center=�6b   $��Stretch=�6   �� 5>      $��2��6!   .+�5?      �� $��Description��6    �� 5@      -   5         ��Name$ tbDescription��5@   $   $
��Wrap=�6s    �� Padding$ 5q�6�   $��2q�6�   ��6;   �� *Description+ �� FallbackValue$ Отсутствует��6�   5A      5B      5C      5D      5E      5F      