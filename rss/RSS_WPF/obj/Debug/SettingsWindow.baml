   M S B A M L   `   `   `  ����B  >RSS_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RSS_WPFRSS_WPF  5   	       RSS_WPF.SettingsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:RSS_WPF     5   	     � Title$  Settings��5   	   $	��300��6   $	��300��6'    � 	Resources 5	       �� 
TargetType �� Property �� Value   Blue��%4  '��       7   �� 5
   
   " ��6   .�5      ��  � ��$ Right=�64   �� 5       � ��$ 3q�6'   �� 5       � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$ Century)�6+   �� 5       � ��$ 3q�6(   �� 5       � ��
 ���� 6,   5      5      .��5      �� $��2q�6   .+�5   
   �� $
��Auto=�6   .��5      �� .+�5      �� $��Channels��6   &   System.Windows.Controls.DataGrid  5      -   5          Name$ gridChannels��5      $��Stretch=�61      
IsReadOnly .     CanUserAddRows .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6   	   CanUserDeleteRows	 . 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width$
 auto 6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *NameChannel+  5      $ * 6-    67   �� *	LinkRSS+5      �� 5      $��Options��6     5      -   5        $ gridSettings��5      $��Stretch=�61    .  $ * 6m   	 .   .  
 5         5!      $ * 6-      
IsReadOnly .  67   �� *NameSetting+6W     5"      $ 40 6-    68   �� *ValueSetting+5$      �� 5%      -   5        $
��Save��5%   4   5&      5'      5(      5)      