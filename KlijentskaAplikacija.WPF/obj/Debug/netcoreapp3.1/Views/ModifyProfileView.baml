   M S B A M L   `   `   `  ����S  OKlijentskaAplikacija.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:KlijentskaAplikacija.WPF.ViewsKlijentskaAplikacija.WPF.Views  5      6    0KlijentskaAplikacija.WPF.Views.ModifyProfileView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:KlijentskaAplikacija.WPF.Views     5      ��5	      �� 5
   
     �� ImageSource$  /Resources/profile.png��6    j� Stretch$ UniformToFill=�6:    �� Opacity$	 0.5Q�6R   .��5      �� $��10q�6    �� Padding$ 50q�6   $��Center=�6'   $��Center=�6D      BrushPrimary2#��[  5       �� CornerRadius$ 10��6;   $��3q�6M   
������  J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 12Q�6      Color$
 Gray��6/   ._�5   
   �  � IsSharedSizeScope$
 True��6   	 � RowDefinitions	 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��Modify profile��6&   $��Center=�6<   $��28(�6Y   � 5      $��1��6   $
��0 10q�6    
 � ColumnDefinitions
 5      �� 5       z� SharedSizeGroup$ Label��6'   $
��auto �6?   �� 5      $	��300 �6'   .+�5      �� $��0��6   $��
First name��6-   �� 5       $��1��6   $��20 0 0 0q�6+   ��6=   �� *	FirstName+ �� UpdateSourceTrigger$ PropertyChanged=�5!      � 5"      $��2��6   $
��0 10q�6    
 5#      �� 5$      $ Label��6'   $
��auto �6?   �� 5%      $	��300 �6'   .+�5'      �� $��0��6   $��	Last name��6-   �� 5(      $��1��6   $��20 0 0 0q�6+   ��6=   �� *
LastName+$ PropertyChanged=�5*      �� 5+      $��3��6   $��2��6"   $
��0 10q�62   $��Confirm��6@   $��Center=�5,       �� 	IsDefault$
 true��6W   ��6.   �� *ModifyProfileCommand+6W   �� 5-      $��4��6   $��Oblique$�6>   
���  ��$��Center=�6c   ��6%   �� *	Warning+6c   5.      5/      50      