   M S B A M L   `   `   `  ����C  ?PMSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PMSystem.ViewPMSystem.View  5   	        PMSystem.View.UserMoreView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PMSystem.View     5   	      UserMoreWindowTitle  � Title#  �   5   	   $	��600��67   $	��600��6D    � 	Resources 5	        SidePanelButtonStyle �� 
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
�������$ 10��6>   $��10q�6P   $ 20q�6\   ._�5)      ��  �� Orientation$ Vertical=�6   .+�5+      �� $
��Bold"�5,      $��28(�6'   ���#333333$��0,0,0,20q�5.      $��Center=�5/      ��5+      �� *CurrentUser.UserName+5/      �� 52      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�53      ��   UserMoreEmailTitle#���  6    $��16(�6L   $��0,0,20,0q�6Z   6n   �� 54      $��16(�55      $��0,0,0,10q�56      ���#555555 �� TextWrapping$
 Wrap=�58      $	��500��59      $
��Left=�5:      ��54      �� *Email+ �� UpdateSourceTrigger$ PropertyChanged=�5:      5;      �� 5?      $ 
Horizontal=�6   $��0,0,0,20q�66   .+�5@      ��   UserMorePasswordTitle#���  6    $��16(�6O   $��0,0,20,0q�6]   6q   �� 5A      $��16(�5B      $��0,0,0,20q�5C      ���#555555$
��Left=�5E      ��5A      �� *
Password+$ PropertyChanged=�5E      5G      �� 5I      $ 
Horizontal=�6   $��0,0,0,20q�66   .+�5J      ��   UserMoreRoleTitle#���  6    $��16(�6K   $��0,0,20,0q�6Y   6m   �� 5K      $��16(�6F   ��6    �� *CurrentUser.UserRole+6W   5L      �� 5O      $ 
Horizontal=�6   $��0,0,0,20q�66   .+�5P      ��   UserMoreNameTitle#���  6    $��16(�6K   $��0,0,20,0q�6Y   6m   �� 5Q      $��16(�6\   ��6   �� *
UserName+$ PropertyChanged=�.��6j   5S      5T      �� 5W      $ 
Horizontal=�6   $��Right=�66   $��0,10,0,0q�6R   .+�5X      ��   SavebuttonTitle#���  6   $��80��6I   $��30��6T   ���#2196F3
�������$��SemiBold"�5[       � Cursor$
 Hand��5\      $��0q�5]      $��0,0,10,0q�5^      ��5_      �� *SaveCommand+�� 5b      -   5          CancelButtonTitle#���  5b      $��80��6K   $��30��6V   ���#f44336
�������$��SemiBold"�5e      $
 Hand��5f      $��0q�5g      6-   �� 5i      -   5        $��DeleteButton��5q        DeleteTaskButtonTitle#���  5i      $��80��6O   $��30��6Z   ���#f44336
�������$��SemiBold"�5l      $
 Hand��5m      $��0q�5n      $��10,0,0,0q�5o      $y�	Collapsed=�5r      ��5p      �� *DeleteCommand+5t      5u      5v      5w      5x      5y      