   M S B A M L   `   `   `  ����D  @WpfZooApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfZooApp.ViewWpfZooApp.View  5   	   -    'WpfZooApp.View.VeterinaryCheksOldWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfZooApp.View     5   	     � Title$  VeterinaryCheksOldWindow��5   	   $	��650��6*   $	��900��67   ���#F4E8D3.��5	      � $��20q�6   .+�5
   
   �� $
��Left=�6   $	��Top=�60   $	��380��6H   .+�5      �� $)��#Название животного��6   $��SemiBold"�62   $��16(�6H   ���#5050506V   �� 5      -   5         ��Name$ AnimalIdComboBox��5      $��
0, 5, 0, 5q�61   $��14(�6E   $��5q�6S   �� 5      $��Дата осмотра��6   $��SemiBold"�6,   $��16(�6B   ���#5050506P   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ CheckDateDatePicker��5      $��
0, 5, 0, 5q�66   $��14(�6J   $��5q�6X   �� 5      $'��!Результат осмотра��6   $��SemiBold"�61   $��16(�6G   ���#5050506U   �� 5      -   5         ��Name$ ResultTextBox��5      $��
0, 5, 0, 5q�6-   $��14(�6A   $��5q�6O   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$! VeterinaryChecksOldDataGrid��5         AutoGenerateColumns . $
��Left=�6S   $	��400��6u   $	��380��6�   $��0,0,20,0q�6�   $��Right=�6�   $	��Top=�6�   
�������
�������
���   �   RowBackground
 �����   AlternatingRowBackground �#F4E8D36F  5      5      