Imports FoundationLibrary.Interfaces.ValMsg
Imports FoundationLibrary.Repositories
Imports FoundationLibrary.Services
Imports FoundationLibrary.ValMsg
Imports Login.Core
Imports Login.Infastructure

Namespace Services
    Public Class LoginServiceCloneEntity
        Inherits ServiceCE(Of Integer, Entity.Entity, Repository)

        Sub New()
            MyBase.New(New Repository)
        End Sub


        Function Login(LoginDTO As DTOs.ILoginDTO) As FoundationLibrary.ValMsg.ValMsg(Of Entity.Entity)


            Dim Result As New ValMsg(Of Entity.Entity)
            If Repository.Exist(LoginDTO) Then
                Result.Success = True
                Result.Msg = "Βρέθηκε ο Χρήστης."
                Result.Model = MemberizeClone(Repository.Find(LoginDTO))
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

        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of Entity.Entity)
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



        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Entity.Entity


            If GetType(DTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function MemberizeClone(Enity As Entity.Entity) As Entity.Entity
            Dim NewEntiry As New Entity.Entity
            With NewEntiry
                .PrimaryKey = Enity.PrimaryKey
                .Username = Enity.Username
                .Password = Enity.Password
                .CreateAt = Enity.CreateAt
            End With
            Return NewEntiry
        End Function
    End Class

    Public Class LoginServiceOfficialEntity
        Inherits FoundationLibrary.Services.ServiceE(Of Integer, Entity.Entity, Repository)

        Sub New()
            MyBase.New(New Repository)
        End Sub


        Function Login(LoginDTO As DTOs.ILoginDTO) As FoundationLibrary.ValMsg.ValMsg(Of Entity.Entity)

            Dim Result As New ValMsg(Of Entity.Entity)
            If Repository.Exist(LoginDTO) Then
                Result.Success = True
                Result.Msg = "Βρέθηκε ο Χρήστης."
                Result.Model = Repository.Find(LoginDTO)
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

        Public Overrides Function Register(Of DTO)(RegisterDTO As DTO) As IValMsg(Of Entity.Entity)
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

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Entity.Entity


            If GetType(DTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function
    End Class
    Public Class LoginServiceModel(Of TModel As FoundationLibrary.Interfaces.Keys.IHasPrimaryKey(Of Int32))

        Inherits FoundationLibrary.Services.Service(Of Integer, TModel, Core.Entity.Entity, Repository)


        Sub New()
            MyBase.New(New Repository)
        End Sub

        Public Overrides Function ToModel(Entity As Entity.Entity) As TModel
            Dim NewEntity As New Entity.Entity
            With NewEntity
                .PrimaryKey = Entity.PrimaryKey
                .Username = Entity.Username
                .Password = Entity.Password
                .CreateAt = Entity.CreateAt
            End With
            Return DirectCast(CType(NewEntity, Object), TModel)
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO) As Entity.Entity
            Dim Entity As New Entity.Entity


            If GetType(DTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function

        Public Overrides Function ToEntity(Of DTO)(DTOLink As DTO, Entity As Entity.Entity) As Entity.Entity
            If GetType(DTO) Is GetType(DTOs.ILoginDTO) Then
                Dim Obj As DTOs.ILoginDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IRegisterDTO) Then
                Dim Obj As DTOs.IRegisterDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeNameDTO) Then
                Dim Obj As DTOs.IChangeNameDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangePasswordDTO) Then
                Dim Obj As DTOs.IChangePasswordDTO = DTOLink
                With Entity
                    .Password = Obj.Password
                End With
            ElseIf GetType(DTO) Is GetType(DTOs.IChangeUsernameAndPasswordDTO) Then
                Dim Obj As DTOs.IChangeUsernameAndPasswordDTO = DTOLink
                With Entity
                    .Username = Obj.Username
                    .Password = Obj.Password
                End With
            End If
            Return Entity
        End Function

    End Class
End Namespace