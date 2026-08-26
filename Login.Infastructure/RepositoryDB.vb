Imports Login.Core

''' <summary>
''' Repository connect to Access database
''' <br/>
''' <em>Initillize new DataRepository ->  Διμιουργει αυτοματα απο το συστημα την DataBase</em><br/>
'''<em> initillize new DataRepository(Ekdosh As String, LinkDataBase As String, NameDatabase As String, Columns As String) -> Εκχωρέις σε ποια βαση θέλεις να κανει Connect</em>
''' </summary>
Public Class DatabaseRepository
    Inherits FoundationLibrary.Repositories.DatabaseRepository(Of Integer, Entity.Entity)


    Sub New()
        MyBase.New("Microsoft.ACE.OLEDB.16.0", "C:\Users\kourt\Documents\kourt.accdb", "Eisodos", "[ID],[Username],[Password],[CreateAt]")
    End Sub

    Sub New(Ekdosh As String, LinkDataBase As String, NameDatabase As String, Columns As String)
        MyBase.New(Ekdosh, LinkDataBase, NameDatabase, Columns)
    End Sub

    Public Overrides Function ConvertRows(Entity As Entity.Entity) As String()
        Return {Entity.PrimaryKey, Entity.Username, Entity.Password, Entity.CreateAt}
    End Function

    Public Overrides Function ConvertEntity(DT As DataRow) As Entity.Entity
        Dim Entity As New Entity.Entity
        With Entity
            .PrimaryKey = DT(0)
            .Username = DT(1)
            .Password = DT(2)
            .CreateAt = DT(3)
        End With
        Return Entity
    End Function

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