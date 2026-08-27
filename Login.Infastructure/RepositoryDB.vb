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