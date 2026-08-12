Imports Login.Core
Public Class Repository

    Inherits FoundationLibrary.Repositories.Repository(Of Integer, Entity.Entity)

    Public Function FindByUserNameAndPassword(UserName As String, Password As String) As Entity.Entity
        For i = 0 To Rep.Count - 1
            If Rep(i).Username = UserName And Password = Rep(i).Password Then Return Rep(i)
        Next
        Return Nothing
    End Function
    Public Function ExistByUsernameAndPassword(UserName As String, Password As String) As Boolean
        For i = 0 To Rep.Count - 1
            If Rep(i).Username = UserName And Password = Rep(i).Password Then Return True
        Next
        Return False
    End Function
    Public Function ExistByUsername(Username As String) As Boolean
        For i = 0 To Rep.Count - 1
            If Rep(i).Username = Username Then Return True
        Next
        Return False
    End Function
    Public Function ExistByPassword(Password As String) As Boolean
        For i = 0 To Rep.Count - 1
            If Rep(i).Password = Password Then Return True
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
