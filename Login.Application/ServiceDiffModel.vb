Imports FoundationLibrary.Interfaces.ValMsg
Imports FoundationLibrary.ValMsg
Imports Login.Application.DTOs
Imports Login.Core

Namespace Services
    Public Class LoginServiceDiffModel(Of TModel As FoundationLibrary.Interfaces.Keys.IHasPrimaryKey(Of Int32))
        Inherits FoundationLibrary.Services.ServicesDiffModels(Of Integer, TModel, Login.Core.Entity.Entity, Login.Infastructure.Repository)

        Sub New(AddresToMemberizeClone As FoundationLibrary.Services.ServicesDiffModels(Of Integer, TModel, Login.Core.Entity.Entity, Infastructure.Repository).DelMemberizeClone)
            MyBase.New(New Infastructure.Repository, AddresToMemberizeClone)
        End Sub

        Function Login(LoginDTO As DTOs.ILoginDTO) As FoundationLibrary.ValMsg.ValMsg(Of TModel)


            Dim Result As New ValMsg(Of TModel)
            If Repository.Exist(LoginDTO) Then
                Result.Success = True
                Result.Msg = "Βρέθηκε ο Χρήστης."
                Result.Model = MyBase.MemberizeClone.Invoke(Repository.Find(LoginDTO))
                Return Result
            End If

            Result.Success = False
            Result.Msg = "Δεν Βρέθηκε ο χρήστης!"
            Return Result
        End Function

        Public Overrides Function Change(Of DTO)(Ref As Entity.Entity, ChangeDTO As DTO) As IValMsg
            Dim Val As New ValMsg
            If TypeOf ChangeDTO Is Ables.IUserName Then
                Console.WriteLine("True")
                Dim ChangeDTOLink As Ables.IUserName = ChangeDTO
                If Repository.ExistByUsername(ChangeDTOLink.Username) Then
                    With Val
                        .Success = False
                        .Msg = "Παρακαλώ άλλαξε Username!"
                    End With
                    Return Val
                End If
            End If
            Return MyBase.Change(Ref, ChangeDTO)
        End Function

        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of TModel)
            Dim LinkRegisterDTO As DTOs.IRegisterDTO = RegisterDTO
            Dim Val As New ValMsg(Of Entity.Entity)
            If Repository.ExistByUsername(LinkRegisterDTO.Username) Then
                With Val
                    .Success = False
                    .Msg = "Παρακαλώ άλλαξε Username!"
                End With
                Return Val
            End If

            Return MyBase.Register(RegisterDTO)
        End Function

        Public Overrides Function ToEntity(Of TDTO)(DTO As TDTO) As Core.Entity.Entity
            Dim Entity As New Entity.Entity


            If GetType(TDTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTO
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(TDTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTO
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(TDTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTO
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(TDTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTO
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(TDTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTO
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of TDTO)(DTO As TDTO, Entity As Core.Entity.Entity) As Core.Entity.Entity

            If GetType(TDTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTO
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(TDTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTO
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(TDTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTO
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(TDTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTO
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(TDTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTO
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function
    End Class
End Namespace

