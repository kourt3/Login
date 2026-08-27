Imports Login.Core

''' <summary>
''' Repository Dynamic Memory
''' </summary>
Public Class Repository

    Inherits FoundationLibrary.Repositories.Repository(Of Integer, Entity.Entity)

    Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean

        'UserName
        If GetType(TCreteria).GetInterfaces.Contains(GetType(Core.Ables.IUserName)) Then
            Dim Username As Core.Ables.IUserName = Creteria
            If Username.Username <> Entity.Username Then Return False
        End If
        'Email
        If GetType(TCreteria).GetInterfaces.Contains(GetType(Core.Ables.IEmail)) Then
            Dim Username As Core.Ables.IEmail = Creteria
            If Username.Email <> Entity.Email Then Return False
        End If
        'Phone
        If GetType(TCreteria).GetInterfaces.Contains(GetType(Core.Ables.IPhone)) Then
            Dim Username As Core.Ables.IPhone = Creteria
            If Username.Phone <> Entity.Phone Then Return False
        End If
        'Password
        If GetType(TCreteria).GetInterfaces.Contains(GetType(Core.Ables.IPassword)) Then
            Dim Username As Core.Ables.IPassword = Creteria
            If Username.Password <> Entity.Password Then Return False
        End If
        'CreateAt
        If GetType(TCreteria).GetInterfaces.Contains(GetType(Core.Ables.ICreateAt)) Then
            Dim Username As Core.Ables.ICreateAt = Creteria
            If Username.CreateAt <> Entity.CreateAt Then Return False
        End If
        Return True
    End Function

End Class
