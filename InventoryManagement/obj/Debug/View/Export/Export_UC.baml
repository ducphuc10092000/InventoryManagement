   M S B A M L   `   `   `  ����N  JInventoryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:InventoryManagement.View.ExportInventoryManagement.View.Export  5      /    )InventoryManagement.View.Export.Export_UC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:InventoryManagement.View.Export     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         Export_UC_VM  � DataContext#  [  5      
�������.��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $��60 �6    6.   �� 5      6"   .+�5      � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��5q�6    �� CornerRadius$ 10��5      
����������	#FF4C7DD6$��1q�5      ._�5      � .+�5      �� $ 
Horizontal=�6)   .+�5   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�6:   $��Center=�5   :   $��Center=�5   :   $��10,0,0,0q�5   :   $��30��5    :   $��30��5!   :   6G   �� 5"   "   $��17(�5#   *   $��5q�5$   *   $��Center=�5%   *   $
��Left=�5&   *   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$" Nhập mã hóa đơn xuất��5'   *   $	��250��5(   *   ��5"   *   �� *exportBillIDFind+ �� UpdateSourceTrigger$ PropertyChanged=� �� NotifyOnSourceUpdated . .��5(   6   5)   #   5*      5+      5,      �� 5.      $��5q�6   $ 10��5/      
����������	#FF4C7DD6$��1q�52      ._�53      � .+�54      �� $ 
Horizontal=�6)   .+�55   "     $ Search=�6:   $��Center=�56   :   $��Center=�57   :   $��10,0,0,0q�58   :   $��30��59   :   $��30��5:   :   6G   �� 5;   "   $��17(�5<   *   $��5q�5=   *   $��Center=�5>   *   $
��Left=�5?   *   $ Nhập tên kho xuất��5@   *   $	��250��5A   *   ��5;   *   �� *inventoryNameFind+$ PropertyChanged=� . .��5A   6   5B   #   5C      5D      5E      �� 5G      $��5q�6   $ 10��5H      $	��130��5I      
����������	#FF4C7DD6$��1q�5L      ._�5M      � .+�5N      �� $ 
Horizontal=�6)   .+�5O   "   (  "System.Windows.Controls.DatePicker  $ 
Từ ngày��6-   
�������   SelectedDateFormat$ Short=�5R   -   $
��Left=�5S   -    ( $MaterialDesignFloatingHintDatePicker#��[ 5T   -   $��20(�5U   -   $��	0,-10,0,0q�5V   -   $��54��5W   -   $��5,-6,0,0q�5X   -   $	��118��5Y   -   	   Text	 5Q   -   �� *DayStart_ExportBill+
 �� StringFormat$
 
dd/MM/yyyy�� �� Mode$ TwoWay=� . $ Default=�5Y   -   5Z      5[      5\      �� 5_      $��5q�6   $ 10��5`      $	��130��5a      
����������	#FF4C7DD6$��1q�5d      ._�5e      � .+�5f      �� $ 
Horizontal=�6)   .+�5g   "     $ Đến ngày��6-   
�������$ Short=�5j   -   $
��Left=�5k   -   #��[ 5l   -   $��20(�5m   -   $��	0,-10,0,0q�5n   -   $��54��5o   -   $��5,-6,0,0q�5p   -   $	��118��5q   -   	 5i   -   �� *DayEnd_ExportBill+$
 
dd/MM/yyyy��$ TwoWay=� . $ Default=�5q   -   5r      5s      5t      �� 5v      $��Tìm kiếm��6     MaterialDesignRaisedButton#���  5x      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5y      
�������$
��Auto��5{      $	��120��5|      $��0q�5}      $��Center=�5~      ���	#FF4C7DD6$��
10,13,0,13q�5�      ��5w      �� *ExportBillFindCommand+$ PropertyChanged=� . 5�      �� 5�      $��Mặc định��6   #���  5�      $ Depth2=�5�      
�������$
��Auto��5�      $	��120��5�      $��0q�5�      $��Center=�5�      ���	#FF4C7DD6$��
10,13,0,13q�5�      ��5�      �� * ExportBillDefaultFilterCommand+$ PropertyChanged=� . 5�      �� 5�      $��Xuất hàng��6   {�. #���  5�      $ Depth2=�5�      
�������$
��Auto��5�      $	��120��5�      $��0q�5�      $��Center=�5�      ���#20c997$��
10,13,0,13q�5�      ��5�      ��  �� Path$&  Open_AddNewExportBill_WD_Command�$ PropertyChanged=� . 5�      5�      5�      �� 5�      $��1��6   $��5q�5�      ���	#FF4C7DD6$��2q�5�      $ 10��5�      ._�5�      �� $��5q�6   .��5�      &   System.Windows.Controls.DataGrid     AlternatingRowBackground �#6c757d   
IsReadOnly . $
��Auto=�5�         AutoGenerateColumns .     CanUserResizeColumns .     CanUserReorderColumns .  ��5�      �� *EXPORTBILLLISTDTG+ . $ PropertyChanged=� �� SelectedItem 5�      �� *selectedExportBill+$ PropertyChanged=� .  � 	Resources 5�      )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  '        '  �     �� 5�      "  6$   .�5�   "   ��  � ��$ 35��5�   )   66   �� 5�   "    � ��$ 13(�5�   )   66   �� 5�   "    � ��$ Arial)�5�   )   69   5�      �� 5�      "  6$   .�5�   "   ��  � ��$ 30��5�   )   66   �� 5�   "    � ��$ Times New Roman)�5�   )   6C   �� 5�   "    � ��$ 15(�5�   )   66   �� 5�   "    � ��$
 Bold"�5�   )   68   �� 5�   "    � ��$ Center=�5�   )   6:   �� 5�   "    � ��$ Center=�5�   )   6:   �� 5�   "    � ��
 �����5�   9   �� 5�   "    � �� �#6c757d5�   ;   �� 5�   "    � ��$ 1,1,0,1q�5�   )   6;   5�      5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Mã HĐ xuất��61    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 120
 5�   1   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   1   �� *hoaDonXuat.ID_HOA_DON_XUAT+5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ 	Thao tác��65   $	 110
 5�   5      CellTemplate 5�   "   �� 5�   &   .R�5�   *   � $��0,0,12,0q�6/    � ColumnDefinitions 5�   .   �� 5�   2   $��30 �6C   6P   �� 5�   2   $��30 �6C   6P   .+�5�   .   �� $��0��65   $��0q�5�   5   $
��Auto��5�   5   $��20��5�   5   $��6,0,5,0q�5�   5   ��5�   5   Z� ��5�   5   �� $/ )DataContext.Open_EditInventory_WD_Command� �� RelativeSource �� *FindAncestor+ �� AncestorType"  ��5�   5   �� $  hoaDonXuat.ID_HOA_DON_XUAT�.��5�   2   � .+�5�   6   �� $��..\..\Photo\edit_icon.png��6<   $��-17,-4,1,-4q�5�   <     J� RenderTransformOrigin$  0.5,0.5&�5�   <   z�5�   :   V� 5�   >   .~�5�   B   �� ! �� ScaleX$! -1Q�6Q   �� 5�   B   �� 5�   B   T� 5�   B   5�   ?   5�   7   5�   3   5�   /   �� 5�   .   $��1��65   $��0q�5�   5   $
��Auto��5�   5   $��20��5�   5   $��11,0,0,0q�5�   5   ��5�   5   Z� ��5�   5   �� $( "DataContext.DeleteInventoryCommand� �� *FindAncestor+"  ��5�   5   �� $ 
kho.ID_KHO�.��5   2   � .+�5  6   �� $!��..\..\Photo\delete_icon.png��6<   $��-17,-15,-4,-15q�5  <   $  0.5,0.5&�5  <   z�5  :   V� 5  >   .~�5  B   �� $! -1Q�6Q   �� 5  B   �� 5  B   T� 5	  B   5
  ?   5  7   5  3   5  /   5  +   5  '   5       5     $ Tên kho xuất��61   $	 200
 5  1    5  1   �� *hoaDonXuat.KHO.TEN_KHO+5  ?     5     $ Người xuất��61   $	 200
 5  1    5  1   �� *'%hoaDonXuat.TAI_KHOAN.NHAN_VIEN.TEN_NV+5  ?     5     $ Thời gian xuất��61   $	 200
 5  1    5  1   �� *hoaDonXuat.THOI_GIAN_XUAT+5  ?     5!     $ Giá trị hóa đơn��61   $	 200
 5#  1    5"  1   �� *hoaDonXuat.TONG_TIEN+5#  ?   5%     5&     5'     5(     5)     5*     