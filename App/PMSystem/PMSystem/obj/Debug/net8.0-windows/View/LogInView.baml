   M S B A M L   `   `   `  ����  PMSystem    PMSystem.View.LogInView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5	      � ���#f0f2f5.+�5
   
   �� $	��350��6   $	��500��5      
�������  �� CornerRadius$  10��5      $��Center=�5      $��Center=�5       �� Padding$ 20q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      ShadowDepth$ 3Q�63      Color$ 	#66000000��6C   ._�5      ��  �� Orientation$ Vertical=�6   $��Center=�60   .+�5      �� -   5        $��En��5      $��30��5      $��Right=�5      
�������$	��0.5q�5       � Cursor$
 Hand��5      5      �� 5         
LoginTitle#���   6   $��28(�6@   $��SemiBold"�6N   ���#333$��Center=�6v   $
��0,10q�6�   �� 5!        UsernameLabel#���  6   $��0,20,0,5q�6C   ���#5556U   �� 5"      ���#ccc$��0,0,0,1q�5#   -   
������ $	��0,5q�6`   ��5"      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5#   `   �� 5%        PasswordLabel#���  6   $��0,20,0,5q�6C   ���#5556U   G� 5&      -   5        	 G�Name$	 PasswordBox��5&      ���#ccc$��0,0,0,1q�5(   1   
������ $	��0,5q�5)   7   �� 5+        	LogInText#���  6   ���#2196F3
�������$��	0,30,0,10q�5/      $��40��50      $��0q�51      $
 Hand��52      $	��250��53      $��Center=�54      ��5,      �� *LoginCommand+��55      �� 56      
 �� 
TargetType"
 ��6    .�57      ��  �� Property � �� �� Value 58   "   �� 59   &    �� 
TargetType" ��66   .R�5:   *   ��  ��Name$ border��61   #��z��6A   $  20��6k   $��40��6}   $	��250��6�   ._�5;   .   �� $��Center=�6?   $��Center=�6\   5<   +    �� Triggers 5=   *   P� 5>   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5?   2   ��  �� 
TargetName$ border��69    � �� �#1976D26c   5@   /   5B   '   5D      5E      5G      �� 5I      $��Center=�6   $��0,10,0,0q�69   $
 Hand��6K   ���#2196F3�� 5J        DontHaveAccountText#��  6    �� 5K        
SignUpText#���  5L      
�������$��0q�5N      ���#2196F3$��0,0,0,-4q�5P      $
 Hand��5Q      ��5K      �� *GoToSignUpCommand+5S      5T      5V      5W      5X      5Y      