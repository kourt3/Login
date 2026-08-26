Imports Login.Core.Ables
Imports FoundationLibrary.Repositories
Imports FoundationLibrary.Results

Public Class LoginRequest(Of TModel, TRepostiry As IRepository(Of Int32, Core.Entity.Entity))
    Private ReadOnly Service As Services.Service(Of TModel, TRepostiry)
    Private ReadOnly Repository As TRepostiry

    Sub New(Service As Services.Service(Of TModel, TRepostiry))
        Me.Service = Service
        Me.Repository = Me.Service.Repository
    End Sub

    Function UserNameAndPassword(LoginDTO As DTOs.ILoginUserNameDTO)
        Dim Creteria As Infastructure.ICritByUsernameAndPassword = New Infastructure.Creterias
        With Creteria
            .Username = LoginDTO.Username
            .Password = LoginDTO.Password
        End With

        If Repository.Exist(Creteria).Success Then
            Return New FoundationLibrary.Results.Result(Of TModel)(False, "Δεν Ήταν επυτιχης το Login λογο Username.")
        End If

        Return Service.Exist(Repository.Read(Creteria))
    End Function

    Function EmailAndPassword(LoginDTO As DTOs.ILoginEmailDTO)
        Dim Creteria As Infastructure.ICritByEmailAndPassword = New Infastructure.Creterias
        With Creteria
            .Email = LoginDTO.Email
            .Password = LoginDTO.Password
        End With

        If Repository.Exist(Creteria).Success Then

            Return New Result(Of TModel)(False, "Δεν Ήταν επιτηχης η εγραφη λογο Email.")
        End If

        Return Service.Exist(Repository.Read(Creteria))
    End Function

    Function PhoneAndPassword(LoginDTO As DTOs.ILoginPhoneDTO)
        Dim Creteria As Infastructure.ICritByPhoneAndPassword = New Infastructure.Creterias
        With Creteria
            .Phone = LoginDTO.Phone
            .Password = LoginDTO.Password
        End With

        If Repository.Exist(Creteria).Success Then
            Return New Result(Of TModel)(False, "Δεν Ήταν επιτηχης η εγραφη λογο Phone.")
        End If

        Return Service.Exist(Repository.Read(Creteria))
    End Function
End Class
