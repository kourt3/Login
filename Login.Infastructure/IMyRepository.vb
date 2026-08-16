
Public Interface IMyRepository

    Function FindByUserNameAndPassword(UserName As String, Password As String) As Core.Entity.Entity
    Function ExistByUsernameAndPassword(UserName As String, Password As String) As Boolean
    Function ExistByUsername(Username As String) As Boolean
    Function ExistByPassword(Password As String) As Boolean
End Interface
