   M S B A M L   `   `   `  ����T  PWpf_MVVM_WriteToSQLServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Wpf_MVVM_WriteToSQLServerWpf_MVVM_WriteToSQLServer  5   	   +    %Wpf_MVVM_WriteToSQLServer.CountryView   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Wpf_MVVM_WriteToSQLServer     5   	     � Title$  CountryView��5   	   $	��450��6   $	��800��6*    � DataContext 5	      0   *Wpf_MVVM_WriteToSQLServer.CountryViewModel  5
   
   .��5      �� 
�������.+�5   
   �� $��30(�6   $��45��6   $	��WPF��6+   $��Center=�69   �� 5   
   $��30(�6   $��45��6   $%��MVVM : Write date to SQL Server��6+   $��Center=�6U   �� 5   
   $��30(�6   $��45��6#   $��Country name:��6/   $��Center=�6D   �� 5   
   $��30(�6   $��45��6!   $	��300��6-   $��Center=�6{   ��69   �� *CountryName+ �� UpdateSourceTrigger$ PropertyChanged=�6{   �� 5   
   $��30(�6   $��45��6#   $��	Greeting:��6/   $��Center=�6@   �� 5   
   $��30(�6   $��45��6!   $	��300��6-   $��Center=�6x   ��69   �� *
Greeting+$ PropertyChanged=�6x   �� 5   
   $��30(�6   $��45��6#   $��10q�6/   $��Center=�6~   ��6;   �� *ErrorMessage+$ PropertyChanged=�6~   �� 5   
   $
��Save��6   $��30(�6    $��45��6/   $	��100��6;   $��Center=�6c   $��10q�6�   ��6G   �� *	cmdSave+6�   5      5      