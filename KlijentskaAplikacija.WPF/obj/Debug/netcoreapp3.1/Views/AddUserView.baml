   M S B A M L   `   `   `  ����S  OKlijentskaAplikacija.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:KlijentskaAplikacija.WPF.ViewsKlijentskaAplikacija.WPF.Views  5      0    *KlijentskaAplikacija.WPF.Views.AddUserView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:KlijentskaAplikacija.WPF.Views     5      ��5	      �� 5
   
     �� ImageSource$  /Resources/profile.png��6    j� Stretch$ UniformToFill=�6:    �� Opacity$	 0.5Q�6R   .��5      �� $��10q�6    �� Padding$ 50q�6   $��Center=�6&   $��Center=�6C      BrushPrimary2#��[  5       �� CornerRadius$ 10��6;   $��3q�6M   
������  J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 12Q�6      Color$
 Gray��6/   ._�5   
   �  � IsSharedSizeScope$
 True��6   	 � RowDefinitions	 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��Add User��6&   $��Center=�66   $��28(�6S   � 5      $��1��6   $
��0 10q�6    
 � ColumnDefinitions
 5       �� 5!       z� SharedSizeGroup$ Label��6'   $
��auto �6?   �� 5"      $	��300 �6'   .+�5$      �� $��0��6   $��Username��6-   �� 5%      $��1��6   $��20 0 0 0q�6+   ��6=   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5&      � 5'      $��2��6   $
��0 10q�6    
 5(      �� 5)      $ Label��6'   $
��auto �6?   �� 5*      $	��300 �6'   .+�5,      �� $��0��6   $��
First name��6-   �� 5-      $��1��6   $��20 0 0 0q�6+   ��6=   �� *	FirstName+$ PropertyChanged=�5.      � 5/      $��3��6   $
��0 10q�6    
 50      �� 51      $ Label��6'   $
��auto �6?   �� 52      $	��300 �6'   .+�54      �� $��0��6   $��	Last name��6-   �� 55      $��1��6   $��20 0 0 0q�6+   ��6=   �� *
LastName+$ PropertyChanged=�56      � 57      $��4��6   $
��0 10q�6    
 58      �� 59      $ Label��6'   $
��auto �6?   �� 5:      $	��300 �6'   .+�5<      �� $��0��6   $��Password��6-   �� 5=      $��1��6   $��20 0 0 0q�6+   ��6=   �� *
Password+$ PropertyChanged=�5>      � 5?      $��5��6   $
��0 10q�6    
 5@      �� 5A      $ Label��6'   $
��auto �6?   �� 5B      $	��300 �6'   .+�5D      �� $��0��6   $��Confirm password��6-   �� 5E      $��1��6   $��20 0 0 0q�6+   ��6=   �� *ConfirmPassword+$ PropertyChanged=�5F      � 5G      $��6��6   $
��0 10q�6    
 5H      �� 5I      $ Label��6'   $
��auto �6?   �� 5J      $	��300 �6'   .+�5L      �� $��0��6   $��Is user administrator��6-   �� 5M      $��1��6   $��20 0 0 0q�6+    d� 	IsChecked 6=   �� *IsAdministrator+$ PropertyChanged=�5O      �� 5P      $��7��6   $��2��6"   $
��0 10q�62   $��Confirm��6@   $��Center=�5Q       �� 	IsDefault$
 true��6Q   ��6.   �� *AddUserCommand+6Q   �� 5R      $��8��6   $��Oblique$�6>   
���  ��$��Center=�6c   ��6%   �� *	Warning+6c   5S      5T      5U      