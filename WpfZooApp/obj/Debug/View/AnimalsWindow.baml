   M S B A M L   `   `   `  ����D  @WpfZooApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:WpfZooApp.ViewWpfZooApp.View  5   	   "    WpfZooApp.View.AnimalsWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:WpfZooApp.View     5   	     � Title$  AnimalsWindow��5   	   $	��650��6   $	��900��6,   ���#F4E8D3.��5	      � $��20q�6   .+�5
   
   �� $
��Left=�6   $	��Top=�60   $	��380��6H   .+�5      �� $)��#Название животного��6   $��SemiBold"�62   $��16(�6H   ���#5050506V   �� 5      -   5         ��Name$ AnimalNameTextBox��5      $��
0, 5, 0, 5q�61   $��14(�6E   $��5q�6S   �� 5      $��ID вида��6   $��SemiBold"�6'   $��16(�6=   ���#5050506K   �� 5      -   5         ��Name$ SpeciesIdComboBox��5      $��
0, 5, 0, 5q�62   $��14(�6F   $��5q�6T   �� 5      $��ID вольера��6   $��SemiBold"�6*   $��16(�6@   ���#5050506N   �� 5      -   5        $ EnclosureIdComboBox��5      $��
0, 5, 0, 5q�64   $��14(�6H   $��5q�6V   �� 5      -   5        $'��!Добавить животное��5      ���#67BA80
�������$��25��6q   $��12(�6}   $��0, 10, 0, 0q�6�   �� 5      -   5        $ ��Редактировать��5      ���#67BA80
�������$��25��6p   $��12(�6|   $��0, 10, 0, 0q�6�   �� 5      -   5        $��Удалить��5      ���#FF4C4C
�������$��25��6j   $��12(�6v   $��0, 10, 0, 0q�6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ AnimalsDataGrid��5         AutoGenerateColumns . $
��Left=�6G   $	��400��6i   $	��380��6u   $��0,0,20,0q�6�   $��Right=�6�   $	��Top=�6�   
�������
�������
���   �   RowBackground
 �����   AlternatingRowBackground �#F4E8D36:  5      5      