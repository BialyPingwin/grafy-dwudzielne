   M S B A M L   `   `   `  ����G  CProjektGrafy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ProjektGrafy.PagesProjektGrafy.Pages  5      &     ProjektGrafy.Pages.LoadGraphPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:ProjektGrafy.Pages     5        N� Title$  LoadGraphPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��270* �6   �� 5      $
��270* �6   �� 5      $
��230* �6   .+�5   
   �� -   5         ��Name$ 
LineCanvas��5      $��10q�6%   $��2��61   � 5   
   -   5         �Name$ LeftGrid��5      $��60,30q�6!   � 5   
   -   5        $ 	RightGrid��5      $��1��6"   $��60,30q�62   �� 5   
   -   5         ��Name$ Load_Button��5      $��Wczytaj graf��6&   $	��Top=�6=   $��
50,30,50,0q�6U   $��69��6i   $��20(�6u   $��2��6�   ���#ffc300
�������   ButtonStyleGraphApp#���   6�   $��3q�6  ���	#FFFFC3006  �� 5   
   -   5        $ CheckGraph_Button��5      $	��Top=�6,   $��50,104,50,0q�6D   $	��106��6Y   $��20(�6f   $��2��6t   ���#ffc300#���   6�   $��3q�6�   ���	#FFFFC300.��5      �� $%��Sprawdź czy graf jest zupełny��6   $
��Wrap=�6=    �� TextAlignment$ Center=�6Q   
�������6h   5      �� 5   
   -   5        $ Back_Button��5      $��Cofnij��6&   $��	10,0,0,10q�67   $��20(�6J   $��35��6X   $��Bottom=�6d   ���#ffc300
�������$
��Left=�6�   $��66��6�   #���   6�   $��3q�6  ���	#FFFFC3006)  �� 5   
   -   5         ��Name$ 	ResultBox��5      $��2��6'   $��10,242,10,85q�67   $
��Wrap=�6M   $	��123��6a   $��30(�6n   
�������$ Center=�6�   �� 6�   �� 6�   �� 6�   �� 6�   6�   5      5      