   M S B A M L   `   `   `  ����H  DShutdownTimer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ShutdownTimerShutdownTimer  5   	       ShutdownTimer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ShutdownTimer     5   	     � Title$  Sleep Timer��5   	   $��125.2��6   $��273.6��6,   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      .+�5   
   �� $��5q�6   ._�5      �� $#��/images/app-shutdown-icon.png��6   5      � 5   
   $��10,10,10,10q�6   $	��Top=�6$   $��0��6<   $��1��6I    5      �� 5      $
��Auto �6#   �� 5       5      �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6    .+�5       �� -   5         ��Name$ label��5       $��Time to shutdown:��6#   $
��Left=�6?   $��0��6Z   $��0��6g   $��1��6w   $	��Top=�6�   �� 5!      -   5         ��Name$ textBox��5!      $��0��6'   $��1��64   �� 5"      -   5         ��Name$ 
stackPanel��5"      $��2��6-   $��0��6:   $��2��6J    �� Orientation$ 
Horizontal=�6^   $��Right=�6w    � 	Resources 5#       �� 
TargetType	 �� Property
 �� Value��%Y   '��       �� 5$      " ��6   .�5%      �� 	 � ��$
 	10,10,0,0q�63   5&      5'      .+�5(      �� -   5         ��Name$ btnShutdown��5(      $��Shutdown��6.   6A   �� 5)      -   5        $ btnSleep��5)      $��Sleep��6+   6;   �� 5*      -   5        $ 	btnCancel��5*      $��Cancel��6,   6=   5+      �� 5,      -   5        $ labelTimeRemaining��5,      $��Time remaining:��60   $
��Left=�6J   $��4��6e   $��0��6r   $��1��6�   $	��Top=�6�   5-      5.      5/      