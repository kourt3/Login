Imports Login.Core
Imports Login.Core.Ables
Namespace DTOs
    Public Interface ILoginUserNameDTO
        Inherits Ables.IUserName, Ables.IPassword
    End Interface
    Public Interface ILoginEmailDTO
        Inherits Ables.IEmail, Ables.IPassword
    End Interface
    Public Interface ILoginPhoneDTO
        Inherits Ables.IPhone, Ables.IPassword
    End Interface

    Public Interface IRegisterUserNameDTO
        Inherits Ables.IUserName, Ables.IPassword
    End Interface
    Public Interface IRegisterEmailDTO
        Inherits Ables.IEmail, Ables.IPassword
    End Interface
    Public Interface IRegisterPhoneDTO
        Inherits Ables.IPhone, Ables.IPassword
    End Interface


    Public Interface IChangeEmailDTO
        Inherits Ables.IEmail
    End Interface
    Public Interface IChangePhoneDTO
        Inherits Ables.IPhone
    End Interface
    Public Interface IChangeUserNameDTO
        Inherits Ables.IUserName
    End Interface
    Public Interface IChangePasswordDTO
        Inherits Ables.IPassword
    End Interface



    Public Interface IDeleteUsernameDTO
        Inherits Ables.IUserName
    End Interface

    Public Interface IDeleteEmailDTO
        Inherits Ables.IEmail
    End Interface
    Public Interface IDeletePhoneDTO
        Inherits Ables.IPhone
    End Interface


    Public Interface IRemoveAccountUsernameDTO
        Inherits Ables.IUserName, Ables.IPassword
    End Interface

    Public Interface IRemoveAccountEmailDTO
        Inherits Ables.IEmail, Ables.IPassword
    End Interface

    Public Interface IRemoveAccountPhoneDTO
        Inherits Ables.IPhone, Ables.IPassword
    End Interface

    Public Class DTOs
        Implements ILoginUserNameDTO, ILoginEmailDTO, ILoginPhoneDTO
        Implements IRegisterUserNameDTO, IRegisterEmailDTO, IRegisterPhoneDTO
        Implements IChangeEmailDTO, IChangeUserNameDTO, IChangePasswordDTO, IChangePhoneDTO
        Implements IDeleteUsernameDTO, IDeleteEmailDTO, IDeletePhoneDTO
        Implements IRemoveAccountUsernameDTO, IRemoveAccountEmailDTO, IRemoveAccountPhoneDTO

        Public Property Username As String Implements IUserName.Username
        Public Property Password As String Implements IPassword.Password
        Public Property Email As String Implements IEmail.Email
        Public Property Phone As String Implements IPhone.Phone

    End Class
End Namespace
