;#DropDB SalaryTrackingSolutionEasyTest

#Application SalaryTrackingSolutionWin
;#Application SalaryTrackingSolutionWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef SalaryTrackingSolutionWin

*Action About...
 
*Action OK

#EndIf

#IfDef SalaryTrackingSolutionWeb
*Action Navigation(My Details)
#EndIf
