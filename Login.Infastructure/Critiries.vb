Imports Login.Core.Ables

Public Interface ICritByUserName
    Inherits Core.Ables.IUserName
End Interface
Public Interface ICritByEmail
    Inherits Core.Ables.IEmail
End Interface
Public Interface ICritByPhone
    Inherits Core.Ables.IPhone
End Interface
Public Interface ICritByPassword
    Inherits Core.Ables.IPassword
End Interface
Public Interface ICritByCreateAt
    Inherits Core.Ables.ICreateAt
End Interface

Public Interface ICritByUsernameAndPassword
    Inherits Core.Ables.IUserName, Core.Ables.IPassword
End Interface
Public Interface ICritByEmailAndPassword
    Inherits Core.Ables.IEmail, Core.Ables.IPassword
End Interface

Public Interface ICritByPhoneAndPassword
    Inherits Core.Ables.IPhone, Core.Ables.IPassword
End Interface


Public Class Creterias
    Implements ICritByUserName, ICritByEmail, ICritByPhone, ICritByPassword, ICritByCreateAt
    Implements ICritByUsernameAndPassword, ICritByEmailAndPassword, ICritByPhoneAndPassword

    Public Property Username As String Implements IUserName.Username
    Public Property Email As String Implements IEmail.Email
    Public Property Phone As String Implements IPhone.Phone
    Public Property Password As String Implements IPassword.Password
    Public Property CreateAt As Date Implements ICreateAt.CreateAt

End Class
