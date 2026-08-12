Imports Login.Core
Imports Login.Core.Ables
Namespace DTOs
    Public Interface ILoginDTO
        Inherits Ables.IUserName, Ables.IPassword
    End Interface
    Public Interface IRegisterDTO
        Inherits Ables.IUserName, Ables.IPassword
    End Interface
    Public Interface IChangeUsernameAndPasswordDTO
        Inherits Ables.IUserName, Ables.IPassword
    End Interface
    Public Interface IChangeNameDTO
        Inherits Ables.IUserName
    End Interface
    Public Interface IChangePasswordDTO
        Inherits Ables.IPassword
    End Interface


    Public Class DTOs
        Implements ILoginDTO, IRegisterDTO, IChangeUsernameAndPasswordDTO, IChangeNameDTO, IChangePasswordDTO, Infastructure.ICritiria

        Public Property Username As String Implements IUserName.Username
        Public Property Password As String Implements IPassword.Password

    End Class
End Namespace
