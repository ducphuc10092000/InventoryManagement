   M S B A M L   `   `   `  ����N  JInventoryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:InventoryManagement.View.Inventory"InventoryManagement.View.Inventory  5   	   9    3InventoryManagement.View.Inventory.InventoryList_WD   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   <local0clr-namespace:InventoryManagement.View.Inventory  5   	   -   5          �Name$  inventoryList_WD��5   	    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      Inventory_UC_VM � DataContext# [  5   	    � Title$ Danh sách kho��5   	   $	��900��5   	   $
��1650��5   	   .��5      �� ���	#FF41A27A���	#FF41A27A$��10q�5       �� CornerRadius$ 20��5      ._�5   
   �  � RowDefinitions 5      �� 5      $��50 �6    6.   �� 5      6"   .+�5      � $��0��6   .+�5      (  "MaterialDesignThemes.Wpf.ColorZone  ���	#FF41A27A$��0��5   +      CornerRadius$ 10��5   +   .��5      ]� .+�5       �� 	 �� Orientation$	 
Horizontal=�6%   .+�5!      ��  * &MaterialDesignFloatingActionMiniButton#���  6%   ���	#FFFF5A5A$��10,0,0,0q�5%   %   $��50��5&   %   $��50��5'   %   +  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth3=�5(   %   ��5"   %   �� *QuitCommand+��5#   %   ��  �� ElementName$ inventoryList_WD��.��5)   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ KeyboardBackspace=�6:   5*      �� 5+      $��Center=�6(   $��25(�5,   (   
�������$
��Bold"�5.   (   $��10,0,0,0q�5/   (   Danh sách kho hàng51      52      53      54      55      �� 56      $��1��6   $��5q�57      
�������
�������$��5q�5:      $ 20��5;      ._�5<      #  MaterialDesignThemes.Wpf.Card  
�������$��5q�5=   &   $
 Depth5=�5>   &   .��5?      �  5@      �� 5A      $��60 �6,   6:   �� 5B      6.   .+�5D      � $��0��6   .+�5E      �� $	 
Horizontal=�6)   .+�5F   "   �� $��5q�6)   $ 10��5G   )   
����������	#FF4C7DD6$��1q�5J   )   ._�5K   &   � .+�5L   *   �� $	 
Horizontal=�65   .+�5M   .     $ Search=�6F   $��Center=�5N   F   $��Center=�5O   F   $��10,0,0,0q�5P   F   $��30��5Q   F   $��30��5R   F   6S   �� 5S   .   $��17(�5T   6   $��5q�5U   6   $��Center=�5V   6   $
��Left=�5W   6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhập tên kho��5X   6   $	��250��5Y   6   ��5S   6   �� *inventoryNameFind+ �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . .��5Y   B   5Z   /   5[   +   5\   '   5]   #   �� 5_   "   $��Tìm kiếm��6)     MaterialDesignRaisedButton#���  5a   )   $
 Depth2=�5b   )   
�������$
��Auto��5d   )   $	��120��5e   )   $��0q�5f   )   $��Center=�5g   )   ���	#FF4C7DD6$��
10,13,0,13q�5i   )   ��5`   )   �� *inventoryFindCommand+$ PropertyChanged=� . 5i   )   �� 5k   "   $��Mặc định��6)   #���  5m   )   $
 Depth2=�5n   )   
�������$
��Auto��5p   )   $	��120��5q   )   $��0q�5r   )   $��Center=�5s   )   ���	#FF4C7DD6$��
10,13,0,13q�5u   )   ��5l   )   �� *inventoryDefaultFilterCommand+$ PropertyChanged=� . 5u   )   �� 5w   "   $��Thêm mới��6)   {�. #���  5z   )   $
 Depth2=�5{   )   
�������$
��Auto��5}   )   $	��120��5~   )   $��0q�5   )   $��Center=�5�   )   ���#20c997$��
10,13,0,13q�5�   )   ��5y   )   ��  �� Path$% Open_AddNewInventory_WD_Command�$ PropertyChanged=� . 5�   )   5�      5�      �� 5�      $��1��6!   $��5q�5�   !   ���	#FF4C7DD6$��2q�5�   !   $ 10��5�   !   ._�5�      �� $��5q�6+   .��5�   "   &   System.Windows.Controls.DataGrid     AlternatingRowBackground �#6c757d   
IsReadOnly . $
��Auto=�5�   +      AutoGenerateColumns .     CanUserResizeColumns .     CanUserReorderColumns .  ��5�   +   �� *INVENTORYLISTDTG+ . $ PropertyChanged=� �� SelectedItem 5�   +   �� *selectedInventory+$ PropertyChanged=� .  J� InputBindings 5�   &   d� 5�   *    d� Gesture$ LeftDoubleClicka�67    �� Command 5�   7   �� *#!DoubleClickSelectInventoryCommand+ �� CommandParameter 5�   7   �� $ inventoryList_WD�� � 	Resources 5�   &   )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  '        '  �     �� 5�   *   "  60   .�5�   .   ��  � ��$ 35��5�   5   6B   �� 5�   .    � ��$ 13(�5�   5   6B   �� 5�   .    � ��$ Arial)�5�   5   6E   5�   +   �� 5�   *   "  60   .�5�   .   ��  � ��$ 30��5�   5   6B   �� 5�   .    � ��$ Times New Roman)�5�   5   6O   �� 5�   .    � ��$ 15(�5�   5   6B   �� 5�   .    � ��$
 Bold"�5�   5   6D   �� 5�   .    � ��$ Center=�5�   5   6F   �� 5�   .    � ��$ Center=�5�   5   6F   �� 5�   .    � ��
 �����5�   E   �� 5�   .    � �� �#6c757d5�   G   �� 5�   .    � ��$ 1,1,0,1q�5�   5   6G   5�   +   5�   '      Columns 5�   &   0	  *System.Windows.Controls.DataGridTextColumn	  5�   *   ,
  &System.Windows.Controls.DataGridColumn  
  Header$  Mã kho��6=   ! 
  Width5  /System.Windows.Controls.DataGridLengthConverter$	! 100 5�   =   1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 5�   =   �� *
kho.ID_KHO+5�   +   4  .System.Windows.Controls.DataGridTemplateColumn  5�   *   $  	Thao tác��6A   $	! 110 5�   A   #   CellTemplate# 5�   .   �� 5�   2   .R�5�   6   � $��0,0,12,0q�6;   $ � ColumnDefinitions$ 5�   :   �� 5�   >   $��30 �6O   6\   �� 5�   >   $��30 �6O   6\   .+�5�   :   �� $��0��6A   $��0q�5�   A   $
��Auto��5�   A   $��20��5�   A   $��6,0,5,0q�5�   A   ��5�   A   Z� ��5�   A   �� $/ )DataContext.Open_EditInventory_WD_Command�% �� RelativeSource% �� *FindAncestor+& �� AncestorType"&  ��5�   A   �� $ 
kho.ID_KHO�.��5�   >   � .+�5�   B   �� $��..\..\Photo\edit_icon.png��6H   $��-17,-4,1,-4q�5�   H   ' J� RenderTransformOrigin$' 0.5,0.5&�5�   H   z�5�   F   V� 5�   J   .~�5�   N   �� ( �� ScaleX$( -1Q�6]   �� 5�   N   �� 5�   N   T� 5�   N   5�   K   5�   C   5�   ?   5�   ;   �� 5�   :   $��1��6A   $��0q�5�   A   $
��Auto��5�   A   $��20��5�   A   $��11,0,0,0q�5�   A   ��5�   A   Z� ��5�   A   �� $( "DataContext.DeleteInventoryCommand�% �� *FindAncestor+"&  ��5�   A   �� $ 
kho.ID_KHO�.��5�   >   � .+�5�   B   �� $!��..\..\Photo\delete_icon.png��6H   $��-17,-15,-4,-15q�5�   H   $' 0.5,0.5&�5�   H   z�5�   F   V� 5�   J   .~�5�   N   �� $( -1Q�6]   �� 5�   N   �� 5�   N   T� 5�   N   5�   K   5�   C   5�   ?   5�   ;   5�   7   5�   3   5   +   	  5  *   $  Tên kho��6=   $	! 200 5  =   " 5  =   �� *kho.TEN_KHO+5  K   	  5  *   $  Tổng giá trị��6=   $	! 200 5  =   " 5  =   �� *kho.TONG_GIA_TRI+5  K   	  5
  *   $  Địa chỉ kho��6=   $	! 400 5  =   " 5  =   �� *kho.DIA_CHI_KHO+5  K   	  5  *   $  Mô tả��6=   $	! 300 5  =   " 5  =   �� *kho.GHI_CHU+5  K   5  #   5     5     5     5     5     5     5     5     