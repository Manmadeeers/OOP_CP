   M S B A M L   `   `   `  ����C  ?PMSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PMSystem.ViewPMSystem.View  5   	       PMSystem.View.AddUserView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PMSystem.View     5   	      AddUserViewTitle  � Title#  �   5   	   $	��500��64   $	��600��6A    � 	Resources 5	        SidePanelButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value �� 
TargetName��%�  &	       �� 5
   
   " ��6-   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   $ 8��6[   # z��6l   ._�5      �� $��Center=�6/   $��Center=�6L   $
��10,0q�6g   5      	 5      P� 5      
 �@J�IsMouseOver$
 True��6=   . �5   "   �� $ border��6)    � �� �#2196F36S   �� 5   "    � ��
 �����6?   5      P� 5      
 � {�$ False��6;   . �5   "   �� $ border��6)    � �� �#1976D26S   �� 5   "    � ��
 �����6?   5      5      5      �� 5       � �� �#3333336+   �� 5       �@�Cursor$
 Hand��6'   �� 5        � ��$ SemiBold"�6+   �� 5!       � ��$ 16(�6)   5"      5#      .��5%      � ���#f0f2f5.+�5&   
   �� $	��500��6   $
��Auto��6   
�������$ 10��6>   $��10q�6P   $ 20q�6\   ._�5)      ��  �� Orientation$ Vertical=�6   .+�5+      �� #���   6   $
��Bold"�5,      $��28(�6    ���#333333$��0,0,0,20q�5.      $��Center=�5/      �� 52      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�53      ��   newUserNameTitle#���  6    $��16(�6J   $��0,0,20,0q�6X   6l   �� 54      $��16(�55      $��0,0,0,10q�56      ���#555555 �� TextWrapping$
 Wrap=�58      $	��500��59      $
��Left=�5:      $	��200��5;      $��30��5<      ��54      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5<      5=      �� 5A      $ 
Horizontal=�6   $��0,0,0,20q�66   .+�5B      ��   newUserPasswordTitle#���  6    $��16(�6N   $��0,0,20,0q�6\   6p   �� 5C      $��16(�5D      $��0,0,0,20q�5E      ���#555555$
��Left=�5G      $	��200��5H      $��30��5I      ��5C      �� *
Password+$ PropertyChanged=�5I      5K      �� 5M      $ 
Horizontal=�6   $��0,0,0,20q�66   .+�5N      ��   newUserEmailTitle#���  6    $��16(�6K   $��0,0,20,0q�6Y   6m   �� 5O      $��16(�5P      $��0,0,0,20q�5Q      ���#555555$
��Left=�5S      $	��200��5T      $��30��5U      ��5O      �� *Email+$ PropertyChanged=�5U      5W      �� 5X      -   5        $��RoleChecker��5\       �� SelectionMode$ Single=�5[      $	��100��5]      ���#FFFFFF���#E0E0E0$��1q�5`      $��14(�5a      $��5q�5b      ��5Y      �� *Roles+5d      �� 5g      $ 
Horizontal=�6   $��Right=�66   $��0,10,0,0q�6R   .+�5h      ��   AddButtonTitle#���  6   $��80��6H   $��30��6S   ���#2196F3
�������$��SemiBold"�5k       � Cursor$
 Hand��5l      $��0q�5m      $��0,0,10,0q�5n      ��5o      �� *
AddCommand+�� 5r      -   5          CancelButtonTitle#���  5r      $��80��6K   $��30��6V   ���#f44336
�������$��SemiBold"�5u      $
 Hand��5v      $��0q�5w      6&   5y      5|      5}      5~      5      