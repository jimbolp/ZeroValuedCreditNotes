   M S B A M L   `   `   `  ���� P  LZeroValuedCreditNotes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ZeroValuedCreditNotesZeroValuedCreditNotes  &     ZeroValuedCreditNotes.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5local#clr-namespace:ZeroValuedCreditNotes       � Title$#  Нулеви Кредитни��$��391.907��$��392.294�� � Icon$ money_poK_icon.ico�� � SizeToContent$ WidthAndHeight=�$	��768��$
��1024��.��� .+�(  "System.Windows.Controls.DatePicker  -     Name$ dateFrom��$��	10,10,0,0q�$	��Top=�   FirstDayOfWeek$ Monday=�$
��Left=�$	��164��  -   $ dateTo��$��	0,10,10,0q�$	��Top=�$ Monday=�$��Right=�$	��164��$��5���� -    ��Name$ getInvoices��$)��#Изтегли информация��$��
10,69,10,0q�$	��Top=�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��10,94,10,10q�!   EnableColumnVirtualization .    
IsReadOnly . 	 J� RenderTransformOrigin$	 0.5,0.5&�
   ClipboardCopyMode$
 IncludeHeader=� � ContextMenu �� .@�m� -   $��	SelectAll�� �� IsTextSearchEnabled .  m� Command$# ApplicationCommands.SelectAll��m� $ ApplicationCommands.Copy��$
��Copy���� -    ��Name$ chckBox_Sofia��$��
София��$
��Left=�$��	10,39,0,0q�$	��Top=� d� 	IsChecked$
 TrueY��� -   $ chckBox_Burgas��$��Бургас��$
��Left=�$��	71,39,0,0q�$	��Top=�$
 TrueY��� -   $ chckBox_Plovdiv��$��Пловдив��$��
132,39,0,0q�$	��Top=�$
 TrueY�$
��Left=�$��68���� -	   $ chckBox_Varna��$��
Варна��$��
205,39,0,0q�$	��Top=�$
 TrueY�$
��Left=�$��53���� -
   $ chckBox_VelikoTyrnovo��$!��Велико Търново��$��
263,39,0,0q�$	��Top=�$
 TrueY�$
��Left=�$	��111��