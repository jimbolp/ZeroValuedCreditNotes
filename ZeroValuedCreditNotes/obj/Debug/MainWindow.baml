   M S B A M L   `   `   `  ����P  LZeroValuedCreditNotes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ZeroValuedCreditNotesZeroValuedCreditNotes  5   	   &     ZeroValuedCreditNotes.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ZeroValuedCreditNotes     5   	     � Title$#  Нулеви Кредитни��5   	   $��391.907��6!   $��392.294��62    � Icon$ money_poK_icon.ico��6B    � SizeToContent$ WidthAndHeight=�6\   $	��768��6{   $
��1024��6�   .��5	      � .+�5
   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ dateFrom��5
      $��	10,10,0,0q�6'   $	��Top=�6:      FirstDayOfWeek$ Monday=�6R   $
��Left=�6j   $	��164��6�     5   
   -   5        $ dateTo��5      $��	0,10,10,0q�6%   $	��Top=�68   $ Monday=�6P   $��Right=�6h   $	��164��6�   $��5��6�   �� 5   
   -   5         ��Name$ getInvoices��5      $)��#Изтегли информация��6&   $��
10,69,10,0q�6C   $	��Top=�6W   6o   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��10,94,10,10q�6S   !   EnableColumnVirtualization .    
IsReadOnly . 	 J� RenderTransformOrigin$	 0.5,0.5&�6�   
   ClipboardCopyMode$
 IncludeHeader=�6�    � ContextMenu 5      �� 5      .@�5      m� -   5        $��	SelectAll��5       �� IsTextSearchEnabled .  m� Command$# ApplicationCommands.SelectAll��6m   m� 5      $ ApplicationCommands.Copy��6   $
��Copy��6B   5      5      �� 5   
   -   5         ��Name$ chckBox_Sofia��5      $��
София��6*   $
��Left=�6:   $��	10,39,0,0q�6U   $	��Top=�6h    d� 	IsChecked$
 TrueY�6�   �� 5   
   -   5        $ chckBox_Burgas��5      $��Бургас��6+   $
��Left=�6<   $��	71,39,0,0q�6W   $	��Top=�6j   $
 TrueY�6�   �� 5   
   -   5        $ chckBox_Plovdiv��5      $��Пловдив��6,   $��
132,39,0,0q�6>   $	��Top=�6R   $
 TrueY�6j   $
��Left=�6{   $��68��6�   �� 5   
   -	   5        $ chckBox_Varna��5      $��
Варна��6*   $��
205,39,0,0q�6:   $	��Top=�6N   $
 TrueY�6f   $
��Left=�6w   $��53��6�   �� 5   
   -
   5        $ chckBox_VelikoTyrnovo��5      $!��Велико Търново��62   $��
263,39,0,0q�6K   $	��Top=�6_   $
 TrueY�6w   $
��Left=�6�   $	��111��6�   5      5      