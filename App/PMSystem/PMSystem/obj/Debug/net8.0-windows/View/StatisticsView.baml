   M S B A M L   `   `   `  ����C  ?PMSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PMSystem.ViewPMSystem.View  5   	   "    PMSystem.View.StatisticsView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PMSystem.View     5   	      StatisticsViewTitle  � Title#  �   5   	   $	��450��67   $	��400��6D   .��5	      � ���#f0f2f5.+�5
   
   �� 
������� �� CornerRadius$ 10��6$    �� Padding$ 30q�66   $��Center=�6C   $��Center=�6^   $	��370��6{   ._�5      �� .+�5      �� -   5        $��En��5      $��Right=�5      $��30��5      
������ $	��0.5q�5       � Cursor$
 Hand��5      5      �� 5      #���   6   $��26(�6I   $��SemiBold"�6W   ���#333$��0,0,0,20q�6   $��Center=�6�   �� 5      -   5        $��	AdminStat��5       �� Orientation$ Vertical=�6.   .+�5      �� $ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�5      ��   AdminProjectsAmoutn#���  6$   6S   �� 5      $��20,0,0,0q�6F   ��6$   �� *AdminProjAmount+6Z   5      �� 5      $ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�5      ��   AdminUsersAmoutn#���  6$   6P   �� 5       $��20,0,0,0q�6E   ��6$   �� *AdminUserCount+6Y   5!      �� 5"      $ 
Horizontal=�6!   .+�5#      ��   AdminTasksAmoutn#���  6$   6P   �� 5$      $��20,0,0,0q�6E   ��6$   �� *AdminTasksCount+6Y   5%      5&      �� 5(      -   5        $��UserStat��5(      .+�5)      �� $ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�5*      ��   userClosedTasks#���  6$   6O   �� 5+      $��20,0,0,0q�6J   ��6$   �� *AmountCompletedTasks+6^   5,      �� 5-      $ 
Horizontal=�6!   $��0,0,0,10q�6:   .+�5.      ��   userProgTasks#���  6$   6M   �� 5/      $��20,0,0,0q�6F   ��6$   �� *AmountProgTasks+6Z   50      �� 51      $ 
Horizontal=�6!   .+�52      ��   userNotTasks#���  6$   6L   �� 53      $��20,0,0,0q�6E   ��6$   �� *AmountNotTasks+6Y   54      �� 55      $ 
Horizontal=�6!   .+�56      ��   
completion#���  6$   6J   �� 57      ��6$   �� *CompletionPercentage+6L   58      59      �� 5:      -   5          UserPAgeCloseButton#���  5:      $	��100��6I   $��36��6U   $��0,30,0,0q�6a   $��Center=�6s   ���#2196F3
�������$��0q�6�   $
 Hand��6�   ��5<      �� 5=       �� 
TargetType" ��6    .�5>      ��  �� Property � �� �� Value 5?   "   �� 5@   &    �� 
TargetType" ��66   .R�5A   *   �� 	 ��Name$	 border��61   #��z��6A   $ 18��6k   $��36��6}   $	��100��6�   ._�5B   .   �� $��Center=�6?   $��Center=�6\   5C   +   
 �� Triggers
 5D   *   P� 5E   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5F   2   ��  �� 
TargetName$ border��69    � �� �#1976D26c   5G   /   5I   '   5K      5L      5N      5O      5P      5Q      5R      