   M S B A M L   `   `   `  ����C  ?PMSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PMSystem.ViewPMSystem.View  5          PMSystem.View.SignUpView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PMSystem.View     5      .��5
      � ���#f0f2f5.+�5   
   �� $	��350��6   $	��500��5      
�������  �� CornerRadius$  10��5      $��Center=�5      $��Center=�5       �� Padding$ 20q�5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      ShadowDepth$ 3Q�63      Color$ 	#66000000��6C   ._�5      ��  �� Orientation$ Vertical=�6   $��Center=�60   .+�5      �� -   5        $��En��5      $��30��5      
�������$	��0.5q�5       � Cursor$
 Hand��5      $��Right=�5      5      �� 5          SignUpTitle#���   6   $��28(�6A   $��SemiBold"�6O   ���#333$��Center=�6w   $
��0,10q�6�   �� 5"        UsernameLabel#���  6   $��0,20,0,5q�6C   ���#5556U   �� 5#      ���#ccc$��0,0,0,1q�6l   
������ $	��0,5q�6�   ��6   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5%        
EmailLabel#���  6   $��0,20,0,5q�6@   ���#5556R   �� 5&      ���#ccc$��0,0,0,1q�6i   
������ $	��0,5q�6�   ��6   �� *Email+$ PropertyChanged=�6�   �� 5(        PasswordLabel#���  6   $��0,20,0,5q�6C   ���#5556U   G� 5)      -   5        	 G�Name$	 PasswordBox��5)      ���#ccc$��0,0,0,1q�5+   1   
������ $	��0,5q�6d   �� 5-        
SignUpText#���  6   ���#2196F3
�������$��	0,30,0,10q�51      $��40��52      $��0q�53      $	��250��55      $��Center=�56      ��5.      �� *SignUpCommand+��57      �� 58      
 �� 
TargetType"
 ��6    .�59      ��  �� Property � �� �� Value 5:   "   �� 5;   &    �� 
TargetType" ��66   .R�5<   *   ��  ��Name$ border��61   #��z��6A   $  20��6k   $��40��6}   $	��250��6�   ._�5=   .   �� $��Center=�6?   $��Center=�6\   5>   +    �� Triggers 5?   *   P� 5@   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5A   2   ��  �� 
TargetName$ border��69    � �� �#1976D26c   5B   /   5D   '   5F      5G      5I      �� 5K      $��Center=�6   $��0,10,0,0q�6:   $
 Hand��6L   ���#2196F3�� 5L        AlreadyHaveAccount#��  6    �� 5M      -   5          
LoginTitle#���  5N   >   $��0,0,0,-4q�6e   
�������$��0q�5O   ,   ���#2196F3$��Center=�5P      $
 Hand��66   ��5N      �� *GoToLoginCommand+5R      5S      5U      5V      5W      5X      