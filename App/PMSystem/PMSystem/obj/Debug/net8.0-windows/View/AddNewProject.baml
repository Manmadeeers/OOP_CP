   M S B A M L   `   `   `  ����C  ?PMSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PMSystem.ViewPMSystem.View  5	   	   !    PMSystem.View.AddNewProject   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PMSystem.View     5	   	      AddProjectPageTitle  � Title#  �   5   	   $	��500��67   $	��600��6D    � 	Resources 5        SidePanelButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding	 �� Triggers
 P� Property P� Value �� 
TargetName��%�  &	       �� 5   
   " ��6-   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��61   $ 8��6[   # z��6l   ._�5      �� $��Center=�6/   $��Center=�6L   $
��10,0q�6g   5      	 5      P� 5      
 �@J�IsMouseOver$
 True��6=   . �5   "   �� $ border��6)    � �� �#2196F36S   �� 5   "    � ��
 �����6?   5      P� 5      
 � {�$ False��6;   . �5   "   �� $ border��6)    � �� �#1976D26S   �� 5   "    � ��
 �����6?   5      5      5       �� 5!       � �� �#3333336+   �� 5"       �@�Cursor$
 Hand��6'   �� 5#       � ��$ SemiBold"�6+   �� 5$       � ��$ 16(�6)   5%      5&      .��5(      � ���#f0f2f5.+�5)   
   �� $	��500��6   $
��Auto��6   
�������$ 10��6>   $��10q�6P   $ 20q�6\   ._�5,      ��  �� Orientation$ Vertical=�6   .+�5.      �� #���   6   $
��Bold"�5/      $��28(�6$   ���#333333$��0,0,0,20q�51      $��Center=�52      �� 55      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�56      ��   ProjectNameTitle#���  6    $��16(�6J   $��0,0,20,0q�6X   6l   �� 57      $��16(�58      $��0,0,0,10q�59      ���#555555 �� TextWrapping$
 Wrap=�5;      $	��500��5<      $
��Left=�5=      $	��200��5>      $��30��5?      ��57      �� *ProjectName+ �� UpdateSourceTrigger$ PropertyChanged=�5?      5@      �� 5D      $ 
Horizontal=�6   $��0,0,0,20q�66   .+�5E      ��   ProjectMethodologyTitle#���  6    $��16(�6Q   $��0,0,20,0q�6_   6s   �� 5F      $��16(�5G      $��0,0,0,20q�5H      ���#555555$
��Left=�5J      $	��200��5K      $��30��5L      ��5F      �� *Methodology+$ PropertyChanged=�5L      5N      �� 5O      -   5        $��UserChecker��5S       �� SelectionMode$ Multiple=�5R      $	��150��5T      ���#FFFFFF���#E0E0E0$��1q�5W      $��14(�5X      $��5q�5Y      ��5P      �� *Users+5[      �� 5^      $ 
Horizontal=�6   $��Right=�66   $��0,10,0,0q�6R   .+�5_      ��   AddButtonTitle#���  6   $��80��6H   $��30��6S   ���#2196F3
�������$��SemiBold"�5b       � Cursor$
 Hand��5c      $��0q�5d      $��0,0,10,0q�5e      ��5f      �� *
AddCommand+�� 5i      -   5          CancelButtonTitle#���  5i      $��80��6K   $��30��6V   ���#f44336
�������$��SemiBold"�5l      $
 Hand��5m      $��0q�5n      6*   5p      5s      5t      5u      5v      