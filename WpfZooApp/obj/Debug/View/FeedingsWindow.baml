   M S B A M L   `   `   `  ����D  @WpfZooApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfZooApp.ViewWpfZooApp.View  5   	   #    WpfZooApp.View.FeedingsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfZooApp.View     5   	     � Title$  FeedingsWindow��5   	   $	��650��6    $	��900��6-   ���#F4E8D3.��5	      � $��20q�6   .+�5
   
   �� $
��Left=�6   $	��Top=�60   $	��380��6H   .+�5      �� $��ID животного��6   $��SemiBold"�6,   $��16(�6B   ���#5050506P   �� 5      -   5         ��Name$ AnimalIdComboBox��5      $��
0, 5, 0, 5q�61   $��14(�6E   $��5q�6S   �� 5      $#��Время кормления��6   $��SemiBold"�6/   $��16(�6E   ���#5050506S   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ FeedingTimeDatePicker��5      $��
0, 5, 0, 5q�68   $��14(�6L   $��5q�6Z   �� 5      $��Заметки��6   $��SemiBold"�6'   $��16(�6=   ���#5050506K   �� 5      -   5         ��Name$ NotesTextBox��5      $��
0, 5, 0, 5q�6,   $��14(�6@   $��5q�6N   �� 5      -   5        $)��#Добавить кормление��5      ���#67BA80
�������$��25��6s   $��12(�6   $��0, 10, 0, 0q�6�   �� 5      -   5        $ ��Редактировать��5      ���#67BA80
�������$��25��6q   $��12(�6}   $��0, 10, 0, 0q�6�   �� 5      -   5        $��Удалить��5      ���#FF4C4C
�������$��25��6k   $��12(�6w   $��0, 10, 0, 0q�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ FeedingsDataGrid��5         AutoGenerateColumns . $
��Left=�6H   $	��400��6j   $	��380��6v   $��0,0,20,0q�6�   $��Right=�6�   $	��Top=�6�   
�������
�������
���   �   RowBackground
 �����   AlternatingRowBackground �#F4E8D36;  5      5      