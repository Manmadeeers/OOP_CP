   M S B A M L   `   `   `  ����  PMSystem     PMSystem.View.UserPageView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	      UserPageTitle  � Title#  �   5   	   $	��450��61   $	��400��6>   ���#f0f2f5 � WindowStartupLocation$ CenterScreen=�6_    � 
ResizeMode$ NoResize=�6�   .��5      � ���#f0f2f5.+�5   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 30q�66   $��Center=�6C   $��Center=�6^   $	��370��6{   ._�5      �� .+�5      �� -   5        $��En��5	      $��Right=�5
      $��30��5      
������ $	��0.5q�5       � Cursor$
 Hand��5      5      �� 5      #���   6   $��26(�6C   $��SemiBold"�6Q   ���#333$��0,0,0,20q�6y   $��Center=�6�   �� 5        UserName#���  6   ���#555$��0,5,0,2q�6P   �� 5      $��16(�6;   ���#222��6   �� *User.UserName+6I   �� 5        	UserEmail#���  6   ���#555$��0,15,0,2q�6Q   �� 5      $��16(�6<   ���#222��6   �� *User.UserEmail+6J   �� 5        UserPassword#���  6   ���#555$��0,15,0,2q�6T   �� 5      $��16(�6?   ���#222$
��Wrap=�6_   $	��150��6s   ��6   �� *User.UserPassword+6s   �� 5      -   5          UserPAgeCloseButton#���  5      $	��100��6I   $��36��6U   $��0,30,0,0q�6a   $��Center=�6s   ���#2196F3
�������$��0q�6�   $
 Hand��6�   ��5      �� 5        �� 
TargetType" ��6    .�5!      ��  �� Property � �� �� Value 5"   "   �� 5#   &   	 �� 
TargetType"	 ��66   .R�5$   *   �� 
 ��Name$
 border��61   #��z��6A   $ 18��6k   $��36��6}   $	��100��6�   ._�5%   .   �� $��Center=�6?   $��Center=�6\   5&   +    �� Triggers 5'   *   P� 5(   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5)   2   ��  �� 
TargetName$ border��69    � �� �#1976D26c   5*   /   5,   '   5.      5/      51      52      53      54      55      