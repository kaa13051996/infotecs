   M S B A M L   `   `   `  ���� B  >RSS_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:RSS_WPFRSS_WPF      RSS_WPF.SettingsWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:RSS_WPF       � Title$  Settings��$	��300��$	��300�� � 	Resources  �� 
TargetType �� Property �� Value   Blue��%�   '��       7   �� " ��.���  � ��$ Right=���  � ��$ 3q���  � ��8   ��  � ��
 �������  � ��$ Century)���  � ��$ 3q���  � ��
 ���� .���� $��2q�.+��� $
��Auto=�.���� .+��� $��Channels��&   System.Windows.Controls.DataGrid  -     Name$ gridChannels��$��Stretch=�   
IsReadOnly .     CanUserAddRows .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 	   CanUserDeleteRows	 . 
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width$
 auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *NameChannel+  $ *  �� *	LinkRSS+�� $��Options��  -   $ gridSettings��$��Stretch=� .  $ * 	 .   .  
   $ *    
IsReadOnly .  �� *NameSetting+  $ 40  �� *ValueSetting+�� -   $
��Save��