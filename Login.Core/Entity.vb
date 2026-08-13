Imports FoundationLibrary.Interfaces.Keys

Namespace Entity
    Public Class Entity
        Implements FoundationLibrary.Interfaces.Keys.IHasPrimaryKey(Of Integer)
        Implements Ables.IReference
        Implements Ables.IUserName
        Implements Ables.IPassword
        Implements Ables.CreateAt


        Public Property PrimaryKey As Integer Implements IHasPrimaryKey(Of Integer).PrimaryKey
        Public Property Username As String Implements Ables.IUserName.Username
        Public Property Password As String Implements Ables.IPassword.Password
        Public Property CreateAt As Date Implements Ables.CreateAt.CreateAt
    End Class
End Namespace







