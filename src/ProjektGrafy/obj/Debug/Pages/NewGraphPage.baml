   M S B A M L   `   `   `  ����G  CProjektGrafy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjektGrafy.PagesProjektGrafy.Pages  5      %    ProjektGrafy.Pages.NewGraphPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ProjektGrafy.Pages     5        N� Title$  NewGraphPage��5	      .��5      � -   5         �Name$ MainGrid��5       � ColumnDefinitions 5   
   �� 5      $
��273* �6   �� 5      $
��273* �6   �� 5      $
��255* �6   .+�5   
   �� -   5         ��Name$ 
LineCanvas��5      $
��Left=�6%   $	��440��6@   $	��Top=�6M   $	��545��6e   $��2��6q   �� 5   
   -   5         ��Name$ Button_AddLeft��5      $��Dodaj wierzchołek��6)   $	��Top=�6E   $��
40,38,40,0q�6]   $��50��6q   $��22(�6�   ���	#FFFFC300
�������   ButtonStyleGraphApp#���   6�   $��3q�6   ���	#FFFFC3006  �� 5   
   -   5        $ Button_AddRight��5      $��Dodaj wierzchołek��6*   $	��Top=�6F   $��
40,39,40,0q�6^   $��49��6r   $��1��6�   $��22(�6�   
����������	#FFFFC300#���   6�   $��3q�6  ���	#FFFFC3006&  � 5   
   -   5        $ LeftGrid��5      $��60,92,60,10q�6!   � 5   
   -   5        $ 	RightGrid��5      $��62,93,60,10q�6"   $��1��67   �� 5   
   $��2��6   $��
10,39,77,0q�6$   $
��Wrap=�68   $%��Aktualnie wybrany wierzchołek:��6L   $	��Top=�6r   $��28��6�   $��20(�6�   
�������6�   �� 5   
   -   5         ��Name$ ActualVertex_Info��5      $��2��6/   $��180,28,27,0q�6?   $
��Wrap=�6T    �� TextAlignment$ Center=�6h   $	��Top=�6   $��54��6�   $��RightToLeft=�6�   $��36(�6�   
�������6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ConnectionsTable��5      $��2��6-   $	��158��6=   $��
29,93,27,0q�6J   $	��Top=�6^      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6v   	   CanUserResizeColumns	 .  
   CanUserReorderColumns
 .     
IsReadOnly .    SelectionMode$ Single=�6�   $��18(�6      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Połączone z��6%      
Foreground
 �   �   FontSize$ 16Q�6j   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
idNumber+6j   5      �� 5   
   -	   5        $ AddConnection_Button��5      $��Dodaj połączenie��6/   $	��Top=�6J    J� RenderTransformOrigin$ 0.5,0.5&�6b   $��2��6�   $��29,256,27,0q�6�   $��55��6�   $��22(�6�   ���#ffc300
�������#���   6  $��3q�6:  ���	#FFFFC3006N  �� 5    
   -
   5        $ Save_Button��5       $��Zapisz graf��6&   $��2��6<   $��
29,0,27,26q�6L   $��22(�6`   ���	#FFFFC300
�������$��55��6�   $��Bottom=�6�   #���   6�   $��3q�6  ���	#FFFFC3006  �� 5!   
   -   5        $ Back_Button��5!      $��Cofnij��6&   $��	10,0,0,10q�67   $��35��6J   $��Bottom=�6V   $��20(�6q   
����������	#FFFFC300$
��Left=�6�   $��66��6�   #���   6�   $��3q�6  ���	#FFFFC3006+  5#      5%      