   M S B A M L   `   `   `  ����  eLibrary"    eLibrary.View.QuanLyNhanVien   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Quản Lý Nhân Viên��5   	   $	��600��6#   $	��900��60   
������� � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Quản Lý Nhân Viên��6   $��28(�5      $
��Bold"�6"   
����=H�$��Center=�5      $��	0,20,0,10q�5      �� 5   
   
�������$��1q�6(    �� CornerRadius$ 10��6<   
������� �� Padding$ 10q�5   $   $��1��61   ._�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�66   .+�5      �� -   5         ��Name$ 
txtTimKiem��5      $	��250��62   $��30��6>   $��0,0,10,0q�6J   $��14(�5      �� 5      -   5        $
��Tìm��5      $��80��6+   $��30��66   ���	#FF795548
�������5   4   5      &   System.Windows.Controls.DataGrid  5"      -   5          Name$ 
dgNhanVien��5"         AutoGenerateColumns$ False��6/   	   HeadersVisibility$	 Column=�5#      
   CanUserAddRows$
 False��66      
IsReadOnly$
 True��5$      $��14(�5%      $	��350��6)      Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã NV��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *
MaNhanVien+6[     5(      $ 	Họ Tên��6-   $	 150 6Y    6=   �� *	HoVaTen+6Y     5)      $ Email��6-   $	 150 6W    6<   �� *Email+6W     5*      $ 
Ngày Sinh��6-   $	 120 6x    6@   �� *
NgaySinh+ �� StringFormat$ 
dd/MM/yyyy��6x     5+      $ Số ĐT��6-   $	 100 6\    6<   �� *SoDienThoai+6\     5,      $ Avatar��6-   $	 100 6X    6=   �� *Avatar+6X     5-      $ Quyền Hạn��6-   $	 100 6f    6@   �� *QuyenHan.TenQuyen+6f   5/      50      51      �� 54   
   $��2��6   $ 
Horizontal=�6"   $��Center=�6;   $��0,15,0,0q�6X   .+�55      �� -   5        $��Thêm��55      $	��100��6$   $��10q�60   ���#4CAF50
�������6d   �� 56      -   5        $��Cập nhật��56      $	��100��6(   $��10q�64   ���#2196F3
�������6h   �� 57      -   5        $
��Xoá��57      $	��100��6#   $��10q�6/   ���#F44336
�������6c   �� 58      -   5        $��Sắp xếp tên ��58      $	��120��6,   $��10q�68   ���#9C27B0
�������6l   �� 59      -   5        $��Sắp xếp Z-A��59      $	��120��6+   $��10q�67   ���#7B1FA2
�������6k   5:      5;      5<      