Imports Login.Core

''' <summary>
''' Repository Dynamic Memory
''' </summary>
Public Class Repository

    Inherits FoundationLibrary.Repositories.Repository(Of Integer, Entity.Entity)

    Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
        If GetType(TCreteria) = GetType(ICritByUsernameAndPassword) Then
            Dim Creterias As ICritByUsernameAndPassword = Creteria
            If Creterias.Username IsNot Nothing AndAlso Creterias.Username <> Entity.Username Then Return False
            If Creterias.Password IsNot Nothing AndAlso Creterias.Password <> Entity.Password Then Return False
        ElseIf GetType(TCreteria) = GetType(ICritByEmailAndPassword) Then
            Dim Creterias As ICritByEmailAndPassword = Creteria
            If Creterias.Email IsNot Nothing AndAlso Creterias.Email <> Entity.Email Then Return False
            If Creterias.Password IsNot Nothing AndAlso Creterias.Password <> Entity.Password Then Return False
        ElseIf GetType(TCreteria) = GetType(ICritByPhoneAndPassword) Then
            Dim Creterias As ICritByPhoneAndPassword = Creteria
            If Creterias.Phone IsNot Nothing AndAlso Creterias.Password <> Entity.Password Then Return False
            If Creterias.Password IsNot Nothing AndAlso Creterias.Password <> Entity.Password Then Return False
        ElseIf GetType(TCreteria) = GetType(ICritByUserName) Then
            Dim Creterias As ICritByUserName = Creteria
            If Creterias.Username IsNot Nothing AndAlso Creterias.Username <> Entity.Username Then Return False
        ElseIf GetType(TCreteria) = GetType(ICritByPassword) Then
            Dim Creterias As ICritByPassword = Creteria
            If Creterias.Password IsNot Nothing AndAlso Creterias.Password <> Entity.Password Then Return False
        ElseIf GetType(TCreteria) = GetType(ICritByEmail) Then
            Dim Creterias As ICritByEmail = Creteria
            If Creterias.Email IsNot Nothing AndAlso Creterias.Email <> Entity.Email Then Return False
        ElseIf GetType(TCreteria) = GetType(ICritByPhone) Then
            Dim Creterias As ICritByPhone = Creteria
            If Creterias.Phone IsNot Nothing AndAlso Creterias.Phone <> Entity.Phone Then Return False
        ElseIf GetType(TCreteria) = GetType(ICritByCreateAt) Then
            Dim Creterias As ICritByCreateAt = Creteria
            If Creterias.CreateAt <> Entity.CreateAt Then Return False 'Creterias.CreateAt IsNot Nothing AndAlso
        End If
        Return True
    End Function

End Class
