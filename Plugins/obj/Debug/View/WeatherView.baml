   M S B A M L   `   `   `  ����B  >Plugins, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Plugins.ViewPlugins.View  5          Plugins.View.WeatherView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Plugins.View     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      
�������.��5      �   � RowDefinitions  5   
   �� 5      $
��0.2* �6   �� 5      .+�5   
   �� $��0��6   $��  BACK TO OPTIONS��6"   $��20(�6;   $
��Bold"�6I   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ 	MouseDown��6%   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 60   �� *
BackToMenu+5      5      �� 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��Center=�6O   .+�5      �� $��
Pressure: ��6   $��18(�6.   �� 5      $��18(�6D   ��6   �� *WeatherInfo.pressure+6D   5      �� 5      $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��Temperature: ��6   $��18(�61   �� 5      $��18(�6@   ��6   �� *WeatherInfo.temp+6@   �� 5      $��	 C degree��6   $��18(�6.   5       �� 5!      $ 
Horizontal=�6   $��Center=�62   .+�5"      �� $��
Humidity: ��6   $��18(�6.   �� 5#      $��18(�6D   ��6   �� *WeatherInfo.humidity+6D   5$      5%      5&      5'      