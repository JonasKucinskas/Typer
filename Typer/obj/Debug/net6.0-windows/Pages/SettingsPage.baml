   M S B A M L   `   `   `  ����@  <Typer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Typer.PagesTyper.Pages  5          Typer.Pages.SettingsPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Typer.Pages     5        N� Title$  SettingsPage��5	      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� -   5        $��SelectTimeLabel��5   1   $��1��6   $��4��6!   $��Select Time��6H   $��Center=�6[   �� 5    
   -   5        $��TimeSelectField��5    /   $��2��6   $��4��6   $��Center=�6F   $��5q�6c   $��50��6n    �� TextAlignment$ Center=�6y   �� 5!   
   -   5        $��
DoneButton��5!      $��4��6#   $��4��60   $��Save and exit��6@   $#��NavigationCommands.BrowseBack��6X   $��20��6�   $��Bottom=�6�   $
��Left=�6�   6�   �� 5#   
   -   5        $��LanguageSelectBox��5#      $��3��6,   $��4��69   $��10q�6I   $��Center=�6U   $��Center=�6r   6�   �� 5$   
   -   5        $��UploadWordFiles��5$      $��Upload word files��6(   $��4��6D   $��4��6Q   $��20��6a   $	��110��6m   $��Right=�6y   $��Bottom=�6�   6�   �� 5%   
   -   5        $��DeleteWordFiles��5%      $��Delete word files��6(   $��4��6D   $��4��6Q   $��20��6a   $	��110��6m   $��Right=�6y   $��Bottom=�6�   $��0,0,0,25q�6�   6�   5(      5)      