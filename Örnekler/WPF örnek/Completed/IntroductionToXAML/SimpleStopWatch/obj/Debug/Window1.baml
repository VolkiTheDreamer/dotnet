   M S B A M L   `   `   `  ����J  FSimpleStopWatch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfStopWatchWpfStopWatch  5          SimpleStopWatch.Window1   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      *localclr-namespace:WpfStopWatch    5        � Title$  Simple Stop Watch��5      $	��150��6   $	��250��6,    � Topmost .  � 	Resources 5         WpfStopWatch.Ticker   localTicker �� 
TargetType  ButtonStyle �� Property �� Value��%�   &	        &	        5   
   6   �� 5	   
   " ��6   .�5
      ��  � ��$ 16(�6)   �� 5       � ��$ 3q�6'   �� 5       � ��$ 7,3,7,3q�6(   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      � 	 � Offset$	 0Q�6   
 � Color$
 	AliceBlue��6*   � 5      $		 0.7Q�6   $
 	SteelBlue��6,   5      .+�5   
   �� $��0��6   $��48(�5      $��Center=�5      $��Center=�61    � DataContext# [  5      ��5       �� *DisplayInterval+�� 5#   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�5$      $��5q�62   .+�5&      �� -   5         ��Name$ startButton��5&      $��16(�5'      $��3q�5(      $��7,3,7,3q�5)      $��Start��5+   7   5,      �� 5.      -   5        $ 
stopButton��5.      #��[ 5/      .��50   .   Stop64   �� 52      -   5        $ clearButton��52      #��[ 53      $��Clear��54      55      56      57      58      