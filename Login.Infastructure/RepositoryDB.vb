Imports Login.Core
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

    Public Function FindByUserNameAndPassword(UserName As String, Password As String) As Entity.Entity
        Dim DT As New DataTable

        Database.TableDbOLe(Database.SelectDB("Eisodos"), DT)

        For i = 0 To DT.Rows.Count - 1
            If DT(i)(1) = UserName And Password = DT(i)(2) Then Return ConvertEntity(DT(i))
        Next
        Return Nothing
    End Function
    Public Function ExistByUsernameAndPassword(UserName As String, Password As String) As Boolean
        Dim DT As New DataTable

        Database.TableDbOLe(Database.SelectDB("Eisodos"), DT)

        For i = 0 To DT.Rows.Count - 1
            If DT(i)(1) = UserName And Password = DT(i)(2) Then Return True
        Next
        Return False
    End Function
    Public Function ExistByUsername(Username As String) As Boolean
        Dim DT As New DataTable

        Database.TableDbOLe(Database.SelectDB("Eisodos"), DT)

        For i = 0 To DT.Rows.Count - 1
            If DT(i)(1) = Username Then Return True
        Next
        Return False
    End Function
    Public Function ExistByPassword(Password As String) As Boolean
        Dim DT As New DataTable

        Database.TableDbOLe(Database.SelectDB("Eisodos"), DT)

        For i = 0 To DT.Rows.Count - 1
            If DT(i)(2) = Password Then Return True
        Next
        Return False
    End Function

    Public Overrides Function Match(Of TCreteria)(Entity As Entity.Entity, Creteria As TCreteria) As Boolean
        Dim Creterias As ICritiria = Creteria
        If Creterias.Username IsNot Nothing AndAlso Creterias.Username <> Entity.Username Then Return False
        If Creterias.Password IsNot Nothing AndAlso Creterias.Password <> Entity.Password Then Return False
        Return True
    End Function
End Class