   M S B A M L   `   `   `  ����E  AMessageApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MessageApp.UIMessageApp.UI  5      #    MessageApp.UI.MessageListView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:MessageApp.UI     5      $��415.546��5   #   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  messageListGrid��5
      $	��430��6,   $��	10,10,0,0q�69   $	��396��6L      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5      �� 5       �� Binding 6&   �� *State+ �� Value
 State16@   .a�5      ��  �� Property � �� �� Value �	#FFF1B3B36O   5      �� 5       6&   �� *State+
 State26@   .a�5      ��  � ��
 �����6K   5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        colDateTimeOn��,  &System.Windows.Controls.DataGridColumn	   Header$	 
Время��5   <   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 90 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   ��  �� Path$ 
DateTimeOn�6o     5      -   5        	colID��$	 ID��5   4   $
 80 6\    6@   �� $ ID�6\     5      -   5        colBody��$	 Значение��5   6   $
 80 6f    6H   �� $
 Body�6f     5      -   5        
colIsValid��$	 Ошибка��5   9   $
 80 6j    6I   �� $ IsValid�6j   5      5!      5"      