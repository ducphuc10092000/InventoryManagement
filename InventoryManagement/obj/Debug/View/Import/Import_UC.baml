   M S B A M L   `   `   `  ����N  JInventoryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:InventoryManagement.View.ImportInventoryManagement.View.Import  5      /    )InventoryManagement.View.Import.Import_UC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:InventoryManagement.View.Import     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Language$  vi-VN�5	         Import_UC_VM � DataContext# [  5
      
�������.��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   6*   �� 5      6   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��5,7,5,7q�6    �� CornerRadius$ 10��5      $	��200��5      
����������	#FF4C7DD6$��1q�5      ._�5      � .+�5      �� $ 
Horizontal=�6%   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Search=�66   $��Center=�5   6   $��Center=�5    6   $��10,0,0,0q�5!   6   $��30��5"   6   $��30��5#   6   6C   �� 5$      $��17(�5%   &    % !MaterialDesignFloatingHintTextBox#��[ 5&   &   $��Center=�5'   &   $
��Left=�5(   &   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nhập mã HĐ��5)   &   $��0,-5,0,0q�5*   &   $	��149��5+   &   ��5$   &   �� *inventoryNameFind+ �� NotifyOnSourceUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�5+   &   5,      5-      5.      �� 50      $��5,7,5,7q�6   $ 10��51      $	��200��52      
����������	#FF4C7DD6$��1q�55      ._�56      � .+�57      �� $ 
Horizontal=�6%   .+�58        $ Search=�66   $��Center=�59   6   $��Center=�5:   6   $��10,0,0,0q�5;   6   $��30��5<   6   $��30��5=   6   6C   �� 5>      $��17(�5?   &   #��[ 5@   &   $��Center=�5A   &   $
��Left=�5B   &   $ Nhập tên kho��5C   &   $	��150��5D   &   $��0,-5,0,0q�5E   &   ��5>   &   �� *inventoryNameFind+$ PropertyChanged=� . 5E   &   5F      5G      5H      �� 5K      $��5,7,5,7q�6   $ 10��5L      $	��160��5M      
����������	#FF4C7DD6$��1q�5P      ._�5Q      � .+�5R      �� $ 
Horizontal=�6%   .+�5S      (  "System.Windows.Controls.DatePicker  $ 
Từ ngày��6)   
�������	   SelectedDateFormat$	 Short=�5V   )   $
��Left=�5W   )    ( $MaterialDesignFloatingHintDatePicker#��[ 5X   )   $��20(�5Y   )   $��	0,-10,0,0q�5Z   )   $��50��5[   )   $��5,-6,0,0q�5\   )   $	��145��5]   )   
   Text
 5U   )   �� *TripStart_ReportTour_DT+ �� StringFormat$ 
dd/MM/yyyy�� �� Mode$ TwoWay=� . $ Default=�5]   )   5^      5_      5`      �� 5c      $��5,7,5,7q�6   $ 10��5d      $	��160��5e      
����������	#FF4C7DD6$��1q�5h      ._�5i      � .+�5j      �� $ 
Horizontal=�6%   .+�5k        $ Đến ngày��6)   
�������$	 Short=�5n   )   $
��Left=�5o   )   #��[ 5p   )   $��20(�5q   )   $��	0,-10,0,0q�5r   )   $��50��5s   )   $��5,-6,0,0q�5t   )   $	��145��5u   )   
 5m   )   �� *TripStart_ReportTour_DT+$ 
dd/MM/yyyy��$ TwoWay=� . $ Default=�5u   )   5v      5w      5x      �� 5{      $��Tìm kiếm��6     MaterialDesignRaisedButton#���  5}      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5~      
�������$
��Auto��5�      $	��120��5�      $��0q�5�      $��Center=�5�      ���	#FF4C7DD6$��
10,13,0,13q�5�      ��5|      �� *inventoryFindCommand+$ PropertyChanged=� . 5�      �� 5�      $��Mặc định��6   #���  5�      $ Depth2=�5�      
�������$
��Auto��5�      $	��120��5�      $��0q�5�      $��Center=�5�      ���	#FF4C7DD6$��
20,13,0,13q�5�      ��5�      �� *inventoryDefaultFilterCommand+$ PropertyChanged=� . 5�      �� 5�      $��Nhập hàng��6   {�. #���  5�      $ Depth2=�5�      
�������$
��Auto��5�      $	��120��5�      $��0q�5�      $��Center=�5�      ���#20c997$��
20,13,0,13q�5�      ��5�      ��  �� Path$&  Open_AddNewImportBill_WD_Command�$ PropertyChanged=� . 5�      5�      5�      �� 5�   
   $��1��6   $��5q�5�      ���	#FF4C7DD6$��2q�5�      $ 10��5�      ._�5�      �� $��5q�6   .��5�      &   System.Windows.Controls.DataGrid     AlternatingRowBackground �#6c757d   
IsReadOnly . $
��Auto=�5�         AutoGenerateColumns .     CanUserResizeColumns .     CanUserReorderColumns .  ��5�      �� *IMPORTBILLLISTDTG+ . $ PropertyChanged=� �� SelectedItem 5�      �� *selectedImportBill+$ PropertyChanged=� .  � 	Resources 5�      )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Property �� Value=  7System.Windows.Controls.Primitives.DataGridColumnHeader��%�  '        '  �     �� 5�      "  6    .�5�      ��  � ��$ 35��5�   %   62   �� 5�       � ��$ 13(�5�   %   62   �� 5�       � ��$ Arial)�5�   %   65   5�      �� 5�      "  6    .�5�      ��  � ��$ 30��5�   %   62   �� 5�       � ��$ Times New Roman)�5�   %   6?   �� 5�       � ��$ 15(�5�   %   62   �� 5�       � ��$
 Bold"�5�   %   64   �� 5�       � ��$ Center=�5�   %   66   �� 5�       � ��$ Center=�5�   %   66   �� 5�       � ��
 �����5�   5   �� 5�       � �� �#6c757d5�   7   �� 5�       � ��$ 1,1,0,1q�5�   %   67   5�      5�         Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Mã HĐ Nhập��6-    	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 120
 5�   -   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5�   -   �� *hoaDonNhap.ID_HOA_DON_NHAP+5�      4  .System.Windows.Controls.DataGridTemplateColumn  5�      $ 	Thao tác��61   $	 110
 5�   1      CellTemplate 5�      �� 5�   "   .R�5�   &   � $��0,0,12,0q�6+    � ColumnDefinitions 5�   *   �� 5�   .   $��30 �6?   6L   �� 5�   .   $��30 �6?   6L   .+�5�   *   �� $��0��61   $��0q�5�   1   $
��Auto��5�   1   $��20��5�   1   $��6,0,5,0q�5�   1   ��5�   1   Z� ��5�   1   �� $0 *DataContext.Open_EditImportBill_WD_Command� �� RelativeSource �� *FindAncestor+  �� AncestorType"   ��5�   1   �� $  hoaDonNhap.ID_HOA_DON_NHAP�.��5�   .   � .+�5�   2   �� $��..\..\Photo\edit_icon.png��68   $��-17,-4,1,-4q�5�   8   ! J� RenderTransformOrigin$! 0.5,0.5&�5�   8   z�5�   6   V� 5�   :   .~�5�   >   �� " �� ScaleX$" -1Q�6M   �� 5�   >   �� 5�   >   T� 5�   >   5�   ;   5�   3   5�   /   5�   +   �� 5�   *   $��1��61   $��0q�5�   1   $
��Auto��5   1   $��20��5  1   $��11,0,0,0q�5  1   ��5�   1   Z� ��5�   1   �� $( "DataContext.DeleteInventoryCommand� �� *FindAncestor+"   ��5�   1   �� $  hoaDonNhap.ID_HOA_DON_NHAP�.��5  .   � .+�5  2   �� $!��..\..\Photo\delete_icon.png��68   $��-17,-15,-4,-15q�5  8   $! 0.5,0.5&�5  8   z�5	  6   V� 5
  :   .~�5  >   �� $" -1Q�6M   �� 5  >   �� 5  >   T� 5  >   5  ;   5  3   5  /   5  +   5  '   5  #   5       5     $ Tên kho��6-   $	 200
 5  -    5  -   �� *hoaDonNhap.KHO.TEN_KHO+5  ;     5     $ Nhà cung cấp��6-   $	 200
 5   -    5  -   �� *!hoaDonNhap.NHA_CUNG_CAP.TEN_NCC+5   ;     5#     $ Người nhập��6-   $	 200
 5%  -    5$  -   �� *'%hoaDonNhap.TAI_KHOAN.NHAN_VIEN.TEN_NV+5%  ;     5'     $ Thời gian nhập��6-   $	 200
 5)  -    5(  -   �� *hoaDonNhap.THOI_GIAN_NHAP+5)  ;     5+     $ Giá trị hóa đơn��6-   $	 200
 5-  -    5,  -   �� *hoaDonNhap.TONG_TIEN+5-  ;   5/     50     51     52     53     